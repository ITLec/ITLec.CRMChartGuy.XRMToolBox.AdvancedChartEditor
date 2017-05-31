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
    public partial class NumberControl :  BaseChartControl//UserControl// 
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
                decimal _val = 0;
                if (decimal.TryParse(val, out _val))
                {
                }

                numericUpDownNumber.Value = _val;
            }
        }
    }
}
