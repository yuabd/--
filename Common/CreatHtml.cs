using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace Maticsoft.Common
{
    public class CreatHtml
    {
        /// <param name="strRelPath">创建的路径及文件名,路径为相对路径</param>     
        public bool Nei_Create(string strURL, string strRelPath)
        {
            string strFilePage;

            strFilePage = HttpContext.Current.Server.MapPath(strRelPath);
            StreamWriter sw = null;
            //获得aspx的静态html     
            try
            {

                if (File.Exists(strFilePage))
                {
                    File.Delete(strFilePage);
                }
                sw = new StreamWriter(strFilePage, false, System.Text.Encoding.GetEncoding("utf-8"));
                System.Net.WebRequest wReq = System.Net.WebRequest.Create(strURL);
                System.Net.WebResponse wResp = wReq.GetResponse();
                System.IO.Stream respStream = wResp.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(respStream, System.Text.Encoding.GetEncoding("utf-8"));
                string strTemp = reader.ReadToEnd();

                Regex r1 = new Regex("<input type=\"hidden\"  name=\"__EVENTTARGET\".*/>", RegexOptions.IgnoreCase);
                Regex r2 = new Regex("<input type=\"hidden\"  name=\"__EVENTARGUMENT\".*/>", RegexOptions.IgnoreCase);
                Regex r3 = new Regex("<input type=\"hidden\"  name=\"__VIEWSTATE\".*/>", RegexOptions.IgnoreCase);

                Regex r4 = new Regex("<form .*id=\"form1\">", RegexOptions.IgnoreCase);
                Regex r5 = new Regex("</form>");

                Regex r6 = new Regex("<input type=\"hidden\" name=\"__EVENTVALIDATION\".*/>", RegexOptions.IgnoreCase);
                strTemp = r1.Replace(strTemp, "");
                strTemp = r2.Replace(strTemp, "");
                strTemp = r3.Replace(strTemp, "");
                strTemp = r4.Replace(strTemp, "");
                strTemp = r5.Replace(strTemp, "");
                strTemp = r6.Replace(strTemp, "");

                sw.Write(strTemp);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                HttpContext.Current.Response.End();
                return false;//生成到出错     
            }
            finally
            {
                sw.Flush();
                sw.Close();
                sw = null;
            }

            return true;
        }
        /// <summary>     
        /// 生成静态页面,生成位置不在本项目下     
        /// </summary>     
        /// <param name="strURL">请求的URL</param>     
        /// <param name="strRelPath">创建的路径及文件名，路径为绝对路径</param>     
        public bool Wai_Create(string strURL, string strRelPath, string filename)
        {
            string strFilePage;
            strFilePage = strRelPath + "//" + filename;
            StreamWriter sw = null;
            //获得aspx的静态html     
            try
            {
                if (!Directory.Exists(strRelPath))
                {
                    Directory.CreateDirectory(strRelPath);
                }
                if (File.Exists(strFilePage))
                {
                    File.Delete(strFilePage);
                }
                sw = new StreamWriter(strFilePage, false, System.Text.Encoding.GetEncoding("gb2312"));
                System.Net.WebRequest wReq = System.Net.WebRequest.Create(strURL);
                System.Net.WebResponse wResp = wReq.GetResponse();
                System.IO.Stream respStream = wResp.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(respStream, System.Text.Encoding.GetEncoding("gb2312"));
                string strTemp = reader.ReadToEnd();

                Regex r1 = new Regex("<input type=\"hidden\" name=\"__EVENTTARGET\".*/>", RegexOptions.IgnoreCase);
                Regex r2 = new Regex("<input type=\"hidden\" name=\"__EVENTARGUMENT\".*/>", RegexOptions.IgnoreCase);
                Regex r3 = new Regex("<input type=\"hidden\" name=\"__VIEWSTATE\".*/>", RegexOptions.IgnoreCase);

                Regex r4 = new Regex("<form .*id=\"form1\">", RegexOptions.IgnoreCase);
                Regex r5 = new Regex("</form>");

                Regex r6 = new Regex("<input type=\"hidden\" name=\"__EVENTVALIDATION\".*/>", RegexOptions.IgnoreCase);
                strTemp = r1.Replace(strTemp, "");
                strTemp = r2.Replace(strTemp, "");
                strTemp = r3.Replace(strTemp, "");
                strTemp = r4.Replace(strTemp, "");
                strTemp = r5.Replace(strTemp, "");
                strTemp = r6.Replace(strTemp, "");

                sw.Write(strTemp);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                HttpContext.Current.Response.End();
                return false;//生成到出错     
            }
            finally
            {
                sw.Flush();
                sw.Close();
                sw = null;
            }

            return true;

        }

        public void FilePicDelete(string path)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
                file.Delete();
        }    
    }
}
