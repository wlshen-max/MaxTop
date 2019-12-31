using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RemoteCIMPC
{
    public partial class FindBox : Form
    {
        private static string textvalue;
        SelectHelper select = new SelectHelper();

        public FindBox()
        {
            InitializeComponent();
        }

        private void FindBox_Load(object sender, EventArgs e)
        {
            findValue.Text = select.getTextData(); // 初始化text值来自Remote的TextBox
            if (!string.IsNullOrEmpty(findValue.Text))
            {
                setResult(select.findTolist());
            }            
        }

        private void FindBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            Remote frm = new Remote();
            frm.frmReload();
        }

        private void findValue_TextChanged(object sender, EventArgs e)
        {
            textvalue = findValue.Text.Trim().ToString().ToUpper();
            select.getTextValue(textvalue);
        }

        private void findValue_Press(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) //Enter 的键值为13
            {
                setResult(select.findTolist());
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            //关闭当前窗口
            this.Close();
        }



        private void find_btn_Click(object sender, EventArgs e)
        {
            setResult(select.findTolist());
        }

        private void setResult(List<string> resultList)
        {
            showResult.Items.Clear();
            for (int i = 0; i < resultList.Count; i++)
            {
                showResult.Items.Add(resultList[i].Trim().ToString());       
            }
        }

        private void showResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            ListViewItem item = this.showResult.GetItemAt(e.X, e.Y);

            if (item != null)
            {
                select.openTree(item.Text);                
            }
        }


    }
}
