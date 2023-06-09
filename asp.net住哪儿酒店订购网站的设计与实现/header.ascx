﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="header" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/";
%>
<!--导航开始-->
<nav class="navbar navbar-default navbar-fixed-top">
    <div class="container">
        <!--小屏幕导航按钮和logo-->
        <div class="navbar-header">
            <button class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a href="<%=basePath %>index.aspx" class="navbar-brand">住哪儿网</a>
        </div>
        <!--小屏幕导航按钮和logo-->
        <!--导航-->
        <div class="navbar-collapse collapse">
            <ul class="nav navbar-nav navbar-left">
                
                <li><a href="<%=basePath %>Hotel/frontlist.aspx?areaObj=1">成都酒店</a></li>
                <li><a href="<%=basePath %>Hotel/frontlist.aspx?areaObj=2">杭州酒店</a></li>
                <li><a href="<%=basePath %>Hotel/frontlist.aspx?areaObj=3">上海酒店</a></li>
                <li><a href="<%=basePath %>Hotel/frontlist.aspx?areaObj=4">广州酒店</a></li>
                <li><a href="<%=basePath %>Hotel/frontlist.aspx?areaObj=5">厦门酒店</a></li>
                <li><a href="<%=basePath %>Hotel/frontlist.aspx?areaObj=6">北京酒店</a></li>
                <!--
                <li><a href="<%=basePath %>UserInfo/frontlist.aspx">用户</a></li>
                <li><a href="<%=basePath %>Area/frontlist.aspx">地区</a></li>
                <li><a href="<%=basePath %>OrderInfo/frontlist.aspx">订单</a></li>
                <li><a href="<%=basePath %>Comment/frontlist.aspx">评论</a></li>
                -->
                <li><a href="<%=basePath %>Notice/frontlist.aspx">新闻公告</a></li>

            </ul>
            
             <ul class="nav navbar-nav navbar-right">
             	<%
                    String user_name = (String)Session["user_name"];
				    if(user_name==null){
	  			%> 
	  			<li><a href="<%=basePath %>UserInfo/frontAdd.aspx"><i class="fa fa-sign-in"></i>&nbsp;&nbsp;注册</a></li>
                <li><a href="#" onclick="login();"><i class="fa fa-user"></i>&nbsp;&nbsp;登录</a></li>
                
                <% } else { %>
                <li class="dropdown">
                    <a id="dLabel" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <%=Session["user_name"].ToString() %>
                        <span class="caret"></span>
                    </a>
                    <ul class="dropdown-menu" aria-labelledby="dLabel">
                        <li><a href="<%=basePath %>index.aspx"><span class="glyphicon glyphicon-screenshot"></span>&nbsp;&nbsp;首页</a></li>
                        <li><a href="<%=basePath %>OrderInfo/frontUserList.aspx"><span class="glyphicon glyphicon-user"></span>&nbsp;&nbsp;我的订单</a></li>
                        <li><a href="<%=basePath %>Comment/frontUserList.aspx"><span class="glyphicon glyphicon-cog"></span>&nbsp;&nbsp;我发布的评论</a></li>
                        <li><a href="<%=basePath %>UserInfo/frontSelfModify.aspx"><span class="glyphicon glyphicon-credit-card"></span>&nbsp;&nbsp;修改个人资料</a></li>
                        <!---<li><a href="<%=basePath %>index.aspx"><span class="glyphicon glyphicon-heart"></span>&nbsp;&nbsp;我的收藏</a></li>-->
                    </ul>
                </li>
                <li><a href="<%=basePath %>logout.aspx"><span class="glyphicon glyphicon-off"></span>&nbsp;&nbsp;退出</a></li>
                <% } %> 
            </ul>
            
        </div>
        <!--导航--> 
    </div>
</nav>
<!--导航结束--> 


<div id="loginDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-key"></i>&nbsp;系统登录</h4>
      </div>
      <div class="modal-body">
      	<form class="form-horizontal" name="loginForm" id="loginForm" enctype="multipart/form-data" method="post"  class="mar_t15">
      	  
      	  <div class="form-group">
			 <label for="userName" class="col-md-3 text-right">用户名:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="userName" name="userName" class="form-control" placeholder="请输入用户名">
			 </div>
		  </div> 
		  
      	  <div class="form-group">
		  	 <label for="password" class="col-md-3 text-right">密码:</label>
		  	 <div class="col-md-9">
			    <input type="password" id="password" name="password" class="form-control" placeholder="登录密码">
			 </div>
		  </div> 
		  
		</form> 
	    <style>#bookTypeAddForm .form-group {margin-bottom:10px;}  </style>
      </div>
      <div class="modal-footer"> 
		<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
		<button type="button" class="btn btn-primary" onclick="ajaxLogin();">登录</button> 
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->




 
<div id="registerDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-sign-in"></i>&nbsp;用户注册</h4>
      </div>
      <div class="modal-body">
      	<form class="form-horizontal" name="registerForm" id="registerForm" enctype="multipart/form-data" method="post"  class="mar_t15">
      	  
      	   
		  
		</form> 
	    <style>#bookTypeAddForm .form-group {margin-bottom:10px;}  </style>
      </div>
      <div class="modal-footer"> 
		<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
		<button type="button" class="btn btn-primary" onclick="ajaxRegister();">注册</button> 
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->






<script>

function register() {
	$("#registerDialog input").val("");
	$("#registerDialog textarea").val("");
	$('#registerDialog').modal('show');
}
function ajaxRegister() {
	$("#registerForm").data('bootstrapValidator').validate();
	if(!$("#registerForm").data('bootstrapValidator').isValid()){
		return;
	}

	jQuery.ajax({
		type : "post" , 
		url : basePath + "UserInfo/add",
		dataType : "json" , 
		data: new FormData($("#registerForm")[0]),
		success : function(obj) { 
			if(obj.success){ 
                alert("注册成功！");
                $("#registerForm").find("input").val("");
                $("#registerForm").find("textarea").val("");
            }else{
                alert(obj.message);
            }
		},
		processData: false,  
	    contentType: false, 
	});
}


function login() {
	$("#loginDialog input").val("");
	$('#loginDialog').modal('show');
}
function ajaxLogin() {
	$.ajax({
		url : "<%=basePath%>frontLogin.aspx",
		type : 'post',
		dataType: "json",
		data : {
			"userName" : $('#userName').val(),
			"password" : $('#password').val(),
		}, 
		success : function (obj, response, status) {
			if (obj.success) {
				
				location.href = "<%=basePath%>index.aspx";
			} else {
				alert(obj.message);
			}
		}
	});
}


</script> 
