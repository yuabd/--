using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI;
using System.IO;

namespace Maticsoft.Common
{
    public class FileControl
    {
        public String SetPicExt = "|.JPG|.GIF|.PNG|";
        int FileMax = 400;

        public FileControl()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region 检查文件是否 有超出大小

        public Boolean CheckFileMax(FileUpload FilePic)
        {
            Boolean tmp = false;

            if (FilePic != null && FilePic.HasFile == true)
            {
                if (FilePic.PostedFile.ContentLength <= 1 * 1024 * FileMax)
                {
                    return true;
                }
            }


            return tmp;
        }

        #endregion

        #region  上传图片

        public String UploadPic(FileUpload FilePic, String SavePath)
        {
            String tmp_filename = "";
            if (FilePic != null && FilePic.HasFile == true)
            {
                String Ext = Path.GetExtension(FilePic.PostedFile.FileName).ToUpper();
                if (!SetPicExt.Contains("|" + Ext + "|"))//格式审核
                {
                    webcommand.Alert("抱歉，图片只上传支持jpg、gif、png格式，请重新上传！", "");
                }
                else
                {
                    if (FilePic.PostedFile.ContentLength > 200 * 1024 * FileMax)
                    {
                        webcommand.Alert("抱歉，图片大小不能超过200K，请将图片缩小后重新上传！", "");
                    }
                    else
                    {   //验证通过，开始上传图片
                        Random radom = new Random();
                        String filename = DateTime.Now.ToString("yyyyMMddHHmmss") + radom.Next(10000) + Ext;
                        FilePic.PostedFile.SaveAs(HttpContext.Current.Server.MapPath("~/UploadFile/" + SavePath + "/").ToString() + filename);
                        tmp_filename = filename;
                        //webcommand.Alert("上传成功！"+filename, "");
                    }
                }
            }
            return tmp_filename;
        }

        #endregion

        #region 生成缩略图

        /// <summary>
        /// 根据高宽生成缩略图
        /// </summary>
        /// <param name="OldImgPath">原图片路径</param>
        /// <param name="NewImgPath">新图片路径</param>
        /// <param name="width">新图片宽</param>
        /// <param name="height">新图片高</param>
        /// <param name="mode">裁剪模式：模式（HW，指定高宽缩放（可能变形）W，指定宽度 H，指定高度 Cut，指定高宽裁减（不变形））</param>
        public static void MakeSpic(String OldImgPath, String NewImgPath, int width, int height, String mode)
        {
            System.Drawing.Image OldImg = System.Drawing.Image.FromFile(OldImgPath);
            int nw = width;
            int nh = height;

            int x = 0, y = 0;
            int ow = OldImg.Width;
            int oh = OldImg.Height;

            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）
                    break;
                case "W"://指定宽，高度按比例
                    nh = OldImg.Height * width / OldImg.Width;
                    break;
                case "H"://指定高，宽度按比例
                    nw = OldImg.Width * height / OldImg.Height;
                    break;
                case "Cut"://原图指定高宽裁剪（不变形）
                    if ((double)OldImg.Width / (double)OldImg.Height > (double)nw / (double)nh)
                    {
                        oh = OldImg.Height;
                        ow = OldImg.Height * nw / nh;
                        y = 0;
                        x = (OldImg.Width - ow) / 2;
                    }
                    else
                    {
                        ow = OldImg.Width;
                        oh = OldImg.Width * nh / nw;
                        x = 0;
                        y = (OldImg.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }
            //新建一个图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(nw, nh);
            //建立一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            //设置一个高质量插法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //设置高质量，低速平滑程度

            //清空画布，并以透明色填充
            g.Clear(System.Drawing.Color.Transparent);
            //在指定位置并且按大小绘制原图片的指定部分
            g.DrawImage(OldImg, new System.Drawing.Rectangle(0, 0, nw, nh), new System.Drawing.Rectangle(x, y, ow, oh), System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(NewImgPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                OldImg.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }

        #endregion

        #region 生成图片水印
        /**/
        /// <summary>
        /// 在图片上生成图片水印
        /// </summary>
        /// <param name="Path">原服务器图片路径</param>
        /// <param name="Path_syp">生成的带图片水印的图片路径</param>
        /// <param name="Path_sypf">水印图片路径</param>
        public static void AddWaterPic(string Path, string Path_syp)
        {
            string Path_sypf = System.Web.HttpContext.Current.Server.MapPath("/images/shuiyin_red.png");
            System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
            System.Drawing.Image copyImage = System.Drawing.Image.FromFile(Path_sypf);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width, image.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, System.Drawing.GraphicsUnit.Pixel);
            g.Dispose();

            //保存加水印过后的图片
            image.Save(Path_syp);
            image.Dispose();

            //删除原始图片
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }

        }
        #endregion

        #region 删除图片

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="FilePath">图片相对路径</param>
        public void DelFile(String FilePath)
        {
            //try{
            String path = System.Web.HttpContext.Current.Server.MapPath(FilePath);
            //文件己存在   
            if (File.Exists(path))
            {
                FileInfo fi = new FileInfo(path);
                //判断当前文件属性是否是只读   
                if (fi.Attributes.ToString().IndexOf("ReadyOnly") >= 0)
                {
                    fi.Attributes = FileAttributes.Normal;
                }
                //删除文件   
                File.Delete(path);
            }
            //删除文件夹   
            //}  
            //catch (Exception ex)
            //    {
            //        //webcommand.Alert("删除失败！", "");
            //    }
        }

        #endregion

        #region 上传图片并生成缩略图及中图

        /// <summary>
        /// 上传图片并生成缩略图及中图
        /// </summary>
        /// <param name="file">文件控件</param>
        /// <param name="id">标识ID</param>
        /// <returns></returns>
        public String CreateSimPic(FileUpload file, String id)
        {
            //保存大图 
            //String NewFileName = ManageCom.CreateNo() + ".jpg";
            FileControl fc = new FileControl();
            String FileName = fc.UploadPic(file, "OldPic");//上传原图文件名

            if (FileName != "")
            {
                //int sspic_w = 189, sspic_h = 145;//小小图
                int spic_w = 200, spic_h = 150;//缩略图
                int pic_w = 1000, pic_h = 1000;//大图
                String FromPath = HttpContext.Current.Server.MapPath("/UploadFile/OldPic/" + FileName);//原图片

                //保存小小图
                //String SavePath0 = HttpContext.Current.Server.MapPath("/UploadFile/Spic/s" + FileName);//小小图存放位置
                //FileControl.MakeSpic(FromPath, SavePath0, sspic_w, sspic_h, "W");//缩略图

                //保存缩略图
                String SavePath = HttpContext.Current.Server.MapPath("/UploadFile/Spic/" + FileName);//缩略图存放位置
                FileControl.MakeSpic(FromPath, SavePath, spic_w, spic_h, "W");//缩略图
                //保存中图
                String SavePath2 = HttpContext.Current.Server.MapPath("/UploadFile/Pic/" + FileName);//中图存放位置
                FileControl.MakeSpic(FromPath, SavePath2, pic_w, pic_h, "W");//中图

                DelFile("/UploadFile/OldPic/" + FileName);
            }
            else
            {
                //webcommand.Alert("抱歉，图片大小不能超过200K,图片未上传成功！", "");
            }
            return FileName;
        }

        /// <summary>
        /// 上传图片并生成缩略图及中图
        /// </summary>
        /// <param name="file">文件控件</param>
        /// <param name="id">标识ID</param>
        /// <param name="spic_w">缩略图宽</param>
        /// <param name="spic_h">缩略图高</param>
        /// <param name="pic_w">大图宽</param>
        /// <param name="pic_h">大图高</param>
        /// <returns></returns>
        public String CreateSimPic(FileUpload file, String id, int spic_w = 200, int spic_h = 200, int pic_w = 1000, int pic_h = 1000)
        {
            FileControl fc = new FileControl();
            String FileName = fc.UploadPic(file, "OldPic");//上传原图文件名

            if (FileName != "")
            {
                String FromPath = HttpContext.Current.Server.MapPath("/UploadFile/OldPic/" + FileName);//原图片

                //保存缩略图
                String SavePath = HttpContext.Current.Server.MapPath("/UploadFile/Spic/" + FileName);//缩略图存放位置
                FileControl.MakeSpic(FromPath, SavePath, spic_w, spic_h, "W");//缩略图
                //保存中图
                String SavePath2 = HttpContext.Current.Server.MapPath("/UploadFile/Pic/" + FileName);//中图存放位置
                FileControl.MakeSpic(FromPath, SavePath2, pic_w, pic_h, "HW");//中图

                DelFile("/UploadFile/OldPic/" + FileName);
            }
            else
            {
                //webcommand.Alert("抱歉，图片大小不能超过200K,图片未上传成功！", "");
            }
            return FileName;
        }

        #endregion
    }
}
