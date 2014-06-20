using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.Configuration;
using System.IO;
using System.Data.OleDb;
using Song.BLL;
using Song.Model;
using Maticsoft.Common;
using Maticsoft.DBUtility;
using System.Web.UI.WebControls;

namespace Song.Web.manage
{
    public partial class ProductsInfo : System.Web.UI.Page
    {
        webcommand webcom = new webcommand();
        FormatHtml fh = new FormatHtml();
        FileControl fc = new FileControl();
        BLL.products bllProducts = new BLL.products();
        Model.products modelProducts = new Model.products();
        public String action = "", ClassName = "", ComUrl = "", pid = "", topid = "", mid = "", rid = "", bid = "", sid = "", id = "", FieldList = "";
        private string[] strUserP = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDefault();
        }
        public static bool bolAnswer(string answer, string[] correctList)
        {
            bool Correct = true;
            if (!((IList)correctList).Contains(answer))
            {
                Correct = false;
            }
            return Correct;
        }
        #region 加载默认设置

        protected void LoadDefault()
        {
            webcommand.CheckUserLogin();
            BLL.manage ubll = new BLL.manage();
            strUserP = ubll.GetModel(Convert.ToInt32(Session["adminid"] + "")).adminlv.Split(',');
            action = Request.QueryString["action"];
            pid = Request.QueryString["pid"];
            rid = Request.QueryString["rid"];
            bid = Request.QueryString["bid"];
            sid = Request.QueryString["sid"];
            mid = Request.QueryString["mid"];
            topid = Request.QueryString["topid"];
            id = Request.QueryString["id"];

            ClassName = webcom.GetClassName(pid);

            //公用参数
            ComUrl = "pid=" + pid + "&mid=" + mid;

            if (mid != null && mid != "")
            {
                FieldList = webcom.GetFiledList(mid);
            }
            if (!bolAnswer(pid + "Add", strUserP))
            {
                Button4.Enabled = false;
                Button4.Attributes.Add("disabled", "disabled");
                delectmessage.Enabled = false;
                delectmessage.Attributes.Add("disabled", "disabled");
            }
            if (!bolAnswer(pid + "Del", strUserP))
            {
                Button3.Enabled = false;
                Button3.Attributes.Add("disabled", "disabled");
                Button5.Enabled = false;
                Button5.Attributes.Add("disabled", "disabled");
            }
            if (!IsPostBack)
            {
                switch (action)
                {
                    case "addproduct"://添加信息
                        this.saletime.Value = DateTime.Now.ToString();
                        webcom.BindProType(this.producttype, " and pid=" + pid + " and fid=0 ");//加载信息类别
                        webcom.BindProType(this.Material, " and pid=14 and fid=0 ");//加载材质
                        break;
                    case "edit":
                        webcom.BindProType(this.producttype, " and pid=" + pid + "  and fid=0 ");//加载信息类别
                        webcom.BindProType(this.Material, " and pid=14 and fid=0 ");//加载材质
                        loadedit();
                        break;
                    case "delete":
                        DeleteInfo();
                        break;
                    case "up"://往前移一位
                        uptype();
                        break;
                    case "down"://往前移一位
                        downtype();
                        break;
                    default:
                        webcom.BindProType(this.searchtype, "  and pid=66 and fid=0  ");//加载信息类别
                        bindData();
                        break;
                }
            }
        }

        #endregion

        #region 排序 》升序
        protected void uptype()
        {
            ManageCom MCom = new ManageCom();

            if (rid != null && rid != "")
            {
                MCom.UpOrDown("down", "", "products", " pid = " + pid + " ", rid, id, "?" + ComUrl);
            }
        }
        #endregion

        #region 排序 》降序
        protected void downtype()
        {
            ManageCom MCom = new ManageCom();

            if (rid != null && rid != "")
            {
                MCom.UpOrDown("up", "", "products", " pid = " + pid + " ", rid, id, "?" + ComUrl);
            }
        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            String filepath = "", filepathbig = "", sql = "", _type1 = "0", _type2 = "0", _type3 = "0", _type4 = "0";
            Boolean isproductShow, isproductNew, isRecommend, isHot;

            //上传图片 小图 开始
            if (this.productphoto.HasFile)//当有图片的时候
            {
                filepath = fc.CreateSimPic(this.productphoto, "", 114, 154, 114, 154);
            }
            else
            {
                filepath = this.productphotoid.Value;
            }

            //上传图片 大图 开始
            if (this.productphotobig.HasFile)//当有图片的时候
            {
                filepathbig = fc.CreateSimPic(this.productphotobig, "");
            }
            else
            {
                filepathbig = this.productphotobigid.Value;
            }

            //判断是否显示信息
            if (this.isShow.Checked)
            {
                isproductShow = true;
            }
            else
            {
                isproductShow = false;
            }

            //判断是否为新信息
            if (this.isNew.Checked)
            {
                isproductNew = true;
            }
            else
            {
                isproductNew = false;
            }

            //判断是否为推荐信息
            if (this.isRecommend.Checked)
            {
                isRecommend = true;
            }
            else
            {
                isRecommend = false;
            }

            //判断是否为热销信息
            if (this.isRecommend.Checked)
            {
                isHot = true;
            }
            else
            {
                isHot = false;
            }

            if (this.producttype.SelectedValue != "")
            {
                _type1 = this.producttype.SelectedValue;
            }


            if (this.type2.SelectedValue != "")
            {
                _type2 = this.type2.SelectedValue;
            }


            if (this.type3.SelectedValue != "")
            {
                _type3 = this.type3.SelectedValue;
            }


            if (this.type4.SelectedValue != "")
            {
                _type4 = this.type4.SelectedValue;
            }


            int maxid = bllProducts.GetMaxId();
            modelProducts.pid = Convert.ToInt32(pid);
            modelProducts.title = fh.ToDBStr(this.title.Text);
            modelProducts.entitle = fh.ToDBStr(this.entitle.Text);
            modelProducts.prono = fh.ToDBStr(this.productno.Text);
            modelProducts.brand = "";
            modelProducts.protype = Convert.ToInt32(topid);
            modelProducts.type2 = _type2;
            modelProducts.type3 = _type3;
            modelProducts.type4 = _type4;
            modelProducts.photo = filepath;
            modelProducts.price = this.price.Text;
            modelProducts.saleprice = this.saleprice.Text;
            modelProducts.isshow = isproductShow;
            modelProducts.isnew = isproductNew;
            modelProducts.ishot = isHot;
            modelProducts.isrecom = isRecommend;
            modelProducts.timeinfo = DateTime.Now;
            modelProducts.features = fh.ToDBStr(this.features.Value);
            modelProducts.content = fh.ToDBStr(this.productcontent.Value);
            modelProducts.encontent = fh.ToDBStr(this.encontent.Value);
            modelProducts.key1 = fh.ToDBStr(this.key1.Value);
            modelProducts.key2 = fh.ToDBStr(this.key2.Value);
            modelProducts.text1 = this.Material.SelectedValue;
            modelProducts.text2 = "";
            modelProducts.text3 = "";
            modelProducts.text4 = "";
            modelProducts.orderid = maxid;
            modelProducts.hit = 0;
            modelProducts.moreno = "";

            //判断是添加数据还是修改数据 
            if (action == "addproduct")
            {
                bllProducts.Add(modelProducts);
                MessageBox.ShowAndRedirect(this, "添加信息信息成功！", "ProductsInfo.aspx?" + ComUrl + "&action=manage" + "&topid=" + topid);
            }
            else
            {
                modelProducts.orderid = Convert.ToInt32(this.hid_maxid.Value);
                modelProducts.moreno = this.hid_moreno.Value;
                modelProducts.id = Convert.ToInt32(id);
                bllProducts.Update(modelProducts);
                MessageBox.ShowAndRedirect(this, "修改信息信息成功！", "ProductsInfo.aspx?" + ComUrl + "&action=manage" + "&topid=" + topid);
            }

        }

        #region 控制表字段

        public String ShowField(String Filed)
        {
            ManageCom mc = new ManageCom();
            return mc.ShowField(Filed, FieldList);
        }

        #endregion

        #region 删除

        protected void DeleteInfo()
        {
            if (id != null && id != "")
            {
                bllProducts.Delete(Convert.ToInt32(id));
                webcom.DelPic(id + ",0", "photo", "products");//删除图片
                MessageBox.ShowAndRedirect(this, "删除数据成功!", "ProductsInfo.aspx?" + ComUrl + "&action=manage" + "&topid=" + topid);
            }
            else
            {
                MessageBox.ShowAndRedirect(this, "请选择要删除的信息！", "ProductsInfo.aspx?action=manage&" + ComUrl + "&topid=" + topid);
            }
        }

        #endregion

        protected void bindData()
        {
            webcommand webcom = new webcommand();
            String key = Request.QueryString["key"];
            System.Text.StringBuilder sqlWhere = new System.Text.StringBuilder();
            System.Text.StringBuilder sql = new System.Text.StringBuilder();
            System.Text.StringBuilder sqlStr = new System.Text.StringBuilder();
            sql.Append("select  count(id) from products where 1=1 ");

            if (pid != null && pid != "")
            {
                sqlWhere.Append(" and pid=" + pid);
            }

            if (topid != null && topid != "" && topid != "0")
            {
                sqlWhere.Append(" and protype=" + topid);
                this.searchtype.SelectedValue = bid;
            }

            if (sid != null && sid != "" && sid != "0")
            {
                sqlWhere.Append(" and type2=" + sid);
            }

            if (key != null && key != "")
            {
                sqlWhere.Append(" and title like '%" + Server.UrlDecode(key) + "%' ");
                this.searchkey.Text = Server.UrlDecode(key);
            }
            sql.Append(sqlWhere);
            int CountData = Convert.ToInt32(DbHelperOleDb.GetScalar(sql.ToString()));//当前总条数
            int CurrentPage = this.AspNetPager1.CurrentPageIndex;//当前页
            //curpage = Convert.ToString(CurrentPage);
            //totalpage = AspNetPager1.PageCount.ToString();//总页数
            this.AspNetPager1.RecordCount = CountData;
            int pageIndex = CurrentPage - 1;
            int pageSize = this.AspNetPager1.PageSize = 12;

            //this.AspNetPager2.RecordCount = CountData;
            //this.AspNetPager2.PageSize = 12;

            if (CountData == 0)
            {
                this.nolist.Text = "抱歉，暂无相关信息！";
            }
            if (pageIndex == 0)
            {
                sqlStr.Append("select top " + pageSize.ToString() + " id,title,photo,entitle,protype,type2,timeinfo,isRecom,isShow,orderid,content from products where 1=1  ");
            }
            else
            {
                sqlStr.Append("select top " + pageSize.ToString() + " id,title,photo,entitle,protype,type2,timeinfo,isRecom,isShow,orderid,content from products where id not in( select top " + Convert.ToString(pageIndex * pageSize) + " id from products where 1=1 " + Convert.ToString(sqlWhere) + "  order by orderid desc,id desc )   ");
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
            String idlist = Request.Form["selectmessage"];
            if (idlist != null && idlist != "")
            {
                bllProducts.DeleteList(idlist);
                webcom.DelPic(Request.Form["selectmessage"], "photo", "products");
                MessageBox.ShowAndRedirect(this, "删除数据成功!", "ProductsInfo.aspx?" + ComUrl + "&action=manage" + "&topid=" + topid);
            }
            else
            {
                MessageBox.ShowAndRedirect(this, "请选择要删除的信息！", "ProductsInfo.aspx?action=manage&" + ComUrl + "&topid=" + topid);
            }
        }

        #region 当处于修改数据时调用
        protected void loadedit()
        {

            if (id != null && id.Length != 0)
            {
                modelProducts = bllProducts.GetModel(Convert.ToInt32(id));

                if (modelProducts != null)
                {
                    this.title.Text = modelProducts.title;
                    this.entitle.Text = modelProducts.entitle;
                    this.productno.Text = modelProducts.prono;
                    if (Convert.ToBoolean(modelProducts.isshow) == true)
                    {
                        this.isShow.Checked = true;//判断显示或者隐藏
                    }
                    else
                    {
                        this.isShow.Checked = false;
                    }

                    if (Convert.ToBoolean(modelProducts.isrecom) == true)
                    {
                        this.isRecommend.Checked = true;//是否推荐
                    }
                    else
                    {
                        this.isRecommend.Checked = false;
                    }

                    if (Convert.ToBoolean(modelProducts.isnew) == true)
                    {
                        this.isNew.Checked = true;//判断是否为新信息
                    }
                    else
                    {
                        this.isNew.Checked = false;
                    }
                    this.producttype.SelectedValue = modelProducts.protype.ToString();
                    this.Material.SelectedValue = modelProducts.text1;
                    this.features.Value = modelProducts.features;
                    this.productcontent.Value = modelProducts.content;
                    this.encontent.Value = modelProducts.encontent;
                    this.productphotoid.Value = modelProducts.photo;
                    this.price.Text = modelProducts.price;
                    this.saleprice.Text = modelProducts.saleprice;
                    this.saletime.Value = modelProducts.timeinfo.ToString();
                    this.key1.Value = modelProducts.key1;
                    this.key2.Value = modelProducts.key2;

                    this.hid_maxid.Value = modelProducts.orderid.ToString();

                    this.Button1.Text = "修改信息";//将按钮的文字改过来

                    String _photo = modelProducts.photo;
                    if (_photo != "" && _photo != "nophoto")
                    {
                        this.show_photo.Text = "<img src='/UploadFile/Spic/" + _photo + "' height='80px' />";
                    }

                    if (modelProducts.type2 != "")
                    {
                        webcom.BindProType(this.type2, " and fid=" + modelProducts.protype);
                        this.type2.Visible = true;
                        this.type2.SelectedValue = modelProducts.type2;
                    }

                    if (modelProducts.type3 != "")
                    {
                        webcom.BindProType(this.type3, " and fid=" + modelProducts.type2);
                        this.type3.Visible = true;
                        this.type3.SelectedValue = modelProducts.type3;
                    }
                }
            }
        }
        #endregion

        protected void producttype_SelectedIndexChanged1(object sender, EventArgs e)
        {
            this.type2.Visible = true;
            webcom.BindProType(this.type2, " and fid=" + this.producttype.SelectedValue);
        }

        protected void type2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.type3.Visible = true;
            webcom.BindProType(this.type3, " and fid=" + this.type2.SelectedValue);
        }
        protected void type3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.type4.Visible = true;
            webcom.BindProType(this.type4, " and fid=" + this.type3.SelectedValue);
        }
        protected void searchtype1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.searchtype2.Visible = true;
            webcom.BindProType(this.searchtype2, " and fid=" + this.searchtype.SelectedValue);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String searchkey = this.searchkey.Text;
            String searchtype = this.searchtype.SelectedValue;
            String searchtype2 = this.searchtype2.SelectedValue;
            MessageBox.Redirects("ProductsInfo.aspx?" + ComUrl + "&bid=" + searchtype + "&sid=" + searchtype2 + "&key=" + searchkey + "&topid=" + topid);
        }

        protected void delectmessage_Click1(object sender, EventArgs e)
        {
            MessageBox.Redirects("ProductsInfo.aspx?" + ComUrl + "&action=addproduct&topid=" + topid);
        }

        protected void manageproductlist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            BLL.products bll = new BLL.products();
            switch (e.CommandName)
            {
                case "Del":
                    bll.Delete(Convert.ToInt32(id));
                    break;
                case "Update":
                    Response.Redirect("ProductsInfo.aspx?" + ComUrl + "&action=edit&id=" + id + "&topid=" + topid);
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

        #region 检查默认图片
        protected String CheckPic(String photo)
        {
            if (photo != "" && photo != "nophoto")
            {
                return "/UploadFile/Spic/" + photo;
            }
            else
            {
                return "images/nopic.jpg";
            }
        }
        #endregion

        #region 产品类别

        protected String ProType(String type)
        {
            String tmp = "";
            if (type.Length > 0)
            {
                tmp = webcom.GetProType(type);
            }
            return tmp;
        }

        #endregion

        public int getCount(string strMidList)
        {
            int num = 0;
            num = strMidList.TrimEnd(',').TrimStart(',').Split(',').Length;
            return num;
        }
    }
}