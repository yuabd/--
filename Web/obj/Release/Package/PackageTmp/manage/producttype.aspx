<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="producttype.aspx.cs" Inherits="Song.Web.manage.producttype" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网站设置</title>
    <link href="css/skin.css" rel="stylesheet" type="text/css" />
    <link href="css/css.css" rel="Stylesheet" type="text/css" />
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
                                    类别管理</div>
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
                    <% if (Request.QueryString["action"] == "edittype")
                       { %>
                    <table class="tablecss1">
                        <tr>
                            <td class="tabletop" colspan="2" style="height: 30px">
                                产品类别修改
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin" style="width: 68px">
                                选择语言：
                            </td>
                            <td>
                                <asp:RadioButtonList ID="weblanguage" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="cn">中文网站</asp:ListItem>
                                    <asp:ListItem Value="en">英文网站</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin" style="width: 77px">
                                类别名称：
                            </td>
                            <td style="width: 571px">
                                <asp:TextBox ID="edit_typename" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin" style="width: 77px">
                                名称（英）：
                            </td>
                            <td style="width: 571px">
                                <asp:TextBox ID="edit_enname" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdMargin" style="width: 77px">
                                类别图片：
                            </td>
                            <td style="width: 571px">
                                <asp:FileUpload ID="FilePhoto" runat="server" />图片大小：370px*200px
                                <asp:HiddenField ID="hid_photo" runat="server" EnableViewState="true" />
                                <asp:Literal ID="show_photo" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin" valign="top">
                                关键字：
                            </td>
                            <td>
                                <textarea name="Textarea1" id="Textarea1" runat="server" style="width: 500px; height: 100px;"></textarea>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin" valign="top">
                                描述：
                            </td>
                            <td>
                                <textarea name="Textarea2" id="Textarea2" runat="server" style="width: 500px; height: 100px;"></textarea>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin" style="width: 77px">
                                类别说明：
                            </td>
                            <td>
                                <textarea name="productcontent2" id="productcontent2" style="display: none" runat="server"></textarea>
                                <iframe src="dafckbo/editor/fckeditor.html?InstanceName=productcontent2&Toolbar=Default"
                                    frameborder="no" scrolling="no" class="i1" height="400" width="100%"></iframe>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td class="tdMargin" style="width: 77px">
                                排列序号：
                            </td>
                            <td>
                                <asp:TextBox ID="edit_typeorder" runat="server" Width="200px"></asp:TextBox><input
                                    type="hidden" name="curid" id="curid" runat="server" /><input type="hidden" name="curid"
                                        id="curlanguage" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="edit_button" runat="server" Text="确认修改" OnClick="edit_button_Click"
                                                CssClass="inp1" />
                                        </td>
                                        <td style="display: none">
                                            <a href="#" onclick="history.back()">返回上一页</a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <%}
                       else
                       { %>
                    <table border="1" cellspacing="0" cellpadding="0" class="tablecss1" bordercolor="#eae3e4">
                        <tr>
                            <td style="height: 30px" colspan="5" class="tabletop">
                                类别管理 <a href="#" onclick="history.back()" style="display: none">返回上一页</a>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <asp:Label ID="curtypename" runat="server"></asp:Label>
                                <!-- 信息类别管理 开始 -->
                                <table border="1" cellspacing="0" cellpadding="0" class="tablecss1" bordercolor="#f7f7f7">
                                    <asp:Repeater ID="newstypelist" runat="server" OnItemCommand="manageproductlist_ItemCommand"
                                        OnItemDataBound="manageproductlist_ItemDataBound">
                                        <HeaderTemplate>
                                            <tr bgcolor="#F7F7F7" style="font-weight: bolder">
                                                <td height="30px" align="center">
                                                    ID
                                                </td>
                                                <td>
                                                    类别名称
                                                </td>
                                                <td style="display: none">
                                                    英文名称
                                                </td>
                                                <td>
                                                    图片
                                                </td>
                                                <td align="center">
                                                    子类
                                                </td>
                                                <td align="center">
                                                    修改
                                                </td>
                                                <td align="center">
                                                    删除
                                                </td>
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td height="25" width="100px" align="center">
                                                    <%# Eval("id") %>
                                                </td>
                                                <td>
                                                    <%# Eval("title")%>
                                                </td>
                                                <td style="display: none">
                                                    <%# Eval("entitle")%>
                                                </td>
                                                <td>
                                                    <img src="<%# CheckPic(Convert.ToString(Eval("photo"))) %>" height="60" />
                                                </td>
                                                <td width="80" align="center">
                                                    <a href="Producttype.aspx?pid=<%=pid %>&topid=<%# Eval("id") %>">子类</a>
                                                </td>
                                                <td width="100px" align="center">
                                                    <asp:LinkButton ID="lbtn_Update" CommandName="Update" CommandArgument='<%#Eval("id") %>'
                                                        runat="server">修改</asp:LinkButton>
                                                </td>
                                                <td width="100px" align="center">
                                                    <asp:LinkButton ID="lbtn_Del" CommandName="Del" CommandArgument='<%#Eval("id") %>'
                                                        runat="server">删除</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                                <center>
                                    <asp:Literal ID="nodate" runat="server"></asp:Literal></center>
                                <!-- 信息类别管理 结束 -->
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" height="20" bgcolor="#f7f7f7">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                名称：<asp:TextBox ID="typename" runat="server" Width="150px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="typename" Display="None"
                                    ValidationGroup="add" ErrorMessage="名称（中）不能为空！"></asp:RequiredFieldValidator>
                                <div style="display: none">
                                    名称（英）：<asp:TextBox ID="enname" runat="server" Width="150px"></asp:TextBox>
                                </div>
                                <span>图片：<asp:FileUpload ID="FileUpload1" runat="server" />图片大小：370px*200px</span>
                                &nbsp;<asp:ValidationSummary ValidationGroup="add" ShowMessageBox="true" ShowSummary="false"
                                    ID="ValidationSummary1" runat="server" />
                                <br />
                                <span style="display: none">关键字：<textarea name="key1" id="key1" runat="server" style="width: 500px;
                                    height: 100px;"></textarea></span> <span style="display: none">描述：<textarea name="key2"
                                        id="key2" runat="server" style="width: 500px; height: 100px;"></textarea></span><br />
                                <br />
                                <asp:Button ID="Button1" runat="server" CssClass="inp1" ValidationGroup="add" Text="添加类别"
                                    OnClick="Button1_Click" />
                            </td>
                            <td align="center" style="display: none">
                                排序
                            </td>
                            <td style="display: none">
                                <asp:TextBox ID="idorder" runat="server" Width="50px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td colspan="5">
                                <textarea name="productcontent" id="productcontent" style="display: none" runat="server"></textarea>
                                <iframe src="dafckbo/editor/fckeditor.html?InstanceName=productcontent&amp;Toolbar=Default"
                                    frameborder="no" scrolling="no" class="i1" height="400" width="100%"></iframe>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" align="center">
                            </td>
                        </tr>
                    </table>
                    <%} %>
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
