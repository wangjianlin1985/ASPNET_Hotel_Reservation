<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Hotel_frontList" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/"; 
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
<title>酒店查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form1" runat="server">
	<div class="col-md-9 wow fadeInLeft">
		<ul class="breadcrumb">
  			<li><a href="../index.aspx">首页</a></li>
  			<li><a href="frontList.aspx">酒店信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加酒店</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpHotel" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?hotelId=<%#Eval("hotelId")%>"><img class="img-responsive" src="../<%#Eval("hotelPhoto")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		酒店id: <%#Eval("hotelId")%>
			     	</div>
			     	<div class="field">
	            		所在地区:<%#GetAreaareaObj(Eval("areaObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		酒店名称: <%#Eval("hotelName")%>
			     	</div>
			     	<div class="field">
	            		每日价格: <%#Eval("price")%>
			     	</div>
			     	<div class="field">
	            		发布时间: <%#Eval("addTime")%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?hotelId=<%#Eval("hotelId")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="hotelEdit('<%#Eval("hotelId")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="hotelDelete('<%#Eval("hotelId")%>');" style="display:none;">删除</a>
			     </div>
			</div>
			</ItemTemplate>
			</asp:Repeater>

			<div class="row">
				<div class="col-md-12">
					<nav class="pull-left">
						<ul class="pagination">
 						        <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
 						            onclick="LBHome_Click">[首页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
 						            onclick="LBUp_Click">[上一页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn"
 						            onclick="LBNext_Click">[下一页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
 						            onclick="LBEnd_Click">[尾页]</asp:LinkButton>
 						        <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
 						        <asp:HiddenField ID="HWhere" runat="server" Value=""/>
 						        <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
 						        <asp:HiddenField ID="HPageSize" runat="server" Value="8"/>
 						        <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
						</ul>
					</nav>
					<div class="pull-right" style="line-height:75px;" ><asp:Label runat="server" ID="PageMes"></asp:Label></div>
				</div>
			</div>
		</div>
	</div>

	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>酒店查询</h1>
		</div>
            <div class="form-group">
            	<label for="areaObj_areaId">所在地区：</label>
                <asp:DropDownList ID="areaObj" runat="server"  CssClass="form-control" placeholder="请选择所在地区"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="hotelName">酒店名称:</label>
				<asp:TextBox ID="hotelName" runat="server"  CssClass="form-control" placeholder="请输入酒店名称"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="addTime">发布时间:</label>
				<asp:TextBox ID="addTime"  runat="server" CssClass="form-control" placeholder="请选择发布时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>
  </form>
</div>
<div id="hotelEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;酒店信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="hotelEditForm" id="hotelEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="hotel_hotelId_edit" class="col-md-3 text-right">酒店id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="hotel_hotelId_edit" name="hotel.hotelId" class="form-control" placeholder="请输入酒店id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="hotel_areaObj_areaId_edit" class="col-md-3 text-right">所在地区:</label>
		  	 <div class="col-md-9">
			    <select id="hotel_areaObj_areaId_edit" name="hotel.areaObj.areaId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="hotel_hotelName_edit" class="col-md-3 text-right">酒店名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="hotel_hotelName_edit" name="hotel.hotelName" class="form-control" placeholder="请输入酒店名称">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="hotel_hotelPhoto_edit" class="col-md-3 text-right">酒店照片:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="hotel_hotelPhotoImg" border="0px"/><br/>
			    <input type="hidden" id="hotel_hotelPhoto" name="hotel.hotelPhoto"/>
			    <input id="hotelPhotoFile" name="hotelPhotoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="hotel_price_edit" class="col-md-3 text-right">每日价格:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="hotel_price_edit" name="hotel.price" class="form-control" placeholder="请输入每日价格">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="hotel_hotelDesc_edit" class="col-md-3 text-right">酒店介绍:</label>
		  	 <div class="col-md-9">
			    <textarea id="hotel_hotelDesc_edit" name="hotel.hotelDesc" rows="8" class="form-control" placeholder="请输入酒店介绍"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="hotel_hotelMemo_edit" class="col-md-3 text-right">备注信息:</label>
		  	 <div class="col-md-9">
			    <textarea id="hotel_hotelMemo_edit" name="hotel.hotelMemo" rows="8" class="form-control" placeholder="请输入备注信息"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="hotel_addTime_edit" class="col-md-3 text-right">发布时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date hotel_addTime_edit col-md-12" data-link-field="hotel_addTime_edit">
                    <input class="form-control" id="hotel_addTime_edit" name="hotel.addTime" size="16" type="text" value="" placeholder="请选择发布时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		</form> 
	    <style>#hotelEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxHotelModify();">提交</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改酒店界面并初始化数据*/
function hotelEdit(hotelId) {
	$.ajax({
		url :  basePath + "Hotel/HotelController.aspx?action=getHotel&hotelId=" + hotelId,
		type : "get",
		dataType: "json",
		success : function (hotel, response, status) {
			if (hotel) {
				$("#hotel_hotelId_edit").val(hotel.hotelId);
				$.ajax({
					url: basePath + "Area/AreaController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(areas,response,status) { 
						$("#hotel_areaObj_areaId_edit").empty();
						var html="";
		        		$(areas).each(function(i,area){
		        			html += "<option value='" + area.areaId + "'>" + area.areanName + "</option>";
		        		});
		        		$("#hotel_areaObj_areaId_edit").html(html);
		        		$("#hotel_areaObj_areaId_edit").val(hotel.areaObjPri);
					}
				});
				$("#hotel_hotelName_edit").val(hotel.hotelName);
				$("#hotel_hotelPhoto").val(hotel.hotelPhoto);
				$("#hotel_hotelPhotoImg").attr("src", basePath +　hotel.hotelPhoto);
				$("#hotel_price_edit").val(hotel.price);
				$("#hotel_hotelDesc_edit").val(hotel.hotelDesc);
				$("#hotel_hotelMemo_edit").val(hotel.hotelMemo);
				$("#hotel_addTime_edit").val(hotel.addTime);
				$('#hotelEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除酒店信息*/
function hotelDelete(hotelId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Hotel/HotelController.aspx?action=delete",
			data : {
				hotelId : hotelId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "Hotel/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交酒店信息表单给服务器端修改*/
function ajaxHotelModify() {
	$.ajax({
		url :  basePath + "Hotel/HotelController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#hotelEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                $("#btnSearch").click();
            }else{
                alert(obj.message);
            } 
		},
		processData: false,
		contentType: false,
	});
}

$(function(){
	/*小屏幕导航点击关闭菜单*/
    $('.navbar-collapse a').click(function(){
        $('.navbar-collapse').collapse('hide');
    });
    new WOW().init();

    /*发布时间组件*/
    $('.hotel_addTime_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd hh:ii:ss',
    	weekStart: 1,
    	todayBtn:  1,
    	autoclose: 1,
    	minuteStep: 1,
    	todayHighlight: 1,
    	startView: 2,
    	forceParse: 0
    });
})
</script>
</body>
</html>

