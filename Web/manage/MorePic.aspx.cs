using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Song.BLL;
using Song.Model;
using Maticsoft.Common;

namespace Song.Web.manage
{
    public partial class testPic : System.Web.UI.Page
    {
        BLL.MorePic MorePicBll = new BLL.MorePic();
        webcommand webcom = new webcommand();
        Model.MorePic MorePicModel = new Model.MorePic();
        public String pid = "0", no = "", action = "", mid = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            //检查是否登录
            webcommand webcom = new webcommand();
            webcommand.CheckUserLogin();
            pid = Request.QueryString["pid"];
            mid = Request.QueryString["mid"];
            no = Request.QueryString["no"];
            action = Request.QueryString["action"];
            EidtPicList();//加载图片列表



            //if (action == "del")
            //{
            //    DelPic();//删除图片及其相关数据
            //}

        }


        //批量上传图片
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            string _type = "0";
            string[] TitleList = Request["txtTitle"].Split(',');
            //string[] DetailList = Request["txtDetail"].Split(',');
            ///'遍历File表单元素
            HttpFileCollection files = HttpContext.Current.Request.Files;

            /// '状态信息
            System.Text.StringBuilder strMsg = new System.Text.StringBuilder();
            //strMsg.Append("上传的文件分别是：<hr color='red'/>");
            try
            {
                Random random = new Random();

                for (int iFile = 0; iFile < files.Count; iFile++)
                {
                    ///'检查文件扩展名字
                    HttpPostedFile postedFile = files[iFile];
                    string fileName, fileExtension;
                    fileName = System.IO.Path.GetFileName(postedFile.FileName);

                    if (fileName != "")
                    {
                        //fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + random.Next(100000)+fileExtension;
                        fileName = ManageCom.CreateNo() + ".jpg";
                        postedFile.SaveAs(System.Web.HttpContext.Current.Request.MapPath("/UploadFile/OldPic/") + fileName);

                        //生成缩略图 开始

                        FileControl fc = new FileControl();
                        int spic_w = 230, spic_h = 165;
                        int pic_w = 490, pic_h = 350;

                        String OldPath = HttpContext.Current.Server.MapPath("/UploadFile/OldPic/" + fileName);//原图片
                        //String FromPath = HttpContext.Current.Server.MapPath("/UploadFile/Pic/" + fileName);//有水印图片
                        //FileControl.AddWaterPic(OldPath, FromPath);
                        //保存缩略图
                        String SavePath = HttpContext.Current.Server.MapPath("/UploadFile/Spic/" + fileName);//缩略图存放位置
                        FileControl.MakeSpic(OldPath, SavePath, spic_w, spic_h, "HW");//缩略图
                        //保存中图
                        String SavePath2 = HttpContext.Current.Server.MapPath("/UploadFile/Pic/" + fileName);//中图存放位置
                        FileControl.MakeSpic(OldPath, SavePath2, pic_w, pic_h, "HW");//中图

                        //生成缩略图 结束

                        //存储到数据库
                        int maxid = MorePicBll.GetMaxId();//排序ID
                        MorePicModel.pid = 0;
                        //MorePicModel.Classid = 0;
                        MorePicModel.photono = no;
                        MorePicModel.Title = TitleList[iFile];
                        //MorePicModel.Detail = DetailList[iFile];
                        MorePicModel.Detail = _type;
                        MorePicModel.Pic = fileName;//缩略图
                        MorePicModel.timeinfo = DateTime.Now;
                        MorePicBll.Add(MorePicModel);
                    }

                }
                //上传成功后跳转
                Response.Write("<script>window.location.href='?action=edit&pid=" + pid + "&mid=" + mid + "&no=" + no + "'</script>");
                strStatus.Text = strMsg.ToString();

            }
            catch (System.Exception Ex)
            {
                strStatus.Text = Ex.Message;
            }

        }


        //编辑图片列表
        protected void EidtPicList()
        {
            if (no != null && no != "")
            {
                BLL.MorePic MorePicBll = new BLL.MorePic();
                DataSet ds = MorePicBll.GetList(" photono = '" + no + "'  ");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.NList.DataSource = ds;
                    this.NList.DataBind();
                }
                ds.Dispose();
            }
        }


        //删除图片及相关数据
        protected void DelPic(string id)
        {
            if (id != null && id != "")
            {
                BLL.MorePic MorePicBll = new BLL.MorePic();
                Model.MorePic MorePicModel = MorePicBll.GetModel(int.Parse(id));
                FileControl fc = new FileControl();
                String pic = MorePicModel.Pic;
                if (pic != "")
                {
                    string str_err = "";
                    try
                    {
                        fc.DelFile("/UploadFile/Pic/" + pic.Trim());//删除图片
                        fc.DelFile("/UploadFile/SPic/" + pic.Trim());//删除图片
                        //fc.DelFile("/UploadFile/Pic/" + pic.Trim());//删除图片
                    }
                    catch (Exception ex)
                    {

                    }
                }
                MorePicBll.Delete(int.Parse(id));
            }
            //EidtPicList();
            Response.Write("<script>window.location.href='?action=edit&pid=" + pid + "&mid=" + mid + "&no=" + no + "'</script>");
            //EidtPicList();
        }

        protected void NList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string ID = e.CommandArgument + "";
            switch (e.CommandName)
            {
                case "Del":
                    DelPic(ID);
                    break;
                case "Update":
                    BLL.MorePic bll = new BLL.MorePic();
                    //bll.Update(" Title='" + Request["PicTitle" + ID + ""] + "',Detail='" + Request["PicDetail" + ID + ""] + "' ", " id=" + ID + " ");
                    bll.Update(" Title='" + Request["PicTitle" + ID + ""] + "' ", " id=" + ID + " ");
                    break;
            }
            EidtPicList();
        }



        protected void NList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                LinkButton btn = (LinkButton)e.Item.FindControl("btn_Del");
                btn.Attributes.Add("onclick", "javascript:return confirm('您确定要删除此商品？删除后将不可恢复！')");
            }
        }
    }
}