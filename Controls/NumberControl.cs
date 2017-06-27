using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITLecChartGuy.AdvancedChartEditor.Controls
{
    public partial class NumberControl : BaseChartControl//  UserControl//
    {
        public NumberControl()
        {
            InitializeComponent();

            //if (!string.IsNullOrEmpty(base.InitValue))
            //{
            //    SetValue(base.InitValue);
            //}

            //InitValue = Value;
        }

        protected override void FillControls()
        {

        }

        protected override string GetLabel()
        {
            return lblNumber.Text;
        }

        protected override string GetValue()
        {
           return numericUpDownNumber.Value.ToString();
        }

        protected override void SetLabel(string label)
        {
            lblNumber.Text = label;
        }

        protected override void SetValue(string val)
        {
            if (!string.IsNullOrEmpty(val))
            {
                checkBoxIgnoreSaving.Visible = true;
                decimal _val = 0;
                if (decimal.TryParse(val, out _val))
                {
            numericUpDownNumber.ForeColor = Color.Black;
                numericUpDownNumber.Value = _val;
                }

            }
        }

        protected override bool GetIsIgnoreSave()
        {
            return checkBoxIgnoreSaving.Checked ||  (numericUpDownNumber.ForeColor != Color.Black);
        }
        private void numericUpDownNumber_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownNumber.ForeColor = Color.Black;
            checkBoxIgnoreSaving.Visible = true;
        }

        protected override void SetDesc(string desc)
        {
            if (!string.IsNullOrEmpty(desc))
            {
                panelHelp.Visible = true;
                ControlToolTip.SetToolTip(lblNumber, desc);
                ControlToolTip.SetToolTip(panelHelp, desc);

            }
        }


        private void panelHelp_Click(object sender, EventArgs e)
        {
            ControlToolTip.Show(this.Desc, panelHelp);
        }
    }
}
