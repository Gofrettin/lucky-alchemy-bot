namespace LuckAlchemyBot.Views.Settings
{
    partial class EnhanceSettingsView
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
            this.label1 = new System.Windows.Forms.Label();
            this.numMaxEnhancement = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.checkUseLuckyStones = new System.Windows.Forms.CheckBox();
            this.checkUseImmortalStones = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboElixir = new System.Windows.Forms.ComboBox();
            this.linkRefreshItemList = new System.Windows.Forms.Label();
            this.checkUseAstralStones = new System.Windows.Forms.CheckBox();
            this.lblLuckyCount = new System.Windows.Forms.Label();
            this.lblImmortalCount = new System.Windows.Forms.Label();
            this.lblAstralCount = new System.Windows.Forms.Label();
            this.checkUseSteadyStones = new System.Windows.Forms.CheckBox();
            this.lblSteadyStonesCount = new System.Windows.Forms.Label();
            this.lblLuckyPowderCount = new System.Windows.Forms.Label();
            this.checkStopLuckyPowder = new System.Windows.Forms.CheckBox();
            this.lblCurrentOptLevel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxEnhancement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Max enhancement:";
            // 
            // numMaxEnhancement
            // 
            this.numMaxEnhancement.Location = new System.Drawing.Point(140, 15);
            this.numMaxEnhancement.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMaxEnhancement.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxEnhancement.Name = "numMaxEnhancement";
            this.numMaxEnhancement.Size = new System.Drawing.Size(54, 22);
            this.numMaxEnhancement.TabIndex = 1;
            this.numMaxEnhancement.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxEnhancement.ValueChanged += new System.EventHandler(this.config_CheckedChange);
            this.numMaxEnhancement.Validated += new System.EventHandler(this.config_CheckedChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "+";
            // 
            // checkUseLuckyStones
            // 
            this.checkUseLuckyStones.AutoSize = true;
            this.checkUseLuckyStones.Location = new System.Drawing.Point(141, 113);
            this.checkUseLuckyStones.Name = "checkUseLuckyStones";
            this.checkUseLuckyStones.Size = new System.Drawing.Size(111, 17);
            this.checkUseLuckyStones.TabIndex = 3;
            this.checkUseLuckyStones.Text = "Use lucky stones";
            this.checkUseLuckyStones.UseVisualStyleBackColor = true;
            this.checkUseLuckyStones.CheckedChanged += new System.EventHandler(this.config_CheckedChange);
            // 
            // checkUseImmortalStones
            // 
            this.checkUseImmortalStones.AutoSize = true;
            this.checkUseImmortalStones.Location = new System.Drawing.Point(141, 136);
            this.checkUseImmortalStones.Name = "checkUseImmortalStones";
            this.checkUseImmortalStones.Size = new System.Drawing.Size(130, 17);
            this.checkUseImmortalStones.TabIndex = 4;
            this.checkUseImmortalStones.Text = "Use immortal stones";
            this.checkUseImmortalStones.UseVisualStyleBackColor = true;
            this.checkUseImmortalStones.CheckedChanged += new System.EventHandler(this.config_CheckedChange);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Elixir:";
            // 
            // comboElixir
            // 
            this.comboElixir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboElixir.FormattingEnabled = true;
            this.comboElixir.Location = new System.Drawing.Point(140, 50);
            this.comboElixir.Name = "comboElixir";
            this.comboElixir.Size = new System.Drawing.Size(193, 21);
            this.comboElixir.TabIndex = 6;
            this.comboElixir.SelectedIndexChanged += new System.EventHandler(this.config_CheckedChange);
            // 
            // linkRefreshItemList
            // 
            this.linkRefreshItemList.AutoSize = true;
            this.linkRefreshItemList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkRefreshItemList.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkRefreshItemList.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.linkRefreshItemList.Location = new System.Drawing.Point(328, 43);
            this.linkRefreshItemList.Name = "linkRefreshItemList";
            this.linkRefreshItemList.Size = new System.Drawing.Size(34, 30);
            this.linkRefreshItemList.TabIndex = 7;
            this.linkRefreshItemList.Text = "🗘";
            this.linkRefreshItemList.Click += new System.EventHandler(this.linkRefreshItemList_Click);
            // 
            // checkUseAstralStones
            // 
            this.checkUseAstralStones.AutoSize = true;
            this.checkUseAstralStones.Location = new System.Drawing.Point(141, 159);
            this.checkUseAstralStones.Name = "checkUseAstralStones";
            this.checkUseAstralStones.Size = new System.Drawing.Size(113, 17);
            this.checkUseAstralStones.TabIndex = 8;
            this.checkUseAstralStones.Text = "Use astral stones";
            this.checkUseAstralStones.UseVisualStyleBackColor = true;
            this.checkUseAstralStones.CheckedChanged += new System.EventHandler(this.config_CheckedChange);
            // 
            // lblLuckyCount
            // 
            this.lblLuckyCount.AutoSize = true;
            this.lblLuckyCount.Location = new System.Drawing.Point(288, 114);
            this.lblLuckyCount.Name = "lblLuckyCount";
            this.lblLuckyCount.Size = new System.Drawing.Size(18, 13);
            this.lblLuckyCount.TabIndex = 9;
            this.lblLuckyCount.Text = "x0";
            // 
            // lblImmortalCount
            // 
            this.lblImmortalCount.AutoSize = true;
            this.lblImmortalCount.Location = new System.Drawing.Point(288, 137);
            this.lblImmortalCount.Name = "lblImmortalCount";
            this.lblImmortalCount.Size = new System.Drawing.Size(18, 13);
            this.lblImmortalCount.TabIndex = 9;
            this.lblImmortalCount.Text = "x0";
            // 
            // lblAstralCount
            // 
            this.lblAstralCount.AutoSize = true;
            this.lblAstralCount.Location = new System.Drawing.Point(288, 160);
            this.lblAstralCount.Name = "lblAstralCount";
            this.lblAstralCount.Size = new System.Drawing.Size(18, 13);
            this.lblAstralCount.TabIndex = 9;
            this.lblAstralCount.Text = "x0";
            // 
            // checkUseSteadyStones
            // 
            this.checkUseSteadyStones.AutoSize = true;
            this.checkUseSteadyStones.Location = new System.Drawing.Point(141, 182);
            this.checkUseSteadyStones.Name = "checkUseSteadyStones";
            this.checkUseSteadyStones.Size = new System.Drawing.Size(118, 17);
            this.checkUseSteadyStones.TabIndex = 8;
            this.checkUseSteadyStones.Text = "Use steady stones";
            this.checkUseSteadyStones.UseVisualStyleBackColor = true;
            this.checkUseSteadyStones.CheckedChanged += new System.EventHandler(this.config_CheckedChange);
            // 
            // lblSteadyStonesCount
            // 
            this.lblSteadyStonesCount.AutoSize = true;
            this.lblSteadyStonesCount.Location = new System.Drawing.Point(288, 183);
            this.lblSteadyStonesCount.Name = "lblSteadyStonesCount";
            this.lblSteadyStonesCount.Size = new System.Drawing.Size(18, 13);
            this.lblSteadyStonesCount.TabIndex = 9;
            this.lblSteadyStonesCount.Text = "x0";
            // 
            // lblLuckyPowderCount
            // 
            this.lblLuckyPowderCount.AutoSize = true;
            this.lblLuckyPowderCount.Location = new System.Drawing.Point(288, 91);
            this.lblLuckyPowderCount.Name = "lblLuckyPowderCount";
            this.lblLuckyPowderCount.Size = new System.Drawing.Size(18, 13);
            this.lblLuckyPowderCount.TabIndex = 11;
            this.lblLuckyPowderCount.Text = "x0";
            // 
            // checkStopLuckyPowder
            // 
            this.checkStopLuckyPowder.AutoSize = true;
            this.checkStopLuckyPowder.Checked = true;
            this.checkStopLuckyPowder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkStopLuckyPowder.Location = new System.Drawing.Point(141, 90);
            this.checkStopLuckyPowder.Name = "checkStopLuckyPowder";
            this.checkStopLuckyPowder.Size = new System.Drawing.Size(141, 17);
            this.checkStopLuckyPowder.TabIndex = 10;
            this.checkStopLuckyPowder.Text = "Stop if 0 lucky powder";
            this.checkStopLuckyPowder.UseVisualStyleBackColor = true;
            this.checkStopLuckyPowder.CheckedChanged += new System.EventHandler(this.config_CheckedChange);
            // 
            // lblCurrentOptLevel
            // 
            this.lblCurrentOptLevel.AutoSize = true;
            this.lblCurrentOptLevel.BackColor = System.Drawing.SystemColors.Control;
            this.lblCurrentOptLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentOptLevel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentOptLevel.Location = new System.Drawing.Point(200, 15);
            this.lblCurrentOptLevel.Name = "lblCurrentOptLevel";
            this.lblCurrentOptLevel.Size = new System.Drawing.Size(31, 22);
            this.lblCurrentOptLevel.TabIndex = 12;
            this.lblCurrentOptLevel.Text = "+0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LuckyAlchemyBot.Properties.Resources.plugin_icon;
            this.pictureBox1.Location = new System.Drawing.Point(188, 223);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // EnhanceSettingsView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblLuckyPowderCount);
            this.Controls.Add(this.checkStopLuckyPowder);
            this.Controls.Add(this.lblSteadyStonesCount);
            this.Controls.Add(this.lblAstralCount);
            this.Controls.Add(this.lblImmortalCount);
            this.Controls.Add(this.lblLuckyCount);
            this.Controls.Add(this.checkUseSteadyStones);
            this.Controls.Add(this.checkUseAstralStones);
            this.Controls.Add(this.comboElixir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkUseImmortalStones);
            this.Controls.Add(this.checkUseLuckyStones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numMaxEnhancement);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkRefreshItemList);
            this.Controls.Add(this.lblCurrentOptLevel);
            this.Enabled = false;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EnhanceSettingsView";
            this.Size = new System.Drawing.Size(438, 306);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxEnhancement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMaxEnhancement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkUseLuckyStones;
        private System.Windows.Forms.CheckBox checkUseImmortalStones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboElixir;
        private System.Windows.Forms.Label linkRefreshItemList;
        private System.Windows.Forms.CheckBox checkUseAstralStones;
        private System.Windows.Forms.Label lblLuckyCount;
        private System.Windows.Forms.Label lblImmortalCount;
        private System.Windows.Forms.Label lblAstralCount;
        private System.Windows.Forms.CheckBox checkUseSteadyStones;
        private System.Windows.Forms.Label lblSteadyStonesCount;
        private System.Windows.Forms.Label lblLuckyPowderCount;
        private System.Windows.Forms.CheckBox checkStopLuckyPowder;
        private System.Windows.Forms.Label lblCurrentOptLevel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
