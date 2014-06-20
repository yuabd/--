<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true"
    CodeBehind="about.aspx.cs" Inherits="Song.Web.about" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="Description" content="<%=Maticsoft.Common.webcommand.GetCompayInfo6()%>">
    <meta name="keywords" content="<%=Maticsoft.Common.webcommand.GetCompayInfo7()%>">s
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main2">
        <div class="left">
            <div class="promenuborder">
                <img src="images/left_03.jpg" width="245" height="6" /></div>
            <div class="promenu">
                <div class="ban">
                    &nbsp;+ 关于我们</div>
                <ul>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <li><strong>&nbsp;- </strong><a href="about.aspx?id=<%#Eval("id") %>">
                                <%#Eval("ClassName")%></a> </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <div class="right">
            <h3>
                &nbsp; 首页&nbsp; >>&nbsp;<%=classname%>
                <% %></h3>
            <div class="text">
                <%=Maticsoft.Common.webcommand.GetInfo(pid,1) %>
            </div>
        </div>
    </div>
    <div id="leftfoot">
        <img src="images/left_06.jpg" width="245" height="6" /></div>
</asp:Content>
