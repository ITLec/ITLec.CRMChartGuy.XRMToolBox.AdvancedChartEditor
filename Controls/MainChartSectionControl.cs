using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITLec.CRMChartGuy.AppCode;
using ITLecChartGuy.AdvancedChartEditor.AppCode;
using ITLec.CRMChartGuy;
using ITLecChartGuy.AdvancedChartEditor.Forms;

namespace ITLecChartGuy.AdvancedChartEditor.Controls
{
    public partial class MainChartSectionControl : BaseMainChartUserControl, IChartSavable
    {
        private readonly Dictionary<string, string> collec;

        public MainChartSectionControl()
        {
            InitializeComponent();
            collec = new Dictionary<string, string>();
        }

        public MainChartSectionControl(Dictionary<string, string> collection)
            : this()
        {
            if (collection != null)
                collec = collection;

            FillControls();
        }

        public MainChartSectionControl(string nodeName, Dictionary<string, string> collec)
            : this()
        {
            this.NodeName = nodeName;
            this.collec = collec;

            FillControls();
        }

        private void FillControls()
        {

            var _chart = ITLec.CRMChartGuy.AppCode.Common.ChartStructure;
            Section section = null;
            if (NodeName == "Series.Series.CustomProperties")
            {
                section = _chart.Sections.Where(e => e.Name == "Series.Series.CustomProperties."+ChartEditorHelper.ChartType).FirstOrDefault();
            }
            else
            {
                 section = _chart.Sections.Where(e => e.Name == NodeName).FirstOrDefault();
            }


            if (section != null && section.Properties.Count > 0)
            {
                foreach (var property in section.Properties)
                {
                    AddDictionaryKeyControl(property, collec);
                }
            }

            foreach (var item in collec)
            {
                AddDictionaryKeyControl(Common.DetectChartElementType(item.Key, item.Value), item.Key, item.Value);
            }

            int x = 0;
            foreach (var item in DictionaryKeyControl.Values)
            {
                item.Location = new Point(0, x);
                x = x + 50;
                panelMain.Height = panelMain.Height + 50;
                item.Dock = DockStyle.Top;
                panelMain.Controls.Add(item);
            }

        }



        public bool Save()
        {

            Dictionary<string, string> collection = new Dictionary<string, string>();

            foreach (var dic in DictionaryKeyControl)
            {
                if (
                    
                  (  collec.Keys.Contains(dic.Key) ||
                    (!string.IsNullOrEmpty(dic.Value.Value) &&

                    dic.Value.Value != dic.Value.InitValue)) &&

                   ! dic.Value.IsIgnoreSave
                    )
                {
                    collection.Add(dic.Key, dic.Value.Value);
                }
            }

            SendSaveMessage(collection);
            return true;
        }


        #region Send Events

        private void SendSaveMessage(Dictionary<string, string> collection)
        {
            SaveEventArgs sea = new SaveEventArgs { AttributeCollection = collection };
            OnSaving(this, sea);
        }

        #endregion
    }
}
