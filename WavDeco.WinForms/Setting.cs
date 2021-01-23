namespace WavDeco.WinForms {

	public enum BackupMode : int {
		Disable = 0,
		One = 1,
		Infinite = 99,
	}

	public enum InitialFolder {
		LastFolder,
		AppFolder,
		WorkingDirectory,
	}

	public class Setting {
		/// <summary>
		/// 埋め込み文字列の長さ制限を有効にするか
		/// </summary>
		public bool EnabledLimitLength { get; set; }
		/// <summary>
		/// 埋め込み文字列の最大長
		/// </summary>
		public int LimitLength { get; set; }
		/// <summary>
		/// バックアップ作成モード
		/// </summary>
		public BackupMode BackupMode { get; set; }

		/// <summary>
		/// 話者の検出を有効にするか
		/// </summary>
		public bool EnabledTalkerDetection { get; set; }

		/// <summary>
		/// 話者とセリフの区切り文字
		/// </summary>
		public string TalkerDelimiter { get; set; }

		/// <summary>
		/// 起動時にフォルダーを自動設定するか
		/// </summary>
		public bool EnableInitialFolder { get; set; }

		/// <summary>
		/// 起動時に自動設定するフォルダー
		/// </summary>
		public InitialFolder InitialFolder { get; set; }

		/// <summary>
		/// 起動してすぐ監視を開始するか
		/// </summary>
		public bool EnableInstantStart { get; set; }

		/// <summary>
		/// 許容するwav/txtファイルのタイムスタンプ時差(ミリ秒)
		/// </summary>
		public double TimestampDeltaThresholdMsec { get; set; }

		/// <summary>
		/// 同一ファイルへの連続処理を無効化する時間(ミリ秒)
		/// </summary>
		public double OperationIntervalMsec { get; set; }


		/// <summary>
		/// (非設定項目)最後に監視したフォルダー
		/// </summary>
		public string LastFolder { get; set; }

		public Setting Clone() {
			return new Setting() {
				EnabledLimitLength = EnabledLimitLength,
				LimitLength = LimitLength,
				BackupMode = BackupMode,
				EnabledTalkerDetection = EnabledTalkerDetection,
				TalkerDelimiter = TalkerDelimiter,
				EnableInitialFolder = EnableInitialFolder,
				InitialFolder = InitialFolder,
				EnableInstantStart = EnableInstantStart,
				TimestampDeltaThresholdMsec = TimestampDeltaThresholdMsec,
				OperationIntervalMsec = OperationIntervalMsec,
				LastFolder = LastFolder,
			};
		}

		public static readonly Setting Default = new Setting() {
			EnabledLimitLength = true,
			LimitLength = 30,
			BackupMode = BackupMode.One,
			EnabledTalkerDetection = true,
			TalkerDelimiter = "＞",
			EnableInitialFolder = true,
			InitialFolder = InitialFolder.LastFolder,
			EnableInstantStart = false,
			TimestampDeltaThresholdMsec = 100,
			OperationIntervalMsec = 10000,
			LastFolder = null,
		};
	}
}
