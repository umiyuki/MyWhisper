using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaToolkit;
using MediaToolkit.Model;
using System.IO;
using MediaToolkit.Options;
using NAudio.Wave;
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
            { "Large", "ggml-large.bin" },
            { "Medium", "ggml-medium.bin" },
            { "Small", "ggml-small.bin" },
            { "Base", "ggml-base.bin" },
            { "Tiny", "ggml-tiny.bin" }
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
            cmbThreads.Items.AddRange(new object[] { 1, 2, 4, 8, 16, 32 });
            cmbProcessor.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });
            cmbOutputFormat.Items.AddRange(new string[] { "txt", "vtt", "srt", "wts" });

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
            cmbThreads.SelectedIndex = 2; // 4 (recommended)
            cmbProcessor.SelectedIndex = 0; // 1 (recommended)
            cmbOutputFormat.SelectedIndex = 0; // txt
            cmbLanguage.SelectedIndex = 7; // ja
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (fileList.Items.Count == 0)
            {
                //ファイルリストが空です。メニューから文字起こしするファイルを選択してください。
                MessageBox.Show(Resources.Strings.Message_Empty_Filelist);
                return;
            }

            string selectedModel = models[cmbModel.SelectedItem.ToString()];
            if (!File.Exists(selectedModel))
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
            labelProgress.Text = "処理中";

            //最初にオーディオファイルを全部wavに変換する
            List<string> wavFiles = new List<string>();

            // Convert all files to WAV format
            for (int i = 0; i < fileList.Items.Count; i++)
            {
                string inputFile = fileList.Items[i].ToString();
                string outputWavPath = Path.ChangeExtension(inputFile, ".temp.wav");
                await ConvertToWavAsync(inputFile, outputWavPath);
                wavFiles.Add(outputWavPath);
            }   

            await RunWhisperAsync(wavFiles);

            foreach (string file in wavFiles)
            {
                //出力テキストをリネーム
                string selectedOutputFormat = cmbOutputFormat.SelectedItem.ToString();
                string outFilePath = file +"." + selectedOutputFormat;
                if (File.Exists(outFilePath))
                {
                    string path1 = Path.GetFileNameWithoutExtension(outFilePath);
                    string path2 = Path.GetFileNameWithoutExtension(path1);
                    string path3 = Path.GetFileNameWithoutExtension(path2);
                    string finalPath = Path.GetDirectoryName(outFilePath) + "\\" + path3 + "." + selectedOutputFormat;
                    Debug.Print(Path.GetFileNameWithoutExtension(finalPath));

                    //すでにファイルが存在するなら削除しとく
                    if (File.Exists(finalPath))
                    {
                        File.Delete(finalPath);
                    }

                    File.Move(outFilePath, finalPath);
                }

                //一時的なwavファイルを全部消す
                File.Delete(file);
            }

            progressBar.Value = 10;
            labelProgress.Text = "完了";
            //ボタン押せるようにする
            btnTranscribe.Enabled = true;
            menuStrip1.Enabled = true;
            processingFiles = false;
        }

        private void btnTranscribe_Click(object sender, EventArgs e)
        {

        }

        private async Task ConvertToWavAsync(string inputPath, string outputPath)
        {
            string extension = Path.GetExtension(inputPath).ToLower();

            if (extension == ".mp4" || extension == ".avi")
            {
                await ConvertVideoToWavAsync(inputPath, outputPath);
            }
            else
            {
                await ConvertAudioToWavAsync(inputPath, outputPath);
            }
        }

        private async Task ConvertAudioToWavAsync(string inputPath, string outputPath)
        {
            using (var reader = new MediaFoundationReader(inputPath))
            using (var resampler = new MediaFoundationResampler(reader, new WaveFormat(16000, 1)))
            {
                WaveFileWriter.CreateWaveFile(outputPath, resampler);
            }
        }

        private async Task ConvertVideoToWavAsync(string inputPath, string outputPath)
        {
            string tempOutputPath = Path.ChangeExtension(inputPath, ".temp.v.wav");

            var inputFile = new MediaFile { Filename = inputPath };
            var outputFile = new MediaFile { Filename = tempOutputPath };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
                engine.Convert(inputFile, outputFile);
            }

            await ConvertAudioToWavAsync(tempOutputPath, outputPath);
            File.Delete(tempOutputPath);
        }

        private async Task RunWhisperAsync(List<string> wavFiles)
        {
            string selectedModel = models[cmbModel.SelectedItem.ToString()];
            string selectedLanguage = languages[cmbLanguage.SelectedItem.ToString()];
            int selectedThreads = (int)cmbThreads.SelectedItem;
            int selectedProcessors = (int)cmbProcessor.SelectedItem;
            string selectedOutputFormat = cmbOutputFormat.SelectedItem.ToString();

            string whisperCommand = "main";
            string whisperArguments = $"-m \"{selectedModel}\" -t {selectedThreads} -p {selectedProcessors} -o{selectedOutputFormat} -l {selectedLanguage}";
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
            this.Text = Resources.Strings.FormTitle;
            ファイルToolStripMenuItem.Text = Resources.Strings.Menu_File;
            ファイルを追加ToolStripMenuItem.Text = Resources.Strings.Add_Files;
            ファイルリストをクリアToolStripMenuItem.Text = Resources.Strings.Clear_Filelist;
            選択した項目を削除ToolStripMenuItem.Text = Resources.Strings.Delete_Selected_Items;
            labelModel.Text = Resources.Strings.Model;
            labelThreads.Text = Resources.Strings.Num_Threads;
            labelProcesses.Text = Resources.Strings.Num_Processes;
            labelLanguage.Text = Resources.Strings.Language;
            labelOutput.Text = Resources.Strings.Output_Format;
            btnTranscribe.Text = Resources.Strings.Start_Transcribe;
        }

        private void MyWhisper_Load(object sender, EventArgs e)
        {

            ApplyLocalization();
            cmbModel.SelectedItem = Properties.Settings.Default.SelectedModel;
            cmbThreads.SelectedItem = Properties.Settings.Default.SelectedThreads;
            cmbProcessor.SelectedItem = Properties.Settings.Default.SelectedProcessors;
            cmbOutputFormat.SelectedItem = Properties.Settings.Default.SelectedOutputFormat;
            cmbLanguage.SelectedItem = languages.FirstOrDefault(x => x.Value == Properties.Settings.Default.SelectedLanguage).Key;
        }

        private void MyWhisper_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SelectedModel = cmbModel.SelectedItem.ToString();
            Properties.Settings.Default.SelectedThreads = (int)cmbThreads.SelectedItem;
            Properties.Settings.Default.SelectedProcessors = (int)cmbProcessor.SelectedItem;
            Properties.Settings.Default.SelectedOutputFormat = cmbOutputFormat.SelectedItem.ToString();
            Properties.Settings.Default.SelectedLanguage = languages[cmbLanguage.SelectedItem.ToString()];
            Properties.Settings.Default.Save();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_About formAbout = new Form_About();
            formAbout.ShowDialog();
        }
    }
}

    