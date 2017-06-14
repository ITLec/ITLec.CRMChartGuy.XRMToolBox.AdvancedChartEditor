namespace ITLecChartGuy.AdvancedChartEditor.Controls
{
    partial class FontControl
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
            this.groupBoxFont = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFontType = new System.Windows.Forms.Label();
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.comboBoxFontType = new System.Windows.Forms.ComboBox();
            this.lblFontSize = new System.Windows.Forms.Label();
            this.checkBoxIgnoreSaving = new System.Windows.Forms.CheckBox();
            this.groupBoxFont.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxFont
            // 
            this.groupBoxFont.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFont.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFont.Name = "groupBoxFont";
            this.groupBoxFont.Size = new System.Drawing.Size(608, 94);
            this.groupBoxFont.TabIndex = 0;
            this.groupBoxFont.TabStop = false;
            this.groupBoxFont.Text = "Font";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblFontType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownFontSize, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxFontType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFontSize, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxIgnoreSaving, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(602, 73);
            this.tableLayoutPanel1.TabIndex = 90;
            // 
            // lblFontType
            // 
            this.lblFontType.AutoSize = true;
            this.lblFontType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFontType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFontType.Location = new System.Drawing.Point(4, 0);
            this.lblFontType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFontType.Name = "lblFontType";
            this.lblFontType.Size = new System.Drawing.Size(172, 36);
            this.lblFontType.TabIndex = 85;
            this.lblFontType.Text = "Font Type";
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.DecimalPlaces = 1;
            this.numericUpDownFontSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownFontSize.ForeColor = System.Drawing.SystemColors.Window;
            this.numericUpDownFontSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownFontSize.Location = new System.Drawing.Point(183, 39);
            this.numericUpDownFontSize.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(295, 22);
            this.numericUpDownFontSize.TabIndex = 88;
            this.numericUpDownFontSize.ValueChanged += new System.EventHandler(this.numericUpDownFontSize_ValueChanged);
            // 
            // comboBoxFontType
            // 
            this.comboBoxFontType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxFontType.FormattingEnabled = true;
            this.comboBoxFontType.Location = new System.Drawing.Point(183, 3);
            this.comboBoxFontType.Name = "comboBoxFontType";
            this.comboBoxFontType.Size = new System.Drawing.Size(295, 24);
            this.comboBoxFontType.TabIndex = 86;
            this.comboBoxFontType.SelectedIndexChanged += new System.EventHandler(this.comboBoxFontType_SelectedIndexChanged);
            // 
            // lblFontSize
            // 
            this.lblFontSize.AutoSize = true;
            this.lblFontSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFontSize.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFontSize.Location = new System.Drawing.Point(4, 36);
            this.lblFontSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFontSize.Name = "lblFontSize";
            this.lblFontSize.Size = new System.Drawing.Size(172, 37);
            this.lblFontSize.TabIndex = 87;
            this.lblFontSize.Text = "Font Size (px)";
            // 
            // checkBoxIgnoreSaving
            // 
            this.checkBoxIgnoreSaving.AutoSize = true;
            this.checkBoxIgnoreSaving.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxIgnoreSaving.Location = new System.Drawing.Point(484, 3);
            this.checkBoxIgnoreSaving.Name = "checkBoxIgnoreSaving";
            this.checkBoxIgnoreSaving.Size = new System.Drawing.Size(115, 30);
            this.checkBoxIgnoreSaving.TabIndex = 89;
            this.checkBoxIgnoreSaving.Text = "Remove";
            this.checkBoxIgnoreSaving.UseVisualStyleBackColor = true;
            this.checkBoxIgnoreSaving.Visible = false;
            // 
            // FontControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxFont);
            this.Name = "FontControl";
            this.Size = new System.Drawing.Size(608, 94);
            this.groupBoxFont.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFont;
        private System.Windows.Forms.ComboBox comboBoxFontType;
        private System.Windows.Forms.Label lblFontType;
        private System.Windows.Forms.NumericUpDown numericUpDownFontSize;
        private System.Windows.Forms.Label lblFontSize;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxIgnoreSaving;
    }
}
