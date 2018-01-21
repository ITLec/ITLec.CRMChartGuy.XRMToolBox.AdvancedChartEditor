using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITLec.CRMChartGuy.AppCode
{
    public  class Common
    {
        public static void FillComboBox(ComboBox comboBox, Dictionary<string, string> dictionary)
        {
            comboBox.DataSource = new BindingSource(dictionary, null);

          //todo:  if (dictionary.Count > 0)
            {
                comboBox.DisplayMember = "Value";
                comboBox.ValueMember = "Key";
            }
        }

        public static object DeserializeObj(string filePath, object obj)
        {
            object retObj = new object();
            if (System.IO.File.Exists(filePath))
            {
                var writer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
                var file = new System.IO.StreamReader(filePath);
                retObj = writer.Deserialize(file);
                file.Close();
            }
            return retObj;
        }

        private static ITLec.CRMChartGuy.Chart chartStructure = null;

        public static string ChartStructurePath
        {
            get
            {
                string pluginLocation = XrmToolBox.Extensibility.Paths.SettingsPath;

                return string.Format("{0}\\{1}", pluginLocation, "ChartStructure.xml");
            }
        }
        public static string TempChartXml
        {
            get
            {
                string pluginLocation = XrmToolBox.Extensibility.Paths.SettingsPath;

                return string.Format("{0}\\{1}", pluginLocation, "TempChartXml.xml");
            }
        }
        public static string TempChartImage
        {
            get
            {
                string pluginLocation = XrmToolBox.Extensibility.Paths.SettingsPath;

                return string.Format("{0}\\{1}", pluginLocation, "TempChartImage.png");
            }
        }

        public static ITLec.CRMChartGuy.Chart ChartStructure
        {
            get
            {
                //if(chartStructure == null)
                //{
                    chartStructure = (ITLec.CRMChartGuy.Chart)ITLec.CRMChartGuy.AppCode.Common.DeserializeObj(ChartStructurePath, new ITLec.CRMChartGuy.Chart());
                //}

                return chartStructure;
            }
        }

        public static string DetectChartElementType(string key, string value)
        {
            string retVal = PropertyType.TEXT;

            string _key = key.ToLower();
            string _value = value.ToLower();

            if(_key.Contains(PropertyType.COLOR) && ConvertStringToColor(value) != null)
            {
                retVal = PropertyType.COLOR;
            }
            else if (_key.Contains(PropertyType.FONT) & value.Contains("px"))
            {
                retVal = PropertyType.FONT;
            }
            return retVal;
        }

        public static System.Drawing.Color? ConvertStringToColor(string strColor)
        {
            System.Drawing.Color? color = null;


            try
            {
                string[] strs = strColor.Split(',');

                if (strs.Count() > 1)
                {

                    color = System.Drawing.Color.FromArgb(int.Parse(strs[0]), int.Parse(strs[1]), int.Parse(strs[2]));
                }
                else
                {
                    color = System.Drawing.Color.FromName(strColor);
                }
            }
            catch(Exception exce)
            {

            }

            return color;
        }

        public static string ShowDialog(string text, string caption, string defaultValue)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            textBox.Text = defaultValue;
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
