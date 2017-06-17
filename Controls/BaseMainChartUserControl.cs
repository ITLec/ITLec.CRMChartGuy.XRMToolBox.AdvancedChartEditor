using ITLec.CRMChartGuy;
using ITLecChartGuy.AdvancedChartEditor.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITLecChartGuy.AdvancedChartEditor.Controls
{
public  class BaseMainChartUserControl :  UserControl
    {

        public string NodeName;


        public  event Action<object, SaveEventArgs> Saving;

        protected virtual void OnSaving(object sender, SaveEventArgs arg)
        {
            Saving?.Invoke(sender, arg);
        }

        public Dictionary<string, BaseChartControl> DictionaryKeyControl = new Dictionary<string, BaseChartControl>();


        public void AddDictionaryKeyControl(BaseChartControl obj, string key, string val, string label = "")
        {

            obj.Key = key;
            obj.Value = val;
            obj.InitValue = obj.Value;

            obj.Label = (label != "") ? label : key;

            DictionaryKeyControl.Add(key, obj);

        }

        public void AddDictionaryKeyControl(string type, string key, Dictionary<string, string> collec, string label = "")
        {
            var val = collec.ContainsKey(key) ? collec[key] : "";

            AddDictionaryKeyControl(type, key, val, label);
        }

        public void AddDictionaryKeyControl(Property property, Dictionary<string, string> collec, string label = "")
        {

            var val = property.DefaultValue;
            
            if (collec.ContainsKey(property.Name) 
                    && !string.IsNullOrEmpty(collec[property.Name]))
            {
                val = collec[property.Name];
            }

            AddDictionaryKeyControl(property.Type, property.Name, val, label);
        }
        public void AddDictionaryKeyControl(string type,string key, string val, string label = "")
        {

            if (!DictionaryKeyControl.ContainsKey(key))
            {

                BaseChartControl obj = null;
                string[] strs = type.ToLower().Split(':');
                switch (strs[0])
                {
                    case PropertyType.TEXT:
                        obj = new TextControl();
                        break;
                    case PropertyType.NUMBER:
                        obj = new NumberControl();
                        break;
                    case PropertyType.COLOR:
                        obj = new ColorControl();
                        break;
                    case PropertyType.FONT:
                        obj = new FontControl();
                        break;
                    case PropertyType.ENUM:
                        obj = new EnumControl(NodeName + ":" + strs[1]);
                        break;

                    default:
                        obj = new TextControl();
                        break;
                }

                AddDictionaryKeyControl(obj, key, val, label);
            }

        }

    }
}
