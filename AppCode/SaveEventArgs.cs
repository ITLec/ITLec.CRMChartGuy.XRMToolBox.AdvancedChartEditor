using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLecChartGuy.AdvancedChartEditor.AppCode
{
    public class SaveEventArgs : EventArgs
    {
        public Dictionary<string, ITLec.CRMChartGuy.Property> AttributeCollection { get; set; }
    }
}
