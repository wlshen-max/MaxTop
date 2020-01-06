using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.IO;

namespace RemoteCIMPC
{
    class SqlHelper
    {
        private readonly string _path = @"D:\TEST.FDB";
        private string _strConn = "";
        private FbConnection _conn = null;

        public void loadlocal(bool isServer)
        {
            _strConn = isServer ? connConfig_Server() : connConfig_Client();
            _conn = new FbConnection(_strConn);
        }

        private string connConfig_Server()
        {
            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.UserID = "SYSDBA";
            cs.Password = "masterkey";
            cs.Database = _path;
            cs.DataSource = "127.0.0.1"; // "localhost";
            cs.Charset = "UTF8";   // "GB_2312";
            cs.Port = 3050;
            cs.Dialect = 3;
            cs.Role = string.Empty;
            cs.ConnectionLifeTime = 15;
            cs.Pooling = true;
            cs.MinPoolSize = 0;
            cs.MaxPoolSize = 50;
            cs.PacketSize = 8192;   // pageSize
            cs.ServerType = 0;
            //cs.ServerType = FbServerType.Default;
            return cs.ToString();
        }

        /// <summary>
        /// 嵌入式连接
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string connConfig_Client()
        {
            FbConnectionStringBuilder cs = new FbConnectionStringBuilder();
            cs.ClientLibrary = @"C:\Program Files\Firebird\Firebird_2_1\binfbembed.dll";
            cs.UserID = "SYSDBA";
            cs.Password = "masterkey";
            cs.Database = _path;
            cs.Charset = "UTF8";
            cs.ServerType = FbServerType.Embedded;
            return cs.ToString();
        }

        private void MyOpen()
        {
            if (_conn.State != ConnectionState.Open)
                _conn.Open();
        }

        private void MyClose()
        {
            if (_conn.State != ConnectionState.Closed)
                _conn.Close();
        }

        /// <summary>
        /// 数据库连接测试 (链接目标库)
        /// </summary>
        public bool ConnectTest()
        {
            loadlocal(true);
            try
            {
                _conn = new FbConnection(_strConn);
                MyOpen();
                MyClose();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //MessageBox.Show(string.Format($"连接失败，原因如下：{ex.Message}"));
                return false;
            }
        }

        /// <summary>  
        /// 执行SQL,返回读取到的数据
        /// </summary>  
        public DataTable getSqlToDt()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT a.SHOP, a.EQID, a.EQIP, a.UPDATETIME FROM EQDATA a";

            if (ConnectTest())
            {
                try
                {
                    MyOpen();
                    FbCommand cmd = new FbCommand(sql, _conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 60;
                    FbDataAdapter fbAda = new FbDataAdapter(cmd);
                    fbAda.Fill(dt);
                    fbAda.Dispose();
                    cmd.Dispose();
                    MyClose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format($"读取失败，原因如下：{ex.Message}"));
                }
            }
            return dt;
        }

        /// <summary>  
        /// 执行SQL,写入数据
        /// </summary>  
        public void setDtToSql(DataTable dt)
        {
            string sql = string.Empty;
            string temp = string.Empty;
            string shop = string.Empty;
            string eqid = string.Empty;
            string eqip = string.Empty;
            string time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:sss");
            

            foreach (DataRow dr in dt.Rows)
            {
                shop = dr[0].ToString();
                eqid = dr[1].ToString();
                eqip = dr[2].ToString();

                temp = string.Format("INSERT INTO EQDATA (SHOP, EQID, EQIP, UPDATETIME) VALUES ('{0}', '{1}', '{2}', '{3}');", shop, eqid, eqip, time);

                if (string.IsNullOrEmpty(sql))
                {
                    sql = temp;
                }
                else
                {
                    sql = sql + "/r/n" + temp;
                }

                sql += temp;
                
            }
            File.WriteAllText(@"temp.text", sql);
            sql = File.ReadAllText(@"temp.text");
            writeSql(sql);
        }


        private void writeSql(string sql)
        {

            if (ConnectTest())
            {
                try
                {
                    MyOpen();
                    FbCommand cmd = new FbCommand(sql, _conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 60;
                    int res = cmd.ExecuteNonQuery();
                    //                    FbDataAdapter fbAda = new FbDataAdapter(cmd);
                    //                    fbAda.Dispose();
                    MessageBox.Show(string.Format("Write sucessfull, use time:{0}",res));
                    cmd.Dispose();
                    MyClose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format($"写入失败，原因如下：{ex.Message}"));
                }
            }
        }



        /// <summary>  
        /// 执行SQL,返回受影响的行数  
        /// </summary>  
        public int getNonQuery(string sql)
        {
            MyOpen();
            FbCommand cmd = new FbCommand(sql, _conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 60;
            int res = cmd.ExecuteNonQuery();
            cmd.Dispose();
            MyClose();
            return res;
        }







    }
}