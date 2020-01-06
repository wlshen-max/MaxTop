using System.Collections.Generic;
using System.Windows.Forms;

namespace RemoteCIMPC
{
    class SelectHelper
    {
        private static string textvalue;
        private static TreeView treeView;

        public List<string> findTolist()
        {
            List<string> result = new List<string>();
            TreeNode temp = new TreeNode();
            if (string.IsNullOrEmpty(textvalue))
            {
                MessageBox.Show("Eqid should not be null !", "Null Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                foreach (TreeNode node in treeView.Nodes)   //treeView1是TreeView控件的名称
                {
                    if (node.Level != 1 && node.Nodes.Count != 0) // Level 1
                    {
                        foreach (TreeNode Child in node.Nodes)
                        {
                            if (Child.Text.Contains(textvalue))
                            {
                                temp.Nodes.Add((TreeNode)Child.Clone());
                            }
                        }
                    }
                    else
                    {
                        if (node.Text.Contains(textvalue))
                        {
                            temp.Nodes.Add((TreeNode)node.Clone());
                        }
                    }
                }

                if (temp.Nodes.Count != 0)
                {
                    foreach (TreeNode tn in temp.Nodes)
                    {
                        string str = tn.Text.ToString();
                        result.Add(str);

                        //tn.BackColor = Color.Blue;
                        //tn.Expand();
                    }
                }
                else
                {
                    MessageBox.Show("Cannot found EqID !", "Null Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return result;
        }

        public void openTree(string text)
        {
            foreach (TreeNode node in treeView.Nodes)   //treeView1是TreeView控件的名称
            {
                if (node.Level != 1 && node.Nodes.Count != 0) // Level 1
                {
                    foreach (TreeNode Child in node.Nodes)
                    {
                        if (Child.Text == text)
                        {
                            //Child.BackColor = Color.Blue; //设定Eqid为蓝色
                            node.Expand();
                            Child.Expand();
                        }
                    }
                }
            }
        }

        public void getTextValue(string text)
        {
            textvalue = text;
        }

        public string getTextData()
        {
            return textvalue;
        }

        public void getTreeView(TreeView treeview)
        {
            treeView = treeview;
        }

    }
}
