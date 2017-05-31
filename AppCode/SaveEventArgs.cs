using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLecChartGuy.AdvancedChartEditor.AppCode
{
    public class SaveEventArgs : EventArgs
    {
        public Dictionary<string, string> AttributeCollection { get; set; }
    }
}
