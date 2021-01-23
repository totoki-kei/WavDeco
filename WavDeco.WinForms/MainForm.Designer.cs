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
			this.TargetFolderTextBox = new System.Windows.Forms.TextBox();
			this.SettingButton = new System.Windows.Forms.Button();
			this.ObserveToggleButton = new System.Windows.Forms.CheckBox();
			this.LogTextBox = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.TargetFolderTextBox);
			this.groupBox1.Location = new System.Drawing.Point(20, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(785, 72);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "監視対象フォルダー(&F)";
			// 
			// TargetFolderTextBox
			// 
			this.TargetFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TargetFolderTextBox.Location = new System.Drawing.Point(8, 26);
			this.TargetFolderTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.TargetFolderTextBox.Name = "TargetFolderTextBox";
			this.TargetFolderTextBox.Size = new System.Drawing.Size(766, 25);
			this.TargetFolderTextBox.TabIndex = 0;
			// 
			// SettingButton
			// 
			this.SettingButton.Location = new System.Drawing.Point(20, 90);
			this.SettingButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.SettingButton.Name = "SettingButton";
			this.SettingButton.Size = new System.Drawing.Size(125, 34);
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
			this.ObserveToggleButton.Location = new System.Drawing.Point(683, 91);
			this.ObserveToggleButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.ObserveToggleButton.Name = "ObserveToggleButton";
			this.ObserveToggleButton.Size = new System.Drawing.Size(123, 36);
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
			this.LogTextBox.Location = new System.Drawing.Point(20, 135);
			this.LogTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.LogTextBox.MaxLength = 2147483547;
			this.LogTextBox.Multiline = true;
			this.LogTextBox.Name = "LogTextBox";
			this.LogTextBox.ReadOnly = true;
			this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.LogTextBox.Size = new System.Drawing.Size(783, 246);
			this.LogTextBox.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(620, 392);
			this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(183, 34);
			this.button1.TabIndex = 4;
			this.button1.Text = "ログを消去(&C)";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(825, 445);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.LogTextBox);
			this.Controls.Add(this.ObserveToggleButton);
			this.Controls.Add(this.SettingButton);
			this.Controls.Add(this.groupBox1);
			this.MinimumSize = new System.Drawing.Size(485, 422);
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
		private System.Windows.Forms.Button button1;
	}
}

