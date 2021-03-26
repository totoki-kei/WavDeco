namespace WavDeco.WinForms {
	partial class MainForm {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.BrowseFolderButton = new System.Windows.Forms.Button();
			this.TargetFolderTextBox = new System.Windows.Forms.TextBox();
			this.SettingButton = new System.Windows.Forms.Button();
			this.ObserveToggleButton = new System.Windows.Forms.CheckBox();
			this.LogTextBox = new System.Windows.Forms.TextBox();
			this.ClearLogButton = new System.Windows.Forms.Button();
			this.ExeuteButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.BrowseFolderButton);
			this.groupBox1.Controls.Add(this.TargetFolderTextBox);
			this.groupBox1.Location = new System.Drawing.Point(12, 8);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox1.Size = new System.Drawing.Size(471, 48);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "監視対象フォルダー(&F)";
			// 
			// BrowseFolderButton
			// 
			this.BrowseFolderButton.Location = new System.Drawing.Point(442, 17);
			this.BrowseFolderButton.Name = "BrowseFolderButton";
			this.BrowseFolderButton.Size = new System.Drawing.Size(24, 19);
			this.BrowseFolderButton.TabIndex = 1;
			this.BrowseFolderButton.Text = "...";
			this.BrowseFolderButton.UseVisualStyleBackColor = true;
			this.BrowseFolderButton.Click += new System.EventHandler(this.BrowseFolderButton_Click);
			// 
			// TargetFolderTextBox
			// 
			this.TargetFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TargetFolderTextBox.Location = new System.Drawing.Point(5, 17);
			this.TargetFolderTextBox.Name = "TargetFolderTextBox";
			this.TargetFolderTextBox.Size = new System.Drawing.Size(440, 19);
			this.TargetFolderTextBox.TabIndex = 0;
			// 
			// SettingButton
			// 
			this.SettingButton.Location = new System.Drawing.Point(12, 60);
			this.SettingButton.Name = "SettingButton";
			this.SettingButton.Size = new System.Drawing.Size(75, 23);
			this.SettingButton.TabIndex = 1;
			this.SettingButton.Text = "設定(&S)";
			this.SettingButton.UseVisualStyleBackColor = true;
			this.SettingButton.Click += new System.EventHandler(this.SettingButton_Click);
			// 
			// ObserveToggleButton
			// 
			this.ObserveToggleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ObserveToggleButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.ObserveToggleButton.AutoCheck = false;
			this.ObserveToggleButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ObserveToggleButton.Location = new System.Drawing.Point(410, 60);
			this.ObserveToggleButton.Name = "ObserveToggleButton";
			this.ObserveToggleButton.Size = new System.Drawing.Size(74, 23);
			this.ObserveToggleButton.TabIndex = 2;
			this.ObserveToggleButton.Text = "監視(&O)";
			this.ObserveToggleButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ObserveToggleButton.UseVisualStyleBackColor = true;
			this.ObserveToggleButton.Click += new System.EventHandler(this.ObserveToggleButton_Click);
			// 
			// LogTextBox
			// 
			this.LogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LogTextBox.Location = new System.Drawing.Point(12, 90);
			this.LogTextBox.MaxLength = 2147483547;
			this.LogTextBox.Multiline = true;
			this.LogTextBox.Name = "LogTextBox";
			this.LogTextBox.ReadOnly = true;
			this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.LogTextBox.Size = new System.Drawing.Size(471, 165);
			this.LogTextBox.TabIndex = 3;
			// 
			// ClearLogButton
			// 
			this.ClearLogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ClearLogButton.Location = new System.Drawing.Point(372, 261);
			this.ClearLogButton.Name = "ClearLogButton";
			this.ClearLogButton.Size = new System.Drawing.Size(110, 23);
			this.ClearLogButton.TabIndex = 4;
			this.ClearLogButton.Text = "ログを消去(&C)";
			this.ClearLogButton.UseVisualStyleBackColor = true;
			this.ClearLogButton.Click += new System.EventHandler(this.ClearLogButton_Click);
			// 
			// ExeuteButton
			// 
			this.ExeuteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ExeuteButton.Location = new System.Drawing.Point(295, 61);
			this.ExeuteButton.Margin = new System.Windows.Forms.Padding(2);
			this.ExeuteButton.Name = "ExeuteButton";
			this.ExeuteButton.Size = new System.Drawing.Size(110, 22);
			this.ExeuteButton.TabIndex = 5;
			this.ExeuteButton.Text = "今すぐ実行(&X)";
			this.ExeuteButton.UseVisualStyleBackColor = true;
			this.ExeuteButton.Click += new System.EventHandler(this.ExeuteButton_Click);
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(495, 297);
			this.Controls.Add(this.ExeuteButton);
			this.Controls.Add(this.ClearLogButton);
			this.Controls.Add(this.LogTextBox);
			this.Controls.Add(this.ObserveToggleButton);
			this.Controls.Add(this.SettingButton);
			this.Controls.Add(this.groupBox1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MinimumSize = new System.Drawing.Size(297, 294);
			this.Name = "MainForm";
			this.Text = "WavDeco";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox TargetFolderTextBox;
		private System.Windows.Forms.Button SettingButton;
		private System.Windows.Forms.CheckBox ObserveToggleButton;
		private System.Windows.Forms.TextBox LogTextBox;
		private System.Windows.Forms.Button ClearLogButton;
		private System.Windows.Forms.Button ExeuteButton;
		private System.Windows.Forms.Button BrowseFolderButton;
	}
}

