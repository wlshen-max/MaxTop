using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RemoteCIMPC
{
    public class TxtHelper
    {

        private static string path = @"ipList.txt"; //publish
        private static string textdata = string.Empty;
        private static DataTable datatable;
        private static string[] nodes = null;


        /// <summary>
        /// Read Text
        /// </summary>
        private string readText()
        {
            if (!string.IsNullOrEmpty(textdata))
            {
                return textdata;
            }
            else
            {
                try
                {
                    textdata = File.ReadAllText(path).Replace("\r\n", ";");
                }
                catch (Exception)
                {
                    MessageBox.Show("IpList not exist!", "File Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    System.Environment.Exit(0);
                }
            }
            return textdata;
        }



        public DataTable txtToTable()
        {
            if (datatable != null)
            {
                return datatable;
            }
            else
            {
                try
                {
                    readText(); //readText取得TextData

                    //初始化DataTable，并定义三列为：Shop，Eqid，Ip
                    datatable = new DataTable();
                    datatable.Columns.Add("Shop", typeof(string));
                    datatable.Columns.Add("Eqid", typeof(string));
                    datatable.Columns.Add("Ip", typeof(string));

                    if (textdata != null)
                    {
                        //将读取的data按‘;’分裂放入数组
                        nodes = textdata.Trim().Split(';');

                        //数组重载入，去除空白行
                        nodes = nodes.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                        foreach (string node in nodes)
                        {
                            //对数组某行内容按‘:’进行分裂
                            string[] str = node.Trim().Split(':');

                            //新建行，并将数组的数据载入到这一行
                            DataRow dr = datatable.NewRow();
                            dr["Shop"] = str[0];
                            dr["Eqid"] = str[1];
                            dr["Ip"] = str[2];

                            datatable.Rows.Add(dr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return datatable;
        }


        public object[] splitArray(string type)
        {
            List<string> list = new List<string>();
            object[] tempArr = new object[1];
            int typeNo;
            try
            {
                if (type.ToUpper().Equals("SHOP"))
                {
                    typeNo = 0;
                }
                else if (type.ToUpper().Equals("EQID"))
                {
                    typeNo = 1;
                }
                else if (type.ToUpper().Equals("EQIP"))
                {
                    typeNo = 2;
                }
                else
                {
                    return null;
                }

                foreach (string node in nodes)
                {
                    //对数组某行内容按‘:’进行分裂
                    string[] str = node.Trim().Split(':');

                    //将数据载入list
                    list.Add(str[typeNo]); // shop list
                }
                tempArr = (list.Distinct().ToList()).ToArray();//先做list的去重
            }
            catch (Exception)
            {
                throw;
            }
            return tempArr;
        }

        private static bool txtchecker(string eqid)
        {            
            bool checker = false;

            if (datatable != null)
            {
                //遍历式比较datatable中的Eqid和要输入的Eqid，有重复时结束循环并返回false
                foreach (DataRow dr in datatable.Rows)
                {
                    if (!eqid.Equals(dr["Eqid"].ToString()))
                    {
                        checker = true;
                    }
                    else
                    {
                        MessageBox.Show("EQID shoud not be repeated","Value Repeated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        checker = false;
                        return checker;
                    }
                }
            }
            return checker;
        }


        public void txtWrite(string eqData)
        {            
            string Shop = string.Empty;
            string Eqid = string.Empty;
            string Ip = string.Empty;
            
            try
            {
                if (!string.IsNullOrEmpty(eqData))
                {
                    //变量初始赋值
                    string[] eqdata = eqData.Split(':');
                    Shop = eqdata[0];
                    Eqid = eqdata[1];
                    Ip = eqdata[2];
                }
                else
                {
                    return;
                }
                if (txtchecker(Eqid) != false)
                {
                    //循环，将data插入到Table中，位置是与其有相同ShopName的
                    for (int i = 0; i < datatable.Rows.Count; i++)
                    {
                        string tempshop = ((datatable.Rows[i])["Shop"]).ToString();
                        if (tempshop == Shop)
                        {
                            DataRow dr = datatable.NewRow();
                            dr["Shop"] = Shop;
                            dr["Eqid"] = Eqid;
                            dr["Ip"] = Ip;

                            datatable.Rows.InsertAt(dr, i);
                            break; //插入完成直接跳出，防止重复插入同一项。
                        }
                    }
                }
                else
                {
                    return;
                }
                writeAction(datatable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void writeAction(DataTable dt)
        {
            Remote remote = new Remote();
            string temp = string.Empty;

            //将DataTable覆盖式写入Txt中
            foreach (DataRow dr in dt.Rows)
            {
                temp = temp + dr["Shop"] + ":" + dr["Eqid"] + ":" + dr["Ip"] + "\r\n";
            }
            File.WriteAllText(path, temp);//覆盖写入
            remote.BuildingTree(txtToTable());//重载入刷新TreeView

        }

    }
}