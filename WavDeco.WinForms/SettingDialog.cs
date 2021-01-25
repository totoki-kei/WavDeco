using System;
using System.Windows.Forms;

namespace WavDeco.WinForms {
	public partial class SettingDialog : Form {

		public Setting Setting { get; private set; }

		public SettingDialog(Setting setting) {
			InitializeComponent();

			this.Setting = setting.Clone();

			LengthLimitCheckBox.Checked = this.Setting.EnabledLimitLength;
			LengthLimitTextBox.Text = this.Setting.LimitLength.ToString();
			switch (this.Setting.BackupMode) {
			case BackupMode.Disable:
				BackupDisableRadioButton.Checked = true;
				break;
			case BackupMode.One:
				BackupOneRadioButton.Checked = true;
				break;
			case BackupMode.Infinite:
				BackupInfiniteRadioButton.Checked = true;
				break;
			}

			TalkerCheckBox.Checked = this.Setting.EnabledTalkerDetection;
			TalkerDelimiterTextBox.Text = this.Setting.TalkerDelimiter;

			StartupInitialFolderCheckBox.Checked = this.Setting.EnableInitialFolder;
			switch (this.Setting.InitialFolder) {
			case InitialFolder.LastFolder:
				StartupLastFolderRadioButton.Checked = true;
				break;
			case InitialFolder.AppFolder:
				StartupAppFolderRadioButton.Checked = true;
				break;
			case InitialFolder.WorkingDirectory:
				StartupWorkinDirectoryRadioButton.Checked = true;
				break;
			}

			InstantStartCheckBox.Checked = this.Setting.EnableInstantStart;

			SetControlEnables();
		}

		private void SetControlEnables() {
			LengthLimitTextBox.Enabled = LengthLimitCheckBox.Checked;
			TalkerDelimiterTextBox.Enabled = TalkerCheckBox.Checked;

			StartupLastFolderRadioButton.Enabled =
				StartupAppFolderRadioButton.Enabled =
				StartupWorkinDirectoryRadioButton.Enabled = StartupInitialFolderCheckBox.Checked;

		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
			if (char.IsDigit(e.KeyChar)) return;
			if (char.IsControl(e.KeyChar)) return;

			e.Handled = true;
		}

		private void LengthLimitCheckBox_CheckedChanged(object sender, EventArgs e) {
			SetControlEnables();
		}

		private void button1_Click(object sender, EventArgs e) {
			Setting.EnabledLimitLength = LengthLimitCheckBox.Checked;
			Setting.LimitLength = int.Parse(LengthLimitTextBox.Text);

			if (BackupDisableRadioButton.Checked) {
				Setting.BackupMode = BackupMode.Disable;
			}
			else if (BackupOneRadioButton.Checked) {
				Setting.BackupMode = BackupMode.One;
			}
			else if (BackupInfiniteRadioButton.Checked) {
				Setting.BackupMode = BackupMode.Infinite;
			}

			Setting.EnabledTalkerDetection = TalkerCheckBox.Checked;
			Setting.TalkerDelimiter = TalkerDelimiterTextBox.Text;

			Setting.EnableInitialFolder = StartupInitialFolderCheckBox.Enabled;
			if (StartupLastFolderRadioButton.Checked) {
				Setting.InitialFolder = InitialFolder.LastFolder;
			}
			else if (StartupAppFolderRadioButton.Checked) {
				Setting.InitialFolder = InitialFolder.AppFolder;
			}
			else if (StartupWorkinDirectoryRadioButton.Checked) {
				Setting.InitialFolder = InitialFolder.WorkingDirectory;
			}

			Setting.EnableInstantStart = InstantStartCheckBox.Checked;

		}

		private void TalkerCheckBox_CheckedChanged(object sender, EventArgs e) {
			SetControlEnables();
		}

		private void StartupInitialFolderCheckBox_CheckedChanged(object sender, EventArgs e) {
			SetControlEnables();
		}
	}
}
