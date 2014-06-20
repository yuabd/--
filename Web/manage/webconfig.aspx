<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webconfig.aspx.cs" Inherits="Song.Web.manage.webconfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网站设置</title>
    <link href="css/skin.css" rel="stylesheet" type="text/css" />
    <link href="css/css.css" rel="stylesheet" type="text/css">
    <style type="text/css">
        .style1
        {
            width: 60px;
            background-color: #ebf1f5;
            height: 28px;
        }
        .style2
        {
            height: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="17" valign="top" background="images/mail_leftbg.gif">
                    <img src="images/left-top-right.gif" width="17" height="29" />
                </td>
                <td valign="top" background="images/content-bg.gif">
                    <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="left_topbg"
                        id="table2">
                        <tr>
                            <td height="31">
                                <div class="titlebt">
                                    网站设置</div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="16" valign="top" background="images/mail_rightbg.gif">
                    <img src="images/nav-right-bg.gif" width="16" height="29" />
                </td>
            </tr>
            <tr>
                <td valign="middle" background="images/mail_leftbg.gif">
                    &nbsp;
                </td>
                <td valign="top" bgcolor="#F7F8F9">
                    <div class="k10">
                    </div>
                    <!--主体内容区 开始-->
                    <table border="1" cellspacing="0" cellpadding="0" class="tablecss1">
                        <tr>
                            <td style="height: 30px" colspan="2" class="tabletop">
                                网站相关信息设置
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                网站名称<input type="hidden" id="curlanguage" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="webname" runat="server" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                关键字(Description)：
                            </td>
                            <td>
                                <asp:TextBox ID="webkey1" runat="server" Height="75px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                关健词(KeyWords)：
                            </td>
                            <td style="height: 32px">
                                <asp:TextBox ID="webkey2" runat="server" Height="75px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin">
                                企业简短说明：
                            </td>
                            <td>
                                <asp:TextBox ID="webkey3" runat="server" Height="75px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                Email：
                            </td>
                            <td>
                                <asp:TextBox ID="webemail" runat="server" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                公司地址：
                            </td>
                            <td>
                                <asp:TextBox ID="webadd" runat="server" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                公司电话：
                            </td>
                            <td>
                                <asp:TextBox ID="webtel" runat="server" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                公司传真：
                            </td>
                            <td style="height: 32px">
                                <asp:TextBox ID="webfax" runat="server" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                版权声明：
                            </td>
                            <td>
                                <asp:TextBox ID="webcopyright" runat="server" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                备案序号：
                            </td>
                            <td class="style2">
                                <asp:TextBox ID="webicp" runat="server" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="tdMargin">
                            <td class="tdMargin" style="width: 68px">
                                联系电话图片：
                            </td>
                            <td>
                                &nbsp;<asp:FileUpload ID="newsphoto" runat="server" />图片大小：285px*82px
                                <asp:Literal ID="photoshow" runat="server"></asp:Literal>
                                <asp:HiddenField ID="hid_photo" runat="server" Value="nophoto" />
                            </td>
                        </tr>
                        <tr class="tdMargin">
                            <td class="tdMargin" style="width: 68px">
                                logo图片：
                            </td>
                            <td>
                                &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />图片大小：178px*82px
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                <asp:HiddenField ID="HiddenField1" runat="server" Value="nophoto" />
                            </td>
                        </tr>
                       
                        <tr>
                            <td class="tdMargin">
                                客服Skype：
                            </td>
                            <td>
                                <asp:TextBox ID="webcode" runat="server" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button1" runat="server" Text="修改设置" OnClick="Button1_Click" CssClass="inp1" />
                            </td>
                        </tr>
                    </table>
                    <!--主体内容区 结束-->
                </td>
                <td background="images/mail_rightbg.gif">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td valign="bottom" background="images/mail_leftbg.gif">
                    <img src="images/buttom_left2.gif" width="17" height="17" />
                </td>
                <td background="images/buttom_bgs.gif">
                    <img src="images/buttom_bgs.gif" width="17" height="17">
                </td>
                <td valign="bottom" background="images/mail_rightbg.gif">
                    <img src="images/buttom_right2.gif" width="16" height="17" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
