
namespace WinWisper
{
    partial class MyWhisper
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyWhisper));
            this.fileList = new System.Windows.Forms.ListBox();
            this.btnTranscribe = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ファイルを追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ファイルリストをクリアToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.選択した項目を削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.lavelVersion = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.labelModel = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.cmbThreads = new System.Windows.Forms.ComboBox();
            this.labelThreads = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.cmbOutputFormat = new System.Windows.Forms.ComboBox();
            this.labelOutput = new System.Windows.Forms.Label();
            this.cmbProcessor = new System.Windows.Forms.ComboBox();
            this.labelProcesses = new System.Windows.Forms.Label();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileList
            // 
            this.fileList.AllowDrop = true;
            this.fileList.FormattingEnabled = true;
            this.fileList.ItemHeight = 12;
            this.fileList.Location = new System.Drawing.Point(12, 27);
            this.fileList.Name = "fileList";
            this.fileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.fileList.Size = new System.Drawing.Size(392, 220);
            this.fileList.TabIndex = 0;
            this.fileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileList_DragDrop);
            this.fileList.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileList_DragEnter);
            this.fileList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fileList_KeyDown);
            // 
            // btnTranscribe
            // 
            this.btnTranscribe.Location = new System.Drawing.Point(13, 262);
            this.btnTranscribe.Name = "btnTranscribe";
            this.btnTranscribe.Size = new System.Drawing.Size(103, 23);
            this.btnTranscribe.TabIndex = 1;
            this.btnTranscribe.Text = "文字起こし開始";
            this.btnTranscribe.UseVisualStyleBackColor = true;
            this.btnTranscribe.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(694, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルを追加ToolStripMenuItem,
            this.ファイルリストをクリアToolStripMenuItem,
            this.選択した項目を削除ToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // ファイルを追加ToolStripMenuItem
            // 
            this.ファイルを追加ToolStripMenuItem.Name = "ファイルを追加ToolStripMenuItem";
            this.ファイルを追加ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ファイルを追加ToolStripMenuItem.Text = "ファイルを追加";
            this.ファイルを追加ToolStripMenuItem.Click += new System.EventHandler(this.ファイルを追加ToolStripMenuItem_Click);
            // 
            // ファイルリストをクリアToolStripMenuItem
            // 
            this.ファイルリストをクリアToolStripMenuItem.Name = "ファイルリストをクリアToolStripMenuItem";
            this.ファイルリストをクリアToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ファイルリストをクリアToolStripMenuItem.Text = "ファイルリストをクリア";
            this.ファイルリストをクリアToolStripMenuItem.Click += new System.EventHandler(this.ファイルリストをクリアToolStripMenuItem_Click);
            // 
            // 選択した項目を削除ToolStripMenuItem
            // 
            this.選択した項目を削除ToolStripMenuItem.Name = "選択した項目を削除ToolStripMenuItem";
            this.選択した項目を削除ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.選択した項目を削除ToolStripMenuItem.Text = "選択した項目を削除";
            this.選択した項目を削除ToolStripMenuItem.Click += new System.EventHandler(this.選択した項目を削除ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(694, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(13, 305);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputBox.Size = new System.Drawing.Size(658, 120);
            this.outputBox.TabIndex = 5;
            // 
            // lavelVersion
            // 
            this.lavelVersion.AutoSize = true;
            this.lavelVersion.Location = new System.Drawing.Point(638, 438);
            this.lavelVersion.Name = "lavelVersion";
            this.lavelVersion.Size = new System.Drawing.Size(33, 12);
            this.lavelVersion.TabIndex = 6;
            this.lavelVersion.Text = "v1.0.1";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(148, 428);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(363, 21);
            this.progressBar.TabIndex = 7;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(13, 432);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(0, 12);
            this.labelProgress.TabIndex = 8;
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Location = new System.Drawing.Point(411, 28);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(34, 12);
            this.labelModel.TabIndex = 9;
            this.labelModel.Text = "モデル";
            // 
            // cmbModel
            // 
            this.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(500, 25);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(121, 20);
            this.cmbModel.TabIndex = 10;
            // 
            // cmbThreads
            // 
            this.cmbThreads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThreads.FormattingEnabled = true;
            this.cmbThreads.Location = new System.Drawing.Point(500, 51);
            this.cmbThreads.Name = "cmbThreads";
            this.cmbThreads.Size = new System.Drawing.Size(121, 20);
            this.cmbThreads.TabIndex = 12;
            // 
            // labelThreads
            // 
            this.labelThreads.AutoSize = true;
            this.labelThreads.Location = new System.Drawing.Point(411, 54);
            this.labelThreads.Name = "labelThreads";
            this.labelThreads.Size = new System.Drawing.Size(51, 12);
            this.labelThreads.TabIndex = 11;
            this.labelThreads.Text = "スレッド数";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(500, 103);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(121, 20);
            this.cmbLanguage.TabIndex = 14;
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Location = new System.Drawing.Point(411, 106);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(29, 12);
            this.labelLanguage.TabIndex = 13;
            this.labelLanguage.Text = "言語";
            // 
            // cmbOutputFormat
            // 
            this.cmbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutputFormat.FormattingEnabled = true;
            this.cmbOutputFormat.Location = new System.Drawing.Point(500, 129);
            this.cmbOutputFormat.Name = "cmbOutputFormat";
            this.cmbOutputFormat.Size = new System.Drawing.Size(121, 20);
            this.cmbOutputFormat.TabIndex = 16;
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(411, 132);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(53, 12);
            this.labelOutput.TabIndex = 15;
            this.labelOutput.Text = "出力形式";
            // 
            // cmbProcessor
            // 
            this.cmbProcessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProcessor.FormattingEnabled = true;
            this.cmbProcessor.Location = new System.Drawing.Point(500, 77);
            this.cmbProcessor.Name = "cmbProcessor";
            this.cmbProcessor.Size = new System.Drawing.Size(121, 20);
            this.cmbProcessor.TabIndex = 18;
            // 
            // labelProcesses
            // 
            this.labelProcesses.AutoSize = true;
            this.labelProcesses.Location = new System.Drawing.Point(411, 80);
            this.labelProcesses.Name = "labelProcesses";
            this.labelProcesses.Size = new System.Drawing.Size(54, 12);
            this.labelProcesses.TabIndex = 17;
            this.labelProcesses.Text = "プロセス数";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.aboutToolStripMenuItem.Text = "about";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MyWhisper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 450);
            this.Controls.Add(this.cmbProcessor);
            this.Controls.Add(this.labelProcesses);
            this.Controls.Add(this.cmbOutputFormat);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.labelLanguage);
            this.Controls.Add(this.cmbThreads);
            this.Controls.Add(this.labelThreads);
            this.Controls.Add(this.cmbModel);
            this.Controls.Add(this.labelModel);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lavelVersion);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnTranscribe);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MyWhisper";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MyWhisper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyWhisper_FormClosing);
            this.Load += new System.EventHandler(this.MyWhisper_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox fileList;
        private System.Windows.Forms.Button btnTranscribe;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルを追加ToolStripMenuItem;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Label lavelVersion;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.ToolStripMenuItem ファイルリストをクリアToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 選択した項目を削除ToolStripMenuItem;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.ComboBox cmbThreads;
        private System.Windows.Forms.Label labelThreads;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.ComboBox cmbOutputFormat;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.ComboBox cmbProcessor;
        private System.Windows.Forms.Label labelProcesses;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

