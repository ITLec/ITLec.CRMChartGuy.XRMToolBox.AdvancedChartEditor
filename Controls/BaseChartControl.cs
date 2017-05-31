using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITLecChartGuy.AdvancedChartEditor.Controls
{
    public abstract class BaseChartControl : UserControl
    {

       public  BaseChartControl()
        {
          //  IsNull = true;
        }
        public string InitValue = "";

        /*
        public bool IsNull
        {
            get
            {
                bool isNull = false;

                if(Value != InitValue)
                {
                    isNull = true;
                }
                return isNull;
            }
        }*/

        public string Value
        {
            get
            {
                return GetValue();
            }
            set
            {
                SetValue(value);
            }
        }

        public string Key;

        public string Label
        {
            get
            {
                return GetLabel();
            }
            set
            {
                SetLabel(value);
            }
        }

        public bool? IsValueChanged { get;  set; }

        protected abstract string GetValue();
        
        protected abstract void SetValue(string val);

        protected abstract void SetLabel(string label);
        protected abstract string GetLabel();
        protected abstract void FillControls();
    }
}
