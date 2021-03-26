namespace WavDeco.WinForms {
	partial class SettingDialog {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.LengthLimitCheckBox = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.LengthLimitTextBox = new System.Windows.Forms.TextBox();
			this.BackupGroupBox = new System.Windows.Forms.GroupBox();
			this.BackupInfiniteRadioButton = new System.Windows.Forms.RadioButton();
			this.BackupOneRadioButton = new System.Windows.Forms.RadioButton();
			this.BackupDisableRadioButton = new System.Windows.Forms.RadioButton();
			this.DialogOkButton = new System.Windows.Forms.Button();
			this.DialogCancelButton = new System.Windows.Forms.Button();
			this.TalkerGroupBox = new System.Windows.Forms.GroupBox();
			this.TalkerDelimiterTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TalkerCheckBox = new System.Windows.Forms.CheckBox();
			this.StartupGroupBox = new System.Windows.Forms.GroupBox();
			this.StartupWorkinDirectoryRadioButton = new System.Windows.Forms.RadioButton();
			this.StartupAppFolderRadioButton = new System.Windows.Forms.RadioButton();
			this.StartupInitialFolderCheckBox = new System.Windows.Forms.CheckBox();
			this.StartupLastFolderRadioButton = new System.Windows.Forms.RadioButton();
			this.InstantStartCheckBox = new System.Windows.Forms.CheckBox();
			this.BackupGroupBox.SuspendLayout();
			this.TalkerGroupBox.SuspendLayout();
			this.StartupGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// LengthLimitCheckBox
			// 
			this.LengthLimitCheckBox.AutoSize = true;
			this.LengthLimitCheckBox.Checked = true;
			this.LengthLimitCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.LengthLimitCheckBox.Location = new System.Drawing.Point(20, 18);
			this.LengthLimitCheckBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.LengthLimitCheckBox.Name = "LengthLimitCheckBox";
			this.LengthLimitCheckBox.Size = new System.Drawing.Size(138, 22);
			this.LengthLimitCheckBox.TabIndex = 0;
			this.LengthLimitCheckBox.Text = "文字数を制限";
			this.LengthLimitCheckBox.UseVisualStyleBackColor = true;
			this.LengthLimitCheckBox.CheckedChanged += new System.EventHandler(this.LengthLimitCheckBox_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(297, 20);
			this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(127, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "文字(話者含む）";
			// 
			// LengthLimitTextBox
			// 
			this.LengthLimitTextBox.Location = new System.Drawing.Point(185, 15);
			this.LengthLimitTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.LengthLimitTextBox.Name = "LengthLimitTextBox";
			this.LengthLimitTextBox.Size = new System.Drawing.Size(99, 25);
			this.LengthLimitTextBox.TabIndex = 2;
			this.LengthLimitTextBox.Text = "20";
			this.LengthLimitTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.LengthLimitTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
			// 
			// BackupGroupBox
			// 
			this.BackupGroupBox.Controls.Add(this.BackupInfiniteRadioButton);
			this.BackupGroupBox.Controls.Add(this.BackupOneRadioButton);
			this.BackupGroupBox.Controls.Add(this.BackupDisableRadioButton);
			this.BackupGroupBox.Location = new System.Drawing.Point(20, 52);
			this.BackupGroupBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.BackupGroupBox.Name = "BackupGroupBox";
			this.BackupGroupBox.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.BackupGroupBox.Size = new System.Drawing.Size(328, 142);
			this.BackupGroupBox.TabIndex = 3;
			this.BackupGroupBox.TabStop = false;
			this.BackupGroupBox.Text = "バックアップ";
			// 
			// BackupInfiniteRadioButton
			// 
			this.BackupInfiniteRadioButton.AutoSize = true;
			this.BackupInfiniteRadioButton.Location = new System.Drawing.Point(12, 94);
			this.BackupInfiniteRadioButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.BackupInfiniteRadioButton.Name = "BackupInfiniteRadioButton";
			this.BackupInfiniteRadioButton.Size = new System.Drawing.Size(224, 22);
			this.BackupInfiniteRadioButton.TabIndex = 0;
			this.BackupInfiniteRadioButton.TabStop = true;
			this.BackupInfiniteRadioButton.Text = "バックアップを無制限で残す";
			this.BackupInfiniteRadioButton.UseVisualStyleBackColor = true;
			// 
			// BackupOneRadioButton
			// 
			this.BackupOneRadioButton.AutoSize = true;
			this.BackupOneRadioButton.Location = new System.Drawing.Point(12, 62);
			this.BackupOneRadioButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.BackupOneRadioButton.Name = "BackupOneRadioButton";
			this.BackupOneRadioButton.Size = new System.Drawing.Size(182, 22);
			this.BackupOneRadioButton.TabIndex = 0;
			this.BackupOneRadioButton.TabStop = true;
			this.BackupOneRadioButton.Text = "バックアップを1個残す";
			this.BackupOneRadioButton.UseVisualStyleBackColor = true;
			// 
			// BackupDisableRadioButton
			// 
			this.BackupDisableRadioButton.AutoSize = true;
			this.BackupDisableRadioButton.Checked = true;
			this.BackupDisableRadioButton.Location = new System.Drawing.Point(12, 28);
			this.BackupDisableRadioButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.BackupDisableRadioButton.Name = "BackupDisableRadioButton";
			this.BackupDisableRadioButton.Size = new System.Drawing.Size(201, 22);
			this.BackupDisableRadioButton.TabIndex = 0;
			this.BackupDisableRadioButton.TabStop = true;
			this.BackupDisableRadioButton.Text = "バックアップを作成しない";
			this.BackupDisableRadioButton.UseVisualStyleBackColor = true;
			// 
			// DialogOkButton
			// 
			this.DialogOkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.DialogOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.DialogOkButton.Location = new System.Drawing.Point(423, 332);
			this.DialogOkButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.DialogOkButton.Name = "DialogOkButton";
			this.DialogOkButton.Size = new System.Drawing.Size(125, 34);
			this.DialogOkButton.TabIndex = 4;
			this.DialogOkButton.Text = "OK";
			this.DialogOkButton.UseVisualStyleBackColor = true;
			this.DialogOkButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// DialogCancelButton
			// 
			this.DialogCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.DialogCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.DialogCancelButton.Location = new System.Drawing.Point(580, 332);
			this.DialogCancelButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.DialogCancelButton.Name = "DialogCancelButton";
			this.DialogCancelButton.Size = new System.Drawing.Size(125, 34);
			this.DialogCancelButton.TabIndex = 5;
			this.DialogCancelButton.Text = "キャンセル";
			this.DialogCancelButton.UseVisualStyleBackColor = true;
			// 
			// TalkerGroupBox
			// 
			this.TalkerGroupBox.Controls.Add(this.TalkerDelimiterTextBox);
			this.TalkerGroupBox.Controls.Add(this.label2);
			this.TalkerGroupBox.Controls.Add(this.TalkerCheckBox);
			this.TalkerGroupBox.Location = new System.Drawing.Point(20, 201);
			this.TalkerGroupBox.Name = "TalkerGroupBox";
			this.TalkerGroupBox.Size = new System.Drawing.Size(328, 102);
			this.TalkerGroupBox.TabIndex = 6;
			this.TalkerGroupBox.TabStop = false;
			this.TalkerGroupBox.Text = "話者設定";
			// 
			// TalkerDelimiterTextBox
			// 
			this.TalkerDelimiterTextBox.Location = new System.Drawing.Point(165, 51);
			this.TalkerDelimiterTextBox.Name = "TalkerDelimiterTextBox";
			this.TalkerDelimiterTextBox.Size = new System.Drawing.Size(101, 25);
			this.TalkerDelimiterTextBox.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "区切り文字 :";
			// 
			// TalkerCheckBox
			// 
			this.TalkerCheckBox.AutoSize = true;
			this.TalkerCheckBox.Location = new System.Drawing.Point(12, 26);
			this.TalkerCheckBox.Name = "TalkerCheckBox";
			this.TalkerCheckBox.Size = new System.Drawing.Size(261, 22);
			this.TalkerCheckBox.TabIndex = 0;
			this.TalkerCheckBox.Text = "話者を「アーティスト」に設定する";
			this.TalkerCheckBox.UseVisualStyleBackColor = true;
			this.TalkerCheckBox.CheckedChanged += new System.EventHandler(this.TalkerCheckBox_CheckedChanged);
			// 
			// StartupGroupBox
			// 
			this.StartupGroupBox.Controls.Add(this.StartupWorkinDirectoryRadioButton);
			this.StartupGroupBox.Controls.Add(this.StartupAppFolderRadioButton);
			this.StartupGroupBox.Controls.Add(this.StartupInitialFolderCheckBox);
			this.StartupGroupBox.Controls.Add(this.StartupLastFolderRadioButton);
			this.StartupGroupBox.Controls.Add(this.InstantStartCheckBox);
			this.StartupGroupBox.Location = new System.Drawing.Point(357, 52);
			this.StartupGroupBox.Name = "StartupGroupBox";
			this.StartupGroupBox.Size = new System.Drawing.Size(348, 250);
			this.StartupGroupBox.TabIndex = 7;
			this.StartupGroupBox.TabStop = false;
			this.StartupGroupBox.Text = "スタートアップ設定";
			// 
			// StartupWorkinDirectoryRadioButton
			// 
			this.StartupWorkinDirectoryRadioButton.AutoSize = true;
			this.StartupWorkinDirectoryRadioButton.Location = new System.Drawing.Point(48, 112);
			this.StartupWorkinDirectoryRadioButton.Name = "StartupWorkinDirectoryRadioButton";
			this.StartupWorkinDirectoryRadioButton.Size = new System.Drawing.Size(205, 22);
			this.StartupWorkinDirectoryRadioButton.TabIndex = 5;
			this.StartupWorkinDirectoryRadioButton.TabStop = true;
			this.StartupWorkinDirectoryRadioButton.Text = "起動時の作業フォルダー";
			this.StartupWorkinDirectoryRadioButton.UseVisualStyleBackColor = true;
			// 
			// StartupAppFolderRadioButton
			// 
			this.StartupAppFolderRadioButton.AutoSize = true;
			this.StartupAppFolderRadioButton.Location = new System.Drawing.Point(48, 84);
			this.StartupAppFolderRadioButton.Name = "StartupAppFolderRadioButton";
			this.StartupAppFolderRadioButton.Size = new System.Drawing.Size(210, 22);
			this.StartupAppFolderRadioButton.TabIndex = 4;
			this.StartupAppFolderRadioButton.TabStop = true;
			this.StartupAppFolderRadioButton.Text = "このアプリのあるフォルダー";
			this.StartupAppFolderRadioButton.UseVisualStyleBackColor = true;
			// 
			// StartupInitialFolderCheckBox
			// 
			this.StartupInitialFolderCheckBox.AutoSize = true;
			this.StartupInitialFolderCheckBox.Location = new System.Drawing.Point(17, 28);
			this.StartupInitialFolderCheckBox.Name = "StartupInitialFolderCheckBox";
			this.StartupInitialFolderCheckBox.Size = new System.Drawing.Size(284, 22);
			this.StartupInitialFolderCheckBox.TabIndex = 3;
			this.StartupInitialFolderCheckBox.Text = "起動時にフォルダーを自動設定する";
			this.StartupInitialFolderCheckBox.UseVisualStyleBackColor = true;
			this.StartupInitialFolderCheckBox.CheckedChanged += new System.EventHandler(this.StartupInitialFolderCheckBox_CheckedChanged);
			// 
			// StartupLastFolderRadioButton
			// 
			this.StartupLastFolderRadioButton.AutoSize = true;
			this.StartupLastFolderRadioButton.Location = new System.Drawing.Point(48, 56);
			this.StartupLastFolderRadioButton.Name = "StartupLastFolderRadioButton";
			this.StartupLastFolderRadioButton.Size = new System.Drawing.Size(187, 22);
			this.StartupLastFolderRadioButton.TabIndex = 2;
			this.StartupLastFolderRadioButton.TabStop = true;
			this.StartupLastFolderRadioButton.Text = "前回の監視フォルダー";
			this.StartupLastFolderRadioButton.UseVisualStyleBackColor = true;
			// 
			// InstantStartCheckBox
			// 
			this.InstantStartCheckBox.AutoSize = true;
			this.InstantStartCheckBox.Location = new System.Drawing.Point(17, 148);
			this.InstantStartCheckBox.Name = "InstantStartCheckBox";
			this.InstantStartCheckBox.Size = new System.Drawing.Size(252, 22);
			this.InstantStartCheckBox.TabIndex = 1;
			this.InstantStartCheckBox.Text = "可能ならすぐに監視を開始する";
			this.InstantStartCheckBox.UseVisualStyleBackColor = true;
			// 
			// SettingDialog
			// 
			this.AcceptButton = this.DialogOkButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.DialogCancelButton;
			this.ClientSize = new System.Drawing.Size(720, 380);
			this.Controls.Add(this.StartupGroupBox);
			this.Controls.Add(this.TalkerGroupBox);
			this.Controls.Add(this.DialogCancelButton);
			this.Controls.Add(this.DialogOkButton);
			this.Controls.Add(this.BackupGroupBox);
			this.Controls.Add(this.LengthLimitTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LengthLimitCheckBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "設定";
			this.BackupGroupBox.ResumeLayout(false);
			this.BackupGroupBox.PerformLayout();
			this.TalkerGroupBox.ResumeLayout(false);
			this.TalkerGroupBox.PerformLayout();
			this.StartupGroupBox.ResumeLayout(false);
			this.StartupGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox LengthLimitCheckBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox LengthLimitTextBox;
		private System.Windows.Forms.GroupBox BackupGroupBox;
		private System.Windows.Forms.RadioButton BackupInfiniteRadioButton;
		private System.Windows.Forms.RadioButton BackupOneRadioButton;
		private System.Windows.Forms.RadioButton BackupDisableRadioButton;
		private System.Windows.Forms.Button DialogOkButton;
		private System.Windows.Forms.Button DialogCancelButton;
		private System.Windows.Forms.GroupBox TalkerGroupBox;
		private System.Windows.Forms.TextBox TalkerDelimiterTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox TalkerCheckBox;
		private System.Windows.Forms.GroupBox StartupGroupBox;
		private System.Windows.Forms.CheckBox InstantStartCheckBox;
		private System.Windows.Forms.RadioButton StartupWorkinDirectoryRadioButton;
		private System.Windows.Forms.RadioButton StartupAppFolderRadioButton;
		private System.Windows.Forms.CheckBox StartupInitialFolderCheckBox;
		private System.Windows.Forms.RadioButton StartupLastFolderRadioButton;
	}
}