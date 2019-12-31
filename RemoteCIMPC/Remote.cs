using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace RemoteCIMPC
{
    public partial class Remote : Form
    {

        TxtHelper txthelper = new TxtHelper();
        SelectHelper select = new SelectHelper();
        TreeNode clickNode = new TreeNode();

        public Remote()
        {
            InitializeComponent();
        }

        private void Remote_Load(object sender, EventArgs e)
        {
            this.InitTreeView(treeView1);
            NetDrive.Checked = true; // default use NetDrive
            this.KeyPreview = true; // for HotKey
            //调用BuildingTree方法数据来自txthelper.txtToTable
            this.BuildingTree(txthelper.txtToTable());
        }

        public void frmReload()
        {
            this.Remote_Load(this, null);
        }

        private void Remote_KeyDown(object sender, KeyEventArgs e)
        {
            FindBox frm2 = new FindBox();
            // use Ctrl+F
            if (e.Control&e.KeyCode == Keys.F)
            {
                frm2.ShowDialog();
            }
            if (e.KeyCode == Keys.F5)
            {
                //this.BuildingTree(txthelper.txtToTable());
                menu_Refresh_btn_Click(this, null);
            }
            if (e.Alt & e.KeyCode == Keys.F4)
            {
                System.Environment.Exit(0);
            }
        }

        private void InitTreeView(TreeView treeView)
        {
            treeView.CheckBoxes = false;//隐藏复选框
            treeView.FullRowSelect = true;//如果单击某项会选择该项及其所有子项，则为 true；如果单击某项仅选择项本身，则为 false。默认为 false。
            treeView.LabelEdit = false;//不能修改编辑项
            treeView.PathSeparator = "\\";//用\符号为分隔符
            treeView.ShowLines = true;//显示连线
            treeView.ShowPlusMinus = true;//显示+-号
            treeView.ShowRootLines = true;//是否在节点之间绘制连线
            select.getTreeView(treeView1);//初始化传值将（TreeView1）传入 SelectHelper中
        }


        /*        /// <summary>
                /// BuildTree
                /// </summary>
                /// <param name="dt">DataTable</param>
                public void BuildTree(DataTable dt)
                {
                    treeView1.Nodes.Clear();
                    DataView dvTree = new DataView(dt);
                    TreeNode Node = new TreeNode();

                    for (int i = 0; i < dvTree.Count; i++)
                    {
                        //新建子节点，每次循环时都需要重置子节点
                        TreeNode node1 = new TreeNode();
                        TreeNode node2 = new TreeNode();

                        //检查当前根节点是否已存在
                        if (Node.Text == dt.Rows[i]["Shop"].ToString())
                        {
                            //添加当已有根节点下的新子节点  
                            node1.Text = dt.Rows[i]["Eqid"].ToString();
                            Node.Nodes.Add(node1);
                            node2.Text = dt.Rows[i]["Ip"].ToString();
                            node1.Nodes.Add(node2);
                        }
                        else
                        {
                            //添加根节点及其子结点
                            Node = new TreeNode();//根节点重置
                            Node.Text = dt.Rows[i]["Shop"].ToString();
                            node1.Text = dt.Rows[i]["Eqid"].ToString();
                            node2.Text = dt.Rows[i]["Ip"].ToString();
                            treeView1.Nodes.Add(Node);
                            Node.Nodes.Add(node1);
                            node1.Nodes.Add(node2);
                        }
                    }
                }
        */


        public void BuildingTree(DataTable dt)
        {
            treeView1.Nodes.Clear();
            TreeNode Node = new TreeNode();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //检查当前根节点是否已存在
                if (Node.Text != dt.Rows[i]["Shop"].ToString())
                {
                    //节点的引用需要重置
                    Node = new TreeNode();
                    TreeNode node1 = new TreeNode();
                    TreeNode node2 = new TreeNode();

                    // 新建根节点并载入他的第一个子节点
                    Node.Text = dt.Rows[i]["Shop"].ToString();
                    node1.Text = dt.Rows[i]["Eqid"].ToString();
                    node2.Text = dt.Rows[i]["Ip"].ToString();
                    node1.Nodes.Add(node2);
                    Node.Nodes.Add(node1);
                    treeView1.Nodes.Add(Node);
                }
                else
                {
                    //节点的引用需要重置
                    TreeNode node1 = new TreeNode();
                    TreeNode node2 = new TreeNode();

                    //已存在的根节点下新建子节点数据
                    node1.Text = dt.Rows[i]["Eqid"].ToString();
                    node2.Text = dt.Rows[i]["Ip"].ToString();
                    Node.Nodes.Add(node1);
                    node1.Nodes.Add(node2);
                }
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //string userId = "CIMPC";
            //string password = "Manager123";
            if (e.Node.Level == 2)
            {
                string ip = e.Node.Text.Trim().ToString();
                if (ip != null)
                {
                    if (RemotePC.Checked)
                    {
                        string cmd = string.Format("mstsc /v: {0} /console", ip);
                        CmdHelper.RunCmd(cmd);
                    }
                    else if (NetDrive.Checked)
                    {
                        string cmd = string.Format(@"explorer \\{0}", ip);
                        //string cmd = string.Format(@"\\{0}:{1}@{2}",userId, password, ip);
                        CmdHelper.RunCmd(cmd);
                    }
                }
            }
        }


        private void TextBox1_Press(object sender, KeyPressEventArgs e)
        {
            FindBox frm2 = new FindBox();

            if (e.KeyChar == 13) //Enter 的键值为13
            {
                string str = textBox1.Text.Trim().ToString().ToUpper();
                if (!string.IsNullOrEmpty(str))
                {
                    select.getTextValue(str);
                    frm2.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show("Eqid should not be null !", "Null Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void showResult(List<string> list)
        {            
            if (list.Count > 0)
            {
                AutoCompleteStringCollection tempArr = new AutoCompleteStringCollection();
                foreach (string eqid in list)
                {
                    tempArr.Add(eqid);
                }
                textBox1.AutoCompleteCustomSource = tempArr;
                textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        public void setTextBox(string text)
        {
            if (string.IsNullOrEmpty(text) || text.Equals(textBox1.Text))
            {
                return;
            }
            else
            {
                textBox1.Text = text;
            }
        }

        private void menu_Select_btn_Click(object sender, EventArgs e)
        {
            FindBox frm2 = new FindBox();
            frm2.ShowDialog();
        }

        private void menu_Refresh_btn_Click(object sender, EventArgs e)
        {
            frmReload();
            BuildingTree(txthelper.txtToTable());
        }

        private void menu_Exit_btn_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Create_Click(object sender, EventArgs e)
        {
            DataChanger dc = new DataChanger();
            dc.setBtnValue(Create.Text);
            dc.ShowDialog(this);
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            DataChanger dc = new DataChanger();
            dc.setBtnValue(Modify.Text);
            dc.ShowDialog(this);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DataChanger dc = new DataChanger();
            dc.setBtnValue(Delete.Text);
            dc.ShowDialog(this);
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point clickPoint = new Point(e.X, e.Y);
                clickNode = treeView1.GetNodeAt(clickPoint);



                if (clickNode != null)
                {

                    string nodeText = clickNode.Text;


                    if (clickNode.Level > 0)
                    {
                        clickNode.ContextMenuStrip = contextMenuStrip1;
                    }
                }
            }
        }

        private void remoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string eqip = getIpByNode(clickNode);

            string cmd = string.Format("mstsc /v: {0} /console", eqip);
            CmdHelper.RunCmd(cmd);
        }

        private void netDriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string eqip = getIpByNode(clickNode);

            string cmd = string.Format(@"explorer \\{0}", eqip);
            CmdHelper.RunCmd(cmd);

        }

        private void appVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string eqip = getIpByNode(clickNode);
            //string eqip = "127.0.0.1";

            string client = string.Format(@"\\{0}\d\CIMPC\Client\Bin\CIMPCClient.exe", eqip);
            string iocon = string.Format(@"\\{0}\d\CIMPC\IOCon\bin\IOCon.exe", eqip);
            string ioconini = string.Format(@"\\{0}\d\CIMPC\IOCon\bin\version.ini", eqip);
            string fdcmini = string.Format(@"\\{0}\d\CIMPC\FDCM\config\version.ini", eqip);
            string serverini = string.Format(@"\\{0}\d\CIMPC\Server\config\version.ini", eqip);

            //.exe
            string clientVer = getVerByExe(client);
            string ioconVer = getVerByExe(iocon);
            //.ini
            string ioconVer2 = ReadIniData("IOCon", "Version", null, ioconini);
            string fdcmVer = ReadIniData("EASServer", "Version", null, fdcmini);
            string serverVer = ReadIniData("EASServer", "Version", null, serverini);

            MessageBox.Show(string.Format("Client.exe Version: \t{0}"
                + "\r\n" + "IoCon.exe Version: \t{1}"
                + "\r\n" + "Server.ini Version: \t{2}"
                + "\r\n" + "FDCM.ini Version: \t{3}"
                + "\r\n" + "IoCon.ini Version: \t{4}"
                , clientVer,ioconVer,serverVer,fdcmVer,ioconVer2));
        }

        private static string getIpByNode(TreeNode node)
        {
            string tempIp = string.Empty;

            if (node.Level == 1)
            {
                TreeNode tempNode = node.Nodes[0];
                tempIp = tempNode.Text;
            }
            else
            {
                tempIp = node.Text;
            }

            return tempIp;
        }

        private static string getVerByExe(string path)
        {
            if (File.Exists(path))
            {
                System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(path);
                return fvi.FileVersion;
            }
            else
            {
                return string.Empty;
            }
        }


        #region API函数声明
        [DllImport("kernel32")]//返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);
        #endregion


        private string ReadIniData(string Section, string Key, string NoText, string path)//读取INI文件
        {

            if (File.Exists(path))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, NoText, temp, 1024, path);
                return temp.ToString();
            }
            else
            {
                return String.Empty;
            }
        }



    }
}


