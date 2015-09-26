using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace XMLMergeTool
{
    public partial class MainForm : Form
    {
        private bool _openAfterMerge = true;

        #region << Constructor >>

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region << Events >>

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.toolStripButton_Preference.Image = global::XMLMergeTool.Properties.Resources.TOP_ON;
            this.toolStripButton_Open.Image = global::XMLMergeTool.Properties.Resources.SETTING_ON;

            comboBox_XML.SelectedIndex = 0;
            textBox_LDSN.Text = Path.Combine(Directory.GetCurrentDirectory(), @"00.LDSN\CustomFormatter_001.xml");
            textBox_BL.Text = Path.Combine(Directory.GetCurrentDirectory(), @"01.BL\CustomFormatter_001.xml");
            textBox_Merge.Text = Path.Combine(Directory.GetCurrentDirectory(), @"02.Merge\CustomFormatter_001.xml");

            if (!Directory.Exists(Path.GetDirectoryName(textBox_LDSN.Text)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(textBox_LDSN.Text));
            }

            if (!Directory.Exists(Path.GetDirectoryName(textBox_BL.Text)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(textBox_BL.Text));
            }

            if (!Directory.Exists(Path.GetDirectoryName(textBox_Merge.Text)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(textBox_Merge.Text));
            }
            
        }

        private void toolStripButton_Help_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.TopMost = this.TopMost;
            helpForm.ShowDialog();
        }

        private void comboBox_XML_SelectedIndexChanged(object sender, EventArgs e)
        {
            string customFormatter = "CustomFormatter_001.xml";
            string remoteAssemblyInfo = "RemoteAssemblyInfo1.xml";
            string fileName = customFormatter;
            if (comboBox_XML.SelectedIndex == 0)
            {
                fileName = customFormatter;
            }
            else
            {
                fileName = remoteAssemblyInfo;
            }

            textBox_LDSN.Text = Path.Combine(Path.GetDirectoryName(textBox_LDSN.Text), fileName);
            textBox_BL.Text = Path.Combine(Path.GetDirectoryName(textBox_BL.Text), fileName);
            textBox_Merge.Text = Path.Combine(Path.GetDirectoryName(textBox_Merge.Text), fileName);
        }

        private void button_LDSN_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "XMLファイル(*.XML)|*.XML";
            ofd.Title = "LDNSからXMLファイルを選ぶ";
            DialogResult ret = ofd.ShowDialog(this);
            if (ret == DialogResult.OK)
            {
                textBox_LDSN.Text = ofd.FileName;

                string dir = Path.GetDirectoryName(textBox_LDSN.Text);
                string name = Path.GetFileName(textBox_LDSN.Text);

                dir = Path.GetDirectoryName(dir);
                if (!Directory.Exists(dir + "\\02.Merge"))
                {
                    Directory.CreateDirectory(dir + "\\02.Merge");
                }
                textBox_Merge.Text = dir + "02.Merge\\" + name;
            }
        }

        private void button_BL_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "XMLファイル(*.XML)|*.XML";
            ofd.Title = "BLからXMLファイルを選ぶ";
            DialogResult ret = ofd.ShowDialog(this);
            if (ret == DialogResult.OK)
            {
                textBox_BL.Text = ofd.FileName;
            }
        }

        private void button_Merge_Click(object sender, EventArgs e)
        {
            bool status = false;
            if (comboBox_XML.SelectedIndex == 0)
            {
                status = DoCustomFormatter();
            }
            else
            {
                status = DoRemoteAssemblyInfo();
            }

            if (status && this._openAfterMerge)
            {
                try
                {
                    Process.Start("explorer.exe", Path.GetDirectoryName(this.textBox_Merge.Text));
                }
                catch (Exception ex)
                {
                }
            }
        }

        #endregion

        #region << Drag&Drop >>
        private void textBox_LDSN_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            if (File.Exists(path))
            {
                textBox_LDSN.Text = path;
                textBox_LDSN.Cursor = System.Windows.Forms.Cursors.IBeam;

                string dir = Path.GetDirectoryName(path);
                string name = Path.GetFileName(path);

                dir = Path.GetDirectoryName(dir);
                if (!Directory.Exists(dir + "\\02.Merge"))
                {
                    Directory.CreateDirectory(dir + "\\02.Merge");
                }
                textBox_Merge.Text = dir+ "02.Merge\\" + name;
            }
        }

        private void textBox_LDSN_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
                this.textBox_LDSN.Cursor = System.Windows.Forms.Cursors.Arrow;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBox_BL_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (File.Exists(path))
            {
                textBox_BL.Text = path;
                textBox_BL.Cursor = System.Windows.Forms.Cursors.IBeam;
            }
        }

        private void textBox_BL_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
                this.textBox_LDSN.Cursor = System.Windows.Forms.Cursors.Arrow;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        #endregion

        #region << CustomFormatter >>

        private bool DoCustomFormatter()
        {
            List<CustomSerializationSurrogate> customSerializationSurrogateListLDNS = new List<CustomSerializationSurrogate>();
            List<CustomSerializationSurrogate> customSerializationSurrogateListBL = new List<CustomSerializationSurrogate>();

            if (Read_CustomFormatter(textBox_LDSN.Text, ref customSerializationSurrogateListLDNS) != 0)
                return false;

            if (Read_CustomFormatter(textBox_BL.Text, ref customSerializationSurrogateListBL) != 0)
                return false;

            // 簡単にファイルのフォーマットをチェックする
            if (customSerializationSurrogateListLDNS.Count == 0)
            {
                MessageBox.Show(this, "LDNSからXMLのフォーマットが不正です。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (customSerializationSurrogateListBL.Count == 0)
            {
                MessageBox.Show(this, "BLからXMLのフォーマットが不正です。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            List<CustomSerializationSurrogate> customSerializationSurrogateListMerge = new List<CustomSerializationSurrogate>();
            List<CustomSerializationSurrogate> customSerializationSurrogateListDiffLDNS = new List<CustomSerializationSurrogate>();
            List<CustomSerializationSurrogate> customSerializationSurrogateListDiffBL = new List<CustomSerializationSurrogate>();

            // BL Has
            bool bLHas = false;
            for (int i = 0; i < customSerializationSurrogateListBL.Count; i++)
            {
                bLHas = false;
                for (int j = 0; j < customSerializationSurrogateListLDNS.Count; j++)
                {
                    if (customSerializationSurrogateListBL[i].Compare(customSerializationSurrogateListLDNS[j]))
                    {
                        customSerializationSurrogateListMerge.Add(customSerializationSurrogateListBL[i]);
                        bLHas = true;
                        break;
                    }
                }

                if (!bLHas)
                {
                    customSerializationSurrogateListDiffBL.Add(customSerializationSurrogateListBL[i]);
                }
            }

            // LDNS has
            bool lDNSHas = false;
            for (int i = 0; i < customSerializationSurrogateListLDNS.Count; i++)
            {
                lDNSHas = false;
                for (int j = 0; j < customSerializationSurrogateListBL.Count; j++)
                {
                    if (customSerializationSurrogateListLDNS[i].Compare(customSerializationSurrogateListBL[j]))
                    {
                        lDNSHas = true;
                        break;
                    }
                }
                if (!lDNSHas)
                {
                    customSerializationSurrogateListDiffLDNS.Add(customSerializationSurrogateListLDNS[i]);
                }
            }

            if (Write_CustomFormatter(textBox_Merge.Text, customSerializationSurrogateListMerge, customSerializationSurrogateListDiffBL, customSerializationSurrogateListDiffLDNS) != 0)
                return false;

            toolStripStatusLabel_LDNS.Text = customSerializationSurrogateListDiffLDNS.Count.ToString() + "件";
            toolStripStatusLabel_BL.Text = customSerializationSurrogateListDiffBL.Count.ToString() + "件";

            MessageBox.Show(this, "Mergeが成功に完了しました。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private int Read_CustomFormatter(string strFileName, ref List<CustomSerializationSurrogate> customSerializationSurrogateListLDNS)
        {
            int status = 0;
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(strFileName);

                XmlNodeList nodes = doc.GetElementsByTagName("CustomSerializationSurrogate");
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (nodes[i].NodeType == XmlNodeType.Element && nodes[i].ChildNodes.Count == 4)
                    {
                        CustomSerializationSurrogate customSerializationSurrogate = new CustomSerializationSurrogate();
                        customSerializationSurrogate.TargetAssemblyShortName = nodes[i].ChildNodes[0].InnerText;
                        customSerializationSurrogate.TargetTypeName = nodes[i].ChildNodes[1].InnerText;
                        customSerializationSurrogate.SurrogateAssemblyName = nodes[i].ChildNodes[2].InnerText;
                        customSerializationSurrogate.SurrogateTypeName = nodes[i].ChildNodes[3].InnerText;
                        customSerializationSurrogateListLDNS.Add(customSerializationSurrogate);
                    }
                }
            }
            catch (Exception ex)
            {
                status = -1;
                MessageBox.Show(this, ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return status;
            }

            return status;
        }

        private int Write_CustomFormatter(string megFileName, List<CustomSerializationSurrogate> customSerializationSurrogateListLDNS, List<CustomSerializationSurrogate> customSerializationSurrogateListDiffBL, List<CustomSerializationSurrogate> customSerializationSurrogateListDiffLDNS)
        {
            XmlDocument doc = new XmlDocument();

            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);

            XmlElement ele = doc.CreateElement("CustomSerializationSurrogates");
            doc.AppendChild(ele);

            // 共通部分
            WriteElement_CustomFormatter(doc, ele, customSerializationSurrogateListLDNS);

            // BLのみ部分
            if (customSerializationSurrogateListDiffBL.Count != 0)
            {
                WriteComment(doc, ele, "BLから");
                WriteElement_CustomFormatter(doc, ele, customSerializationSurrogateListDiffBL);
            }
            // LNDSのみ部分
            if (customSerializationSurrogateListDiffLDNS.Count != 0)
            {
                WriteComment(doc, ele, "LNDSから");
                WriteElement_CustomFormatter(doc, ele, customSerializationSurrogateListDiffLDNS);
            }

            int status = 0;
            try
            {
                doc.Save(megFileName);
            }
            catch (Exception ex)
            {
                status = -1;
                MessageBox.Show(this, ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return status;
        }

        private void WriteElement_CustomFormatter(XmlDocument doc, XmlElement ele, List<CustomSerializationSurrogate> customSerializationSurrogateListLDNS)
        {
            foreach (CustomSerializationSurrogate customSerializationSurrogate in customSerializationSurrogateListLDNS)
            {
                XmlElement ele2 = doc.CreateElement("CustomSerializationSurrogate");
                ele.AppendChild(ele2);

                XmlElement ele3 = doc.CreateElement("TargetAssemblyShortName");
                ele3.InnerText = customSerializationSurrogate.TargetAssemblyShortName;
                ele2.AppendChild(ele3);

                XmlElement ele4 = doc.CreateElement("TargetTypeName");
                ele4.InnerText = customSerializationSurrogate.TargetTypeName;
                ele2.AppendChild(ele4);

                XmlElement ele5 = doc.CreateElement("SurrogateAssemblyName");
                ele5.InnerText = customSerializationSurrogate.SurrogateAssemblyName;
                ele2.AppendChild(ele5);

                XmlElement ele6 = doc.CreateElement("SurrogateTypeName");
                ele6.InnerText = customSerializationSurrogate.SurrogateTypeName;
                ele2.AppendChild(ele6);
            }
        }

        #endregion

        #region << RemoteAssemblyInfo >>

        private bool DoRemoteAssemblyInfo()
        {
            List<RemoteAssemblyInfo> remoteAssemblyInfoListLDNS = new List<RemoteAssemblyInfo>();
            List<RemoteAssemblyInfo> remoteAssemblyInfoListBL = new List<RemoteAssemblyInfo>();

            if (Read_RemoteAssemblyInfo(textBox_LDSN.Text, ref remoteAssemblyInfoListLDNS) != 0)
                return false;

            if (Read_RemoteAssemblyInfo(textBox_BL.Text, ref remoteAssemblyInfoListBL) != 0)
                return false;

            // 簡単にファイルのフォーマットをチェックする
            if (remoteAssemblyInfoListLDNS.Count == 0)
            {
                MessageBox.Show(this, "LDNSからXMLのフォーマットが不正です。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (remoteAssemblyInfoListBL.Count == 0)
            {
                MessageBox.Show(this, "BLからXMLのフォーマットが不正です。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            List<RemoteAssemblyInfo> remoteAssemblyInfoListMerge = new List<RemoteAssemblyInfo>();
            List<RemoteAssemblyInfo> remoteAssemblyInfoListDiffLDNS = new List<RemoteAssemblyInfo>();
            List<RemoteAssemblyInfo> remoteAssemblyInfoListDiffBL = new List<RemoteAssemblyInfo>();

            // BL Has
            bool bLHas = false;
            for (int i = 0; i < remoteAssemblyInfoListBL.Count; i++)
            {
                bLHas = false;
                for (int j = 0; j < remoteAssemblyInfoListLDNS.Count; j++)
                {
                    if (remoteAssemblyInfoListBL[i].Compare(remoteAssemblyInfoListLDNS[j]))
                    {
                        remoteAssemblyInfoListMerge.Add(remoteAssemblyInfoListBL[i]);
                        bLHas = true;
                        break;
                    }
                }

                if (!bLHas)
                {
                    remoteAssemblyInfoListDiffBL.Add(remoteAssemblyInfoListBL[i]);
                }
            }

            // LDNS has
            bool lDNSHas = false;
            for (int i = 0; i < remoteAssemblyInfoListLDNS.Count; i++)
            {
                lDNSHas = false;
                for (int j = 0; j < remoteAssemblyInfoListBL.Count; j++)
                {
                    if (remoteAssemblyInfoListLDNS[i].Compare(remoteAssemblyInfoListBL[j]))
                    {
                        lDNSHas = true;
                        break;
                    }
                }
                if (!lDNSHas)
                {
                    remoteAssemblyInfoListDiffLDNS.Add(remoteAssemblyInfoListLDNS[i]);
                }
            }

            XmlNode xs_schema = null;
            XmlNode dataroot = null;
            Read_FirstTwoNodes(textBox_BL.Text, ref xs_schema, ref dataroot);

            if (Write_RemoteAssemblyInfo(textBox_Merge.Text, xs_schema, dataroot, remoteAssemblyInfoListMerge, remoteAssemblyInfoListDiffBL, remoteAssemblyInfoListDiffLDNS) != 0)
                return false;

            toolStripStatusLabel_LDNS.Text = remoteAssemblyInfoListDiffLDNS.Count.ToString() + "件";
            toolStripStatusLabel_BL.Text = remoteAssemblyInfoListDiffBL.Count.ToString() + "件";
            MessageBox.Show(this, "Mergeが成功に完了しました。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
        }

        private int Read_RemoteAssemblyInfo(string strFileName, ref List<RemoteAssemblyInfo> remoteAssemblyInfoList)
        {
            int status = 0;
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(strFileName);

                XmlNodeList nodes = doc.GetElementsByTagName("RemoteAssemblyInfo");
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (nodes[i].NodeType == XmlNodeType.Element && nodes[i].ChildNodes.Count == 6)
                    {
                        RemoteAssemblyInfo remoteAssemblyInfo = new RemoteAssemblyInfo();
                        remoteAssemblyInfo.AssemblyName = nodes[i].ChildNodes[0].InnerText;
                        remoteAssemblyInfo.ClassName = nodes[i].ChildNodes[1].InnerText;
                        remoteAssemblyInfo.ObjectUri = nodes[i].ChildNodes[2].InnerText;
                        remoteAssemblyInfo.Mode = nodes[i].ChildNodes[3].InnerText;
                        remoteAssemblyInfo.Status = nodes[i].ChildNodes[4].InnerText;
                        remoteAssemblyInfo.Path = nodes[i].ChildNodes[5].InnerText;
                        remoteAssemblyInfoList.Add(remoteAssemblyInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                status = -1;
                MessageBox.Show(this, ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return status;
            }

            return status;
        }

        private int Write_RemoteAssemblyInfo(string megFileName, XmlNode xs_schema, XmlNode dataroot, List<RemoteAssemblyInfo> remoteAssemblyInfoListLDNS, List<RemoteAssemblyInfo> remoteAssemblyInfoListDiffBL, List<RemoteAssemblyInfo> remoteAssemblyInfoListDiffLDNS)
        {
            XmlDocument doc = new XmlDocument();

            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, "yes");
            doc.AppendChild(dec);

            XmlElement ele = doc.CreateElement("root");
            doc.AppendChild(ele);

            XmlNode xs_schema2 = doc.ImportNode(xs_schema, true);
            ele.AppendChild(xs_schema2);

            XmlNode dataroot2 = doc.ImportNode(dataroot, true);
            ele.AppendChild(dataroot2);

            // 共通部分
            WriteElement_RemoteAssemblyInfo(doc, ele, remoteAssemblyInfoListLDNS);

            // BLのみ部分
            if (remoteAssemblyInfoListDiffBL.Count != 0)
            {
                WriteComment(doc, ele, "BLから");
                WriteElement_RemoteAssemblyInfo(doc, ele, remoteAssemblyInfoListDiffBL);
            }
            // LNDSのみ部分
            if (remoteAssemblyInfoListDiffLDNS.Count != 0)
            {
                WriteComment(doc, ele, "LNDSから");
                WriteElement_RemoteAssemblyInfo(doc, ele, remoteAssemblyInfoListDiffLDNS);
            }

            int status = 0;
            try
            {
                doc.Save(megFileName);
            }
            catch (Exception ex)
            {
                status = -1;
                MessageBox.Show(this, ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return status;
        }

        private void WriteElement_RemoteAssemblyInfo(XmlDocument doc, XmlElement ele, List<RemoteAssemblyInfo> remoteAssemblyInfoListLDNS)
        {
            foreach (RemoteAssemblyInfo remoteAssemblyInfo in remoteAssemblyInfoListLDNS)
            {
                XmlElement ele2 = doc.CreateElement("RemoteAssemblyInfo");
                ele.AppendChild(ele2);

                XmlElement ele3 = doc.CreateElement("AssemblyName");
                ele3.InnerText = remoteAssemblyInfo.AssemblyName;
                ele2.AppendChild(ele3);

                XmlElement ele4 = doc.CreateElement("ClassName");
                ele4.InnerText = remoteAssemblyInfo.ClassName;
                ele2.AppendChild(ele4);

                XmlElement ele5 = doc.CreateElement("ObjectUri");
                ele5.InnerText = remoteAssemblyInfo.ObjectUri;
                ele2.AppendChild(ele5);

                XmlElement ele6 = doc.CreateElement("Mode");
                ele6.InnerText = remoteAssemblyInfo.Mode;
                ele2.AppendChild(ele6);

                XmlElement ele7 = doc.CreateElement("Status");
                ele7.InnerText = remoteAssemblyInfo.Status;
                ele2.AppendChild(ele7);

                XmlElement ele8 = doc.CreateElement("Path");
                //ele8.InnerText = remoteAssemblyInfo.Path;　// [<Path />]のようなフォーマットで出力するため
                ele2.AppendChild(ele8);
            }
        }

        private void Read_FirstTwoNodes(string strFileName, ref XmlNode xs_schema, ref XmlNode dataroot)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(strFileName);

                XmlNodeList nodes = doc.GetElementsByTagName("root");

                xs_schema = nodes[0].ChildNodes[0];
                dataroot = nodes[0].ChildNodes[1];
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #region << Common >>
        
        private void WriteComment(XmlDocument doc, XmlElement ele, string comment)
        {
            XmlComment cmt = doc.CreateComment(comment);
            ele.AppendChild(cmt);
        }

        #endregion

        private void toolStripButton_Preference_Click(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.TopMost = false;
                this.toolStripButton_Preference.Image = global::XMLMergeTool.Properties.Resources.TOP_OFF;
            }
            else
            {
                this.TopMost = true;
                this.toolStripButton_Preference.Image = global::XMLMergeTool.Properties.Resources.TOP_ON;
            }

            
        }

        private void toolStripButton_Open_Click(object sender, EventArgs e)
        {
            if (this._openAfterMerge)
            {
                this._openAfterMerge = false;
                this.toolStripButton_Open.Image = global::XMLMergeTool.Properties.Resources.SETTING;
            }
            else
            {
                this._openAfterMerge = true;
                this.toolStripButton_Open.Image = global::XMLMergeTool.Properties.Resources.SETTING_ON;
            }
        }
    }

    public class CustomSerializationSurrogate
    {
        #region << Private Members - Fields>>
        private string targetAssemblyShortName;
        private string targetTypeName;
        private string surrogateAssemblyName;
        private string surrogateTypeName;
        #endregion

        #region << Public Members - Property >>
        public string TargetAssemblyShortName
        {
            get
            {
                return targetAssemblyShortName;
            }
            set
            {
                targetAssemblyShortName = value;
            }
        }
        public string TargetTypeName
        {
            get
            {
                return targetTypeName;
            }
            set
            {
                targetTypeName = value;
            }
        }
        public string SurrogateAssemblyName
        {
            get
            {
                return surrogateAssemblyName;
            }
            set
            {
                surrogateAssemblyName = value;
            }
        }
        public string SurrogateTypeName
        {
            get
            {
                return surrogateTypeName;
            }
            set
            {
                surrogateTypeName = value;
            }
        }
        #endregion

        #region << Constructor >>
        public CustomSerializationSurrogate()
        {
        }
        #endregion

        #region << Public Methods >>
        public CustomSerializationSurrogate(string targetAssemblyShortName, string targetTypeName, string surrogateAssemblyName, string surrogateTypeName)
        {
            this.targetAssemblyShortName = targetAssemblyShortName;
            this.targetTypeName = targetTypeName;
            this.surrogateAssemblyName = surrogateAssemblyName;
            this.surrogateTypeName = surrogateTypeName;
        }
        public bool Compare(CustomSerializationSurrogate customSerializationSurrogate)
        {
            //return (targetAssemblyShortName == customSerializationSurrogate.TargetAssemblyShortName) &&
            //       (targetTypeName == customSerializationSurrogate.TargetTypeName) &&
            //       (surrogateAssemblyName == customSerializationSurrogate.SurrogateAssemblyName) &&
            //       (surrogateTypeName == customSerializationSurrogate.SurrogateTypeName);

            return (targetAssemblyShortName == customSerializationSurrogate.TargetAssemblyShortName) &&
                   (targetTypeName == customSerializationSurrogate.TargetTypeName);
        }
        #endregion
    }

    public class RemoteAssemblyInfo
    {
        #region << Private Members - Fields>>
        private string assemblyName;
        private string className;
        private string objectUri;
        private string mode;
        private string status;
        private string path;
        #endregion

        #region << Public Members - Property >>
        public string AssemblyName
        {
            get
            {
                return assemblyName;
            }
            set
            {
                assemblyName = value;
            }
        }
        public string ClassName
        {
            get
            {
                return className;
            }
            set
            {
                className = value;
            }
        }
        public string ObjectUri
        {
            get
            {
                return objectUri;
            }
            set
            {
                objectUri = value;
            }
        }
        public string Mode
        {
            get
            {
                return mode;
            }
            set
            {
                mode = value;
            }
        }
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }
        #endregion

        #region << Constructor >>
        public RemoteAssemblyInfo()
        {
        }
        #endregion

        #region << Public Methods >>
        public RemoteAssemblyInfo(string assemblyName, string className, string objectUri, string mode, string status, string path)
        {
            this.assemblyName = assemblyName;
            this.className = className;
            this.objectUri = objectUri;
            this.mode = mode;
            this.status = status;
            this.path = path;
        }
        public bool Compare(RemoteAssemblyInfo remoteAssemblyInfo)
        {
            return ((assemblyName == remoteAssemblyInfo.assemblyName) &&
                   (className == remoteAssemblyInfo.className) &&
                   (objectUri == remoteAssemblyInfo.objectUri) &&
                   (mode == remoteAssemblyInfo.mode) &&
                   (status == remoteAssemblyInfo.status) &&
                   (path == remoteAssemblyInfo.path));
        }
        #endregion
    }
}