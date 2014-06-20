<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true"
    CodeBehind="detail.aspx.cs" Inherits="Song.Web.detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/lightbox.css" rel="stylesheet" type="text/css" media="screen" />
    <meta name="Description" content="<%=Maticsoft.Common.webcommand.GetCompayInfo6()%>">
    <meta name="keywords" content="<%=Maticsoft.Common.webcommand.GetCompayInfo7()%>">
    <script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="js/lightbox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater runat="server" ID="Repeater1" OnItemDataBound="Repeater1_ItemDataBound">
        <ItemTemplate>
            <div id="pro_info">
                <div class="left">
                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("moreno") %>' />
                    <asp:Repeater runat="server" ID="Repeater2">
                        <ItemTemplate>
                            <a href="/uploadfile/pic/<%#Eval("Pic") %>" rel="lightbox["box"]" >
                                <img src="/uploadfile/pic/<%#Eval("Pic") %>" width="491" height="350" border="0" title="点击查看更多图片"></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="right">
                    <!--<div class="bigimg">
                <a href="images/201041171916569.jpg" target="_blank">
                    <img src="images/pro_info_06.jpg" width="99" height="30" border="0">
                </a>
            </div>-->
                    <h3>
                        &nbsp; <%#Eval("title") %>
                    </h3>
                    <div class="info">
                        <strong>规 格：</strong> <%#Eval("prono")%>
                        <br>
                        <br>
                        <strong>颜 色：</strong> <%#Eval("saleprice")%>
                        <br>
                        <br>
                        <strong>原 价：</strong>￥<%#Eval("price")%>
                        <br>
                        <br>
                        <strong style="color:#800000">优惠价：</strong><font style="color:#800000"><%#Eval("text2") %></font></span></span>
                        <br>
                        <br>
                        <br>
                        <span><==点击左边图片可浏览：<span><font>多图、大图</font></span></span>
                    </div>
                </div>
            </div>
            <div id="pro_help">
                <div class="info">
                    <strong>产品介绍</strong>：<br>
                    <%#Eval("features")%>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
