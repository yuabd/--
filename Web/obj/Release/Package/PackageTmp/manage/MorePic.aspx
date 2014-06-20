<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MorePic.aspx.cs" Inherits="Song.Web.manage.testPic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>多图片上传</title>
    <script src="js/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function addFile(id) {
            var div = document.createElement("div");
            div.setAttribute("id", id);
            div.innerHTML += "<br />";
            var f = document.createElement("input");
            f.setAttribute("type", "text");
            f.setAttribute("name", "txtTitle");
            f.setAttribute("size", "50");
            div.innerHTML += "<span>标题：</span>";
            div.appendChild(f);
            div.innerHTML += "<br />";
            //            f = document.createElement("textarea");
            //            f.setAttribute("name", "txtDetail");
            //            f.setAttribute("cols", "44");
            //            f.setAttribute("rows", "2");
            //            div.innerHTML += "<span>说明：</span>";
            //            div.appendChild(f);
            div.innerHTML += "<br />";
            f = document.createElement("input");
            f.setAttribute("type", "file");
            f.setAttribute("name", "File");
            f.setAttribute("size", "50");
            div.innerHTML += "<span>图片：</span>";
            div.appendChild(f);

            //IE不支持
            var d = document.createElement("input");
            d.setAttribute("type", "button")
            d.setAttribute("name", "del")
            d.setAttribute("onclick", "deteFile(this)");
            d.setAttribute("value", "移除")
            div.appendChild(d)
            div.innerHTML += "<br />";
            document.getElementById("_container").appendChild(div);

            //IE情况下，设置按钮属性
            //$("input[type=button]").click(function(){ deteFile(this) });
            $("input[name=del]").click(function () { deteFile(this) });
        }

        //删除节点
        function deteFile(o) {
            while (o.tagName != "DIV") o = o.parentNode;
            o.parentNode.removeChild(o);
        }

        //查找出改产品中



        //    $.ajax({url:"http://www.baidu.com",cache = false, success:function(html){$("#result").append(html)}})
        //$get("http://www.baidu.com",function(){ alert("1") })//get
        //$post("http://www.baidu.com","{'id':1}",function(){ alert("1") });//post
        //  </script>
    <style type="text/css">
    <!--
        .PicList { width:100%;  font-size:12px; float:left }
        .PicList ul { padding:0px; margin:0px; }
        .PicList li { list-style:none; padding:0px; margin:0px; margin-left:10px; float:left; width:80px; height:80px;overflow:hidden; border:1px solid #aaa; text-align:center; }
        .PicList_Link { margin-top:5px; }
        a:link,a:visted { color:#333; text-decoration:none;}
        a:hover { color:#ff9900; text-decoration:underline; } 
    -->
</style>
</head>
<body>
    <form id="form1" runat="server" method="post" enctype="multipart/form-data">
    <div class="PicList">
        <table width="100%" style="border: 1px solid #9CAAC1;" cellpadding="0" cellspacing="0">
            <tr style="height: 30px; background-color: #9CAAC1; font-size: 14px;">
                <td align="center" style="width: 120px; display: none;" >
                    标题
                </td>
                <%--                <td align="center">
                    图片说明
                </td>--%>
                <td align="center">
                    图片
                </td>
                <td align="center">
                    添加日期
                </td>
                <td align="center">
                    操作
                </td>
            </tr>
            <asp:Repeater ID="NList" runat="server" OnItemCommand="NList_ItemCommand" OnItemDataBound="NList_ItemDataBound">
                <ItemTemplate>
                    <tr style="height: 70px;">
                        <td align="center" style="border-bottom: 1px solid #9CAAC1; display: none;">
                            <input id="PicTitle<%#Eval("id") %>" name="PicTitle<%#Eval("id") %>" type="text"
                                value="<%#Eval("Title") %>" />
                        </td>
                        <%-- <td align="center" style="border-bottom: 1px solid #9CAAC1;">
                            <asp:DropDownList ID="color1" runat="server">
        </asp:DropDownList>
                            <textarea name="PicDetail<%#Eval("id") %>" rows="2" cols="20" id="PicDetail<%#Eval("id") %>"
                                style="height: 50px; width: 220px;"><%#Eval("Detail") %></textarea>
                        </td>--%>
                        <td align="center" style="border-bottom: 1px solid #9CAAC1;">
                            <img height="60px;" src="../UploadFile/Spic/<%#Eval("Pic") %>" />
                        </td>
                        <td align="center" style="border-bottom: 1px solid #9CAAC1;">
                            <%#Eval("timeinfo") %>
                        </td>
                        <td align="center" style="border-bottom: 1px solid #9CAAC1;">
                            <asp:LinkButton ID="Btn_Update" CommandArgument='<%#Eval("id") %>' CommandName='Update'
                                runat="server">修改</asp:LinkButton>
                            &nbsp;|&nbsp;<asp:LinkButton ID="btn_Del" CommandArgument='<%#Eval("id") %>' CommandName='Del'
                                runat="server">删除</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div id="_container" style="float: left; padding-top: 20px; line-height: 30px; width: 100%">
        <span>标题：</span><input name="txtTitle" size="50" type="text" /><br />
        <%--<span>说明：</span><textarea name="txtDetail" cols="44" rows="2"></textarea><br />--%>
        <span>图片：</span><input type="file" size="50" name="File" /> 图片大小： 490px*350px<br />
    </div>
    <div style="float: left; padding-top: 20px;">
        <%--<input type="button" value="添加文件(Add)" onclick="addFile('')" />--%>
        <asp:Button runat="server" Text="开始上传" ID="UploadButton" OnClick="UploadButton_Click">
        </asp:Button>
    </div>
    <div style="padding: 10px 0">
    </div>
    <div>
        <asp:Label ID="strStatus" runat="server" Font-Names="宋体" Font-Bold="True" Font-Size="9pt"
            Width="450px" BorderStyle="None" BorderColor="White"></asp:Label>
    </div>
    </form>
</body>
</html>
