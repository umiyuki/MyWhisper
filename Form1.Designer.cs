
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
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.cmbDeviceID = new System.Windows.Forms.ComboBox();
            this.labelDeviceID = new System.Windows.Forms.Label();
            this.cmbDevice = new System.Windows.Forms.ComboBox();
            this.labelDevice = new System.Windows.Forms.Label();
            this.cmbVADFilter = new System.Windows.Forms.ComboBox();
            this.labelVADFilter = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileList
            // 
            this.fileList.AllowDrop = true;
            this.fileList.FormattingEnabled = true;
            resources.ApplyResources(this.fileList, "fileList");
            this.fileList.Name = "fileList";
            this.fileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.fileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileList_DragDrop);
            this.fileList.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileList_DragEnter);
            this.fileList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fileList_KeyDown);
            // 
            // btnTranscribe
            // 
            resources.ApplyResources(this.btnTranscribe, "btnTranscribe");
            this.btnTranscribe.Name = "btnTranscribe";
            this.btnTranscribe.UseVisualStyleBackColor = true;
            this.btnTranscribe.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルを追加ToolStripMenuItem,
            this.ファイルリストをクリアToolStripMenuItem,
            this.選択した項目を削除ToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            resources.ApplyResources(this.ファイルToolStripMenuItem, "ファイルToolStripMenuItem");
            // 
            // ファイルを追加ToolStripMenuItem
            // 
            this.ファイルを追加ToolStripMenuItem.Name = "ファイルを追加ToolStripMenuItem";
            resources.ApplyResources(this.ファイルを追加ToolStripMenuItem, "ファイルを追加ToolStripMenuItem");
            this.ファイルを追加ToolStripMenuItem.Click += new System.EventHandler(this.ファイルを追加ToolStripMenuItem_Click);
            // 
            // ファイルリストをクリアToolStripMenuItem
            // 
            this.ファイルリストをクリアToolStripMenuItem.Name = "ファイルリストをクリアToolStripMenuItem";
            resources.ApplyResources(this.ファイルリストをクリアToolStripMenuItem, "ファイルリストをクリアToolStripMenuItem");
            this.ファイルリストをクリアToolStripMenuItem.Click += new System.EventHandler(this.ファイルリストをクリアToolStripMenuItem_Click);
            // 
            // 選択した項目を削除ToolStripMenuItem
            // 
            this.選択した項目を削除ToolStripMenuItem.Name = "選択した項目を削除ToolStripMenuItem";
            resources.ApplyResources(this.選択した項目を削除ToolStripMenuItem, "選択した項目を削除ToolStripMenuItem");
            this.選択した項目を削除ToolStripMenuItem.Click += new System.EventHandler(this.選択した項目を削除ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // outputBox
            // 
            resources.ApplyResources(this.outputBox, "outputBox");
            this.outputBox.Name = "outputBox";
            // 
            // lavelVersion
            // 
            resources.ApplyResources(this.lavelVersion, "lavelVersion");
            this.lavelVersion.Name = "lavelVersion";
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            // 
            // labelProgress
            // 
            resources.ApplyResources(this.labelProgress, "labelProgress");
            this.labelProgress.Name = "labelProgress";
            // 
            // labelModel
            // 
            resources.ApplyResources(this.labelModel, "labelModel");
            this.labelModel.Name = "labelModel";
            // 
            // cmbModel
            // 
            this.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModel.FormattingEnabled = true;
            resources.ApplyResources(this.cmbModel, "cmbModel");
            this.cmbModel.Name = "cmbModel";
            // 
            // cmbThreads
            // 
            this.cmbThreads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThreads.FormattingEnabled = true;
            resources.ApplyResources(this.cmbThreads, "cmbThreads");
            this.cmbThreads.Name = "cmbThreads";
            // 
            // labelThreads
            // 
            resources.ApplyResources(this.labelThreads, "labelThreads");
            this.labelThreads.Name = "labelThreads";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            resources.ApplyResources(this.cmbLanguage, "cmbLanguage");
            this.cmbLanguage.Name = "cmbLanguage";
            // 
            // labelLanguage
            // 
            resources.ApplyResources(this.labelLanguage, "labelLanguage");
            this.labelLanguage.Name = "labelLanguage";
            // 
            // cmbOutputFormat
            // 
            this.cmbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutputFormat.FormattingEnabled = true;
            resources.ApplyResources(this.cmbOutputFormat, "cmbOutputFormat");
            this.cmbOutputFormat.Name = "cmbOutputFormat";
            // 
            // labelOutput
            // 
            resources.ApplyResources(this.labelOutput, "labelOutput");
            this.labelOutput.Name = "labelOutput";
            // 
            // cmbDeviceID
            // 
            this.cmbDeviceID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeviceID.FormattingEnabled = true;
            resources.ApplyResources(this.cmbDeviceID, "cmbDeviceID");
            this.cmbDeviceID.Name = "cmbDeviceID";
            // 
            // labelDeviceID
            // 
            resources.ApplyResources(this.labelDeviceID, "labelDeviceID");
            this.labelDeviceID.Name = "labelDeviceID";
            // 
            // cmbDevice
            // 
            this.cmbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevice.FormattingEnabled = true;
            resources.ApplyResources(this.cmbDevice, "cmbDevice");
            this.cmbDevice.Name = "cmbDevice";
            // 
            // labelDevice
            // 
            resources.ApplyResources(this.labelDevice, "labelDevice");
            this.labelDevice.Name = "labelDevice";
            // 
            // cmbVADFilter
            // 
            this.cmbVADFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVADFilter.FormattingEnabled = true;
            resources.ApplyResources(this.cmbVADFilter, "cmbVADFilter");
            this.cmbVADFilter.Name = "cmbVADFilter";
            // 
            // labelVADFilter
            // 
            resources.ApplyResources(this.labelVADFilter, "labelVADFilter");
            this.labelVADFilter.Name = "labelVADFilter";
            // 
            // MyWhisper
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbVADFilter);
            this.Controls.Add(this.labelVADFilter);
            this.Controls.Add(this.cmbDeviceID);
            this.Controls.Add(this.labelDeviceID);
            this.Controls.Add(this.cmbDevice);
            this.Controls.Add(this.labelDevice);
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
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MyWhisper";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbDeviceID;
        private System.Windows.Forms.Label labelDeviceID;
        private System.Windows.Forms.ComboBox cmbDevice;
        private System.Windows.Forms.Label labelDevice;
        private System.Windows.Forms.ComboBox cmbVADFilter;
        private System.Windows.Forms.Label labelVADFilter;
    }
}

