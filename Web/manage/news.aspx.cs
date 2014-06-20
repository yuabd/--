using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using Maticsoft.Common;
using Maticsoft.DBUtility;
using System.Collections;

namespace Song.Web.manage
{
    public partial class news : System.Web.UI.Page
    {
        public String ComUrl = "", action = "", pid = "", mid = "", id = "", idlist = "", page = "", FieldList = "", MoreNo = "", rid = "", keyword = "", ClassName = "";
        webcommand webcom = new webcommand();
        FileControl fc = new FileControl();
        FormatHtml fh = new FormatHtml();
        BLL.news bll = new BLL.news();
        Model.news model = new Model.news();
        private string[] strUserP = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            webcommand webcom = new webcommand();
            webcommand.CheckUserLogin();
            BLL.manage ubll = new BLL.manage();
            var adminid = (Session["adminid"]).Uint();
            if (adminid != 0)
            {
                var model = ubll.GetModel(adminid);
                strUserP = model != null ? model.adminlv.Split(',') : null;
                if (!string.IsNullOrEmpty(Request.QueryString["pid"]))
                    pid = Request.QueryString["pid"];
                if (!string.IsNullOrEmpty(Request.QueryString["idlist"]))
                    idlist = Request.QueryString["idlist"];
                if (!string.IsNullOrEmpty(Request.QueryString["page"]))
                    page = Request.QueryString["page"];
                if (!string.IsNullOrEmpty(Request.QueryString["mid"]))
                    mid = Request.QueryString["mid"];
                if (!string.IsNullOrEmpty(Request.QueryString["rid"]))
                    rid = Request.QueryString["rid"];//排序ID
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(Request.QueryString["key"]))
                    keyword = Request.QueryString["key"];

                if (mid != null && mid != "")
                {
                    FieldList = webcom.GetFiledList(mid);
                }
                ClassName = webcom.GetClassName(pid);

                ComUrl = "pid=" + pid + "&mid=" + mid;
                if (keyword != null && keyword != "")
                {
                    ComUrl += "&key=" + keyword;
                }

                if (!bolAnswer(pid + "Add", strUserP))
                {
                    Button4.Enabled = false;
                    Button4.Attributes.Add("disabled", "disabled");
                    Button2.Enabled = false;
                    Button2.Attributes.Add("disabled", "disabled");
                }
                if (!bolAnswer(pid + "Del", strUserP))
                {
                    Button5.Enabled = false;
                    Button5.Attributes.Add("disabled", "disabled");
                    delectmessage.Enabled = false;
                    delectmessage.Attributes.Add("disabled", "disabled");
                }

                action = Request.QueryString["action"];

                if (!IsPostBack)
                {
                    switch (action)
                    {
                        case "delete"://删除
                            DeleteInfo();
                            break;
                        case "addnew":
                            MoreNo = webcom.CreateOrderno("M");
                            hid_more.Value = MoreNo;
                            loadtype();//加载数据类型
                            break;
                        case "edit":
                            loadtype();//加载数据类型
                            loadedit();
                            break;
                        case "up"://往前移一位
                            uptype();
                            break;
                        case "down"://往前移一位
                            downtype();
                            break;
                        default:
                            bindData();//加载信息列表
                            break;
                    }
                }
            }
            else
            {
                webcommand.Alert("", "Logout.aspx");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            String filepath = "", sql, _moreno = "", _newstype = "0", _photo;
            Boolean isNewsShow;
            _moreno = this.hid_more.Value;


            //上传图片 开始
            if (this.newsphoto.HasFile)//当有图片的时候
            {
                if (pid == "157")
                    filepath = fc.CreateSimPic(this.newsphoto, "", 98, 28, 750, 300);
                else if (pid == "166")
                    filepath = fc.CreateSimPic(this.newsphoto, "", 20, 16, 200, 160);
                else if (pid == "168" || pid == "169" || pid == "170")
                    filepath = fc.CreateSimPic(this.newsphoto, "", 136, 136, 136, 136);
            }
            else
            {
                filepath = this.hid_photo.Value;
            }
            //上传图片 结束

            if (this.newstype.SelectedValue != "")
            {
                _newstype = this.newstype.SelectedValue;
            }

            //判断是否显示新闻
            if (this.isShow.Checked)
            {
                isNewsShow = true;
            }
            else
            {
                isNewsShow = false;
            }

            model.pid = Convert.ToInt32(pid);
            model.title = fh.NoHTML(this.title.Text);
            model.entitle = "";
            model.isShow = isNewsShow;
            model.newstype = Convert.ToInt32(_newstype);
            model.photo = filepath;
            model.content = fh.ToDBStr(this.txtContent.Value);
            model.encontent = "";
            model.timeinfo = DateTime.Now;
            model.orderid = Convert.ToInt32(webcom.NewsMax());
            model.hit = 0;
            model.moreno = "";
            model.links = fh.ToDBStr(this.Links.Text);
            model.key1 = fh.ToDBStr(this.key1.Value);
            model.key2 = fh.ToDBStr(this.key2.Value);
            model.text1 = "";
            model.text2 = "";
            model.text3 = hid_more.Value;

            //判断是添加数据还是修改数据 
            if (action == "addnew")
            {
                bll.Add(model);
                MessageBox.ShowAndRedirect(this, "添加信息成功！", "news.aspx?action=manage&" + ComUrl);
            }
            else
            {
                model.id = Convert.ToInt32(id);
                model.timeinfo = Convert.ToDateTime(this.hid_time.Value);
                bll.Update(model);
                MessageBox.ShowAndRedirect(this, "修改信息成功！", "news.aspx?action=manage&" + ComUrl);
            }


        }

        //删除信息[ID列表]
        protected void DeleteInfo()
        {
            if (idlist != null && idlist != "")
            {
                bll.DeleteList(idlist);
                MessageBox.ShowAndRedirect(this, "删除信息成功！", "news.aspx?action=manage&" + ComUrl);
            }
            else
            {
                MessageBox.ShowAndRedirect(this, "请选择要删除的信息！", "news.aspx?action=manage&" + ComUrl);
            }
        }

        #region 检测图片

        public String CheckPic(String pic)
        {
            if (pic != "" && pic != "nophoto")
            {
                return "/UploadFile/Pic/" + pic;
            }
            else
            {
                return "images/nopic.jpg";
            }
        }

        #endregion

        //加载类别
        protected void loadtype()
        {
            webcom.BindNewsType(this.newstype, "");
        }

        protected void bindData()
        {
            webcommand webcom = new webcommand();
            String key = Request.QueryString["key"];
            System.Text.StringBuilder sqlWhere = new System.Text.StringBuilder();
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            System.Text.StringBuilder sqlStr = new System.Text.StringBuilder();
            sql.Append("select  count(id) from news where 1=1 ");

            if (pid != null && pid != "")
            {
                sqlWhere.Append(" and pid=" + pid);
            }

            if (keyword != null && keyword != "")
            {
                sqlWhere.Append(" and title like '%" + Server.UrlDecode(keyword) + "%' ");
            }

            sql.Append(sqlWhere.ToString());
            int CountData = Convert.ToInt32(DbHelperOleDb.GetScalar(sql.ToString()));//当前总条数
            int CurrentPage = this.AspNetPager1.CurrentPageIndex;//当前页
            //curpage = Convert.ToString(CurrentPage);
            //totalpage = AspNetPager1.PageCount.ToString();//总页数
            this.AspNetPager1.RecordCount = CountData;
            int pageIndex = CurrentPage - 1;
            int pageSize = this.AspNetPager1.PageSize = 12;

            this.AspNetPager2.RecordCount = CountData;
            this.AspNetPager2.PageSize = 12;

            if (CountData == 0)
            {
                this.nolist.Text = "· 抱歉，暂无相关信息！";
            }
            if (pageIndex == 0)
            {
                sqlStr.Append("select top " + pageSize.ToString() + " id,title,newstype,photo,isShow,timeinfo,orderid from news where 1=1  ");
            }
            else
            {
                sqlStr.Append("select top " + pageSize.ToString() + " id,title,newstype,photo,isShow,timeinfo,orderid from news where id not in( select top " + Convert.ToString(pageIndex * pageSize) + " id from news where 1=1 " + Convert.ToString(sqlWhere) + "  order by orderid desc, id desc )   ");
            }

            sqlStr.Append(sqlWhere);
            sqlStr.Append(" order by orderid desc,id desc ");

            this.DList.Visible = true;
            this.DList.DataSource = webcom.GetCurrentPage(sqlStr.ToString(), pageIndex, pageSize);
            this.DList.DataBind();

        }


        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bindData();
        }

        protected void delectmessage_Click(object sender, EventArgs e)
        {
            idlist = Request.Form["selectmessage"];
            if (idlist != null && idlist != "")
            {
                bll.DeleteList(idlist);
                MessageBox.ShowAndRedirect(this, "删除数据成功！", "news.aspx?action=manage&" + ComUrl);
            }
            else
            {
                MessageBox.ShowAndRedirect(this, "请选择要删除的信息！", "news.aspx?action=manage&" + ComUrl);
            }
        }

        //当处于修改数据时调用 
        protected void loadedit()
        {
            model = bll.GetModel(Convert.ToInt32(id));
            this.title.Text = model.title;
            if (Convert.ToBoolean(model.isShow) == true)
            {
                this.isShow.Checked = true;//判断显示或者隐藏
            }
            else
            {
                this.isShow.Checked = false;
            }
            this.newstype.SelectedValue = model.newstype.ToString();
            this.txtContent.Value = model.content;
            String _moreno = model.moreno;

            if (_moreno != "")
            {
                MoreNo = _moreno;
            }
            else
            {
                MoreNo = webcom.CreateOrderno("M");
            }
            String photo = model.photo;
            if (photo != "" && photo != "nophoto")
            {
                this.photoshow.Text = "<img src='/UploadFile/spic/" + photo + "' height='100px' />";
            }
            this.hid_photo.Value = photo;
            this.hid_time.Value = model.timeinfo.ToString();
            this.hid_more.Value = MoreNo;
            this.Links.Text = model.links;
            this.key1.Value = model.key1;
            this.key2.Value = model.key2;
            hid_more.Value = MoreNo = model.text3;
            this.Button1.Text = "修改信息";//将按钮的文字改过来
        }

        public String getClassName(String id)
        {
            return webcom.GetNewsType(id);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("news.aspx?action=addnew&" + ComUrl + "");
        }

        #region 控制表字段

        public String ShowField(String Filed)
        {
            ManageCom mc = new ManageCom();
            return mc.ShowField(Filed, FieldList);
        }

        #endregion

        #region 排序 》升序
        protected void uptype()
        {
            ManageCom MCom = new ManageCom();

            if (rid != null && rid != "")
            {
                MCom.UpOrDown("down", "", "news", " Pid = " + pid + " ", rid, id, "?pid=" + pid);
            }
        }
        #endregion

        #region 排序 》降序
        protected void downtype()
        {
            ManageCom MCom = new ManageCom();

            if (rid != null && rid != "")
            {
                MCom.UpOrDown("up", "", "news", " pid = " + pid + " ", rid, id, "?pid=" + pid);
            }
        }
        #endregion

        protected void Button3_Click(object sender, EventArgs e)
        {
            String _key = this.key.Text;
            webcommand.Alert("", "news.aspx?pid=" + pid + "&key=" + Server.UrlEncode(_key) + "");
        }

        protected void manageproductlist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            BLL.news bll = new BLL.news();
            switch (e.CommandName)
            {
                case "Del":
                    bll.Delete(Convert.ToInt32(id));
                    break;
                case "Update":
                    Response.Redirect("news.aspx?" + ComUrl + "&action=edit&id=" + id);
                    break;
            }
            bindData();
        }

        protected void manageproductlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                LinkButton btn = (LinkButton)e.Item.FindControl("lbtn_Del");
                if (!bolAnswer(pid + "Del", strUserP))
                {
                    btn.Enabled = false;
                    btn.Attributes.Add("disabled", "disabled");
                }
                else
                    btn.Attributes.Add("onclick", "javascript:return confirm('您确定要删除此信息？删除后将不可恢复！')");

                btn = (LinkButton)e.Item.FindControl("lbtn_Update");
                if (!bolAnswer(pid + "Update", strUserP))
                {
                    btn.Enabled = false;
                    btn.Attributes.Add("disabled", "disabled");
                }
            }
        }

        public static bool bolAnswer(string answer, string[] correctList)
        {
            bool Correct = true;
            if (correctList != null)
            {
                if (!((IList)correctList).Contains(answer))
                {
                    Correct = false;
                }
            }
            return Correct;
        }
    }
}