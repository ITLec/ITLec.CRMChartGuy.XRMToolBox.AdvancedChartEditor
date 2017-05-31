using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLec.CRMChartGuy
{

    public class Chart
    {

        public List<Property> ChartProperties = new List<Property>();

        public List<Section> Sections = new List<Section>();

        public List<CustomEnum> CustomEnums = new List<CustomEnum>();


        public List<CustomProperties> CustomPropertiesSet = new List<CustomProperties>();
    }

    public class Section
    {
        public string Name
        {
            get;
            set;
        }
        public List<Property> Properties = new List<Property>();
    }
    public class CustomProperties
    {
        public string ChartType
        {
            get;
            set;
        }
        public List<Property> Properties = new List<Property>();
    }

    public class Property : PropertyHeader
    {

        public List<CustomProperty> CustomProperties = new List<CustomProperty>();
    }
    public class CustomProperty 
    {

        public string PropertyValue
        {
            get;
            set;
        }

        public List<Property> Properties = new List<Property>();
    }

    public class PropertyHeader
    {
        public string Name
        {
            get;
            set;
        }
        public string Type
        {
            get;
            set;
        }
        //public string PropertyTypeValue
        //{
        //    get;
        //    set;
        //}

        //public PropertyType PropertyType
        //{
        //    get;
        //    set;
        //}
        public string DefaultValue
        {
            get;
            set;
        }

    }


    public class CustomEnum
    {
        public string Name { get; set; }
        public List<EnumItem> EnumItems = new List<EnumItem>();
    }

    public class EnumItem
    {
        public string Name
        {
            get;
            set;
        }
    }

    public class PropertyType
    {
        public  const string   TEXT = "text";
        public  const string NUMBER = "number";
        public  const string COLOR = "color";
        public  const string FONT = "font";
        public const string ENUM = "enum";
    }

}
