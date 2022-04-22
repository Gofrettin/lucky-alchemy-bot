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
            this.lblOptLevel = new System.Windows.Forms.Label();
            this.comboItem = new System.Windows.Forms.ComboBox();
            this.lblOptLevelText = new System.Windows.Forms.Label();
            this.lblItemSelection = new System.Windows.Forms.Label();
            this.lblDegree = new System.Windows.Forms.Label();
            this.lblDegreeText = new System.Windows.Forms.Label();
            this.linkRefreshItemList = new System.Windows.Forms.Label();
            this.lvLog = new System.Windows.Forms.ListView();
            this.colItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSuccess = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCopyright = new System.Windows.Forms.Label();
            this.tabControlItemInfo = new RSBot.Theme.Controls.TabControl();
            this.tabMagicOptions = new System.Windows.Forms.TabPage();
            this.listMagicOptions = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblUnsupported = new System.Windows.Forms.Label();
            this.listAttributes = new System.Windows.Forms.ListBox();
            this.linkGithub = new System.Windows.Forms.LinkLabel();
            this.panelSettingsGroup = new System.Windows.Forms.Panel();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioMagicOptions = new System.Windows.Forms.RadioButton();
            this.radioEnhance = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.tabControlItemInfo.SuspendLayout();
            this.tabMagicOptions.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panelSettingsGroup.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblOptLevel);
            this.groupBox1.Controls.Add(this.comboItem);
            this.groupBox1.Controls.Add(this.lblOptLevelText);
            this.groupBox1.Controls.Add(this.lblItemSelection);
            this.groupBox1.Controls.Add(this.lblDegree);
            this.groupBox1.Controls.Add(this.lblDegreeText);
            this.groupBox1.Controls.Add(this.linkRefreshItemList);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item selection";
            // 
            // lblOptLevel
            // 
            this.lblOptLevel.AutoSize = true;
            this.lblOptLevel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptLevel.Location = new System.Drawing.Point(101, 88);
            this.lblOptLevel.Name = "lblOptLevel";
            this.lblOptLevel.Size = new System.Drawing.Size(108, 13);
            this.lblOptLevel.TabIndex = 1;
            this.lblOptLevel.Text = "<no item selected>";
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
            // lblOptLevelText
            // 
            this.lblOptLevelText.AutoSize = true;
            this.lblOptLevelText.Location = new System.Drawing.Point(15, 88);
            this.lblOptLevelText.Name = "lblOptLevelText";
            this.lblOptLevelText.Size = new System.Drawing.Size(80, 13);
            this.lblOptLevelText.TabIndex = 0;
            this.lblOptLevelText.Text = "&Enhancement:";
            // 
            // lblItemSelection
            // 
            this.lblItemSelection.AutoSize = true;
            this.lblItemSelection.Location = new System.Drawing.Point(15, 25);
            this.lblItemSelection.Name = "lblItemSelection";
            this.lblItemSelection.Size = new System.Drawing.Size(32, 13);
            this.lblItemSelection.TabIndex = 3;
            this.lblItemSelection.Text = "Item:";
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
            // lblDegreeText
            // 
            this.lblDegreeText.AutoSize = true;
            this.lblDegreeText.Location = new System.Drawing.Point(15, 65);
            this.lblDegreeText.Name = "lblDegreeText";
            this.lblDegreeText.Size = new System.Drawing.Size(47, 13);
            this.lblDegreeText.TabIndex = 0;
            this.lblDegreeText.Text = "&Degree:";
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
            this.colSuccess.Width = 109;
            // 
            // colResult
            // 
            this.colResult.Text = "Result";
            this.colResult.Width = 383;
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
            this.tabMagicOptions.Location = new System.Drawing.Point(4, 25);
            this.tabMagicOptions.Name = "tabMagicOptions";
            this.tabMagicOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabMagicOptions.Size = new System.Drawing.Size(268, 145);
            this.tabMagicOptions.TabIndex = 0;
            this.tabMagicOptions.Text = "Magic options";
            this.tabMagicOptions.UseVisualStyleBackColor = true;
            // 
            // listMagicOptions
            // 
            this.listMagicOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMagicOptions.FormattingEnabled = true;
            this.listMagicOptions.Location = new System.Drawing.Point(3, 3);
            this.listMagicOptions.Name = "listMagicOptions";
            this.listMagicOptions.Size = new System.Drawing.Size(262, 139);
            this.listMagicOptions.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblUnsupported);
            this.tabPage2.Controls.Add(this.listAttributes);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(268, 145);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Attributes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblUnsupported
            // 
            this.lblUnsupported.AutoSize = true;
            this.lblUnsupported.Location = new System.Drawing.Point(56, 66);
            this.lblUnsupported.Name = "lblUnsupported";
            this.lblUnsupported.Size = new System.Drawing.Size(157, 13);
            this.lblUnsupported.TabIndex = 4;
            this.lblUnsupported.Text = "This feature is not supported";
            // 
            // listAttributes
            // 
            this.listAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listAttributes.Enabled = false;
            this.listAttributes.FormattingEnabled = true;
            this.listAttributes.Location = new System.Drawing.Point(3, 3);
            this.listAttributes.Name = "listAttributes";
            this.listAttributes.Size = new System.Drawing.Size(262, 139);
            this.listAttributes.TabIndex = 3;
            // 
            // linkGithub
            // 
            this.linkGithub.AutoSize = true;
            this.linkGithub.Location = new System.Drawing.Point(704, 490);
            this.linkGithub.Name = "linkGithub";
            this.linkGithub.Size = new System.Drawing.Size(44, 13);
            this.linkGithub.TabIndex = 6;
            this.linkGithub.TabStop = true;
            this.linkGithub.Text = "GitHub";
            // 
            // panelSettingsGroup
            // 
            this.panelSettingsGroup.Controls.Add(this.panelSettings);
            this.panelSettingsGroup.Controls.Add(this.panel2);
            this.panelSettingsGroup.Location = new System.Drawing.Point(310, 12);
            this.panelSettingsGroup.Name = "panelSettingsGroup";
            this.panelSettingsGroup.Size = new System.Drawing.Size(438, 303);
            this.panelSettingsGroup.TabIndex = 7;
            // 
            // panelSettings
            // 
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSettings.Location = new System.Drawing.Point(0, 38);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(438, 265);
            this.panelSettings.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioMagicOptions);
            this.panel2.Controls.Add(this.radioEnhance);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(438, 38);
            this.panel2.TabIndex = 0;
            // 
            // radioMagicOptions
            // 
            this.radioMagicOptions.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioMagicOptions.AutoSize = true;
            this.radioMagicOptions.Location = new System.Drawing.Point(93, 7);
            this.radioMagicOptions.Name = "radioMagicOptions";
            this.radioMagicOptions.Size = new System.Drawing.Size(86, 23);
            this.radioMagicOptions.TabIndex = 1;
            this.radioMagicOptions.Text = "Mag. options";
            this.radioMagicOptions.UseVisualStyleBackColor = true;
            this.radioMagicOptions.CheckedChanged += new System.EventHandler(this.radioEngine_CheckedChanged);
            // 
            // radioEnhance
            // 
            this.radioEnhance.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioEnhance.AutoSize = true;
            this.radioEnhance.Checked = true;
            this.radioEnhance.Location = new System.Drawing.Point(9, 7);
            this.radioEnhance.Name = "radioEnhance";
            this.radioEnhance.Size = new System.Drawing.Size(78, 23);
            this.radioEnhance.TabIndex = 0;
            this.radioEnhance.TabStop = true;
            this.radioEnhance.Text = "Enhance (+)";
            this.radioEnhance.UseVisualStyleBackColor = true;
            this.radioEnhance.CheckedChanged += new System.EventHandler(this.radioEngine_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelSettingsGroup);
            this.Controls.Add(this.linkGithub);
            this.Controls.Add(this.tabControlItemInfo);
            this.Controls.Add(this.lvLog);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCopyright);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Main";
            this.Size = new System.Drawing.Size(765, 505);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControlItemInfo.ResumeLayout(false);
            this.tabMagicOptions.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panelSettingsGroup.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label linkRefreshItemList;
        private System.Windows.Forms.ComboBox comboItem;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader colItem;
        private System.Windows.Forms.ColumnHeader colSuccess;
        private System.Windows.Forms.ColumnHeader colResult;
        private System.Windows.Forms.Label lblOptLevelText;
        private System.Windows.Forms.Label lblDegree;
        private System.Windows.Forms.Label lblDegreeText;
        private System.Windows.Forms.Label lblOptLevel;
        private System.Windows.Forms.ListBox listMagicOptions;
        private System.Windows.Forms.Label lblCopyright;
        private RSBot.Theme.Controls.TabControl tabControlItemInfo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabMagicOptions;
        private System.Windows.Forms.Label lblItemSelection;
        private System.Windows.Forms.ListBox listAttributes;
        private System.Windows.Forms.Label lblUnsupported;
        private System.Windows.Forms.LinkLabel linkGithub;
        private System.Windows.Forms.Panel panelSettingsGroup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioEnhance;
        private System.Windows.Forms.RadioButton radioMagicOptions;
        private System.Windows.Forms.Panel panelSettings;
    }
}
