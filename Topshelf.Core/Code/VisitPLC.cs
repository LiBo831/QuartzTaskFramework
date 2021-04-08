﻿using NLog;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace Topshelf.Core
{
    public static class VisitPLC
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 网络状态
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool Ping(string ip)
        {
            PingReply pingStatus = new Ping().Send(IPAddress.Parse(ip), 1000); 
            return pingStatus.Status == IPStatus.Success ? true : false;
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="savepath">下载后另存为（全路径）</param>
        /// <param name="downpath">下载文件地址</param>
        /// <param name="ip">PLC IP地址</param>
        /// <returns></returns>
        public static bool DownloadFile(string savepath, string downpath, string ip)
        {
            bool result = true;
            string URL = downpath;
            string filename = savepath;
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            try
            {
                httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
                CookieContainer cookie = new CookieContainer();
                httpWebRequest.CookieContainer = cookie;
                httpWebRequest.ContentType = "application/octet-stream";
                httpWebRequest.Referer = URL.Substring(0, URL.IndexOf("/F")) + "/Portal/Portal.mwsl?PriNav=FileBrowser&Path=/DataLogs/";
                httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.101 Safari/537.36";
                httpWebRequest.Method = "GET";
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream st = httpWebResponse.GetResponseStream();
                Stream so = new FileStream(filename, FileMode.Create);
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    so.Write(by, 0, osize);
                    osize = st.Read(by, 0, (int)by.Length);
                }
                so.Close();
                st.Close();
            }
            catch (Exception e)
            {
                _log.Error($"文件下载错误:[{ip}]_____>原因:{e.Message}");
                result = false;
            }
            finally
            {
                if (httpWebRequest != null) httpWebRequest.Abort();
                if (httpWebResponse != null) httpWebResponse.Close();
            }
            return result;
        }


        /// <summary>
        /// 读取CSV文件通过文本格式
        /// </summary>
        /// <param name="savepath">下载后另存为（全路径）</param>
        /// <param name="downpath">下载文件地址</param>
        /// <param name="isNew">是否为新PLC</param>
        /// <param name="ip">IP地址</param>
        /// <returns></returns>
        public static DataTable readCsvTxt(string savepath, string downpath, string ip)
        {
            string strpath = savepath;
            int intColCount = 0;
            bool blnFlag = true;
            DataTable mydt = new DataTable("myTableName");
            DataColumn mydc;
            DataRow mydr;
            string strline;
            string[] aryline;
            //访问PLC数据文件（CSV）
            bool download = DownloadFile(savepath, downpath, ip);
            if (download)
            {
                try
                {
                    StreamReader mysr = new StreamReader(strpath, Encoding.Default);
                    while ((strline = mysr.ReadLine()) != null)
                    {
                        aryline = strline.Split(',');
                        if (aryline.Length > 1)
                        {
                            if (blnFlag)
                            {
                                blnFlag = false;
                                intColCount = aryline.Length;
                                for (int i = 0; i < aryline.Length; i++)
                                {
                                    mydc = new DataColumn(aryline[i]);
                                    mydt.Columns.Add(mydc);
                                }
                            }
                            mydr = mydt.NewRow();
                            for (int i = 0; i < intColCount; i++)
                            {
                                if (aryline[i].Trim() == "INF") { mydr[i] = 0; }
                                else if (aryline[i].Trim() == "NAN") { mydr[i] = 0; }
                                else { mydr[i] = aryline[i].Trim(); }
                            }
                            mydt.Rows.Add(mydr);
                        }
                    }
                    mysr.Dispose();
                    mysr.Close();
                    //移除第一行列名
                    mydt.Rows.RemoveAt(0);
                }
                catch (Exception ex) { _log.Error($"创建内存数据错误:[{ip}]_____>原因:{ex.Message}"); }
            }
            return mydt;
        }

        /// <summary>
        /// 科学计算法转换
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public static double ChangeDataToD(string strData)
        {
            try
            {
                double dData;
                if (strData.Contains("E"))
                {
                    dData = Math.Round(Convert.ToDouble(double.Parse(strData.Trim().ToString(), System.Globalization.NumberStyles.Float)), 4);
                    return dData;
                }
                else
                {
                    dData = Math.Round(Convert.ToDouble(strData.Trim()), 4);
                    return dData;
                }
            }
            catch(Exception ex)
            {
                _log.Error($"科学计数法转换失败，{strData}");
                return 0;
            }
        }
    }
}
