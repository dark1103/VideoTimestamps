using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VideoTimestamps
{
    public partial class MainForm : Form
    {
        private List<(TimeSpan, string)> stamps = new List<(TimeSpan, string)>();
        private BindingSource bindingSource;

        private DateTime startTime;
        private DateTime? writeStartTime;

        private Config config;

        private bool haveChanges = false;

        public MainForm()
        {
            InitializeComponent();

            startTime = DateTime.Now;
            time_textbox.Text = DateTime.Now.ToString("HH:mm:ss");

            bindingSource = new BindingSource();
            bindingSource.DataSource = stamps;
            stamps_listbox.DataSource = bindingSource;
            stamps_listbox.Format += (sender, args) =>
            {
                var val = (ValueTuple<TimeSpan, string>) args.ListItem;
                args.Value = val.Item1.ToString(@"hh\:mm\:ss") + " | " + val.Item2;
            };
            clear_text_btn.Enabled = false;
            add_button.Enabled = false;

            this.AcceptButton = add_button;
            LoadConfig();

            bindingSource.ListChanged += (sender, args) => { haveChanges = true; };
        }

        private void LoadConfig()
        {
            if (File.Exists("config.json"))
            {
                var text = File.ReadAllText("config.json");
                config = JsonConvert.DeserializeObject<Config>(text);
                folders_comboBox.Items.Clear();
                folders_comboBox.Items.AddRange(config.Folders.Keys.ToArray());

                if (folders_comboBox.Items.Count > 0)
                {
                    folders_comboBox.SelectedIndex = 0;
                }
            }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            time_textbox.Text = DateTime.Now.ToString("HH:mm:ss");
            startTime = DateTime.Now;
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            stamps.Add(((writeStartTime.Value - startTime), label_textbox.Text));
            label_textbox.Text = "";
            clear_text_btn.Enabled = false;
            writeStartTime = null;
            bindingSource.ResetBindings(false);
            label_textbox.Focus();
            stamp_time_label.Text = "-------";

            haveChanges = true;
        }

        private void label_textbox_TextChanged(object sender, EventArgs e)
        {
            if (writeStartTime == null)
            {
                add_button.Enabled = true;
                writeStartTime = DateTime.Now;
                stamp_time_label.Text = (writeStartTime.Value - startTime).ToString(@"hh\:mm\:ss");
                clear_text_btn.Enabled = true;
            }
        }

        private void clear_text_btn_Click(object sender, EventArgs e)
        {
            add_button.Enabled = false;
            writeStartTime = null;
            clear_text_btn.Enabled = false;
            label_textbox.Text = "";
            stamp_time_label.Text = "-------";
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Stamps file (*.stmp) | *.stmp",
                FileName = name_textbox.Text + ".stmp"
            };

            if (config != null)
            {
                dialog.InitialDirectory = Path.Combine(config.Directory, folders_comboBox.SelectedItem.ToString(), subfolders_comboBox.SelectedItem.ToString());
                if (!Directory.Exists(dialog.InitialDirectory))
                {
                    Directory.CreateDirectory(dialog.InitialDirectory);
                }
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string closestFile = FindClosest(startTime);
                if (closestFile != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Pick up file: " + Path.GetFileName(closestFile) + " ?", "Pick up file?", MessageBoxButtons.YesNoCancel);

                    if (dialogResult == DialogResult.No)
                    {
                        closestFile = null;
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                List<string> lines = new List<string>()
                {
                    name_textbox.Text,
                    startTime.ToString("G"),
                };
                lines.AddRange(stamps.Select(x => x.Item1.ToString(@"hh\:mm\:ss") + " | " + x.Item2));
                File.WriteAllLines(dialog.FileName, lines);

                if (closestFile != null)
                {
                    bool saving = true;
                    while (saving)
                    {
                        try
                        {
                            File.Move(closestFile, Path.ChangeExtension(dialog.FileName, Path.GetExtension(closestFile)));
                            saving = false;
                        }
                        catch
                        {
                            DialogResult dialogResult = MessageBox.Show("Unable to move the file: " + Path.GetFileName(closestFile), "Move failed", MessageBoxButtons.RetryCancel);
                            if (dialogResult != DialogResult.Retry)
                            {
                                saving = false;
                            }
                        }
                    }

                }

                haveChanges = false;
            }
        }

        private string FindClosest(DateTime time)
        {
            if (config.RecordsDirectory != null && Directory.Exists(config.RecordsDirectory))
            {
                string FMT = config.RecordsTimeFormat;
                List<(DateTime, string)> files = new List<(DateTime, string)>();

                foreach (var path in Directory.EnumerateFiles(config.RecordsDirectory))
                {
                    try
                    {
                        DateTime parsed;
                        string fileName = Path.GetFileName(path);
                        string val = Regex.Match(fileName, config.RecordsRegex).Groups[1].Value;
                        parsed = DateTime.ParseExact(val, FMT, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);
                        files.Add((parsed, path));
                    }
                    catch
                    {
                        // ignored
                    }
                }

                if (files.Any())
                {
                    files = files.OrderBy(x => Math.Abs((x.Item1 - time).TotalSeconds)).ToList();

                    if (Math.Abs((files[0].Item1 - time).TotalSeconds) < config.RecordPickupHours * 60 * 60)
                    {
                        return files[0].Item2;
                    }
                }
            }

            return null;
        }

        private void label_textbox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedIndex = stamps_listbox.SelectedIndex;
            if (selectedIndex > -1)
            {
                stamps.RemoveAt(selectedIndex);
                bindingSource.ResetBindings(false);
                haveChanges = true;
            }
        }

        private void stamps_listbox_MouseUp(object sender, MouseEventArgs e)
        {
            int index = stamps_listbox.IndexFromPoint(e.Location);
            if (e.Button == MouseButtons.Right)
            {
                if (index != ListBox.NoMatches)
                {
                    stamps_listbox.SelectedIndex = index;
                    stamps_listbox.ContextMenuStrip.Visible = true;
                }
                else
                {
                    stamps_listbox.ContextMenuStrip.Visible = false;
                }
            }
            else
            {
                stamps_listbox.ContextMenuStrip.Visible = false;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            var stmp = files.FirstOrDefault(x => x.EndsWith(".stmp"));
            var mp4 = files.FirstOrDefault(x => x.EndsWith(".mp4"));

            if (stmp != null && mp4 == null)
            {
                var path = Path.ChangeExtension(stmp, ".mp4");
                if (File.Exists(path))
                {
                    mp4 = path;
                }
            }

            if (stmp == null && mp4 != null)
            {
                var path = Path.ChangeExtension(mp4, ".stmp");
                if (File.Exists(path))
                {
                    stmp = path;
                }
            }

            if (stmp != null)
            {
                var lines = File.ReadAllLines(stmp);
                name_textbox.Text = lines[0];
                startTime = DateTime.Parse(lines[1]);

                var data = lines.Skip(2).Select(x => x.Split(new []{ " | " }, StringSplitOptions.RemoveEmptyEntries)).Select(x=> (TimeSpan.Parse(x[0]), x[1])).ToList();

                stamps.Clear();
                stamps.AddRange(data);
                bindingSource.ResetBindings(false);
                haveChanges = false;
            }


            if (mp4 != null)
            {
                player.URL = mp4;
                player.Show();
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void stamps_listbox_DoubleClick(object sender, EventArgs e)
        {
            if (stamps_listbox.SelectedIndex > -1)
            {
                var val = (ValueTuple<TimeSpan,string>)stamps_listbox.SelectedItem;
                player.Ctlcontrols.currentPosition = val.Item1.TotalSeconds;
            }
        }

        private void time_textbox_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(time_textbox.Text, out var result))
            {
                startTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, result.Hour, result.Minute, result.Second);
            }
        }

        private void player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 1)
            {
                player.URL = null;
                player.Hide();
            }
        }

        private void folders_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            subfolders_comboBox.Items.Clear();
            if (folders_comboBox.SelectedIndex > -1)
            {
                if (config?.Folders?.ContainsKey(folders_comboBox.SelectedItem.ToString()) == true)
                {
                    subfolders_comboBox.Items.AddRange(config.Folders[folders_comboBox.SelectedItem.ToString()].Subfolders.ToArray());
                }

                if (subfolders_comboBox.Items.Count > 0)
                {
                    subfolders_comboBox.SelectedIndex = 0;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (haveChanges)
            {
                var result = MessageBox.Show("Unsaved data will be lost. Continue?", "Exit confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                e.Cancel = (result == DialogResult.No);
            }
        }
    }
}
