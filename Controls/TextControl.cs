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
    public partial class TextControl : BaseChartControl//UserControl// 
    {
        public TextControl()
        {
            InitializeComponent();

            FillControls();
            //if (!string.IsNullOrEmpty(base.InitValue))
            //{
            //    SetValue(base.InitValue);
            //}

            //InitValue = Value;
        }

        protected override void FillControls()
        {
        }


        protected override string GetValue()
        {
            string str = txtText.Text;
            return str;
        }

        protected override void SetValue(string val)
        {
            if (!string.IsNullOrEmpty(val))
            {
                txtText.Text = val;
            }
        }


        protected override void SetLabel(string label)
        {
            lblLabel.Text = label;
        }
        protected override string GetLabel()
        {
            return lblLabel.Text;
        }
    }
}
