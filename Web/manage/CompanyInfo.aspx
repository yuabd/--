<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyInfo.aspx.cs" Inherits="Song.Web.manage.CompanyInfo"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网站设置</title>
    <link href="css/skin.css" rel="stylesheet" type="text/css" />
    <link href="css/css.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" charset="utf-8" src="ueditor/editor_config.js"></script>
    <script type="text/javascript" charset="utf-8" src="ueditor/editor_all_min.js"></script>
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
                                    <%=ClassName%></div>
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
                    <table border="1" cellspacing="0" cellpadding="0" class="tablecss1" bordercolor="#eae3e4">
                        <tr>
                            <td style="height: 30px" colspan="2" class="tabletop">
                                <%=ClassName %>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                标题
                            </td>
                            <td>
                                <asp:TextBox ID="menuname" runat="server" Width="95%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td class="tdMargin">
                                图片
                            </td>
                            <td>
                                <asp:FileUpload ID="Pic" runat="server" />
                                <asp:HiddenField ID="hid_pic" Value="nophoto" runat="server" />
                                <asp:Literal ID="show_Pic" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin" valign="top">
                                <br />
                                内容<%--(中文版)--%>
                            </td>
                            <td>
                                <textarea name="information" id="information" style="display: none" runat="server"></textarea>
                                <iframe src="dafckbo/editor/fckeditor.html?InstanceName=information&amp;Toolbar=Default"
                                    frameborder="no" scrolling="no" class="i1" height="500" width="100%"></iframe>
                                <%--<textarea id="information" name="information" runat="server" cols="20" rows="2"></textarea>
                                <script type="text/javascript">
                                    UE.getEditor('information');
                                </script>--%>
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td class="tdMargin" valign="top">
                                <br />
                                关键字
                            </td>
                            <td>
                                <textarea name="key1" id="key1" style="width: 500px; height: 100px" runat="server"></textarea>
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td class="tdMargin" valign="top">
                                <br />
                                描述
                            </td>
                            <td>
                                <textarea name="key2" id="key2" style="width: 500px; height: 100px" runat="server"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin">
                                修改时间
                            </td>
                            <td>
                                <asp:Label ID="updatetime" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button1" runat="server" Text="修改资料" OnClick="Button1_Click" CssClass="inp1" />
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
