using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace RemoteCIMPC
{
    public class CmdHelper
    {
        private static string CmdPath = @"C:\Windows\System32\cmd.exe";

        private static string normalReturn = string.Empty;
        private static string errorReturn = string.Empty;

        /// <summary>
        /// 执行cmd命令
        /// 多命令请使用批处理命令连接符：
        /// <![CDATA[
        /// &:同时执行两个命令
        /// |:将上一个命令的输出,作为下一个命令的输入
        /// &&：当&&前的命令成功时,才执行&&后的命令
        /// ||：当||前的命令失败时,才执行||后的命令]]>
        /// 其他请百度
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="output"></param>
        public static void RunCmd(string cmd)
        {


            try
            {
                cmd = cmd.Trim().TrimEnd('&') + "&exit";
                //说明：不管命令是否成功均执行exit命令，否则当调用ReadToEnd()方法时，会处于假死状态
                Process p = new Process();
                p.StartInfo.FileName = CmdPath;
                p.StartInfo.UseShellExecute = false;        //是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;   //接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;  //由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;   //重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;         //不显示程序窗口
                p.Start();//启动程序
                p.StandardInput.AutoFlush = true;

                //向cmd窗口写入命令
                p.StandardInput.WriteLine(cmd);
                // 关闭StandardInput流
                p.StandardInput.Close();

                //获取cmd窗口的输出信息
                normalReturn = p.StandardOutput.ReadToEnd();
                errorReturn = p.StandardError.ReadToEnd();

                //等待程序执行完退出进程,为防止dos执行卡顿导致窗口也会卡顿，设定为3秒
                p.WaitForExit(300);
                p.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static string getReturn()
        {
            string returnMsg = string.Empty;

            if (!string.IsNullOrEmpty(normalReturn))
            {
                returnMsg = normalReturn.Trim();
            }
            else if (!string.IsNullOrEmpty(errorReturn))
            {
                returnMsg = errorReturn.Trim();
            }

            return returnMsg;
        }


    }
}