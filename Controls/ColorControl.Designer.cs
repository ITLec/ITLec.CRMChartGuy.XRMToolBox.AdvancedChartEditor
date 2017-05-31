namespace ITLecChartGuy.AdvancedChartEditor.Controls
{
    partial class ColorControl
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
            this.lblColorLLabel = new System.Windows.Forms.Label();
            this.colorDialogSelector = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelColor = new System.Windows.Forms.Panel();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.lblClickToSelectColor = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblColorLLabel
            // 
            this.lblColorLLabel.AutoSize = true;
            this.lblColorLLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblColorLLabel.Location = new System.Drawing.Point(3, 0);
            this.lblColorLLabel.Name = "lblColorLLabel";
            this.lblColorLLabel.Size = new System.Drawing.Size(232, 44);
            this.lblColorLLabel.TabIndex = 1;
            this.lblColorLLabel.Text = "Color";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblColorLLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelColor, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxColor, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(596, 44);
            this.tableLayoutPanel1.TabIndex = 90;
            // 
            // panelColor
            // 
            this.panelColor.Controls.Add(this.lblClickToSelectColor);
            this.panelColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelColor.Location = new System.Drawing.Point(241, 3);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(172, 38);
            this.panelColor.TabIndex = 3;
            this.panelColor.Click += new System.EventHandler(this.panelColor_Click);
            // 
            // textBoxColor
            // 
            this.textBoxColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxColor.Location = new System.Drawing.Point(419, 3);
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.Size = new System.Drawing.Size(174, 22);
            this.textBoxColor.TabIndex = 4;
            this.textBoxColor.TextChanged += new System.EventHandler(this.textBoxColor_TextChanged);
            // 
            // lblClickToSelectColor
            // 
            this.lblClickToSelectColor.AutoSize = true;
            this.lblClickToSelectColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClickToSelectColor.Location = new System.Drawing.Point(0, 0);
            this.lblClickToSelectColor.Name = "lblClickToSelectColor";
            this.lblClickToSelectColor.Size = new System.Drawing.Size(138, 17);
            this.lblClickToSelectColor.TabIndex = 0;
            this.lblClickToSelectColor.Text = "Click To Select Color";
            this.lblClickToSelectColor.Click += new System.EventHandler(this.lblClickToSelectColor_Click);
            // 
            // ColorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ColorControl";
            this.Size = new System.Drawing.Size(596, 44);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelColor.ResumeLayout(false);
            this.panelColor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblColorLLabel;
        private System.Windows.Forms.ColorDialog colorDialogSelector;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.TextBox textBoxColor;
        private System.Windows.Forms.Label lblClickToSelectColor;
    }
}
