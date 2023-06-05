using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using WinWisper.Resources;
using System.Globalization;

namespace WinWisper
{
    public partial class MyWhisper : Form
    {
        private bool processingFiles = false;

        Dictionary<string, string> models = new Dictionary<string, string>
        {
            { "Large", "large-v2" },
            { "Medium", "medium" },
            { "Small", "small" },
            { "Base", "base" },
            { "Tiny", "tiny" }
        };

        Dictionary<string, string> languages = new Dictionary<string, string>
        {
            { "english", "en" },
            { "chinese", "zh" },
            { "german", "de" },
            { "spanish", "es" },
            { "russian", "ru" },
            { "korean", "ko" },
            { "french", "fr" },
            { "japanese", "ja" },
            { "portuguese", "pt" },
            { "turkish", "tr" },
            { "polish", "pl" },
            { "catalan", "ca" },
            { "dutch", "nl" },
            { "arabic", "ar" },
            { "swedish", "sv" },
            { "italian", "it" },
            { "indonesian", "id" },
            { "hindi", "hi" },
            { "finnish", "fi" },
            { "vietnamese", "vi" },
            { "hebrew", "he" },
            { "ukrainian", "uk" },
            { "greek", "el" },
            { "malay", "ms" },
            { "czech", "cs" },
            { "romanian", "ro" },
            { "danish", "da" },
            { "hungarian", "hu" },
            { "tamil", "ta" },
            { "norwegian", "no" },
            { "thai", "th" },
            { "urdu", "ur" },
            { "croatian", "hr" },
            { "bulgarian", "bg" },
            { "lithuanian", "lt" },
            { "latin", "la" },
            { "maori", "mi" },
            { "malayalam", "ml" },
            { "welsh", "cy" },
            { "slovak", "sk" },
            { "telugu", "te" },
            { "persian", "fa" },
            { "latvian", "lv" },
            { "bengali", "bn" },
            { "serbian", "sr" },
            { "azerbaijani", "az" },
            { "slovenian", "sl" },
            { "kannada", "kn" },
            { "estonian", "et" },
            { "macedonian", "mk" },
            { "breton", "br" },
            { "basque", "eu" },
            { "icelandic", "is" },
            { "armenian", "hy" },
            { "nepali", "ne" },
            { "mongolian", "mn" },
            { "bosnian", "bs" },
            { "kazakh", "kk" },
            { "albanian", "sq" },
            { "swahili", "sw" },
            { "galician", "gl" },
            { "marathi", "mr" },
            { "punjabi", "pa" },
            { "sinhala", "si" },
            { "khmer", "km" },
            { "shona", "sn" },
            { "yoruba", "yo" },
            { "somali", "so" },
            { "afrikaans", "af" },
            { "occitan", "oc" },
            { "georgian", "ka" },
            { "belarusian", "be" },
            { "tajik", "tg" },
            { "sindhi", "sd" },
            { "gujarati", "gu" },
            { "amharic", "am" },
            { "yiddish", "yi" },
            { "lao", "lo" },
            { "uzbek", "uz" },
            { "faroese", "fo" },
            { "haitian creole", "ht" },
            { "pashto", "ps" },
            { "turkmen", "tk" },
            { "nynorsk", "nn" },
            { "maltese", "mt" },
            { "sanskrit", "sa" },
            { "luxembourgish", "lb" },
            { "myanmar", "my" },
            { "tibetan", "bo" },
            { "tagalog", "tl" },
            { "malagasy", "mg" },
            { "assamese", "as" },
            { "tatar", "tt" },
            { "hawaiian", "haw" },
            { "lingala", "ln" },
            { "hausa", "ha" },
            { "bashkir", "ba" },
            { "javanese", "jw" },
            { "sundanese", "su" }
        };

        public MyWhisper()
        {
            InitializeComponent();

            // Populate ComboBoxes
            cmbThreads.Items.AddRange(new object[] { 0, 1, 2, 4, 8, 16, 32 });
            cmbOutputFormat.Items.AddRange(new string[] { "txt", "vtt", "srt", "tsv", "json" });
            cmbDevice.Items.AddRange(new string[] { "auto", "cpu", "cuda" });
            cmbDeviceID.Items.AddRange(new object[] { 0, 1, 2, 3, 4, 5 });
            cmbVADFilter.Items.AddRange(new object[] { Resources.Strings.Yes, Resources.Strings.No });

            foreach (var model in models.Keys)
            {
                cmbModel.Items.Add(model);
            }

            foreach (var language in languages.Keys)
            {
                cmbLanguage.Items.Add(language);
            }

            // Set default values
            cmbModel.SelectedIndex = 3; // ggml-base.bin
            cmbThreads.SelectedIndex = 0; // 0 (recommended)
            cmbOutputFormat.SelectedIndex = 0; // txt
            cmbLanguage.SelectedIndex = 7; // ja
            cmbDevice.SelectedIndex = 0; //auto
            cmbDeviceID.SelectedIndex = 0; //0
            cmbVADFilter.SelectedIndex = 1; //いいえ
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (fileList.Items.Count == 0)
            {
                //ファイルリストが空です。メニューから文字起こしするファイルを選択してください。
                MessageBox.Show(Resources.Strings.Message_Empty_Filelist);
                return;
            }

            string selectedModel = cmbModel.SelectedItem.ToString();
            if (selectedModel == "Large" && !Directory.Exists("whisper_ctranslate2\\models\\models--guillaumekln--faster-whisper-large-v2"))
            {
                //Largeモデルを使用するにはプロ版が必要です
                MessageBox.Show(Resources.Strings.Message_Need_Pro_Version);
                return;
            }

            //処理終わるまでボタン押せなくする
            processingFiles = true;
            btnTranscribe.Enabled = false;
            menuStrip1.Enabled = false;

            //コンソールのテキストをクリア
            outputBox.Clear();

            progressBar.Maximum = 10;
            progressBar.Value = 0;
            labelProgress.Text = Resources.Strings.Processing;//処理中

            //最初にオーディオファイルを全部wavに変換する
            List<string> wavFiles = new List<string>();

            // Convert all files to WAV format
            for (int i = 0; i < fileList.Items.Count; i++)
            {
                string inputFile = fileList.Items[i].ToString();
                wavFiles.Add(inputFile);
            }   

            await RunWhisperAsync(wavFiles);

            progressBar.Value = 10;
            labelProgress.Text = Resources.Strings.Complete;//完了
            //ボタン押せるようにする
            btnTranscribe.Enabled = true;
            menuStrip1.Enabled = true;
            processingFiles = false;
        }

        private async Task RunWhisperAsync(List<string> wavFiles)
        {
            string selectedModel = models[cmbModel.SelectedItem.ToString()];
            string selectedLanguage = languages[cmbLanguage.SelectedItem.ToString()];
            int selectedThreads = (int)cmbThreads.SelectedItem;
            string selectedOutputFormat = cmbOutputFormat.SelectedItem.ToString();
            string selectedDevice = cmbDevice.SelectedItem.ToString();
            int selectedDeviceID = (int)cmbDeviceID.SelectedItem;
            string useVADFilter = cmbVADFilter.SelectedIndex == 0 ? "True" : "False";

            string whisperCommand = "whisper_ctranslate2\\whisper_ctranslate2";
            string whisperArguments = $"--model \"{selectedModel}\" --threads {selectedThreads} --output_format {selectedOutputFormat} --language {selectedLanguage} --device {selectedDevice} --device_index {selectedDeviceID} --vad_filter {useVADFilter} --model_dir whisper_ctranslate2/models --local_files_only True";
            foreach (string wavFile in wavFiles)
            {
                whisperArguments += $" \"{wavFile}\"";
            }

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = whisperCommand,
                    Arguments = whisperArguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            
            process.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    //まずはバイト配列に変換する
                    byte[] bytesUTF8 = System.Text.Encoding.Default.GetBytes(e.Data);

                    //バイト配列をUTF8の文字コードとしてStringに変換する
                    string stringSJIS = System.Text.Encoding.UTF8.GetString(bytesUTF8);

                    this.Invoke((MethodInvoker)delegate {
                        outputBox.AppendText(stringSJIS + Environment.NewLine);
                    });
                }
            };

            process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    this.Invoke((MethodInvoker)delegate {

                        //まずはバイト配列に変換する
                        byte[] bytesUTF8 = System.Text.Encoding.Default.GetBytes(e.Data);

                        //バイト配列をUTF8の文字コードとしてStringに変換する
                        string stringSJIS = System.Text.Encoding.UTF8.GetString(bytesUTF8);

                        outputBox.AppendText(stringSJIS + Environment.NewLine);
                    });
                }
            };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            await process.WaitForExitAsync();
        }

        private void ファイルを追加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Audio/Video files|*.wav;*.mp3;*.m4a;*.mp4;*.avi"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    if (!fileList.Items.Contains(file))
                    {
                        fileList.Items.Add(file);
                    }
                }
            }
        }

        private void ファイルリストをクリアToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileList.Items.Clear();
        }

        private void fileList_DragDrop(object sender, DragEventArgs e)
        {
            if (!processingFiles)
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files)
                {
                    if (!fileList.Items.Contains(file))
                    {
                        fileList.Items.Add(file);
                    }
                }
            }
            Debug.Print(fileList.Items.Count.ToString());
        }

        private void fileList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && !processingFiles)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void fileList_KeyDown(object sender, KeyEventArgs e)
        {
            if (processingFiles) return;

            if (e.KeyCode == Keys.Delete)
            {
                while (fileList.SelectedItems.Count > 0)
                {
                    fileList.Items.Remove(fileList.SelectedItems[0]);
                }
            }
        }

        private void 選択した項目を削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (fileList.SelectedItems.Count > 0)
            {
                fileList.Items.Remove(fileList.SelectedItems[0]);
            }
        }

        private void ApplyLocalization()
        {
            //ローカライズを適用
            this.Text = Resources.Strings.FormTitle;
            ファイルToolStripMenuItem.Text = Resources.Strings.Menu_File;
            ファイルを追加ToolStripMenuItem.Text = Resources.Strings.Add_Files;
            ファイルリストをクリアToolStripMenuItem.Text = Resources.Strings.Clear_Filelist;
            選択した項目を削除ToolStripMenuItem.Text = Resources.Strings.Delete_Selected_Items;
            labelModel.Text = Resources.Strings.Model;
            labelThreads.Text = Resources.Strings.Num_Threads;
            labelLanguage.Text = Resources.Strings.Language;
            labelOutput.Text = Resources.Strings.Output_Format;
            btnTranscribe.Text = Resources.Strings.Start_Transcribe;
            labelDevice.Text = Resources.Strings.Device;
            labelDeviceID.Text = Resources.Strings.DeviceID;
            labelVADFilter.Text = Resources.Strings.VADFilter;
        }

        private void MyWhisper_Load(object sender, EventArgs e)
        {
            //ローカライズ、設定を読み込む
            ApplyLocalization();
            cmbModel.SelectedItem = Properties.Settings.Default.SelectedModel;
            cmbThreads.SelectedItem = Properties.Settings.Default.SelectedThreads;
            cmbOutputFormat.SelectedItem = Properties.Settings.Default.SelectedOutputFormat;
            cmbLanguage.SelectedItem = languages.FirstOrDefault(x => x.Value == Properties.Settings.Default.SelectedLanguage).Key;
            cmbDevice.SelectedIndex = Properties.Settings.Default.SelectedDevice;
            cmbDeviceID.SelectedIndex = Properties.Settings.Default.SelectedDeviceID;
            cmbVADFilter.SelectedIndex = Properties.Settings.Default.SelectedVADFilter;
        }

        private void MyWhisper_FormClosing(object sender, FormClosingEventArgs e)
        {
            //設定をセーブする
            Properties.Settings.Default.SelectedModel = cmbModel.SelectedItem.ToString();
            Properties.Settings.Default.SelectedThreads = (int)cmbThreads.SelectedItem;
            Properties.Settings.Default.SelectedOutputFormat = cmbOutputFormat.SelectedItem.ToString();
            Properties.Settings.Default.SelectedLanguage = languages[cmbLanguage.SelectedItem.ToString()];
            Properties.Settings.Default.SelectedDevice = cmbDevice.SelectedIndex;
            Properties.Settings.Default.SelectedDeviceID = cmbDeviceID.SelectedIndex;
            Properties.Settings.Default.SelectedVADFilter = cmbVADFilter.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_About formAbout = new Form_About();
            formAbout.ShowDialog();
        }

    }
}

    