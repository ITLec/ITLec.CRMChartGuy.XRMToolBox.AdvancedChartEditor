﻿using System;
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
    public partial class EnumControl : BaseChartControl//UserControl//
    {
        string currentNodeName;
        string _enumType;
        public EnumControl(string enumType)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(enumType))
            {
                string[] strs = enumType.Split(':');
                if (strs.Count() > 0)
                {
                    currentNodeName = strs[0];
                    _enumType = strs[1];
                }
            }

            FillControls();
        }

        Dictionary<string, string> EnumItems = new Dictionary<string, string>();
        protected override void FillControls()
        {
            EnumItems =
                                 ITLec.CRMChartGuy.AppCode.EnumHelper.GetCustomEnumItems(_enumType);
            ITLec.CRMChartGuy.AppCode.Common.FillComboBox(cmbEnum, EnumItems);

            SetCustomProperties();
        }

        private void SetCustomProperties()
        {
            //   throw new NotImplementedException();


            var _chart = ITLec.CRMChartGuy.AppCode.Common.ChartStructure;

            var section = _chart.Sections.Where(e => e.Name.ToLower() == currentNodeName.ToLower()).FirstOrDefault();

            if (section != null && section.Properties.Count > 0)
            {
                var property = section.Properties.Where(e => e.Name.ToLower() == _enumType.ToLower()).FirstOrDefault();

                if (property != null && property.CustomProperties.Count > 0)
                {
                    var customProperty = property.CustomProperties.Where(e => e.PropertyValue.ToLower() == cmbEnum.Text.ToLower()).FirstOrDefault();

                    if (customProperty != null && customProperty.Properties.Count > 0)
                    {
                        var dd = customProperty.Properties;
                        //TODO: Display Controls
                    }
                }
            }
        }

        protected override string GetLabel()
        {

            string str = lblEnum.Text;
            return str;
        }

        protected override string GetValue()
        {
            string str = cmbEnum.Text;
            return str;
        }

        protected override void SetLabel(string label)
        {
            lblEnum.Text = label;
        }

        protected override void SetValue(string val)
        {
            if (!string.IsNullOrEmpty(val))
            {

                if (!EnumItems.ContainsKey(val))
                {
                    EnumItems.Add(val, val);
                    ITLec.CRMChartGuy.AppCode.Common.FillComboBox(cmbEnum, EnumItems);
                }

                cmbEnum.Text = val;

                // cmbEnum.high
                //    cmbEnum.BeginInvoke(new Action(() => cmbEnum.SelectionLength = 0));
                //     cmbEnum.BeginInvoke(new Action(() => { cmbEnum.Select(0, 0); }));
                //lblEnum.Focus();
            }
        }

        private void cmbEnum_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCustomProperties();
        }

        private void EnumControl_Paint(object sender, PaintEventArgs e)
        {

            cmbEnum.SelectionLength = 0;
        }
    }
}
