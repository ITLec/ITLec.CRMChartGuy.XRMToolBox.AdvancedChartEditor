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
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.lblFontType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownFontSize, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxFontType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFontSize, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
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
            this.lblFontType.Size = new System.Drawing.Size(232, 41);
            this.lblFontType.TabIndex = 85;
            this.lblFontType.Text = "Font Type";
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownFontSize.Location = new System.Drawing.Point(243, 44);
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(356, 22);
            this.numericUpDownFontSize.TabIndex = 88;
            // 
            // comboBoxFontType
            // 
            this.comboBoxFontType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxFontType.FormattingEnabled = true;
            this.comboBoxFontType.Location = new System.Drawing.Point(243, 3);
            this.comboBoxFontType.Name = "comboBoxFontType";
            this.comboBoxFontType.Size = new System.Drawing.Size(356, 24);
            this.comboBoxFontType.TabIndex = 86;
            // 
            // lblFontSize
            // 
            this.lblFontSize.AutoSize = true;
            this.lblFontSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFontSize.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFontSize.Location = new System.Drawing.Point(4, 41);
            this.lblFontSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFontSize.Name = "lblFontSize";
            this.lblFontSize.Size = new System.Drawing.Size(232, 32);
            this.lblFontSize.TabIndex = 87;
            this.lblFontSize.Text = "Font Size (px)";
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
    }
}
