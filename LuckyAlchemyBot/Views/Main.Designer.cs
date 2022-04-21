namespace LuckyAlchemyBot.Views
{
    partial class Main
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEnhancement = new System.Windows.Forms.Label();
            this.comboItem = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDegree = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.linkRefreshItemList = new System.Windows.Forms.Label();
            this.radioMagicOptions = new System.Windows.Forms.RadioButton();
            this.radioAttribute = new System.Windows.Forms.RadioButton();
            this.radioEnhance = new System.Windows.Forms.RadioButton();
            this.lvLog = new System.Windows.Forms.ListView();
            this.colItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSuccess = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupSettings = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listMagicOptions = new System.Windows.Forms.ListBox();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.tabControlItemInfo = new RSBot.Theme.Controls.TabControl();
            this.tabMagicOptions = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.enhanceSettingsView = new LuckAlchemyBot.Views.Settings.EnhanceSettingsView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupSettings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControlItemInfo.SuspendLayout();
            this.tabMagicOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEnhancement);
            this.groupBox1.Controls.Add(this.comboItem);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblDegree);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.linkRefreshItemList);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item selection";
            // 
            // lblEnhancement
            // 
            this.lblEnhancement.AutoSize = true;
            this.lblEnhancement.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnhancement.Location = new System.Drawing.Point(101, 88);
            this.lblEnhancement.Name = "lblEnhancement";
            this.lblEnhancement.Size = new System.Drawing.Size(108, 13);
            this.lblEnhancement.TabIndex = 1;
            this.lblEnhancement.Text = "<no item selected>";
            // 
            // comboItem
            // 
            this.comboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboItem.FormattingEnabled = true;
            this.comboItem.Location = new System.Drawing.Point(18, 41);
            this.comboItem.Name = "comboItem";
            this.comboItem.Size = new System.Drawing.Size(219, 21);
            this.comboItem.TabIndex = 4;
            this.comboItem.SelectedIndexChanged += new System.EventHandler(this.comboItem_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "&Enhancement:";
            // 
            // lblDegree
            // 
            this.lblDegree.AutoSize = true;
            this.lblDegree.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDegree.Location = new System.Drawing.Point(101, 65);
            this.lblDegree.Name = "lblDegree";
            this.lblDegree.Size = new System.Drawing.Size(108, 13);
            this.lblDegree.TabIndex = 1;
            this.lblDegree.Text = "<no item selected>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "&Degree:";
            // 
            // linkRefreshItemList
            // 
            this.linkRefreshItemList.AutoSize = true;
            this.linkRefreshItemList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkRefreshItemList.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkRefreshItemList.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.linkRefreshItemList.Location = new System.Drawing.Point(233, 34);
            this.linkRefreshItemList.Name = "linkRefreshItemList";
            this.linkRefreshItemList.Size = new System.Drawing.Size(34, 30);
            this.linkRefreshItemList.TabIndex = 5;
            this.linkRefreshItemList.Text = "🗘";
            this.linkRefreshItemList.Click += new System.EventHandler(this.linkRefreshItemList_Click);
            // 
            // radioMagicOptions
            // 
            this.radioMagicOptions.AutoSize = true;
            this.radioMagicOptions.Enabled = false;
            this.radioMagicOptions.Location = new System.Drawing.Point(164, 2);
            this.radioMagicOptions.Name = "radioMagicOptions";
            this.radioMagicOptions.Size = new System.Drawing.Size(91, 17);
            this.radioMagicOptions.TabIndex = 2;
            this.radioMagicOptions.Text = "Mag. Option";
            this.radioMagicOptions.UseVisualStyleBackColor = true;
            // 
            // radioAttribute
            // 
            this.radioAttribute.AutoSize = true;
            this.radioAttribute.Enabled = false;
            this.radioAttribute.Location = new System.Drawing.Point(94, 2);
            this.radioAttribute.Name = "radioAttribute";
            this.radioAttribute.Size = new System.Drawing.Size(71, 17);
            this.radioAttribute.TabIndex = 1;
            this.radioAttribute.Text = "Attribute";
            this.radioAttribute.UseVisualStyleBackColor = true;
            // 
            // radioEnhance
            // 
            this.radioEnhance.AutoSize = true;
            this.radioEnhance.Location = new System.Drawing.Point(7, 2);
            this.radioEnhance.Name = "radioEnhance";
            this.radioEnhance.Size = new System.Drawing.Size(86, 17);
            this.radioEnhance.TabIndex = 0;
            this.radioEnhance.Text = "Enhance (+)";
            this.radioEnhance.UseVisualStyleBackColor = true;
            this.radioEnhance.CheckedChanged += new System.EventHandler(this.radioEngine_CheckedChanged);
            // 
            // lvLog
            // 
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colItem,
            this.colSuccess,
            this.colResult});
            this.lvLog.FullRowSelect = true;
            this.lvLog.HideSelection = false;
            this.lvLog.Location = new System.Drawing.Point(14, 324);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(734, 163);
            this.lvLog.TabIndex = 1;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            // 
            // colItem
            // 
            this.colItem.Text = "Item";
            this.colItem.Width = 228;
            // 
            // colSuccess
            // 
            this.colSuccess.Text = "Success";
            this.colSuccess.Width = 300;
            // 
            // colResult
            // 
            this.colResult.Text = "Result";
            this.colResult.Width = 283;
            // 
            // groupSettings
            // 
            this.groupSettings.Controls.Add(this.enhanceSettingsView);
            this.groupSettings.Controls.Add(this.panel1);
            this.groupSettings.Location = new System.Drawing.Point(310, 12);
            this.groupSettings.Name = "groupSettings";
            this.groupSettings.Size = new System.Drawing.Size(438, 306);
            this.groupSettings.TabIndex = 2;
            this.groupSettings.TabStop = false;
            this.groupSettings.Text = "Settings";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioEnhance);
            this.panel1.Controls.Add(this.radioAttribute);
            this.panel1.Controls.Add(this.radioMagicOptions);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 25);
            this.panel1.TabIndex = 4;
            // 
            // listMagicOptions
            // 
            this.listMagicOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMagicOptions.FormattingEnabled = true;
            this.listMagicOptions.Location = new System.Drawing.Point(3, 3);
            this.listMagicOptions.Name = "listMagicOptions";
            this.listMagicOptions.Size = new System.Drawing.Size(262, 135);
            this.listMagicOptions.TabIndex = 2;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(307, 490);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(188, 13);
            this.lblCopyright.TabIndex = 4;
            this.lblCopyright.Text = "LuckyAlchemyBot © 2022 Wimbeam";
            // 
            // tabControlItemInfo
            // 
            this.tabControlItemInfo.Controls.Add(this.tabMagicOptions);
            this.tabControlItemInfo.Controls.Add(this.tabPage2);
            this.tabControlItemInfo.Location = new System.Drawing.Point(14, 141);
            this.tabControlItemInfo.Name = "tabControlItemInfo";
            this.tabControlItemInfo.SelectedIndex = 0;
            this.tabControlItemInfo.Size = new System.Drawing.Size(276, 174);
            this.tabControlItemInfo.TabIndex = 5;
            // 
            // tabMagicOptions
            // 
            this.tabMagicOptions.Controls.Add(this.listMagicOptions);
            this.tabMagicOptions.Location = new System.Drawing.Point(4, 29);
            this.tabMagicOptions.Name = "tabMagicOptions";
            this.tabMagicOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabMagicOptions.Size = new System.Drawing.Size(268, 141);
            this.tabMagicOptions.TabIndex = 0;
            this.tabMagicOptions.Text = "Magic options";
            this.tabMagicOptions.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(268, 123);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Attributes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // enhanceSettingsView
            // 
            this.enhanceSettingsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enhanceSettingsView.Enabled = false;
            this.enhanceSettingsView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enhanceSettingsView.Location = new System.Drawing.Point(3, 43);
            this.enhanceSettingsView.Name = "enhanceSettingsView";
            this.enhanceSettingsView.Size = new System.Drawing.Size(432, 260);
            this.enhanceSettingsView.TabIndex = 3;
            this.enhanceSettingsView.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Item:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlItemInfo);
            this.Controls.Add(this.groupSettings);
            this.Controls.Add(this.lvLog);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCopyright);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Main";
            this.Size = new System.Drawing.Size(765, 505);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupSettings.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControlItemInfo.ResumeLayout(false);
            this.tabMagicOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label linkRefreshItemList;
        private System.Windows.Forms.ComboBox comboItem;
        private System.Windows.Forms.RadioButton radioMagicOptions;
        private System.Windows.Forms.RadioButton radioAttribute;
        private System.Windows.Forms.RadioButton radioEnhance;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader colItem;
        private System.Windows.Forms.ColumnHeader colSuccess;
        private System.Windows.Forms.ColumnHeader colResult;
        private System.Windows.Forms.GroupBox groupSettings;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDegree;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblEnhancement;
        private System.Windows.Forms.ListBox listMagicOptions;
        private System.Windows.Forms.Label lblCopyright;
        private LuckAlchemyBot.Views.Settings.EnhanceSettingsView enhanceSettingsView;
        private RSBot.Theme.Controls.TabControl tabControlItemInfo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabMagicOptions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}
