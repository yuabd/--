//获取页面名称
function GetPageName()
{
        var u = window.location.href;//js获取当前页面url
        var n = u.lastIndexOf("/");
        if(n == -1){
                n = u.lastIndexOf("\\");
        }
        var s = u.substr(n +1);//截取文件名
        //var n2 = s.lastIndexOf(".");
        //var s = s.substring(0,n2);
        return s;
}

//绑定菜单样式
function BindTopNav()
{
    var nid = $.cookie('nid');
    
    var page = GetPageName();
    
    switch(page)
    {
        case "Default.aspx":
            nid=1;
        break;
        case "News.aspx":
            nid=2;
        break;
        case "Tuan.aspx":
            nid=3;
        break;
        case "Preferential.aspx":
            nid=4;
        break;
        case "Spike.aspx":
            nid=5;
        break;
        case "Mall.aspx":
            nid=6;
        break;
        case "ShopList.aspx?bid=2":
            nid=7;
        break;
        case "ShopList.aspx?bid=1":
            nid=8;
        break;
        case "ShopList.aspx?bid=3":
            nid=9;
        break;
        case "Point.aspx":
            nid=10;
        break;
    }
    
    if(nid != "")
    {
       $("#nav"+nid).addClass("on");
    }
    else
    {
       $("nav1").addClass("on");
    }
  
}
//绑定菜单样式
function NavCss(id)
{
 //$(".menu_box a").removeClass("on");
//for(i=1;i<=10;i++)
//{
        $(".menu_box a").removeClass("on");
//}
    $("#nav"+id).addClass("on");
    $.cookie('nid',id);
    
}

//绑定菜单样式
function NavCss2(id)
{
    $(".admin_sidebar_box li").removeClass("current");
    $("#m"+id).addClass("current");
    $.cookie('lid',id);
}

//绑定菜单样式
function BindTopNav2()
{
    var nid = $.cookie('lid');
     $(".admin_sidebar_box li").removeClass("current");
    
    if(nid != "")
    {
       $("#m"+nid).addClass("current");
    }
    else
    {
       $("#m2").addClass("current");
    }
  
}

//判断是否为数字
function CheckNum(id)
{
    var num = $("#"+id).attr("value");
    if(isNumber(num)==true)
    {
         $("#"+id).attr("value","1");
    }
}


//购物车判断是否为数字
function CheckNum2(id)
{
    var num = $("#"+id).attr("value");
    var oldnum = $("#"+id).attr("rel");
    if(isNumber(num)==true)
    {
         $("#"+id).attr("value",oldnum) 
    }
    else
    {
         $("#"+id).attr("rel",num) 
    }
}

function isNumber(str)
{
    if(isNaN(str))
    {
        return true;
    }
    else
    {
        return false;
    }
}


function ShowUserAdd(id)
{
    //var hid_curid = $("#curid").attr("value");
    //alert(hid_curid);
    $(".adddetail:visible").slideUp();
    //$(".adddetail:not(:first)").slideUp();
    $("#div"+id).slideDown();
}

//加载详细产品页左侧图片
function ShowPic(id)
{
    var pic = $("#img"+id).attr("rel");
    $("#propic").attr("src","UploadFile/Pic/p"+pic);
    $("#propic").attr("rel","UploadFile/Pic/"+pic);
}

//加载修改地址修改信息
function BindUpdate()
{
   $("input[name='useradd']").each(function(){
        if(this.checked==true)
        {
            var id = this.value;
            $("#hid_curid").attr("value",id);
            $("#adbox"+id).slideUp();
            $("#AddBox2").slideDown();
            $("#cnname").attr("value",$("#hid_username"+id).attr("value"));
            $("#detailadd").attr("value",$("#hid_prov"+id).attr("value"));
            $("#detailadd").attr("value",$("#hid_city"+id).attr("value"));
            $("#detailadd").attr("value",$("#hid_area"+id).attr("value"));
            $("#detailadd").attr("value",$("#hid_address"+id).attr("value"));
            $("#postcode").attr("value",$("#hid_postno"+id).attr("value"));
            $("#tel").attr("value",$("#hid_tel"+id).attr("value"));
            $("#mobile").attr("value",$("#hid_mobile"+id).attr("value"));
        }
   })
}

//保存地址修改数据
function SvaeAdd()
{
        var id = $("#hid_curid").attr("value");
        var curuser= $("#hid_curuser").attr("value");
        
        //文本框值
        var cnname = $("#cnname").attr("value");
        var detailadd = $("#detailadd").attr("value");
        var postcode = $("#postcode").attr("value");
        var tel = $("#tel").attr("value");
        var mobile = $("#mobile").attr("value");
        var prov = $("#province").attr("value");
        var city = $("#city").attr("value");
        var area = $("#area").attr("value");
        
        //将值显示到文本内
        $("#span_cnname"+id).text(cnname);
        //$("#span_prov"+id).text(detailadd);
        //$("#span_city"+id).text($("#detailadd").attr("value"));
        //$("#spanspan_area"+id).text($("#detailadd").attr("value"));
        $("#span_address"+id).text($("#detailadd").attr("value"));
        $("#span_postno"+id).text(postcode);
        $("#span_tel"+id).text(tel);
        $("#span_mobile"+id).text(mobile);

        //将值存入隐藏域
        $("#hid_username"+id).attr("value",cnname);
        //$("#hid_prov"+id).attr("value",$("#detailadd").attr("value"));
        //$("#hid_city"+id).attr("value",$().attr("value"));
        //$("#hid_area"+id).attr("value",$("#detailadd").attr("value"));
        $("#hid_address"+id).attr("value",detailadd);
        $("#hid_postno"+id).attr("value",postcode);
        $("#hid_tel"+id).attr("value",tel);
        $("#hid_mobile"+id).attr("value",mobile);
        
        //$("#AddBox2").slideUp();
        //$("#adbox"+id).slideDown();
        
        //保存至数据库
        //$.get("AjaxService/AjaxDate.aspx",{action:"updateuseradd",{g_cnname:cnname,g_id:id},function(){} });
        
        if(cnname == "" || detailadd == "" || postcode == "" || tel =="")
        {
            alert('为了保证您的商品及时送达，请填写完整资料！');
            return false;
        }
        else
        {
         $.get("AjaxService/AjaxDate.aspx", {action:"insertuseradd",name:curuser,cnname:cnname,tel:tel,zip:postcode,street:detailadd,province:prov,city:city,area:area}, function (data, textStatus){
                //返回的 data 可以是 xmlDoc, jsonObj, html, text, 等等.
                this; // 在这里this指向的是Ajax请求的选项配置信息，请参考下图
                alert(data);
                //alert(textStatus);//请求状态：success，error等等。
                //当然这里捕捉不到error，因为error的时候根本不会运行该回调函数
                //alert(this);
                });

            window.location.href="Cart.aspx";
        }
}

//产品推荐第一项默认选中
function DefautRecom()
{
    $("#recom li:first").addClass("hover");
}

//首页推荐产品
function GetPro(bid)
{
    $("#recom li").removeClass("hover");
    $("#li"+bid).addClass("hover");//添加定位样式
    $("#con_zzjs_1").load("AjaxService/DefaultRecommendPro.aspx?bid="+bid);
}

//购物车增加商品数
function CutCart(id,type)
{
    var num = Number($("#"+id).attr("value"));
    if(num >1)
    {
           num = num-1;
           if(num<0)
           {
             num = 0;
           }
           window.location.href="?action=quantity&num="+ num +"&itemid="+ id +"";
           //UpdateCart(id,num,type);
    }
    else
    {
        $("#a"+id).removeAttr("href");//小于1按钮不可用
    }
}

//购物车减少商品数
function AddCart(id,type)
{
    var num = Number($("#"+id).attr("value"));
    if(num < 99)
    {
           num = num+1;
           //UpdateCart(id,num,type);
           window.location.href="?action=quantity&num="+ num +"&itemid="+ id +"";
    }
    else
    {
        $("#a2"+id).removeAttr("href");//增加数量
    }
}

function SetCart(id)
{
   CheckNum(id);
   var num = Number($("#"+id).attr("value"));
   UpdateCart(id,num);
   window.location.href=window.location.href;
}
//更新购物车数据
function UpdateCart(id,num,type)
{
    //$("#cartbox").load("AjaxService/UpdateCart.aspx?type="+ type +"&action=quantity&itemid="+id+"&num="+num);
    window.location.href="ShoppingCart.aspx?action=quantity&itemid="+id+"&num="+num;
}

//商品详细页产品价格小计
function SmallPrice(id)
{   
    CheckNum(id);
    var num = $("#"+id).attr("value");
    
    if(num > 0)
    {
        var price =  $("#ProPrice").attr("value");
        if(price != "")
        {
            html = "<font class='rFont fz14'><b>小计：￥"+ Number(price)*num +"</b></font>";
            $("#smallprice").html(html);
        }
    }
}
//邮箱验证
function checkEmail(email){
var emailRegExp = new RegExp(            "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
if (!emailRegExp.test(email)||email.indexOf('.')==-1){
return false;
}else{
return true;
}
}


//订阅 邮件
function SubEmail(id)
{
   key = $("#"+id).attr("value");
   if(key != "" && key != "输入Email,订阅每日团购信息")
   {
    if(checkEmail(key)==true)
    {
        alert('感谢您订阅本站邮件，城市商家祝您生活愉快！');
    }
    else
    {
        alert('您输入的邮箱格式错误！');
    }
   }
   else
   {
    alert('请输入Email,订阅每日团购信息！');
   }    
}

//加载积分
function LoadSing()
{
    var f1 = $("#f1").attr("value");
    var f2 = $("#f2").attr("value");
    var f3 = $("#f3").attr("value");
    WriteSing("1",Number(f1));
    WriteSing("2",Number(f3));
    WriteSing("3",Number(f3));

    //统计平均积分
    //total = Number(f1) + Number(f2) + Number(f3);
    //var comnum = $("#hid_comnum").attr("value");
    //if(comnum != "" && comnum != "0")
    //{
    //    var f = Number(total)/Number(comnum);
    //    $("#shopf").html(f);
    //}
    //else
    //{
    //    $("#shopf").html("10");
    //}
    
}

function WriteSing(id,f)
{
    var tmp = "";
    for(var i=0;i<f;i++)
    {
        tmp += "<img src='images/star.jpg' />";
    }
    
    for(var i=0;i<5-f;i++)
    {
        tmp += "<img src='images/star-empty.jpg' />";
    }
    $("#sing"+id).html(tmp);
}

function SetDeli()
{
    var deli = $("input[name='Delivery'][checked]").val();
    if(deli == "Express")
    {
        var money = 10;
        $("#hid_expressmoney").val(money);
        $("#s_delimoney").text("￥" + String(money));
        var totalmoney = $("#CartModel1_hid_ordermoney").val()
        var spantext = "￥" + String(Number(totalmoney)+Number(money));
        $("#s_totalmoney").text(spantext);
        
    }
    if(deli == "Self")
    {
        $("#hid_expressmoney").val("0");
        $("#hid_expressmoney").val(money);
        $("#s_delimoney").text("￥0");
        var totalmoney = $("#CartModel1_hid_ordermoney").val()
        $("#s_totalmoney").text("￥" + String(Number(totalmoney)));
    }
}


//显示对应购物车
function ShowCartLink()
{
    var   strPathName=window.location.pathname; 
    var   strPageName=strPathName.substring((strPathName.lastIndexOf( '/ ')+1),strPathName.length); 
    
    //团购购物车
    if(strPageName.indexOf('Tuan')>-1)
    {
        $("#cartlink").html("<img src='images/carico.gif'/> <a href='Cart.aspx'>团购购物车</a> ");
    }
    
    //秒杀购物车
    if(strPageName.indexOf('Spike')>-1)
    {
        $("#cartlink").html("<img src='images/carico.gif'/> <a href='Cart.aspx'>秒杀购物车</a> ");
    }
    
    //商城购物车
    if(strPageName.indexOf('Mall')>-1 || strPageName.indexOf('Pro')>-1)
    {
        $("#cartlink").html("<img src='images/carico.gif'/> <a href='OrderCart.aspx'>商城购物车</a> ");
    }
}

//检查用户是否被注册
function CheckUser(username)
{
    var username = $("#"+username).val();
    //var usertype = $("input[name='membertype'][checked]").val();
    usertype = "personal";
    $("#checkuser").load("AjaxService/AjaxDate.aspx?action=checkuser&type="+ usertype +"&username="+username);

}

//检查邮箱是否被注册
function CheckEmail(email)
{
    var useremail = $("#"+email).val();
    var usertype = $("input[name='membertype'][checked]").val();
    $("#checkemail").load("AjaxService/AjaxDate.aspx?action=checkemail&type="+ usertype +"&useremail="+useremail);

}

//检查验证码输入是否正确
function CheckCode(codeid)
{
    var code = $("#"+codeid).val();
    $("#checkbox").load("AjaxService/AjaxDate.aspx?action=checkcode&code="+code);

}

//字符超出隐藏
function CheckStr(str,len)
{
    if(str.length > Number(len))
    {
        document.write(str.substring(0,len)+"..");
    }
    else
    {
        document.write(str);
    }
}

//在线充值
function OnlineMoney()
{
    var money = $("#money").val();
    if(money != "")
    {
         window.location.href="PayCenter.aspx?payment=alipay&m="+money;
    }
}

//商铺支持
function Support(id)
{
    var isSupport = $.cookie('support');
    if(isSupport != null && Number(isSupport) == Number(id))
    {
      alert('您已经支持过喽！');
    }else{
       
       $.cookie('support',id);
        var curnum = $("#supportnum").html();
        $("#supportnum").html(Number(curnum)+1)
        alert("感谢您对本店的支持！");
        $.get("AjaxService/AjaxDate.aspx", {action:"support",shopid:id}, function (data, textStatus){});
    }

}

//订单查询
function OrderSearch()
{
   var key = $("#orderno").val();
   window.location.href='?key='+key;
}

//根据时间查询订单
function MonthOrder()
{
   var key = $("#ordertime").val();
   window.location.href='?ordertime='+key;
}

//订单状态查询订单
function OrderState()
{
   var key = $("#orderstate").val();
   window.location.href='?state='+key;
}


//颜色选择
function SelColor(sizelist,id)
{
    var tmp = "",htmlstr="",photo="";
    var i=0;
    
    $("#ProColor").val(id);
    photo = $("#img"+id).attr("alt");
    $("#photo").val(photo);
    $("#colordd a").removeClass("current");
    $("#color"+id).addClass("current");
    //$("#sizedd").html("xx");
    
    if(sizelist != "")
    {
        var str = sizelist.split('|');
        for(i=0;i<str.length;i++)
        {
            tmp = str[i];
            if(tmp != "")
            {
                var s2 = tmp.split(',');
                if(s2[0]!="")
                {
                    htmlstr += "<a  class=\"size\" id='css" + s2[0] + "' onclick=SelSize('" + s2[0] + "','" + s2[1] + "')>" + s2[0] + "<span class=\"ext_bg\"></span></a><input name='size' id='size" + s2[0] + "' value='" + s2[0] + "' type='hidden' /><input name='sizenum' id='sizenum" + s2[0] + "' value='" + s2[1] + "' type='hidden' />";
                }
            }
        }
        $("#sizedd").html(htmlstr);
    }
    LoadPhoto(id);
}

//尺码选择
function SelSize(size,sizenum)
{
    //未选中前
    $("#ProSize").val(size);
    $("#sizedd a").removeClass("current");
    $("#css"+size).addClass("current");
    if(Number(sizenum)>0)
    {
        $("#stock").html(sizenum);
        $("#ImageButton1").removeAttr("disabled"); 
        $("#ImageButton2").removeAttr("disabled");
    }
    else
    {
        $("#stock").html("无货");
        //$("#sizesel select option").attr({"disabled":"disabled"});
        $("#ImageButton1").attr({"disabled":"disabled"}); 
        $("#ImageButton2").attr({"disabled":"disabled"}); 

    }
}


//加载图片展示
function LoadPhoto(id)
{
    $("#photoshow").load("AjaxService/PhotoShow.aspx?id="+id);
}

//选择默认地址
function BindTopAdd() {
    var sel = $(".all_addresses input[type='radio']:checked").val();
    if (sel != undefined && sel != "") {
    }
    else {
        $(".all_addresses input[type='radio']:first").attr("checked", "checked");
    }
}

