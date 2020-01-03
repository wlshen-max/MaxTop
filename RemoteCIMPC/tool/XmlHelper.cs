using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RemoteCIMPC
{
    public class XmlHelper
    {

        public static void GetXml(XmlElement xmlrootele, TreeNodeCollection nodes)
        {
            //循环根元素的子元素
            foreach (XmlNode item in xmlrootele.ChildNodes)
            {
                //判断当前节点的类型
                if (item.NodeType == XmlNodeType.Element)
                {
                    //将元素节点加载到TeerView
                    TreeNode node = nodes.Add(item.Name);
                    GetXml((XmlElement)item, node.Nodes);
                }
                else if(item.NodeType == XmlNodeType.Text || item.NodeType == XmlNodeType.CDATA)
                {
                    nodes.Add(item.InnerText);
                }
            }

        }




        //通过XmlDocument的方式将xml加载到TreeView
        public static void Getxml(XElement rootEle, TreeNodeCollection nodes)
        {
            //获取根元素的所有子元素
            rootEle.Elements();
            //遍历根元素所有的子元素

            foreach (XElement item in rootEle.Elements())
            {
                if (item.Elements().Count() == 0)
                {
                    nodes.Add(item.Name.ToString()).Nodes.Add(item.Value.ToString());
                }
                else
                {
                    //
                    TreeNode node = nodes.Add(item.Name.ToString());
                    Getxml(item, node.Nodes);

                }
            }
        }
    }
}
