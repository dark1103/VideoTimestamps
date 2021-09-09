
namespace VideoTimestamps
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.time_textbox = new System.Windows.Forms.MaskedTextBox();
            this.start_btn = new System.Windows.Forms.Button();
            this.name_textbox = new System.Windows.Forms.TextBox();
            this.stamps_listbox = new System.Windows.Forms.ListBox();
            this.list_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_textbox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.player = new AxWMPLib.AxWindowsMediaPlayer();
            this.save_btn = new System.Windows.Forms.Button();
            this.clear_text_btn = new System.Windows.Forms.Button();
            this.stamp_time_label = new System.Windows.Forms.Label();
            this.add_button = new System.Windows.Forms.Button();
            this.folders_comboBox = new System.Windows.Forms.ComboBox();
            this.subfolders_comboBox = new System.Windows.Forms.ComboBox();
            this.list_MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // time_textbox
            // 
            this.time_textbox.Location = new System.Drawing.Point(234, 30);
            this.time_textbox.Mask = "00:00:00";
            this.time_textbox.Name = "time_textbox";
            this.time_textbox.Size = new System.Drawing.Size(100, 20);
            this.time_textbox.TabIndex = 0;
            this.time_textbox.ValidatingType = typeof(System.DateTime);
            this.time_textbox.TextChanged += new System.EventHandler(this.time_textbox_TextChanged);
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(340, 28);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(75, 23);
            this.start_btn.TabIndex = 1;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // name_textbox
            // 
            this.name_textbox.Location = new System.Drawing.Point(14, 31);
            this.name_textbox.Name = "name_textbox";
            this.name_textbox.Size = new System.Drawing.Size(214, 20);
            this.name_textbox.TabIndex = 2;
            // 
            // stamps_listbox
            // 
            this.stamps_listbox.ContextMenuStrip = this.list_MenuStrip;
            this.stamps_listbox.FormattingEnabled = true;
            this.stamps_listbox.Location = new System.Drawing.Point(14, 57);
            this.stamps_listbox.Name = "stamps_listbox";
            this.stamps_listbox.Size = new System.Drawing.Size(405, 381);
            this.stamps_listbox.TabIndex = 3;
            this.stamps_listbox.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.stamps_listbox.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.stamps_listbox.DoubleClick += new System.EventHandler(this.stamps_listbox_DoubleClick);
            this.stamps_listbox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.stamps_listbox_MouseUp);
            // 
            // list_MenuStrip
            // 
            this.list_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem});
            this.list_MenuStrip.Name = "list_MenuStrip";
            this.list_MenuStrip.Size = new System.Drawing.Size(119, 26);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // label_textbox
            // 
            this.label_textbox.Location = new System.Drawing.Point(12, 365);
            this.label_textbox.Name = "label_textbox";
            this.label_textbox.Size = new System.Drawing.Size(552, 20);
            this.label_textbox.TabIndex = 4;
            this.label_textbox.TextChanged += new System.EventHandler(this.label_textbox_TextChanged);
            this.label_textbox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.label_textbox_PreviewKeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.subfolders_comboBox);
            this.splitContainer1.Panel1.Controls.Add(this.folders_comboBox);
            this.splitContainer1.Panel1.Controls.Add(this.stamps_listbox);
            this.splitContainer1.Panel1.Controls.Add(this.start_btn);
            this.splitContainer1.Panel1.Controls.Add(this.name_textbox);
            this.splitContainer1.Panel1.Controls.Add(this.time_textbox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.player);
            this.splitContainer1.Panel2.Controls.Add(this.save_btn);
            this.splitContainer1.Panel2.Controls.Add(this.clear_text_btn);
            this.splitContainer1.Panel2.Controls.Add(this.stamp_time_label);
            this.splitContainer1.Panel2.Controls.Add(this.add_button);
            this.splitContainer1.Panel2.Controls.Add(this.label_textbox);
            this.splitContainer1.Size = new System.Drawing.Size(1016, 450);
            this.splitContainer1.SplitterDistance = 436;
            this.splitContainer1.TabIndex = 5;
            this.splitContainer1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.splitContainer1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            // 
            // player
            // 
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(12, 6);
            this.player.Name = "player";
            this.player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player.OcxState")));
            this.player.Size = new System.Drawing.Size(552, 353);
            this.player.TabIndex = 9;
            this.player.Visible = false;
            this.player.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.player_PlayStateChange);
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(489, 420);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 23);
            this.save_btn.TabIndex = 8;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // clear_text_btn
            // 
            this.clear_text_btn.Location = new System.Drawing.Point(12, 391);
            this.clear_text_btn.Name = "clear_text_btn";
            this.clear_text_btn.Size = new System.Drawing.Size(75, 23);
            this.clear_text_btn.TabIndex = 7;
            this.clear_text_btn.Text = "Clear";
            this.clear_text_btn.UseVisualStyleBackColor = true;
            this.clear_text_btn.Click += new System.EventHandler(this.clear_text_btn_Click);
            // 
            // stamp_time_label
            // 
            this.stamp_time_label.AutoSize = true;
            this.stamp_time_label.Location = new System.Drawing.Point(392, 396);
            this.stamp_time_label.Name = "stamp_time_label";
            this.stamp_time_label.Size = new System.Drawing.Size(28, 13);
            this.stamp_time_label.TabIndex = 6;
            this.stamp_time_label.Text = "-------";
            this.stamp_time_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(489, 391);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(75, 23);
            this.add_button.TabIndex = 5;
            this.add_button.Text = "Add";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // folders_comboBox
            // 
            this.folders_comboBox.FormattingEnabled = true;
            this.folders_comboBox.Location = new System.Drawing.Point(12, 6);
            this.folders_comboBox.Name = "folders_comboBox";
            this.folders_comboBox.Size = new System.Drawing.Size(165, 21);
            this.folders_comboBox.TabIndex = 4;
            this.folders_comboBox.SelectedIndexChanged += new System.EventHandler(this.folders_comboBox_SelectedIndexChanged);
            // 
            // subfolders_comboBox
            // 
            this.subfolders_comboBox.FormattingEnabled = true;
            this.subfolders_comboBox.Location = new System.Drawing.Point(183, 6);
            this.subfolders_comboBox.Name = "subfolders_comboBox";
            this.subfolders_comboBox.Size = new System.Drawing.Size(165, 21);
            this.subfolders_comboBox.TabIndex = 5;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "VideoStamps";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.list_MenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox time_textbox;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.TextBox name_textbox;
        private System.Windows.Forms.ListBox stamps_listbox;
        private System.Windows.Forms.TextBox label_textbox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Label stamp_time_label;
        private System.Windows.Forms.Button clear_text_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.ContextMenuStrip list_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer player;
        private System.Windows.Forms.ComboBox subfolders_comboBox;
        private System.Windows.Forms.ComboBox folders_comboBox;
    }
}

