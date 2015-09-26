namespace XMLMergeTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboBox_XML = new System.Windows.Forms.ComboBox();
            this.button_BL = new System.Windows.Forms.Button();
            this.button_LDSN = new System.Windows.Forms.Button();
            this.button_Merge = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_LDNS = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_BL = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Help = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Preference = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Open = new System.Windows.Forms.ToolStripButton();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Merge = new System.Windows.Forms.TextBox();
            this.textBox_BL = new System.Windows.Forms.TextBox();
            this.textBox_LDSN = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_XML
            // 
            this.comboBox_XML.BackColor = System.Drawing.Color.White;
            this.comboBox_XML.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_XML.FormattingEnabled = true;
            this.comboBox_XML.Items.AddRange(new object[] {
            "CustomFormatter",
            "RemoteAssemblyInfo"});
            this.comboBox_XML.Location = new System.Drawing.Point(113, 21);
            this.comboBox_XML.Name = "comboBox_XML";
            this.comboBox_XML.Size = new System.Drawing.Size(183, 23);
            this.comboBox_XML.TabIndex = 13;
            this.toolTip1.SetToolTip(this.comboBox_XML, "XML選択");
            this.comboBox_XML.SelectedIndexChanged += new System.EventHandler(this.comboBox_XML_SelectedIndexChanged);
            // 
            // button_BL
            // 
            this.button_BL.Image = global::XMLMergeTool.Properties.Resources.OPEN;
            this.button_BL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_BL.Location = new System.Drawing.Point(796, 106);
            this.button_BL.Margin = new System.Windows.Forms.Padding(4);
            this.button_BL.Name = "button_BL";
            this.button_BL.Size = new System.Drawing.Size(75, 26);
            this.button_BL.TabIndex = 18;
            this.button_BL.Text = "Open";
            this.button_BL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.button_BL, "BL様からXMLを選ぶ");
            this.button_BL.UseVisualStyleBackColor = true;
            this.button_BL.Click += new System.EventHandler(this.button_BL_Click);
            // 
            // button_LDSN
            // 
            this.button_LDSN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_LDSN.Image = global::XMLMergeTool.Properties.Resources.OPEN;
            this.button_LDSN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_LDSN.Location = new System.Drawing.Point(796, 59);
            this.button_LDSN.Margin = new System.Windows.Forms.Padding(4);
            this.button_LDSN.Name = "button_LDSN";
            this.button_LDSN.Size = new System.Drawing.Size(75, 26);
            this.button_LDSN.TabIndex = 15;
            this.button_LDSN.Text = "Open";
            this.button_LDSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.button_LDSN, "LDNSからXMLを選ぶ");
            this.button_LDSN.UseVisualStyleBackColor = true;
            this.button_LDSN.Click += new System.EventHandler(this.button_LDSN_Click);
            // 
            // button_Merge
            // 
            this.button_Merge.Image = global::XMLMergeTool.Properties.Resources.Merge;
            this.button_Merge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Merge.Location = new System.Drawing.Point(796, 152);
            this.button_Merge.Margin = new System.Windows.Forms.Padding(4);
            this.button_Merge.Name = "button_Merge";
            this.button_Merge.Size = new System.Drawing.Size(75, 26);
            this.button_Merge.TabIndex = 21;
            this.button_Merge.Text = "Merge";
            this.button_Merge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.button_Merge, "上記のXMLをマージする");
            this.button_Merge.UseVisualStyleBackColor = true;
            this.button_Merge.Click += new System.EventHandler(this.button_Merge_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel_LDNS,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel_BL});
            this.statusStrip1.Location = new System.Drawing.Point(0, 277);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 23);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(113, 18);
            this.toolStripStatusLabel1.Text = "LDNSのみがある：";
            // 
            // toolStripStatusLabel_LDNS
            // 
            this.toolStripStatusLabel_LDNS.Name = "toolStripStatusLabel_LDNS";
            this.toolStripStatusLabel_LDNS.Size = new System.Drawing.Size(113, 18);
            this.toolStripStatusLabel_LDNS.Text = "LDNSのみがある件";
            this.toolStripStatusLabel_LDNS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(176, 18);
            this.toolStripStatusLabel2.Text = "                                          ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(107, 18);
            this.toolStripStatusLabel3.Text = "BL様のみがある：";
            // 
            // toolStripStatusLabel_BL
            // 
            this.toolStripStatusLabel_BL.Name = "toolStripStatusLabel_BL";
            this.toolStripStatusLabel_BL.Size = new System.Drawing.Size(107, 18);
            this.toolStripStatusLabel_BL.Text = "BL様のみがある件";
            this.toolStripStatusLabel_BL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Help,
            this.toolStripButton_Preference,
            this.toolStripButton_Open});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(884, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_Help
            // 
            this.toolStripButton_Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Help.Image = global::XMLMergeTool.Properties.Resources.help;
            this.toolStripButton_Help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Help.Name = "toolStripButton_Help";
            this.toolStripButton_Help.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Help.ToolTipText = "使用方法の説明";
            this.toolStripButton_Help.Click += new System.EventHandler(this.toolStripButton_Help_Click);
            // 
            // toolStripButton_Preference
            // 
            this.toolStripButton_Preference.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Preference.Font = new System.Drawing.Font("メイリオ", 9F);
            this.toolStripButton_Preference.Image = global::XMLMergeTool.Properties.Resources.TOP_OFF;
            this.toolStripButton_Preference.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Preference.Name = "toolStripButton_Preference";
            this.toolStripButton_Preference.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Preference.Text = "Top";
            this.toolStripButton_Preference.ToolTipText = "Always On Top";
            this.toolStripButton_Preference.Click += new System.EventHandler(this.toolStripButton_Preference_Click);
            // 
            // toolStripButton_Open
            // 
            this.toolStripButton_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Open.Image = global::XMLMergeTool.Properties.Resources.SETTING;
            this.toolStripButton_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Open.Name = "toolStripButton_Open";
            this.toolStripButton_Open.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Open.Text = "Open Folder Afer Merging";
            this.toolStripButton_Open.Click += new System.EventHandler(this.toolStripButton_Open_Click);
            // 
            // panel_Main
            // 
            this.panel_Main.BackColor = System.Drawing.SystemColors.Control;
            this.panel_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Main.Controls.Add(this.comboBox_XML);
            this.panel_Main.Controls.Add(this.label6);
            this.panel_Main.Controls.Add(this.button_BL);
            this.panel_Main.Controls.Add(this.button_LDSN);
            this.panel_Main.Controls.Add(this.label3);
            this.panel_Main.Controls.Add(this.label2);
            this.panel_Main.Controls.Add(this.label1);
            this.panel_Main.Controls.Add(this.textBox_Merge);
            this.panel_Main.Controls.Add(this.textBox_BL);
            this.panel_Main.Controls.Add(this.button_Merge);
            this.panel_Main.Controls.Add(this.textBox_LDSN);
            this.panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Main.Location = new System.Drawing.Point(0, 25);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(884, 252);
            this.panel_Main.TabIndex = 16;
            this.panel_Main.TabStop = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 29);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 23;
            this.label6.Text = "XML選択";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 163);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Merge XML";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "BL様からXML";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "LDNSからXML";
            // 
            // textBox_Merge
            // 
            this.textBox_Merge.BackColor = System.Drawing.Color.White;
            this.textBox_Merge.ForeColor = System.Drawing.Color.Black;
            this.textBox_Merge.Location = new System.Drawing.Point(113, 156);
            this.textBox_Merge.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Merge.Name = "textBox_Merge";
            this.textBox_Merge.ReadOnly = true;
            this.textBox_Merge.Size = new System.Drawing.Size(673, 22);
            this.textBox_Merge.TabIndex = 20;
            this.textBox_Merge.TabStop = false;
            this.textBox_Merge.Text = "E:\\02.Merge\\CustomFormatter_001.xml";
            // 
            // textBox_BL
            // 
            this.textBox_BL.AllowDrop = true;
            this.textBox_BL.BackColor = System.Drawing.Color.White;
            this.textBox_BL.Location = new System.Drawing.Point(113, 110);
            this.textBox_BL.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_BL.Name = "textBox_BL";
            this.textBox_BL.ReadOnly = true;
            this.textBox_BL.Size = new System.Drawing.Size(673, 22);
            this.textBox_BL.TabIndex = 16;
            this.textBox_BL.Text = "E:\\02.BL\\CustomFormatter_001.xml";
            this.textBox_BL.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_BL_DragDrop);
            this.textBox_BL.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_BL_DragEnter);
            // 
            // textBox_LDSN
            // 
            this.textBox_LDSN.AllowDrop = true;
            this.textBox_LDSN.BackColor = System.Drawing.Color.White;
            this.textBox_LDSN.Location = new System.Drawing.Point(113, 63);
            this.textBox_LDSN.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_LDSN.Name = "textBox_LDSN";
            this.textBox_LDSN.ReadOnly = true;
            this.textBox_LDSN.Size = new System.Drawing.Size(673, 22);
            this.textBox_LDSN.TabIndex = 14;
            this.textBox_LDSN.Text = "E:\\01.LDNS\\CustomFormatter_001.xml";
            this.textBox_LDSN.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_LDSN_DragDrop);
            this.textBox_LDSN.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_LDSN_DragEnter);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 300);
            this.Controls.Add(this.panel_Main);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XMLMerge";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel_Main.ResumeLayout(false);
            this.panel_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Help;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_LDNS;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_BL;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Panel panel_Main;
        private System.Windows.Forms.ComboBox comboBox_XML;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_BL;
        private System.Windows.Forms.Button button_LDSN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Merge;
        private System.Windows.Forms.TextBox textBox_BL;
        private System.Windows.Forms.Button button_Merge;
        private System.Windows.Forms.TextBox textBox_LDSN;
        private System.Windows.Forms.ToolStripButton toolStripButton_Preference;
        private System.Windows.Forms.ToolStripButton toolStripButton_Open;
    }
}

