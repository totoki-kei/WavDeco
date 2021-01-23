using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public bool EnableInitialFolder { get; set; }

		public InitialFolder InitialFolder { get; set; }

		public bool EnableInstantStart { get; set; }

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
			LastFolder = null,
		};
	}
}
