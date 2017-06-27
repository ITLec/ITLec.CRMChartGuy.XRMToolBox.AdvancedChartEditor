using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using XrmToolBox.Extensibility;

namespace ITLecChartGuy.AdvancedChartEditor.Forms
{
    public partial class ChartEditor : Form
    {
        private Panel infoPanel;

        private readonly Entity chart;

        private readonly IOrganizationService service;

        public ChartEditor(Entity chart, IOrganizationService service)
        {
            InitializeComponent();
            this.chart = chart;
            this.service = service;
        }

        public bool HasUpdatedContent { get; private set; }

        private void ChartEditor_Load(object sender, EventArgs e)
        {
            txtName.Text = chart.GetAttributeValue<string>("name");
            txtDescription.Text = chart.GetAttributeValue<string>("description");
            tecDataDescription.Text = chart.GetAttributeValue<string>("datadescription");
            tecVisualizationDescription.Text = chart.GetAttributeValue<string>("presentationdescription");

            tecDataDescription.Text = IndentXmlString(tecDataDescription.Text);
            tecVisualizationDescription.Text = IndentXmlString(tecVisualizationDescription.Text);

            tecDataDescription.SetHighlighting("XML");
            tecVisualizationDescription.SetHighlighting("XML");
            
            Size = new Size(Size.Width + 1, Size.Height);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string IndentXmlString(string xml)
        {
            MemoryStream ms = new MemoryStream();
            XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.Unicode);
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.LoadXml(xml);

                xtw.Formatting = Formatting.Indented;
                doc.WriteContentTo(xtw);
                xtw.Flush();
                ms.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(ms);
                return sr.ReadToEnd();
            }
            catch (Exception error)
            {
                MessageBox.Show(string.Format("An error occured while identing XML: {0}", error));
                return null;
            }
        }


        private void btnlVisualEditor_Click(object sender, EventArgs e)
        {
            var pos = tecVisualizationDescription.ActiveTextAreaControl.Caret.Position;

            //  tecVisualizationDescription.ActiveTextAreaControl.TextArea.ge
            //  var dd = tecVisualizationDescription.Document.GetLineNumberForOffset(rr);

            tecVisualizationDescription.ActiveTextAreaControl.SelectionManager.SetSelection(new ICSharpCode.TextEditor.TextLocation(0, pos.Line), new ICSharpCode.TextEditor.TextLocation(1000000000, pos.Line));

            var str = tecVisualizationDescription.ActiveTextAreaControl.SelectionManager.SelectedText;

            str = tecVisualizationDescription.Text;
            var frm = new ChartEditorHelper(str);
           if ( frm.ShowDialog() ==  DialogResult.OK)
            {
                string chartXML = frm.ChartXML;

                if (!string.IsNullOrEmpty(chartXML))
                {
                    chartXML = ITLec.CRMChartGuy.AppCode.TreeNodeHelper.GetFormatedXML(chartXML);
                    tecVisualizationDescription.Text = chartXML;
                }
            }
        }

        private void btnUpdatePublish_Click(object sender, EventArgs e)
        {

            chart["name"] = txtName.Text;
            chart["description"] = txtDescription.Text;
            chart["datadescription"] = tecDataDescription.Text;
            chart["presentationdescription"] = tecVisualizationDescription.Text;


            infoPanel = InformationPanel.GetInformationPanel(this, "Updating chart...", 350, 150);

            var worker = new BackgroundWorker { WorkerReportsProgress = true };
            worker.DoWork += (w, evt) =>
            {
                service.Update((Entity)evt.Argument);

                ((BackgroundWorker)w).ReportProgress(0, "Publishing entity...");

                service.Execute(new PublishXmlRequest
                {
                    ParameterXml = string.Format("<importexportxml><entities><entity>{0}</entity></entities><nodes/><securityroles/><settings/><workflows/></importexportxml>", chart.GetAttributeValue<string>("primaryentitytypecode"))
                });
            };
            worker.ProgressChanged += (w, evt) =>
            {
                InformationPanel.ChangeInformationPanelMessage(infoPanel, evt.UserState.ToString());
            };
            worker.RunWorkerCompleted += (w, evt) =>
            {
                if (evt.Error != null)
                {
                    MessageBox.Show(this, evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    HasUpdatedContent = true;
                }

                Controls.Remove(infoPanel);
                infoPanel.Dispose();
            };
            worker.RunWorkerAsync(chart);
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            chart["name"] = txtName.Text;
            chart["description"] = txtDescription.Text;
            chart["datadescription"] = tecDataDescription.Text;
            chart["presentationdescription"] = tecVisualizationDescription.Text;


            infoPanel = InformationPanel.GetInformationPanel(this, "Updating chart...", 350, 150);

            var worker = new BackgroundWorker { WorkerReportsProgress = true };
            worker.DoWork += (w, evt) =>
            {
                service.Update((Entity)evt.Argument);
            };
            worker.ProgressChanged += (w, evt) =>
            {
                InformationPanel.ChangeInformationPanelMessage(infoPanel, evt.UserState.ToString());
            };
            worker.RunWorkerCompleted += (w, evt) =>
            {
                if (evt.Error != null)
                {
                    MessageBox.Show(this, evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    HasUpdatedContent = true;
                }

                Controls.Remove(infoPanel);
                infoPanel.Dispose();
            };
            worker.RunWorkerAsync(chart);
        }

        private void buttonSaveAs_Click(object sender, EventArgs e)
        {




            Entity newchart = chart;
            string newChartName = ITLec.CRMChartGuy.AppCode.Common.ShowDialog("New Chart Name:", "Chart Name", txtName.Text+" - COPY");

            if (!string.IsNullOrEmpty(newChartName))
            {
                newchart["name"] = newChartName;
                newchart["description"] = txtDescription.Text;
                newchart["datadescription"] = tecDataDescription.Text;
                newchart["presentationdescription"] = tecVisualizationDescription.Text;

                newchart.Id = Guid.NewGuid();

                if (newchart.Attributes.Contains("savedqueryvisualizationid"))
                {
                    newchart["savedqueryvisualizationid"] = newchart.Id;
                }
                else
                {
                    newchart["userqueryvisualizationid"] = newchart.Id;
                }

                infoPanel = InformationPanel.GetInformationPanel(this, "Save As chart...", 350, 150);

                var worker = new BackgroundWorker { WorkerReportsProgress = true };
                worker.DoWork += (w, evt) =>
                {
                    service.Create((Entity)evt.Argument);
                };
                worker.ProgressChanged += (w, evt) =>
                {
                    InformationPanel.ChangeInformationPanelMessage(infoPanel, evt.UserState.ToString());
                };
                worker.RunWorkerCompleted += (w, evt) =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        HasUpdatedContent = true;
                    }

                    Controls.Remove(infoPanel);
                    infoPanel.Dispose();
                    this.Close();
                };
                worker.RunWorkerAsync(newchart);
            }
        }

        private void buttonDeleteChart_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Are you sure to delete this chart ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {

                infoPanel = InformationPanel.GetInformationPanel(this, "Deleting chart...", 350, 150);

                var worker = new BackgroundWorker { WorkerReportsProgress = true };
                worker.DoWork += (w, evt) =>
                {
                    service.Delete(((Entity)evt.Argument).LogicalName, ((Entity)evt.Argument).Id);
                };
                worker.ProgressChanged += (w, evt) =>
                {
                    InformationPanel.ChangeInformationPanelMessage(infoPanel, evt.UserState.ToString());
                };
                worker.RunWorkerCompleted += (w, evt) =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        HasUpdatedContent = true;
                    }

                    Controls.Remove(infoPanel);
                    infoPanel.Dispose();

                    this.Close();
                };
                worker.RunWorkerAsync(chart);
            }
        }
    }
}
