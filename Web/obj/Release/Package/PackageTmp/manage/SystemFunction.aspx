<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemFunction.aspx.cs" Inherits="Song.Web.manage.SystemFunction" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>功能设置</title>
    <link href="css/skin.css" rel="stylesheet" type="text/css"/>
<link href="css/css.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="17" valign="top" background="images/mail_leftbg.gif"><img src="images/left-top-right.gif" width="17" height="29" /></td>
    <td valign="top" background="images/content-bg.gif"><table width="100%" height="31" border="0" cellpadding="0" cellspacing="0" class="left_topbg" id="table2">
      <tr>
        <td height="31"><div class="titlebt">栏目管理</div></td>
      </tr>
    </table></td>
    <td width="16" valign="top" background="images/mail_rightbg.gif"><img src="images/nav-right-bg.gif" width="16" height="29" /></td>
  </tr>
  <tr>
    <td valign="middle" background="images/mail_leftbg.gif">&nbsp;</td>
    <td valign="top" bgcolor="#F7F8F9">
    <div class="k10"></div>
    <!--主体内容区 开始-->

        <table border="1" cellspacing="0" cellpadding="0" class="tablecss1" width="100%" >
            <tr>
                <td style="height: 30px" colspan="2" class="tabletop">
                    功能设置
                </td>
            </tr>
            <tr>
                <td width="100px">
                    功能名称：
                </td>
                <td>
                    <asp:TextBox ID="title" runat="server" Widtd="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    功能链接：
                </td>
                <td>
                    <asp:TextBox ID="url" runat="server" Widtd="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <input type="submit" name="btAddInfo" value="添加" runat="server" id="btAddInfo" class="inp1"  visible="false" onserverclick="btAddInfo_ServerClick" />
                    <input type="submit" name="btAddInfo"   value="修改" runat="server" id="Submit1" class="inp1" onserverclick="Submit1_ServerClick"  visible="false" />
                </td>
            </tr>
        </table>
        <br />
       <table class="tablecss1">
            <asp:Repeater ID="NList" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td width="150px">
                            功能
                        </td>
                        <td>
                            功能链接
                        </td>
                        <td width="150px">
                            操作
                        </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td >
                            <b>
                                <%# Eval("title")%></b>
                        </td>
                        <td>
                            <input type="text" id="i<%# Eval("id") %>" name="i<%# Eval("id") %>" value="<%# Eval("url") %>"
                                style="width: 80%" />
                        </td>
                        <td width="80px">
                            <a onclick="showDIV('guige_edit');" href="?action=edittype&bid=<%=bid %>&id=<%# Eval("id") %>">
                                修改</a> <a href="#" onclick="if (confirm('您确定要删除功能吗？')) { location.href='?action=deletetype&bid=<%=bid %>&id=<%# Eval("id") %>';} else { location.href='?bid=<%=bid %>';}"">
                                    删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>

        <!--主体内容区 结束-->

    </td>
    <td background="images/mail_rightbg.gif">&nbsp;</td>
  </tr>
  <tr>
    <td valign="bottom" background="images/mail_leftbg.gif"><img src="images/buttom_left2.gif" width="17" height="17" /></td>
    <td background="images/buttom_bgs.gif"><img src="images/buttom_bgs.gif" width="17" height="17"></td>
    <td valign="bottom" background="images/mail_rightbg.gif"><img src="images/buttom_right2.gif" width="16" height="17" /></td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
