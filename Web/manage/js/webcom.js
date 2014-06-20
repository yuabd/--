$(function () {
    var id = request("id");
    var no = $("#morePicNo").val();
    $("#addpic").click(function () {
        $.XYTipsWindow({
            ___title: "添加/管理 更多图片",
            ___content: "iframe:MorePic.aspx?classid=" + id + "&no=" + no,
            ___width: "465",
            ___height: "300"
        });
    });

    //添加更多款式
    $("#addnewpro").click(function () {
        $.XYTipsWindow({
            ___title: "添加/管理 更多款式",
            ___content: "iframe:MoreProManage.aspx?pid=" + request("pid") + "&mid=" + request("mid") + "&ismore=1&no=" + no,
            ___width: "770",
            ___height: "400"
        });
    });

    //添加更多套装
    $("#addpic2").click(function () {
        $.XYTipsWindow({
            ___title: "添加/管理 套装商品",
            ___content: "iframe:AddProManage.aspx?pid=" + request("pid") + "&mid=" + request("mid") + "&no=" + no,
            ___width: "700",
            ___height: "450"
        });
    });

})




/*--获取网页传递的参数--*/
function request(paras) {
    var url = location.href;
    var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
    var paraObj = {}
    for (i = 0; j = paraString[i]; i++) {
        paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
    }
    var returnValue = paraObj[paras.toLowerCase()];
    if (typeof (returnValue) == "undefined") {
        return "";
    } else {
        return returnValue;
    }
}


/*--功能管理修改--*/

function UpdeteClass(id) {
    var name = $("#c_" + id).attr("value");
    var enname = $("#e_" + id).attr("value");
    var fun = $("#f_" + id).attr("value");
    var pageid = $("#p_" + id).attr("value");
    //var parm =  encodeURI($("#u_"+id).attr("value"));
    //alert(parm);
    var isSelf = $("#i_" + id).attr("checked");
    var isShow = $("#show_" + id).attr("checked");
    var LinkUrl = $("#Url_" + id).attr("value");
    $.post("AjaxWebService.aspx?come=menu&id=" + id + "&isSelf=" + isSelf + "&isShow=" + isShow + "&name=" + escape(name) + "&enname=" + escape(enname) + "&fun=" + fun + "&LinkUrl=" + LinkUrl + "&pageid=" + pageid, null, function (result) { alert(result); });
}

function UpdeteSuccess(result) {
    alert(result);
}
/*--功能管理修改--*/

/*--全选--*/
$(function () {
    $("#selectall").click(function () {
        if (this.checked) {
            //全选
            $("input[name='allbox']").each(function () {
                this.checked = true;
            });
            $("#delall").attr("disabled", false);
        }
        else {
            //反选
            $("input[name='allbox']").each(function () {
                this.checked = false;
            });
            $("#delall").attr("disabled", true);
        }
    })
})

//单选框有选择，删除按钮启动
function ShowDelBtn() {
    var isCheck = false;
    var isAll = true;
    $("input[name='allbox']").each(function () {
        if (this.checked) {
            isCheck = true; //用来控制删除按钮
        }
        else {
            isAll = false; //用来控制全选按钮
        }
    })
    //删除按钮
    if (isCheck == true) {
        $("#delall").attr("disabled", false);
    }
    else {
        $("#delall").attr("disabled", true);
    }
    //全选框
    if (isAll == true) {
        $("#selectall").attr("checked", true);
    }
    else {
        $("#selectall").attr("checked", false);
    }
}

function DelListDate(name) {
    if (confirm("您确定要删除吗？请谨慎操作！")) {
        var list = "";
        $("input[name='" + name + "']").each(function () {
            if (this.checked) {
                list += this.id + ",";
            }
        })
        list += "0";
        window.location.href = '?action=deletetype&pid=' + $("#pid").attr("value") + '&mid=' + $("#mid").attr("value") + '&idlist=' + list;
    }
    else {
        return false;
    }
}

/*--全选--*/

//显示开始时间
function ShowTr() {
    var isSale = $("#isSale").attr("checked");
    if (isSale == true) {
        //$("#stime").css("display", "block");
        //$("#etime").css("display", "block");
        $("#vprice").css("display", "block");
    } else {
        //$("#stime").css("display", "none");
        //$("#etime").css("display", "none");
        $("#vprice").css("display", "none");
    }
}


function showMsg(title, url, w, h) {
    var div = "<div ><iframe src=\"" + url + "\" width='" + w + "' height='" + h + "' frameborder='0' ></iframe></div>";
    h = parseInt(h) + 30;
    popWin(title, div, w, h);
}
