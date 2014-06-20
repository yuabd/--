<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FieldRunList.aspx.cs" Inherits="Song.Web.manage.FieldRunList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>无标题页</title>
    <link href="css/skin.css" rel="stylesheet" type="text/css" />
    <link href="css/css.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="js/webcom.js"></script>
</head>
<body class="rightbody">
    <div class="location bluelink">
        当前位置：<a href="#">系统管理</a> &gt;&gt; 字段组别设置
    </div>
    <form id="form1" runat="server">
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
                                字段设置</div>
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
                <div class="yspace setbar">
                    <h1>
                        <font style="font-size: 16px; font-weight: bolder">
                            <asp:Label ID="Label1" runat="server" Text="字段组别设置" ForeColor="Black"></asp:Label></font><input
                                type="hidden" id="curstate" runat="server" value="add" /><input type="hidden" id="curid"
                                    runat="server" /></h1>
                    <div id="addrule" runat="server">
                        <p>
                            功能选择：<asp:DropDownList ID="FunctionList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="FunctionList_SelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp; 组名称：<input type="text" id="zuname" name="zuname" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="zuname"
                                ErrorMessage="组名不能为空！" ForeColor="OrangeRed"></asp:RequiredFieldValidator></p>
                        <p style="display: none">
                            权限：<label><input id="limit_all" type="checkbox" onclick="allSelect('limit_all',this,'permit');" />
                                全部</label>
                        </p>
                    </div>
                    <div id="permit">
                        <h2 style="display: none">
                            系统管理</h2>
                        <div class="ruleList">
                            <asp:Repeater ID="productlist" runat="server">
                                <HeaderTemplate>
                                    <b>字段组：</b></HeaderTemplate>
                                <ItemTemplate>
                                    &nbsp;[ <a href="?action=edit&fun=<%=CurFunction %>&id=<%# Eval("id") %>">
                                        <%# Eval("RuleName") %></a> &nbsp; <a href="#" onclick="if (confirm('您确定要删除组别吗？')) { location.href='?action=del&fun=<%=CurFunction %>&id=<%# Eval("id")%>';} else { location.href='?action=edit&fun=<%=CurFunction %>&id=<%# Eval("id") %>';}">
                                            删除</a>]
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <%--新闻管理--%>
                        <asp:Panel ID="panel_news" runat="server" Visible="false">
                            <div class="ruleList">
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <HeaderTemplate>
                                        <b>字段组：</b></HeaderTemplate>
                                    <ItemTemplate>
                                        &nbsp;[ <a href="?action=edit&fun=<%=CurFunction %>&id=<%# Eval("id") %>">
                                            <%# Eval("RuleName") %></a> &nbsp; <a href="#" onclick="if (confirm('您确定要删除组别吗？')) { location.href='?action=del&fun=<%=CurFunction %>&id=<%# Eval("id")%>';} else { location.href='?action=edit&fun=<%=CurFunction %>&id=<%# Eval("id") %>';}">
                                                删除</a>]
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <fieldset>
                                <legend>
                                    <input name="power" id="Checkbox33" type="checkbox" onclick="allSelect('limit_pic',this,'limit_pic_all');"
                                        value="productsall" <%=ReturnCheck("productsall") %> />
                                    <label for="limit_system">
                                        图片管理字段管理</label></legend>
                                <ul class="limit_system_all">
                                    <li>
                                        <input name="power" id="Checkbox34" type="checkbox" value="newstitle" <%=ReturnCheck("newstitle") %> />
                                        <label for="limit_zu">
                                            标题</label></li>
                                    <li>
                                        <input name="power" id="Checkbox35" type="checkbox" value="NewsPhoto" <%=ReturnCheck("NewsPhoto") %> />
                                        <label for="limit_manager">
                                            图片</label></li>
                                    <li>
                                        <input name="power" id="Checkbox1" type="checkbox" value="MorePic" <%=ReturnCheck("MorePic") %> />
                                        <label for="limit_manager">
                                            更多图片</label></li>
                                    <li>
                                        <input name="power" id="Checkbox36" type="checkbox" value="isShow" <%=ReturnCheck("isShow") %> />
                                        <label for="limit_manager">
                                            新闻设置</label></li>
                                    <li>
                                        <input name="power" id="Checkbox37" type="checkbox" value="newstype" <%=ReturnCheck("newstype") %> />
                                        <label for="limit_zu">
                                            新闻类别</label></li>
                                    <li>
                                        <input name="power" id="Checkbox2" type="checkbox" value="Links" <%=ReturnCheck("Links") %> />
                                        <label for="limit_zu">
                                            链接地址</label></li>
                                    <li>
                                        <input name="power" id="Checkbox38" type="checkbox" value="txtContent" <%=ReturnCheck("txtContent") %> />
                                        <label for="limit_zu">
                                            详细介绍</label></li>
                                    <li>
                                        <input name="power" id="Checkbox11" type="checkbox" value="key1" <%=ReturnCheck("key1") %> />
                                        <label for="limit_zu">
                                            关键词一</label></li>
                                    <li>
                                        <input name="power" id="Checkbox12" type="checkbox" value="key2" <%=ReturnCheck("key2") %> />
                                        <label for="limit_zu">
                                            关键词二</label></li>
                                </ul>
                                <div class="cf">
                                </div>
                            </fieldset>
                        </asp:Panel>
                        <%--新闻管理 --%>
                        <%--产品中心 --%>
                        <asp:Panel ID="panel_product" runat="server" Visible="false">
                            <fieldset>
                                <legend>
                                    <input name="power" id="limit_system" type="checkbox" onclick="allSelect('limit_system',this,'limit_system_all');"
                                        value="productsall" <%=ReturnCheck("productsall") %> />
                                    <label for="limit_system">
                                        产品字段管理</label></legend>
                                <ul class="limit_system_all">
                                    <li <%=ReturnCheck("producttitle") %>>
                                        <input name="power" id="limit_zu" type="checkbox" value="producttitle" <%=ReturnCheck("producttitle") %> />
                                        <label for="limit_zu">
                                            品名</label></li>
                                    <li <%=ReturnCheck("entitle") %>>
                                        <input name="power" id="Checkbox9" type="checkbox" value="entitle" <%=ReturnCheck("entitle") %> />
                                        <label for="limit_zu">
                                            英文标题</label></li>
                                    <li <%=ReturnCheck("productno") %>>
                                        <input name="power" id="Checkbox10" type="checkbox" value="productno" <%=ReturnCheck("productno") %> />
                                        <label for="limit_manager">
                                            产品编号</label></li>
                                    <li <%=ReturnCheck("price") %>>
                                        <input name="power" id="Checkbox3" type="checkbox" value="price" <%=ReturnCheck("price") %> />
                                        <label for="limit_manager">
                                            产品原价</label></li>
                                     <li <%=ReturnCheck("Material") %>>
                                        <input name="power" id="Checkbox16" type="checkbox" value="Material" <%=ReturnCheck("Material") %> />
                                        <label for="limit_manager">
                                            材质</label></li>
                                    <li <%=ReturnCheck("sale") %>>
                                        <input name="power" id="Checkbox17" type="checkbox" value="sale" <%=ReturnCheck("sale") %> />
                                        <label for="limit_zu">
                                            销售价格</label></li>
                                    <li <%=ReturnCheck("saletime") %>>
                                        <input name="power" id="Checkbox18" type="checkbox" value="saletime" <%=ReturnCheck("saletime") %> />
                                        <label for="limit_zu">
                                            销售时间</label></li>
                                    <li <%=ReturnCheck("proset") %>>
                                        <input name="power" id="Checkbox66" type="checkbox" value="proset" <%=ReturnCheck("proset") %> />
                                        <label for="limit_zu">
                                            产品设置</label></li>
                                    <li <%=ReturnCheck("producttype") %>>
                                        <input name="power" id="Checkbox4" type="checkbox" value="producttype" <%=ReturnCheck("producttype") %> />
                                        <label for="limit_manager">
                                            产品类别</label></li>
                                    <li <%=ReturnCheck("productphoto") %>>
                                        <input name="power" id="Checkbox5" type="checkbox" value="productphoto" <%=ReturnCheck("productphoto") %> />
                                        <label for="limit_manager">
                                            产品图片</label></li>
                                    <li <%=ReturnCheck("productphotobig") %>>
                                        <input name="power" id="Checkbox6" type="checkbox" value="productphotobig" <%=ReturnCheck("productphotobig") %> />
                                        <label for="limit_zu">
                                            产品大图</label></li>
                                    <li <%=ReturnCheck("features") %>>
                                        <input name="power" id="Checkbox7" type="checkbox" value="features" <%=ReturnCheck("features") %> />
                                        <label for="limit_zu">
                                            产品简介</label></li>
                                    <li <%=ReturnCheck("productcontent") %>>
                                        <input name="power" id="Checkbox8" type="checkbox" value="productcontent" <%=ReturnCheck("productcontent") %> />
                                        <label for="limit_zu">
                                            详细介绍(中)</label></li>
                                    <li <%=ReturnCheck("encontent") %>>
                                        <input name="power" id="Checkbox15" type="checkbox" value="encontent"  <%=ReturnCheck("encontent") %> />
                                        <label for="limit_zu">
                                            详细介绍（英）</label></li>
                                    <li <%=ReturnCheck("key1") %>>
                                        <input name="power" id="Checkbox13" type="checkbox" value="key1" <%=ReturnCheck("key1") %> />
                                        <label for="limit_zu">
                                            关键词（keywords）</label></li>
                                    <li <%=ReturnCheck("key1") %>>
                                        <input name="power" id="Checkbox14" type="checkbox" value="key2" <%=ReturnCheck("key2") %> />
                                        <label for="limit_zu">
                                            关键词（Despions）</label></li>
                                </ul>
                                <div class="cf">
                                </div>
                            </fieldset>
                        </asp:Panel>
                        <%--产品中心 --%>
                        <div class="btn">
                            <input class="inp1" type="button" value="增 加" runat="server" id="Button1" onserverclick="Button1_ServerClick" />
                        </div>
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
    <script type="text/javascript" language="javascript">
        function CheckForm()//无刷新顶
        {
            var zuname = document.getElementById("zuname").value;

            if (zuname == "") {
                alert('请输入名称！');
                document.getElementById("zuname").focus();
                return false;
            }

            if (!isSelect('permit')) {
                window.alert('请勾选权限');
                return false;
            }

        }
    </script>
</body>
</html>
