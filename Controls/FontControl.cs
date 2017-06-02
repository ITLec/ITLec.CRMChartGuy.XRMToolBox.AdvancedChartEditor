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
    public partial class FontControl : BaseChartControl//UserControl//
    {
        

        public FontControl() 
        {
            
            InitializeComponent();

            FillControls();

            //if (!string.IsNullOrEmpty(base.InitValue))
            //{
            //    SetValue(base.InitValue);
            //}

            //InitValue = Value;
        }

        Dictionary<string, string> FontTypes = new Dictionary<string, string>();
        protected override void FillControls()
        {
            FontTypes = ITLec.CRMChartGuy.AppCode.EnumHelper.GetCustomEnumItems("Font");
            ITLec.CRMChartGuy.AppCode.Common.FillComboBox(comboBoxFontType, FontTypes);
        }

        protected override string GetValue()
        {
            string fontType = comboBoxFontType.Text;

            if(string.IsNullOrEmpty(fontType) )
            {
                return "";
            }

            string val = string.Format("{0}, {1}px", fontType, numericUpDownFontSize.Value.ToString());
            return val;
        }

       protected override void SetValue(string val)
        {

            if (!string.IsNullOrEmpty(val))
            {
                checkBoxIgnoreSaving.Visible = true;

                string[] strs = val.Split(',');

                if (!FontTypes.ContainsKey(strs[0]))
                {
                    FontTypes.Add(strs[0], strs[0]);
                    comboBoxFontType.DataSource = new BindingSource(FontTypes, null);
                }

                comboBoxFontType.Text = strs[0];

                if (!string.IsNullOrEmpty(strs[1]))
                {
                    numericUpDownFontSize.Value = decimal.Parse(strs[1].Replace("px", ""));
                    numericUpDownFontSize.ForeColor = Color.Black;
                }

            }
        }

        protected override bool GetIsIgnoreSave()
        {
            return checkBoxIgnoreSaving.Checked;
        }

        protected override void SetLabel(string label)
        {
            groupBoxFont.Text = label;
        }
        protected override string GetLabel()
        {
            return groupBoxFont.Text;
        }

        private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownFontSize.ForeColor = Color.Black;

            checkBoxIgnoreSaving.Visible = true;
        }

        private void comboBoxFontType_SelectedIndexChanged(object sender, EventArgs e)
        {

            checkBoxIgnoreSaving.Visible = true;
        }
    }
}
