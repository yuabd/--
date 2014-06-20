using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using Maticsoft.Common;

namespace Song.Web.manage
{
    public partial class webconfig : System.Web.UI.Page
    {
        String id = "2";
        protected void Page_Load(object sender, EventArgs e)
        {
            webcommand.CheckUserLogin();
            id = Request.QueryString["id"];

            if (!IsPostBack)
            {
                ShowInfo();
            }
        }

        protected void ShowInfo()
        {
            Song.BLL.webconfig bll = new Song.BLL.webconfig();
            Song.Model.webconfig model = bll.GetModel(id);
            this.webname.Text = model.webname;
            this.webkey1.Text = model.webkey1;
            this.webkey2.Text = model.webkey2;
            this.webkey3.Text = model.webkey3;
            this.webemail.Text = model.webemail;
            this.webadd.Text = model.webadd;
            this.webcode.Text = model.webcode;
            this.webtel.Text = model.webtel;
            this.webfax.Text = model.webfax;
            this.webcopyright.Text = model.webcopyright;
            this.webicp.Text = model.webicp;
            String photo = model.qq1;
            if (photo != "" && photo != "nophoto")
            {
                this.photoshow.Text = "<img src='/UploadFile/pic/" + photo + "' height='100px' />";
            }
            this.hid_photo.Value = photo;
            String photo1 = model.qq2;
            if (photo1 != "" && photo1 != "nophoto")
            {
                this.Literal1.Text = "<img src='/UploadFile/pic/" + photo1 + "' height='100px' />";
            }
            this.HiddenField1.Value = photo1;

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
        protected void Button1_Click(object sender, EventArgs e)
        {
            FileControl fc = new FileControl();
            BLL.webconfig BllWebconfig = new BLL.webconfig();
            Model.webconfig model = new Model.webconfig();
            String filepath = "", filepath1 = "";
            //上传图片 开始
            if (this.newsphoto.HasFile)//当有图片的时候
            {
                filepath = fc.UploadPic(this.newsphoto, "pic");

            }
            else
            {
                filepath = this.hid_photo.Value;
            }

            if (this.FileUpload1.HasFile)//当有图片的时候
            {
                filepath1 = fc.UploadPic(this.FileUpload1, "pic");

            }
            else
            {
                filepath1 = this.HiddenField1.Value;
            }

            if (model != null)
            {
                model.id = Convert.ToInt32(id);
                model.webname = this.webname.Text;
                model.webkey1 = this.webkey1.Text;
                model.webkey2 = this.webkey2.Text;
                model.webkey3 = this.webkey3.Text;
                model.webemail = this.webemail.Text;
                model.webadd = this.webadd.Text;
                model.webcode = this.webcode.Text;
                model.webtel = this.webtel.Text;
                model.webfax = this.webfax.Text;
                model.webcopyright = this.webcopyright.Text;
                model.webicp = this.webicp.Text;
                model.qq1 = filepath;
                model.qq2 = filepath1;
                model.weblanguage = "cn";
            }
            BllWebconfig.Update(model);
            MessageBox.ShowAndRedirect(this, "保存成功！", "Webconfig.aspx?id=" + id);
        }

    }
}