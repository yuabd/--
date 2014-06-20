using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Web.SessionState;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using Maticsoft.DBUtility;
using System.Collections;

namespace Maticsoft.Common
{
    public class webcommand
    {

        public String WebHost()
        {
            String tmp = "http://" + System.Web.HttpContext.Current.Request.Url.Host;
            int port = HttpContext.Current.Request.Url.Port;
            if (port != 80)
            {
                tmp += ":" + port.ToString();
            }
            return tmp;
        }

        /// <summary>
        /// 新闻类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public String getNewsType(String id) //显示新闻id 所对应的新闻类别
        {
            String sql = "select typename from newstype where id =" + id;
            return DbHelperOleDb.GetScalar(sql);
        }

        /// <summary>
        /// 产品类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public String GetProType(String id)
        {
            String sql = "select title from producttype where id =" + id;
            return DbHelperOleDb.GetScalar(sql);
        }

        /// <summary>
        /// 远程客户端IP
        /// </summary>
        /// <returns></returns>
        public string GetClientIP()
        {
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] == null)
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
            else
            {
                return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
        }

        #region 格式化时间

        public static String MarkTime(String timestr)
        {
            if (timestr != null && timestr != "")
            {
                return Convert.ToDateTime(timestr).ToString("yyyy-MM-dd");
            }
            else
            {
                return "";
            }
        }

        #endregion

        #region 判断是否为数字

        public static Boolean IsNum(String str)
        {
            Boolean isN = false;
            try
            {
                int i = Convert.ToInt32(str);
                isN = true;
            }
            catch (Exception ex)
            {
                isN = false;
            }
            return isN;
        }

        #endregion

        #region 检查登录帐号密码

        public void CheckUserPwd(String uname, String upass, String surl, String furl, String ctype)
        {
            String sql = "select id from manage where adminname = '" + uname + "' and adminpassword = '" + upass + "' ";
            String str = DbHelperOleDb.GetScalar(sql);
            if (Convert.ToInt32(str) > 0)
            {
                sql = "select intStatus from manage where id = " + str + " ";
                string strStatus = DbHelperOleDb.GetScalar(sql);
                if (strStatus != "0")
                {
                    System.Web.HttpContext.Current.Response.Write("<script>alert('抱歉，您帐号已被锁定，请联系管理员！');window.location.href='" + furl + "'</script>");
                }
                else
                {
                    System.Web.HttpContext.Current.Session["adminid"] = str;
                    System.Web.HttpContext.Current.Session["songadmin"] = uname;
                    sql = "update manage set strLoginIP='" + GetClientIP() + "',dtmLoginTime ='" + DateTime.Now + "',intLoginNum=intLoginNum+1 where id = " + str + " ";
                    DbHelperOleDb.ExecuteSql(sql);
                    System.Web.HttpContext.Current.Response.Write("<script>window.location.href='" + surl + "'</script>");
                }
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('抱歉，您帐号密码输入不正确，请重新输入！');window.location.href='" + furl + "'</script>");
            }
        }

        #endregion

        #region 获取管理员用户名

        public static String GetAdminName()
        {
            if (HttpContext.Current.Session["songadmin"] != null && HttpContext.Current.Session["songadmin"] != "")
            {
                return Convert.ToString(HttpContext.Current.Session["songadmin"]);
            }
            else
            {
                return "";
            }
        }

        #endregion

        #region 格式化密码

        public String FormatPwd(String pwd)
        {
            pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");
            return "021" + pwd + "1";
        }

        #endregion

        #region 去除单引号
        public String ToDBStr(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            return str.Replace("'", "''");
        }
        #endregion

        #region 获取当前语言版本Cookie

        public static String CurLang()
        {
            if (System.Web.HttpContext.Current.Request.Cookies["lang"] != null)
            {
                try
                {
                    String Lang = System.Web.HttpContext.Current.Request.Cookies["lang"].Value.ToString();
                    return Lang;
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        #endregion

        #region  绑定下拉框
        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        /// <param name="theobj"></param>
        /// <param name="dt">datatable</param>
        /// <param name="TextFiled">TextFiled</param>
        /// <param name="ValueFiled">ValueFiled</param>
        ///  <param name="defalutmsg">默认提示</param>
        public void BindDropDownList(System.Web.UI.WebControls.DropDownList thelist, System.Data.OleDb.OleDbDataReader dr, string TextFiled, string ValueFiled, string defalutmsg)
        {
            thelist.DataSource = dr;
            thelist.DataTextField = TextFiled;
            thelist.DataValueField = ValueFiled;
            thelist.DataBind();
            if (defalutmsg.Length > 0) thelist.Items.Insert(0, new System.Web.UI.WebControls.ListItem(defalutmsg, "0"));
        }
        #endregion

        #region 绑定下拉框（带SQL）

        /// <summary>
        /// 绑定下拉框（带SQL）
        /// </summary>
        /// <param name="thelist"></param>
        /// <param name="dr"></param>
        /// <param name="TextFiled"></param>
        /// <param name="ValueFiled"></param>
        /// <param name="defalutmsg"></param>
        /// <param name="sqlWhere"></param>
        public void BindProType(System.Web.UI.WebControls.DropDownList thelist, string sqlWhere)
        {
            String sql = "select id,title from producttype where 1=1  ";
            if (sqlWhere != null && sqlWhere != "")
            {
                sql += sqlWhere;
            }
            else
            {
                String pid = System.Web.HttpContext.Current.Request["pid"];
                if (pid != null && pid != "")
                {
                    sql += " and fid=0  and pid=" + pid;
                }
            }

            OleDbDataReader dr = DbHelperOleDb.ExecuteReader(sql);

            thelist.DataSource = dr;
            thelist.DataTextField = "title";
            thelist.DataValueField = "id";
            thelist.DataBind();
            thelist.Items.Insert(0, new System.Web.UI.WebControls.ListItem("请选择类别", "0"));
            dr.Close();
            dr.Dispose();
        }

        #endregion

        #region 绑定下拉框（带SQL）

        /// <summary>
        /// 绑定下拉框（带SQL）
        /// </summary>
        /// <param name="thelist"></param>
        /// <param name="dr"></param>
        /// <param name="TextFiled"></param>
        /// <param name="ValueFiled"></param>
        /// <param name="defalutmsg"></param>
        /// <param name="sqlWhere"></param>
        public void BindNewsType(System.Web.UI.WebControls.DropDownList thelist, string _pid, string[] strUserP = null)
        {
            String sql = "select id,title from newstype where 1=1  ";
            if (_pid != "")
            {
                //String pid = System.Web.HttpContext.Current.Request["pid"];
                String pid = _pid;
                if (pid != null && pid != "")
                {
                    if (pid == "132")
                    {
                        if (!bolAnswer("17", strUserP))
                            sql += " and id<>17 ";
                        if (!bolAnswer("18", strUserP))
                            sql += " and id<>18 ";
                        if (!bolAnswer("19", strUserP))
                            sql += " and id<>19 ";
                        if (!bolAnswer("20", strUserP))
                            sql += " and id<>20 ";
                        sql += "  and pid=" + pid;
                    }
                    else
                        sql += "  and pid=" + pid;
                }
            }

            OleDbDataReader dr = DbHelperOleDb.ExecuteReader(sql);

            thelist.DataSource = dr;
            thelist.DataTextField = "title";
            thelist.DataValueField = "id";
            thelist.DataBind();
            thelist.Items.Insert(0, new System.Web.UI.WebControls.ListItem("请选择类别", "0"));
            dr.Close();
            dr.Dispose();
        }

        #endregion

        #region 返回网站关键字

        public String Web_Title = "", Web_Key = "", Web_Des = "", Web_Copy = "", Web_Icp = "", Web_Script = "", Web_Tel = "";
        public void GetWebKey()
        {
            String id = "2";

            if (CurLang() == "en")
            {
                id = "1";
            }
            String sql = " select webname,webkey1,webkey2,webkey3,webcopyright,webicp,webtel from webconfig where id=" + id;
            OleDbDataReader dr = DbHelperOleDb.ExecuteReader(sql);
            while (dr.Read())
            {
                Web_Title = Convert.ToString(dr["webname"]);
                Web_Key = Convert.ToString(dr["webkey1"]);
                Web_Des = Convert.ToString(dr["webkey2"]);
                Web_Script = Convert.ToString(dr["webkey3"]);
                Web_Copy = Convert.ToString(dr["webcopyright"]);
                Web_Icp = Convert.ToString(dr["webicp"]);
                Web_Tel = Convert.ToString(dr["webtel"]);
            }
            dr.Close();
            dr.Dispose();
        }

        #endregion

        #region 返回关键词组

        public static String GetKeyInfo(String Title)
        {
            StringBuilder tmp = new StringBuilder();
            String id = "2";

            if (CurLang() == "en")
            {
                id = "1";
            }

            webcommand webcom = new webcommand();

            OleDbDataReader dr = DbHelperOleDb.ExecuteReader(" select * from webconfig where id=" + id + " ");
            while (dr.Read())
            {
                tmp.Append("<title>" + Title + " " + dr["webname"].ToString() + "</title>");
                tmp.Append("<meta name=\"keywords\" content=\"" + dr["webkey1"].ToString() + "\" />");
                tmp.Append("<meta name=\"description\" content=\"" + dr["webkey2"].ToString() + "\" />");
            }
            dr.Close();
            dr.Dispose();

            return tmp.ToString();
        }

        #endregion

        #region 返回底部公司信息组

        public static String GetCompayInfo()
        {
            StringBuilder tmp = new StringBuilder();
            String lan = "cn";

            if (CurLang() == "en")
            {
                lan = "en";
            }

            webcommand webcom = new webcommand();

            OleDbDataReader dr = DbHelperOleDb.ExecuteReader(" select * from webconfig where weblanguage='" + lan + "'");
            while (dr.Read())
            {
                tmp.Append(dr["webcopyright"].ToString());
            }
            dr.Close();
            dr.Dispose();

            return tmp.ToString();
        }

        public static String GetCompayInfo3()
        {
            StringBuilder tmp = new StringBuilder();
            String lan = "cn";

            if (CurLang() == "en")
            {
                lan = "en";
            }

            webcommand webcom = new webcommand();

            OleDbDataReader dr = DbHelperOleDb.ExecuteReader(" select * from webconfig where weblanguage='" + lan + "'");
            while (dr.Read())
            {
                tmp.Append(dr["webname"].ToString());
            }
            dr.Close();
            dr.Dispose();

            return tmp.ToString();
        }

        public static String GetCompayInfo4()
        {
            StringBuilder tmp = new StringBuilder();
            String lan = "cn";

            if (CurLang() == "en")
            {
                lan = "en";
            }

            webcommand webcom = new webcommand();

            OleDbDataReader dr = DbHelperOleDb.ExecuteReader(" select * from webconfig where weblanguage='" + lan + "'");
            while (dr.Read())
            {
                tmp.Append(dr["qq1"].ToString());
            }
            dr.Close();
            dr.Dispose();

            return tmp.ToString();
        }

        public static String GetCompayInfo5()
        {
            StringBuilder tmp = new StringBuilder();
            String lan = "cn";

            if (CurLang() == "en")
            {
                lan = "en";
            }

            webcommand webcom = new webcommand();

            OleDbDataReader dr = DbHelperOleDb.ExecuteReader(" select * from webconfig where weblanguage='" + lan + "'");
            while (dr.Read())
            {
                tmp.Append(dr["qq2"].ToString());
            }
            dr.Close();
            dr.Dispose();

            return tmp.ToString();
        }

        public static String GetCompayInfo6()
        {
            StringBuilder tmp = new StringBuilder();
            String lan = "cn";

            if (CurLang() == "en")
            {
                lan = "en";
            }

            webcommand webcom = new webcommand();

            OleDbDataReader dr = DbHelperOleDb.ExecuteReader(" select * from webconfig where weblanguage='" + lan + "'");
            while (dr.Read())
            {
                tmp.Append(dr["webkey1"].ToString());
            }
            dr.Close();
            dr.Dispose();

            return tmp.ToString();
        }

        public static String GetCompayInfo7()
        {
            StringBuilder tmp = new StringBuilder();
            String lan = "cn";

            if (CurLang() == "en")
            {
                lan = "en";
            }

            webcommand webcom = new webcommand();

            OleDbDataReader dr = DbHelperOleDb.ExecuteReader(" select * from webconfig where weblanguage='" + lan + "'");
            while (dr.Read())
            {
                tmp.Append(dr["webkey2"].ToString());
            }
            dr.Close();
            dr.Dispose();

            return tmp.ToString();
        }

        #endregion

        #region 弹出提示框

        public static void Alert(String msg, String url)
        {
            StringBuilder tmp = new StringBuilder();
            tmp.Append("<script>");

            if (msg != null && msg != "")
            {
                tmp.Append("alert('" + msg + "');");//提示错误消息
            }

            if (url != null && url != "")
            {
                tmp.Append("window.location.href='" + url + "';");//跳转页面
            }

            tmp.Append("</script>");
            System.Web.HttpContext.Current.Response.Write(tmp);

            //System.Web.UI.ScriptManager.RegisterStartupScript(System.Web.UI.Page, Page.GetType(), "ShowMsg", "alert('"+ msg +"')", true);

            if (url != "")
            {
                //System.Web.HttpContext.Current.Response.Redirect(url);
            }

        }

        #endregion

        #region 检查 用户是否登录

        public static void CheckUserLogin()
        {
            if (HttpContext.Current.Session["songadmin"].UString() == "")
            {
                webcommand.Alert("", "Logout.aspx");
            }
        }

        #endregion

        #region 检查 用户是否登录

        public void CheckWebLogin()
        {
            if (HttpContext.Current.Session["songuser"].UString() == "")
            {
                webcommand.Alert("", "login.aspx");
            }
        }

        #endregion

        #region 显示类别管理子类个数

        public String GetClassNum(String Fid)
        {
            webcommand webcom = new webcommand();
            String sql = "select count(id) from ClassManage where Fid ='" + Fid + "'";
            return Convert.ToString(DbHelperOleDb.GetScalar(sql));
        }

        #endregion

        #region 获取最大ID

        public String GetMax(String table)
        {
            String tmp = "0";

            String _tmp = DbHelperOleDb.GetScalar(" select max(id) from " + table + " ");

            if (_tmp != "")
            {
                tmp = Convert.ToString(Convert.ToInt32(_tmp) + 1);
            }

            return tmp;
        }

        #endregion

        #region 获取栏目名

        public String GetClassName(String id)
        {
            String tmp = "";
            if (id != null && id != "")
            {
                if (CurLang() == "en")
                {
                    String sql = " select EnName from ClassManage Where id=" + id;
                    tmp = DbHelperOleDb.GetScalar(sql);
                }
                else
                {
                    String sql = " select ClassName from ClassManage Where id=" + id;
                    tmp = DbHelperOleDb.GetScalar(sql);
                }
            }
            return Convert.ToString(tmp);
        }

        public String GetClassName1(String id)
        {
            String tmp = "";
            if (id != null && id != "")
            {

                String sql = " select title from producttype Where id=" + id;
                tmp = DbHelperOleDb.GetScalar(sql);

            }
            return Convert.ToString(tmp);
        }

        public String Getmp(String id)
        {
            String tmp = "";
            if (id != null && id != "")
            {

                String sql = " select top 1 Pic from MorePic Where photono='" + id + "'";
                tmp = DbHelperOleDb.GetScalar(sql);

            }
            return Convert.ToString(tmp);
        }

        public String Getmp1(String id)
        {
            String tmp = "";
            if (id != null && id != "")
            {

                String sql = " select  Pic from MorePic Where photono='" + id + "'";
                tmp = DbHelperOleDb.GetScalar(sql);

            }
            return Convert.ToString(tmp);
        }

        public String GetClassName2(String id)
        {
            String tmp = "";
            if (id != null && id != "")
            {

                String sql = " select title from producttype Where fid=" + id;
                tmp = DbHelperOleDb.GetScalar(sql);

            }
            return Convert.ToString(tmp);
        }

        public String GetenClassName(String id)
        {
            String tmp = "";
            if (id != null && id != "")
            {
                String sql = " select EnName from ClassManage Where id=" + id;
                tmp = DbHelperOleDb.GetScalar(sql);
            }
            return Convert.ToString(tmp);
        }
        #endregion

        #region 获取栏目第一个类

        public String GetFirstClass(String Fid)
        {
            String tmp = "";
            if (Fid != null && Fid != "")
            {
                String sql = " select top 1 id from ClassManage Where Fid=" + Fid + "  order by orderid asc,id asc  ";
                String tmp2 = DbHelperOleDb.GetScalar(sql);
                if (tmp2 != "")
                {
                    tmp = GetClassName(tmp2);
                }
            }
            return Convert.ToString(tmp);
        }

        #endregion

        #region 获取栏目名

        public String GetNewsType(String id)
        {
            if (id != null && id != "")
            {
                String sql = " select title from newstype Where id=" + id;
                String tmp = DbHelperOleDb.GetScalar(sql);
                return tmp;
            }
            return "";
        }

        #endregion

        #region 去除HTML
        /// <summary>
        /// 去除HTML标记
        /// </summary>
        /// <param name="strHtml">包括HTML的源码 </param>
        /// <returns>已经去除后的文字</returns>
        public static string StripHTML(string strHtml)
        {
            string[] aryReg ={
          @"<script[^>]*?>.*?</script>",

          @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",
          @"([\r\n])[\s]+",
          @"&(quot|#34);",
          @"&(amp|#38);",
          @"&(lt|#60);",
          @"&(gt|#62);", 
          @"&(nbsp|#160);", 
          @"&(iexcl|#161);",
          @"&(cent|#162);",
          @"&(pound|#163);",
          @"&(copy|#169);",
          @"&#(\d+);",
          @"-->",
          @"<!--.*\n"
         
         };

            string[] aryRep = {
           "",
           "",
           "",
           "\"",
           "&",
           "<",
           ">",
           " ",
           "\xa1",//chr(161),
           "\xa2",//chr(162),
           "\xa3",//chr(163),
           "\xa9",//chr(169),
           "",
           "\r\n",
           ""
          };

            string newReg = aryReg[0];
            string strOutput = strHtml;
            for (int i = 0; i < aryReg.Length; i++)
            {
                Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
                strOutput = regex.Replace(strOutput, aryRep[i]);
            }

            strOutput = System.Text.RegularExpressions.Regex.Replace(strOutput, "<[^>]+>", "");
            strOutput.Replace("\r\n", "");
            strOutput.Replace("&nbsp;", " ");

            return strOutput;
        }

        #endregion

        #region 显示新闻简介

        public String NewsFtile(String content, int len)
        {
            if (content != null && content != "")
            {
                content = StripHTML(content);
                if (content.Length > len)
                {
                    content = content.Substring(0, len) + "..";
                }
            }
            return content;
        }

        #endregion

        #region 截取字符串

        public static String MartStr(String str, int len)
        {
            if (str != "" && str.Length > len)
            {
                str = str.Substring(0, len);
                str += "..";
            }
            return str;
        }

        #endregion

        #region 增加新闻点击数

        public void NewsHitAdd(String id)
        {
            DbHelperOleDb.Query(" update news set hit=hit+1 where id=" + id);
        }

        #endregion

        #region 绑定Reader控件,使用完关闭数据资源
        /// <summary>
        /// 绑定Reader控件,使用完关闭数据资源
        /// </summary>
        /// <param name="repeater">Repater控件</param>
        /// <param name="sql">Sql语句</param>
        public void BindReaderControl(Repeater repeater, String sql)
        {
            OleDbDataReader dr = DbHelperOleDb.ExecuteReader(sql);
            repeater.DataSource = dr;
            repeater.DataBind();
            dr.Close();
            dr.Dispose();
        }

        #endregion

        #region 获取相关字段

        public String GetFiledList(String mid)
        {
            return DbHelperOleDb.GetScalar("select RulePower from FieldRule where id =" + mid);
        }

        #endregion 获取相关字段

        #region 生成编号

        public String CreateOrderno(String prefix)
        {
            String no = "";
            if (prefix != null)
            {
                no += prefix;
            }
            no += DateTime.Now.ToString("yyyyMMddHHmmssffff");
            return no;
        }

        #endregion

        #region 获取新闻最大ID

        public String NewsMax()
        {
            String tmp = "";
            tmp = DbHelperOleDb.GetScalar(" select max(id) from news ");
            if (tmp != "")
            {
                tmp = Convert.ToString(Convert.ToInt32(tmp) + 1);
            }
            else
            {
                tmp = "0";
            }
            return tmp;
        }

        #endregion

        #region 获取当前用户名

        public static String GetCurUser()
        {
            String tmp = "";
            if (HttpContext.Current.Session["songuser"].UString() != "")
            {
                tmp = Convert.ToString(HttpContext.Current.Session["songuser"]);
            }
            return tmp;
        }

        #endregion

        #region 设置当前用户名

        public void SetSession(String uname)
        {
            HttpContext.Current.Session["songuser"] = uname;
        }

        #endregion

        #region 设置当前用户名

        public void ClearSession()
        {
            HttpContext.Current.Session.RemoveAll();
        }

        #endregion

        #region 判断用户是否存在

        public Boolean CheckUser(String uname)
        {
            Boolean tmp = false;

            if (uname != "")
            {
                if (DbHelperOleDb.GetScalar(" select id from WebUser where username='" + uname + "' ") == "")
                {
                    tmp = true;
                }
            }

            return tmp;
        }

        #endregion

        #region 判断用户名密码是否正确

        public void UserLogin(String uname, String upass, String successurl, String falseurl)
        {
            if (DbHelperOleDb.GetScalar(" select id from WebUser where username='" + uname + "' and password='" + FormatPwd(upass) + "' ") != "")
            {
                if (DbHelperOleDb.GetScalar(" select userstate from WebUser where username='" + uname + "' ") == "True")
                {
                    SetSession(uname);
                    Alert("", successurl);
                }
                else
                {
                    if (CurLang() == "en")
                    {
                        Alert("Sorry!Your account is pending, please be patient, or contact our customer service!", falseurl);
                    }
                    else
                    {
                        Alert("抱歉！您账户正处于待审核状态中，请耐心等待，或联系本公司客服人员！", falseurl);
                    }
                }

            }
            else
            {
                if (CurLang() == "en")
                {
                    Alert("Sorry!The account password you entered is incorrect, please re-enter!", falseurl);
                }
                else
                {
                    Alert("抱歉！您输入的帐号密码不正确，请重新输入！", falseurl);
                }
            }
        }

        #endregion

        //发送邮件参数 收信人,发送内容
        public void SendEmail(String AcceptEmail, String title, String SendContent)
        {
            //发件箱信息
            //String send_smtp = "mail.qq.com";
            //String send_emailid = "512952654@qq.com";
            //String send_emailpw = "wxrdj@1314520";

            String send_smtp = "mail.king-long.com.cn";
            String send_emailid = "kingwings@mail.king-long.com.cn";
            String send_emailpw = "chenjin678";

            //初始化一个发邮件发件人地址
            MailAddress from = new MailAddress(send_emailid, title);
            //发邮件用到协议
            SmtpClient client = new SmtpClient(send_smtp);
            client.UseDefaultCredentials = false;

            //发邮件身份验证
            client.Credentials = new System.Net.NetworkCredential(send_emailid, send_emailpw);
            //发邮件的处理方式为使用网络方式
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //创建一个发邮件的对象
            MailMessage message = new MailMessage();
            message.From = from;
            string toemail = AcceptEmail;
            //收信人地址
            message.To.Add(toemail);

            //邮件主题
            message.Subject = title;
            //编码

            //生成临时密码 结束

            message.BodyEncoding = System.Text.Encoding.Default;
            //邮件正文

            message.Body = EmailContent(title, SendContent);
            //是否是HTML代码
            message.IsBodyHtml = true;

            //发送
            try
            {
                client.Send(message);

                message.Dispose();
            }
            catch
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('抱歉！邮件未发送成功！')</script>");
            }
        }

        public String EmailContent(String title, String usercontent)
        {
            String ImgUrl = "http://kingwings.king-long.com.cn/";
            String content = "";
            content += "<!DOCTYPE html PUBLIC \" -//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">";
            content += "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
            content += "<head>";
            content += "<title>" + title + "</title>";
            content += "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />";
            content += "<style type=\"text/css\">td img{display: block;}</style>";
            content += "<!--Fireworks 8 Dreamweaver 8 target.  Created Wed Dec 30 16:51:22 GMT+0800 2009-->";
            content += "</head>";
            content += "<body bgcolor=\"#ffffff\">";
            content += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"670\" style=\"font-size: 12px;color: #444;\" align=\"center\">";
            content += "  <tr>";
            content += "    <td><img src=\"" + ImgUrl + "images/email_top.gif\" border=\"0\" /></td>";
            content += "  </tr>";
            content += "  <tr>";
            content += "    <td background=\"" + ImgUrl + "images/email_line.gif\"><table width=\"640\" align=\"center\"  style=\"background:#f6f6f6; text-align:center;\">";
            content += "        <tr>";
            content += "          <td colspan=\"2\"><br />";
            content += "            <div style=\"font-size:14px;text-align:left;line-height:18px;padding:10px 30px;\">";
            content += "            " + usercontent + "";
            content += "            </div></td>";
            content += "        </tr>";
            content += "      </table></td>";
            content += "  </tr>";
            content += "  <tr>";
            content += "    <td><img src=\"" + ImgUrl + "images/email_bot.gif\" border=\"0\" /></td>";
            content += "  </tr>";
            content += "</table>";
            content += "</body>";
            content += "</html>";
            return content;
        }

        #region 删除表对应图片
        /// <summary>
        /// 删除表对应图片
        /// </summary>
        /// <param name="idlist">idlist：1,2,3</param>
        /// <param name="pField">字段</param>
        /// <param name="pTable">表名</param>
        public void DelPic(String idlist, String pField, String pTable)
        {
            FileControl fc = new FileControl();
            OleDbDataReader dr = DbHelperOleDb.ExecuteReader(" select " + pField + " from " + pTable + " where id in(" + idlist + ")");
            System.Web.HttpContext.Current.Response.Write(" select " + pField + " from " + pTable + " where id in(" + idlist + ")");

            while (dr.Read())
            {
                fc.DelFile("/UploadFile/Spic/" + dr[pField].ToString());
                fc.DelFile("/UploadFile/Pic/" + dr[pField].ToString());
            }
            dr.Close();
            dr.Dispose();
        }

        #endregion

        #region 分页

        public DataSet GetCurrentPage(String sql, int pageIndex, int pageSize)
        {
            OleDbConnection conn = new OleDbConnection(PubConstant.ConnectionString);
            OleDbDataAdapter da = new OleDbDataAdapter();
            int firstPage = pageIndex * pageSize;
            da = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, 0, pageSize, "0");
            conn.Close();
            conn.Dispose();
            return ds;
        }

        #endregion

        public static bool bolAnswer(string answer, string[] correctList)
        {
            bool Correct = true;
            if (!((IList)correctList).Contains(answer))
            {
                Correct = false;
            }
            return Correct;
        }

        /// <summary>
        /// 获取图文简介
        /// </summary>
        /// <param name="Infoid">信息ID</param>
        /// <param name="intType">返回内容类别：1文字内容；2图片路径</param>
        /// <returns></returns>
        public static string GetInfo(int Infoid, int intType)
        {
            String str = "";
            String sql = "";
            if (intType == 1)
                sql = " select information from companyInformation Where pid=" + Infoid;
            else
                sql = " select pic from companyInformation Where pid=" + Infoid;
            str = DbHelperOleDb.GetScalar(sql);
            return str;
        }

        /// <summary>
        /// 获取公司信息
        /// </summary>
        /// <param name="Infoid">信息ID</param>
        /// <param name="intType">返回内容类别：name是字段；intTypes是id</param>
        /// <returns></returns>
        public static string Getinfom(string name, int intType2)
        {

            String str = "";
            String sql = "";
            sql = "select [" + name + "]  from webconfig where id=" + intType2;
            str = DbHelperOleDb.GetScalar(sql);
            return str;
        }


        public static string Getinfom1(string name, int intType2)
        {
            String str = "";
            String sql = "";
            sql = "select [" + name + "]  from companyInformation where id=" + intType2;
            str = DbHelperOleDb.GetScalar(sql);
            return str;
        }
    }
}
