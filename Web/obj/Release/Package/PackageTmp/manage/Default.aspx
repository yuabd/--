<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Song.Web.manage.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>网站管理员登陆</title>
    <style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-color: #1D3647;
}
.inps {
	border:1px solid #ccc;
	width:150px;
}
.inps1 {
	border:1px solid #ccc;
	width:90px;
}
    .style1
    {
        height: 25px;
        padding-right:10px;
    }
-->
</style>
    <script language="JavaScript">
        function correctPNG() {
            var arVersion = navigator.appVersion.split("MSIE")
            var version = parseFloat(arVersion[1])
            if ((version >= 5.5) && (document.body.filters)) {
                for (var j = 0; j < document.images.length; j++) {
                    var img = document.images[j]
                    var imgName = img.src.toUpperCase()
                    if (imgName.substring(imgName.length - 3, imgName.length) == "PNG") {
                        var imgID = (img.id) ? "id='" + img.id + "' " : ""
                        var imgClass = (img.className) ? "class='" + img.className + "' " : ""
                        var imgTitle = (img.title) ? "title='" + img.title + "' " : "title='" + img.alt + "' "
                        var imgStyle = "display:inline-block;" + img.style.cssText
                        if (img.align == "left") imgStyle = "float:left;" + imgStyle
                        if (img.align == "right") imgStyle = "float:right;" + imgStyle
                        if (img.parentElement.href) imgStyle = "cursor:hand;" + imgStyle
                        var strNewHTML = "<span " + imgID + imgClass + imgTitle
             + " style=\"" + "width:" + img.width + "px; height:" + img.height + "px;" + imgStyle + ";"
             + "filter:progid:DXImageTransform.Microsoft.AlphaImageLoader"
             + "(src=\'" + img.src + "\', sizingMethod='scale');\"></span>"
                        img.outerHTML = strNewHTML
                        j = j - 1
                    }
                }
            }
        }
        window.attachEvent("onload", correctPNG);
    </script>
    <link href="css/skin.css" rel="stylesheet" type="text/css" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" height="166" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td height="42" valign="top">
                <table width="100%" height="42" border="0" cellpadding="0" cellspacing="0" class="login_top_bg">
                    <tr>
                        <td width="1%" height="21">
                            &nbsp;
                        </td>
                        <td height="42">
                            &nbsp;
                        </td>
                        <td width="17%">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="login_bg">
                    <tr>
                        <td width="49%" align="right">
                            <table width="91%" height="532" border="0" cellpadding="0" cellspacing="0" class="login_bg2">
                                <tr>
                                    <td height="138" valign="top">
                                        <table width="89%" height="427" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td height="149">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="80" align="right" valign="top">
                                                    <img src="images/logo.png" width="279" height="68">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="198" align="right" valign="top">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="35%">
                                                            </td>
                                                            <td colspan="2" class="style1">
                                                                <p>
                                                                    1- 企业网站信息更新维护的首选方案</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td height="25" colspan="2" class="style1">
                                                                <p>
                                                                    2- 一站通式的整合方式，方便用户使用</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td height="25" colspan="2" class="style1">
                                                                <p>
                                                                    3- 强大的后台系统，管理内容易如反掌</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td width="30%" height="40">
                                                                <img src="images/icon-demo.gif" width="16" height="16"><a href="#" class="left_txt3">
                                                                    使用说明</a>
                                                            </td>
                                                            <td width="35%">
                                                                <img src="images/icon-login-seaver.gif" width="16" height="16"><a href="#" class="style1">
                                                                    在线客服</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="1%">
                            &nbsp;
                        </td>
                        <td width="50%" valign="bottom">
                            <table width="100%" height="59" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="4%">
                                        &nbsp;
                                    </td>
                                    <td width="96%" height="38">
                                        <span class="login_txt_bt">登陆信息网后台管理</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td height="21">
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0" id="table211" height="328">
                                            <tr>
                                                <td height="164" colspan="2" align="middle">
                                                    <form name="myform" action="index.html" method="post">
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0" height="143" id="table212">
                                                        <tr>
                                                            <td width="13%" height="38">
                                                                <span class="login_txt">管理员：&nbsp;&nbsp; </span>
                                                            </td>
                                                            <td height="38" colspan="2" align="left">
                                                                <asp:TextBox ID="username" CssClass="inps" runat="server" MaxLength="20"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username"
                                                                    ErrorMessage="请输入管理员帐号！"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="13%" height="35">
                                                                <span class="login_txt">密 码： &nbsp;&nbsp; </span>
                                                            </td>
                                                            <td height="35" colspan="2" align="left">
                                                                <asp:TextBox ID="password" CssClass="inps" TextMode="Password" runat="server" MaxLength="20"></asp:TextBox>
                                                                <img src="images/luck.gif" width="19" height="18">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password"
                                                                    ErrorMessage="请输入帐号密码！"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="13%" height="35">
                                                                <span class="login_txt">验证码：</span>
                                                            </td>
                                                            <td height="35" colspan="2" align="left">
                                                                <asp:TextBox ID="CheckCode" CssClass="inps1" runat="server" MaxLength="4"></asp:TextBox>
                                                                <img id="imgVerify" src="VerifyCode.aspx?" alt="看不清？点击更换" onclick="this.src=this.src+'?'"
                                                                    width="60px" style="cursor: hand" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="CheckCode"
                                                                    ErrorMessage="请输入验证码！"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="35">
                                                                &nbsp;
                                                            </td>
                                                            <td colspan="2" height="35" align="left">
                                                                <asp:Button ID="Button1" runat="server" Text="登 录" CssClass="inp1" OnClick="Button1_Click" />
                                                                &nbsp;&nbsp;
                                                                <asp:Button ID="Button2" runat="server" Text="取 消" CssClass="inp1" ValidationGroup="cancel"
                                                                    OnClick="Button2_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br>
                                                    </form>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="433" height="164" align="right" valign="bottom">
                                                    <img src="images/login-wel.gif" width="242" height="138">
                                                </td>
                                                <td width="57" align="right" valign="bottom">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="20">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="login-buttom-bg">
                    <tr>
                        <td align="center">
                            <span class="login-buttom-txt">Copyright &copy; 2013-2020 版权所有</span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
