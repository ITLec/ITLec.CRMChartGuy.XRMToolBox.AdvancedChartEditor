using ITLec.CRMChartGuy.AppCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ITLecChartGuy.AdvancedChartEditor.Forms
{
    public partial class ChartReviewForm : Form
    {
        public ChartReviewForm(string chartXml)
        {
            InitializeComponent();

            XmlDocument chartXmlDoc = new XmlDocument();
            chartXmlDoc.LoadXml(chartXml);


            XmlNode chartEditorXmlNode = chartXmlDoc.DocumentElement;

            
            foreach (XmlNode parentNode in chartEditorXmlNode.ChildNodes)
            {
                if (parentNode.Name.ToLower() == "series")
                {
                    foreach (XmlNode childtNode in parentNode.ChildNodes)
                    {
                        if (childtNode.Name.ToLower() == "series")
                        {


                            var pointsNode = chartXmlDoc.CreateElement("Points");

                            var dataPoint10 = chartXmlDoc.CreateElement("DataPoint");
                            dataPoint10.SetAttribute("XValue", "10");
                            dataPoint10.SetAttribute("YValues", "10,10");
                            pointsNode.AppendChild(dataPoint10);


                            var dataPoint20 = chartXmlDoc.CreateElement("DataPoint");
                            dataPoint20.SetAttribute("XValue", "20");
                            dataPoint20.SetAttribute("YValues", "20,20");
                            pointsNode.AppendChild(dataPoint20);



                            var dataPoint30 = chartXmlDoc.CreateElement("DataPoint");
                            dataPoint30.SetAttribute("XValue", "30");
                            dataPoint30.SetAttribute("YValues", "30,30");
                            pointsNode.AppendChild(dataPoint30);



                            var dataPoint40 = chartXmlDoc.CreateElement("DataPoint");
                            dataPoint40.SetAttribute("XValue", "40");
                            dataPoint40.SetAttribute("YValues", "40,40");
                            pointsNode.AppendChild(dataPoint40);


                            var dataPoint50 = chartXmlDoc.CreateElement("DataPoint");
                            dataPoint50.SetAttribute("XValue", "50");
                            dataPoint50.SetAttribute("YValues", "50,50");
                            pointsNode.AppendChild(dataPoint50);

                            childtNode.AppendChild(pointsNode);

                        }
                    }
                }
            }

            chartXmlDoc.Save(Common.TempChartXml);
        }

        private void ChartReviewForm_Load(object sender, EventArgs e)
        {

          //  string file = "E:\\DeleteMe\\chart.xml";
            //TODO chart1.DataSource
            chart1.Serializer.Load(Common.TempChartXml);
        //    ch.SaveImage(imageFile, ChartImageFormat.Png);
        }
    }
}
