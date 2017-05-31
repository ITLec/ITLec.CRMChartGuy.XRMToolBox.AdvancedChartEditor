using ITLec.CRMChartGuy.AppCode;
using ITLecChartGuy.AdvancedChartEditor.AppCode;
using ITLecChartGuy.AdvancedChartEditor.Controls;
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
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace ITLecChartGuy.AdvancedChartEditor.Forms
{
    public partial class ChartEditorHelper : Form
    {
        public static string ChartType = "";
        private string strXmlLine;
        internal AppCode.Clipboard clipboard = new AppCode.Clipboard();

        private XmlDocument siteMapDoc;

        public string ChartXML { get; set; }

        public ChartEditorHelper()
        {
            InitializeComponent();
        }
        public ChartEditorHelper(string str)
        {
            this.strXmlLine = str;
            InitializeComponent();


            LoadChart();
        }

        private void LoadChart()
        {

            siteMapDoc = new XmlDocument();
            siteMapDoc.LoadXml(strXmlLine);

            DisplayChart();
        }
        private void DisplayChart()
        {
            XmlNode siteMapXmlNode = siteMapDoc.DocumentElement;
            tvSiteMap.Nodes.Clear();

            TreeNodeHelper.AddTreeViewNode(tvSiteMap, siteMapXmlNode, this);

          //  ManageMenuDisplay();
            tvSiteMap.Nodes[0].Expand();
        }


        private void CtrlSaving(object sender, SaveEventArgs e)
        {
            tvSiteMap.SelectedNode.Tag = e.AttributeCollection;


            string nodeFullName = TreeNodeHelper.FullNodeName(tvSiteMap.SelectedNode);

            if (nodeFullName == "Series.Series")
            {
                if (e.AttributeCollection.ContainsKey("ChartType"))
                {
                    ChartType = e.AttributeCollection["ChartType"];
                }
            }

            var doc = new XmlDocument();
            XmlNode rootNode = doc.CreateElement("parent");
             doc.AppendChild(rootNode);

            AddXmlNode(tvSiteMap.Nodes[0], rootNode);
            var tmpDoc = doc.ChildNodes[0].ChildNodes[0].OuterXml;

       //     tmpDoc.

            ChartXML = doc.ChildNodes[0].ChildNodes[0].OuterXml;



        }

        private void TvSiteMapNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            selectedNode.TreeView.SelectedNode = selectedNode;
            var collec = (Dictionary<string, string>)selectedNode.Tag;

            TreeNodeHelper.AddContextMenu(e.Node, this);
            Control existingControl = panelContainer.Controls.Count > 0 ? panelContainer.Controls[0] : null;

            if (existingControl != null)
            {
                panelContainer.Controls.Remove(existingControl);
                existingControl.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }

            panelContainer.Controls.Clear();
            BaseMainChartUserControl  ctrl = null;

            string fullNodeName = TreeNodeHelper.FullNodeName(selectedNode);

            ctrl = new ITLecChartGuy.AdvancedChartEditor.Controls.MainChartSectionControl(fullNodeName, collec);
            /*
            string nodeName = selectedNode.Text.Split(' ')[0];
            switch (nodeName)
            {//selectedNode.Parent.Text
                case "Series":
                    {
                        if (selectedNode.Parent.Text.Split(' ')[0] == "Series")
                        {
                             ctrl = new MainChartSectionControl(nodeName, collec);

                        }
                        else
                        {
                            panelContainer.Controls.Clear();
                            tsbItemSave.Visible = false;
                        }
                    }
                    break;
                case "ChartAreas":
                case "Titles":
                    {
                        panelContainer.Controls.Clear();
                        tsbItemSave.Visible = false;

                    }
                    break;
                default:
                    {
                        ctrl = new ITLecChartGuy.AdvancedChartEditor.Controls.MainChartSectionControl(nodeName, collec);
                    }
                    break;
            }
            */
            if (ctrl != null)
            {
                ctrl.Saving += CtrlSaving;
                ctrl.Dock = DockStyle.Fill;

                panelContainer.Controls.Add(ctrl);
                ctrl.BringToFront();
                if (existingControl != null) panelContainer.Controls.Remove(existingControl);
                tsbItemSave.Visible = true;
            }
            ManageMenuDisplay();
        }
        

        private void ManageMenuDisplay()
        {
            TreeNode selectedNode = tvSiteMap.SelectedNode;

            tsbItemSave.Enabled = selectedNode != null;
            toolStripButtonDelete.Enabled = selectedNode != null && selectedNode.Text != "SiteMap";
            toolStripButtonMoveUp.Enabled = selectedNode != null && selectedNode.Parent != null &&
                                            selectedNode.Index != 0;
            toolStripButtonMoveDown.Enabled = selectedNode != null && selectedNode.Parent != null &&
                                              selectedNode.Index != selectedNode.Parent.Nodes.Count - 1;
            toolStripButtonAddXml.Enabled = selectedNode != null && selectedNode.Text != "Title" &&
                                            selectedNode.Text != "Description" && selectedNode.Text != "Privilege";
            toolStripButtonDisplayXml.Enabled = selectedNode != null;

            toolStripDropDownButtonMoreActions.Enabled = tvSiteMap.Nodes.Count > 0;
            tsbUpdateSiteMap.Enabled = tvSiteMap.Nodes.Count > 0;
            toolStripButtonSaveSiteMapToDisk.Enabled = tvSiteMap.Nodes.Count > 0;
        }

        private void tsbItemSave_Click(object sender, EventArgs e)
        {
            if (!((IChartSavable)panelContainer.Controls[0]).Save())
            {
                return;
            }
            
        }

        private void toolStripButtonSaveSiteMapToDisk_Click(object sender, EventArgs e)
        {

            var sfd = new SaveFileDialog
            {
                Title = "Select a location to save the SiteMap as a Xml file",
                Filter = "Xml file (*.xml)|*.xml",
                FileName = "Chart.xml"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                EnableControls(false);

                // Build the Xml SiteMap from SiteMap TreeView
                var doc = new XmlDocument();
                XmlNode rootNode = doc.CreateElement("charts");
                doc.AppendChild(rootNode);


                AddXmlNode(tvSiteMap.Nodes[0], rootNode);

                

                /*if (siteMap != null)
                {
                    siteMap["sitemapxml"] = doc.SelectSingleNode("SiteMap/SiteMap").OuterXml;
                }*/
                MessageBox.Show(doc.SelectSingleNode("chart").OuterXml);
                siteMapDoc.LoadXml(doc.SelectSingleNode("chart").OuterXml);

                siteMapDoc.Save(sfd.FileName);

                EnableControls(true);

                MessageBox.Show(this, "SiteMap saved!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        /// <summary>
        ///     Add the specified TreeNode properties in a XmlNode
        /// </summary>
        /// <param name="currentNode">TreeNode to add to the Xml</param>
        /// <param name="parentXmlNode">XmlNode where to add data</param>
        /// <param name="hasDisabledParent">Indicates if a parent node is already disabled</param>
        private void AddXmlNode(TreeNode currentNode, XmlNode parentXmlNode, bool hasDisabledParent = false)
        {
            string newNodeName;
            if (currentNode.Text.StartsWith("#"))
            {
                newNodeName = currentNode.Text.Remove(0, 2).Trim();
                XmlComment comment = parentXmlNode.OwnerDocument.CreateComment(newNodeName);
                parentXmlNode.AppendChild(comment);
                return;
            }

            newNodeName = currentNode.Text.Split(' ')[0];
            var collec = (Dictionary<string, string>)currentNode.Tag;
           // string newNodeFullName = TreeNodeHelper.FullNodeName(currentNode);
            if (newNodeName == "CustomProperties")
            {
                AppendCustomProperties(parentXmlNode, collec);
            }
            else
            {
                XmlNode newNode = parentXmlNode.OwnerDocument.CreateElement(newNodeName);



                foreach (string key in collec.Keys)
                {
                    if (key != "_disabled")
                    {
                        XmlAttribute attr = parentXmlNode.OwnerDocument.CreateAttribute(key);
                        attr.Value = collec[key];

                        newNode.Attributes.Append(attr);
                    }
                }

                TreeNode titles = null;
                TreeNode descriptions = null;
                var others = new List<TreeNode>();

                foreach (TreeNode childNode in currentNode.Nodes)
                {
                    if (childNode.Text == "Titles")
                        titles = childNode;
                    else if (childNode.Text == "Descriptions")
                        descriptions = childNode;
                    else
                        others.Add(childNode);
                }

                if (titles != null)
                    AddXmlNode(titles, newNode, hasDisabledParent || collec.ContainsKey("_disabled"));
                if (descriptions != null)
                    AddXmlNode(descriptions, newNode, hasDisabledParent || collec.ContainsKey("_disabled"));
                foreach (TreeNode otherNode in others)
                    AddXmlNode(otherNode, newNode, hasDisabledParent || collec.ContainsKey("_disabled"));

                if (collec.ContainsKey("_disabled") && !hasDisabledParent)
                {
                    XmlComment comment = parentXmlNode.OwnerDocument.CreateComment(newNode.OuterXml);
                    parentXmlNode.AppendChild(comment);
                }
                else
                {
                    parentXmlNode.AppendChild(newNode);
                }
            }
        }

        private void AppendCustomProperties(XmlNode parentXmlNode, Dictionary<string, string> collec)
        {
            string customPropertiesStr = "";

            foreach (string key in collec.Keys)
            {
                customPropertiesStr = string.Format("{0}={1}{2}", key, collec[key], (string.IsNullOrEmpty(customPropertiesStr) ? "" : "," + customPropertiesStr));
                
            }

            XmlAttribute attr = parentXmlNode.OwnerDocument.CreateAttribute("CustomProperties");
            attr.Value = customPropertiesStr;
            parentXmlNode.Attributes.Append(attr);
        }

        internal void EnableControls(bool enabled)
        {
            MethodInvoker mi = delegate
            {
                tsbMainOpenSiteMap.Enabled = enabled;
                tsbUpdateSiteMap.Enabled = enabled;
                toolStripButtonSaveSiteMapToDisk.Enabled = enabled;
                toolStripButtonLoadSiteMapFromDisk.Enabled = enabled;
                toolStripDropDownButtonMoreActions.Enabled = enabled;
                gbSiteMap.Enabled = enabled;
                gbProperties.Enabled = enabled;
            };

            if (InvokeRequired)
            {
                Invoke(mi);
            }
            else
            {
                mi();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        /*  private void btnOk_Click(object sender, EventArgs e)
          {

              var doc = new XmlDocument();
              XmlNode rootNode = doc.CreateElement("charts");
              // doc.AppendChild(rootNode);

              AddXmlNode(tvSiteMap.Nodes[0], rootNode);

              MessageBox.Show(doc.SelectSingleNode("chart").OuterXml);
              siteMapDoc.LoadXml(doc.SelectSingleNode("chart").OuterXml);
          }*/
    }
}
