using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Linq;
using WavDeco.Core;

namespace WavDeco.WinForms {
	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();
		}

		Setting setting;
		bool observing;

		FileSystemWatcher watcher;

		readonly ConcurrentDictionary<string, PhreaseSet> phreases = new ConcurrentDictionary<string, PhreaseSet>();

		readonly ConcurrentQueue<TaskRequest<PhreaseSet>> processQueue = new ConcurrentQueue<TaskRequest<PhreaseSet>>();
		readonly AutoResetEvent processQueueEvent = new AutoResetEvent(false);
		readonly ManualResetEvent exitEvent = new ManualResetEvent(false);

		Thread processThread;

		private void MainForm_Load(object sender, EventArgs e) {
			setting = LoadSetting();
			observing = false;

			// FileSystemWatcherの初期化
			watcher = new FileSystemWatcher();
			watcher.Changed += Watcher_Changed;
			watcher.Renamed += Watcher_Renamed;
			watcher.Created += Watcher_Created;
			watcher.Deleted += Watcher_Deleted;
			watcher.Error += Watcher_Error;

			this.Disposed += (o, ev) => exitEvent.Set();
			this.Disposed += (o, ev) => watcher.Dispose();


			if (setting.EnableInitialFolder) {
				switch (setting.InitialFolder) {
				case InitialFolder.LastFolder:
					TargetFolderTextBox.Text = setting.LastFolder ?? "";
					break;
				case InitialFolder.AppFolder:
					TargetFolderTextBox.Text = Application.StartupPath ?? "";
					break;
				case InitialFolder.WorkingDirectory:
					TargetFolderTextBox.Text = Environment.CurrentDirectory ?? "";
					break;
				}
			}

			if (setting.EnableInstantStart) {
				StartObserve();
			}

		}

		private void Watcher_Error(object sender, ErrorEventArgs e) {
			Debug.WriteLine(e.ToString(), "Error");
			WriteLog($"監視エラー: {e.ToString()}");
		}

		private void Watcher_Deleted(object sender, FileSystemEventArgs e) {
			Debug.WriteLine(e.Name, "Deleted");
			//WriteLog($"ファイル削除: {e.Name}");
		}

		private void Watcher_Created(object sender, FileSystemEventArgs e) {
			Debug.WriteLine(e.Name, "Created");
			//WriteLog($"ファイル作成: {e.Name}");
		}

		private void Watcher_Renamed(object sender, RenamedEventArgs e) {
			Debug.WriteLine(e.Name, "Renamed");
			//WriteLog($"ファイル名前変更: {e.OldName} => {e.Name}");
		}

		private void Watcher_Changed(object sender, FileSystemEventArgs e) {
			Debug.WriteLine(e.Name, "Changed");
			//WriteLog($"ファイル更新: {e.Name}");

			// VOICEROID2、ガイノイドTalkでは最終的にChangedイベントが発生して出力が完了する
			// Changedイベントをトリガーとして処理を行う

			var fullpath = e.FullPath;
			OnFileDetected(fullpath);

		}

		private void OnFileDetected(string fullpath) {
			var ext = Path.GetExtension(fullpath);
			var pathWithoutExt = Path.Combine(
				Path.GetDirectoryName(fullpath),
				Path.GetFileNameWithoutExtension(fullpath)
			);

			var ph = phreases.GetOrAdd(pathWithoutExt, (k) => new PhreaseSet());

			if (ext == ".txt") {
				ph.TextFilePath = fullpath;
				ph.TextFileTime = DateTime.Now;
			}
			else if (ext == ".wav") {
				ph.WaveFilePath = fullpath;
				ph.WaveFileTime = DateTime.Now;
			}

			EnqueueRequest(ph);
		}

		private void RemovePhraseCache(string fullpath) {
			var pathWithoutExt = Path.Combine(
				Path.GetDirectoryName(fullpath),
				Path.GetFileNameWithoutExtension(fullpath)
			);

			phreases.TryRemove(pathWithoutExt, out _);
		}

		private void EnqueueRequest(PhreaseSet ph) {
			if (processThread == null) {
				processThread = new Thread(new ThreadStart(ThreadProc));
				processThread.Start();
			}
			processQueue.Enqueue(new TaskRequest<PhreaseSet>(ph));
			processQueueEvent.Set();
		}

		/// <summary>
		/// 既定の設定ファイルを読み込む 存在しない場合はデフォルトの設定を返す
		/// </summary>
		/// <returns>読み込まれた設定</returns>
		private static Setting LoadSetting() {
			var path = Path.Combine(Application.StartupPath, "setting.xml");
			Setting result = null;

			XmlSerializer serializer = new XmlSerializer(typeof(Setting));

			try {
				if (File.Exists(path)) {
					using (var src = File.OpenRead(path)) {
						result = serializer.Deserialize(src) as Setting;
					}
				}
			}
			catch (InvalidOperationException) {

			}

			if (result == null) {
				result = Setting.Default.Clone();
			}

			return result;
		}

		/// <summary>
		/// 既定のパスに設定を保存する
		/// </summary>
		/// <param name="setting">設定</param>
		private static void SaveSetting(Setting setting) {
			var path = Path.Combine(Application.StartupPath, "setting.xml");
			XmlSerializer serializer = new XmlSerializer(typeof(Setting));
			using (var dest = new FileStream(path, FileMode.Create, FileAccess.Write)) {
				serializer.Serialize(dest, setting);
			}
		}

		/// <summary>
		/// 設定ダイアログをモーダル表示する
		/// </summary>
		private void ShowSettingDialog() {
			SettingDialog dialog = new SettingDialog(this.setting);

			var dialogResult = dialog.ShowDialog();
			if (dialogResult == DialogResult.OK) {
				this.setting = dialog.Setting;
			}
		}

		private bool IsValidDragEvent(DragEventArgs e) {
			return IsValidDragEvent(e, out _);
		}

		private bool IsValidDragEvent(DragEventArgs e, out string folder) {
			folder = null;
			var path = e.Data.GetData(DataFormats.FileDrop);
			if (path is string[] pathList) {
				if (pathList.Length == 1) {
					if (Directory.Exists(pathList[0])) {
						folder = pathList[0];
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// ファイル/フォルダのドラッグ検知
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_DragEnter(object sender, DragEventArgs e) {
			if (!observing && e.Data.GetDataPresent(DataFormats.FileDrop)) {
				if (IsValidDragEvent(e)) {
					e.Effect = DragDropEffects.Copy;
				}
			}
		}

		/// <summary>
		/// ファイル/フォルダのドロップ検知
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_DragDrop(object sender, DragEventArgs e) {
			var path = e.Data.GetData(DataFormats.FileDrop);
			if (IsValidDragEvent(e, out var folder)) {
				// フォルダの場合は監視対象フォルダとして設定
				TargetFolderTextBox.Text = folder;
			}
		}

		/// <summary>
		/// フォルダの監視を開始する
		/// </summary>
		private void StartObserve() {
			TargetFolderTextBox.Enabled = SettingButton.Enabled = false;

			try {
				watcher.Path = TargetFolderTextBox.Text;
				watcher.EnableRaisingEvents = true;

				observing = true;
				ObserveToggleButton.Checked = true;
			}
			catch {
				// TODO: ここにエラーダイアログを表示する何かを入れる
				//throw;
			}
			finally {
				if (!observing) {
					watcher.EnableRaisingEvents = false;
					TargetFolderTextBox.Enabled = SettingButton.Enabled = true;
				}
				else {
					setting.LastFolder = watcher.Path;
					WriteLog($"フォルダ監視を開始しました フォルダ:'{watcher.Path}'");
					SaveSetting(setting);
				}
			}
		}

		void StopObserve() {
			observing = false;

			watcher.EnableRaisingEvents = false;
			TargetFolderTextBox.Enabled = SettingButton.Enabled = true;

			WriteLog("フォルダ監視を停止しました");
		}

		private void ObserveToggleButton_Click(object sender, EventArgs e) {
			if (!observing) {
				StartObserve();
			}
			else {
				StopObserve();
			}


			ObserveToggleButton.Checked = observing;
		}

		#region ログ窓
		private void WriteLog(DateTime timestamp, string line) {
			if (this.InvokeRequired) {
				Invoke(new Action(() => WriteLog(timestamp, line)));
			}
			else {
				if (!LogTextBox.IsDisposed) LogTextBox.AppendText($"[{timestamp:G}] {line}\r\n");
			}
		}
		private void WriteLog(string line) {
			WriteLog(DateTime.Now, line);
		}

		private void ClearLog() {
			if (this.InvokeRequired) {
				Invoke(new Action(() => ClearLog()));
			}
			else {
				if (!LogTextBox.IsDisposed) LogTextBox.Clear();
			}
		}

		#endregion


		private void ThreadProc() {

			WriteLog("バックグラウンドスレッドを開始");

			bool exitFlag = false;
			while (!exitFlag) {
				switch (WaitHandle.WaitAny(new WaitHandle[] { processQueueEvent, exitEvent })) {
				case 0:
					while (processQueue.TryDequeue(out var qi)) {
						if (exitEvent.WaitOne(0)) break;
						ProcessPhreaseSet(qi);
					}
					break;
				case 1:
					exitFlag = true;
					break;
				}
			}

			WriteLog("バックグラウンドスレッドを終了");
		}

		private void ProcessPhreaseSet(TaskRequest<PhreaseSet> qi) {

			var ph = qi.Value;

			if (!ph.IsReady(setting)) {
				return;
			}

			WriteLog($"処理を開始します({qi.Trial + 1}回目)： {ph.WaveFilePath}");

			try {
				// セリフ
				string phraseText = File.ReadAllText(ph.TextFilePath, Encoding.Default);
				// 話者
				string talkerName = null;

				if (setting.EnabledLimitLength) {
					if (phraseText.Length > setting.LimitLength) {
						phraseText = phraseText.Substring(0, setting.LimitLength);
					}
				}

				if (setting.EnabledTalkerDetection) {
					var s = phraseText.Split(new[] { setting.TalkerDelimiter }, StringSplitOptions.RemoveEmptyEntries);
					if (s.Length >= 2) {
						// 最初の区切りまでを話者、それ以降をセリフとする
						talkerName = s[0];
						phraseText = phraseText.Substring(talkerName.Length + setting.TalkerDelimiter.Length);
					}
				}

				ListTag tag = new ListTag();
				tag.Name = phraseText;
				if (talkerName != null) tag.Artist = talkerName;

				switch (setting.BackupMode) {
				case BackupMode.Disable:
					WavFile.WriteTagToWavFile(ph.WaveFilePath, tag, false);
					break;
				case BackupMode.One:
					WavFile.WriteTagToWavFile(ph.WaveFilePath, tag, 1);
					break;
				case BackupMode.Infinite:
					WavFile.WriteTagToWavFile(ph.WaveFilePath, tag, 99);
					break;
				}

				ph.LastProcessed = DateTime.Now;
				WriteLog($"処理が終了しました： {ph.WaveFilePath}");

				return;
			}
			catch (IOException ex) {
				WriteLog($"ファイルIO失敗 {ex.Message}");
				if (qi.IncrementTrialCount(10)) {
					processQueue.Enqueue(qi);
					processQueueEvent.Set();
				}
			}
			catch (FileFormatException ex) {
				WriteLog($"ファイル書式解析失敗 {ex.Message}");
				if (qi.IncrementTrialCount(10)) {
					processQueue.Enqueue(qi);
					processQueueEvent.Set();
				}
			}

			// ここに来るのはリトライ回数オーバーの時
			WriteLog($"処理に失敗しました： {ph.WaveFilePath}");
		}

		private void SettingButton_Click(object sender, EventArgs e) {
			ShowSettingDialog();
			SaveSetting(setting);
		}

		private void button1_Click(object sender, EventArgs e) {
			ClearLog();
		}

		private void ExeuteButton_Click(object sender, EventArgs e) {
			var folder = TargetFolderTextBox.Text;
			if (string.IsNullOrEmpty(folder)) {
				MessageBox.Show("監視対象フォルダーが空です。", null, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (!Directory.Exists(folder)) {
				MessageBox.Show("監視対象フォルダーが正しく指定されていません。", null, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}

			switch (MessageBox.Show("監視フォルダー内の全ファイルに処理を行います。よろしいですか？", null, MessageBoxButtons.YesNo)) {
			case DialogResult.Yes:
				break;
			default:
				return;
			}

			var filelist = Directory.EnumerateFiles(folder).ToArray();

			foreach (var item in filelist) {
				RemovePhraseCache(item);
			}
			foreach (var item in filelist) {
				OnFileDetected(item);
			}


		}
	}
}
