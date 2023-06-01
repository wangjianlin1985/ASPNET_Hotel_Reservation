<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontUserList.aspx.cs" Inherits="OrderInfo_frontList" %>
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
<title>订单查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form2" runat="server">
	<div class="row"> 
		<div class="col-md-9 wow fadeInDown" data-wow-duration="0.5s">
			<div>
				<!-- Nav tabs -->
				<ul class="nav nav-tabs" role="tablist">
			    	<li><a href="../index.aspx">首页</a></li>
			    	<li role="presentation" class="active"><a href="#orderInfoListPanel" aria-controls="orderInfoListPanel" role="tab" data-toggle="tab">订单列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加订单</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="orderInfoListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>订单id</td><td>预订酒店</td><td>入住日期</td><td>入住天数</td><td>订单总价</td><td>订单状态</td><td>预订时间</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpOrderInfo" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("orderId")%></td>
 											<td><%#GetHotelhotelObj(Eval("hotelObj").ToString())%></td> 
 											<td><%#Eval("liveDate")%></td>
 											<td><%#Eval("orderDays")%></td>
 											<td><%#Eval("totalPrice")%></td>
 											<td><%#Eval("orderState")%></td>
 											<td><%#Eval("orderTime")%></td>
 											<td>
 												<a href="frontshow.aspx?orderId=<%#Eval("orderId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="orderInfoEdit('<%#Eval("orderId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="orderInfoDelete('<%#Eval("orderId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
 											</td> 
 										</tr>
 										</ItemTemplate>
 										</asp:Repeater>
				    				</table>
				    				</div>
				    			</div>
				    		</div>

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
			</div>
		</div>
	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>订单查询</h1>
		</div>
            <div class="form-group">
            	<label for="hotelObj_orderId">预订酒店：</label>
                <asp:DropDownList ID="hotelObj" runat="server"  CssClass="form-control" placeholder="请选择预订酒店"></asp:DropDownList>
            </div>
             
			<div class="form-group">
				<label for="liveDate">入住日期:</label>
				<asp:TextBox ID="liveDate"  runat="server" CssClass="form-control" placeholder="请选择入住日期" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="orderState">订单状态:</label>
				<asp:TextBox ID="orderState" runat="server"  CssClass="form-control" placeholder="请输入订单状态"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="orderTime">预订时间:</label>
				<asp:TextBox ID="orderTime"  runat="server" CssClass="form-control" placeholder="请选择预订时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="orderInfoEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;订单信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="orderInfoEditForm" id="orderInfoEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="orderInfo_orderId_edit" class="col-md-3 text-right">订单id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="orderInfo_orderId_edit" name="orderInfo.orderId" class="form-control" placeholder="请输入订单id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="orderInfo_hotelObj_hotelId_edit" class="col-md-3 text-right">预订酒店:</label>
		  	 <div class="col-md-9">
			    <select id="orderInfo_hotelObj_hotelId_edit" name="orderInfo.hotelObj.hotelId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="orderInfo_userObj_user_name_edit" class="col-md-3 text-right">预订用户:</label>
		  	 <div class="col-md-9">
			    <select id="orderInfo_userObj_user_name_edit" name="orderInfo.userObj.user_name" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="orderInfo_liveDate_edit" class="col-md-3 text-right">入住日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date orderInfo_liveDate_edit col-md-12" data-link-field="orderInfo_liveDate_edit"  data-link-format="yyyy-mm-dd">
                    <input class="form-control" id="orderInfo_liveDate_edit" name="orderInfo.liveDate" size="16" type="text" value="" placeholder="请选择入住日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="orderInfo_orderDays_edit" class="col-md-3 text-right">入住天数:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="orderInfo_orderDays_edit" name="orderInfo.orderDays" class="form-control" placeholder="请输入入住天数">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="orderInfo_totalPrice_edit" class="col-md-3 text-right">订单总价:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="orderInfo_totalPrice_edit" name="orderInfo.totalPrice" class="form-control" placeholder="请输入订单总价">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="orderInfo_orderMemo_edit" class="col-md-3 text-right">订单备注:</label>
		  	 <div class="col-md-9">
			    <textarea id="orderInfo_orderMemo_edit" name="orderInfo.orderMemo" rows="8" class="form-control" placeholder="请输入订单备注"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="orderInfo_orderState_edit" class="col-md-3 text-right">订单状态:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="orderInfo_orderState_edit" name="orderInfo.orderState" class="form-control" placeholder="请输入订单状态">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="orderInfo_orderTime_edit" class="col-md-3 text-right">预订时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date orderInfo_orderTime_edit col-md-12" data-link-field="orderInfo_orderTime_edit">
                    <input class="form-control" id="orderInfo_orderTime_edit" name="orderInfo.orderTime" size="16" type="text" value="" placeholder="请选择预订时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		</form> 
	    <style>#orderInfoEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxOrderInfoModify();">提交</button>
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
/*弹出修改订单界面并初始化数据*/
function orderInfoEdit(orderId) {
	$.ajax({
		url :  basePath + "OrderInfo/OrderInfoController.aspx?action=getOrderInfo&orderId=" + orderId,
		type : "get",
		dataType: "json",
		success : function (orderInfo, response, status) {
			if (orderInfo) {
				$("#orderInfo_orderId_edit").val(orderInfo.orderId);
				$.ajax({
					url: basePath + "Hotel/HotelController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(hotels,response,status) { 
						$("#orderInfo_hotelObj_hotelId_edit").empty();
						var html="";
		        		$(hotels).each(function(i,hotel){
		        			html += "<option value='" + hotel.hotelId + "'>" + hotel.hotelName + "</option>";
		        		});
		        		$("#orderInfo_hotelObj_hotelId_edit").html(html);
		        		$("#orderInfo_hotelObj_hotelId_edit").val(orderInfo.hotelObjPri);
					}
				});
				$.ajax({
					url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(userInfos,response,status) { 
						$("#orderInfo_userObj_user_name_edit").empty();
						var html="";
		        		$(userInfos).each(function(i,userInfo){
		        			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
		        		});
		        		$("#orderInfo_userObj_user_name_edit").html(html);
		        		$("#orderInfo_userObj_user_name_edit").val(orderInfo.userObjPri);
					}
				});
				$("#orderInfo_liveDate_edit").val(orderInfo.liveDate);
				$("#orderInfo_orderDays_edit").val(orderInfo.orderDays);
				$("#orderInfo_totalPrice_edit").val(orderInfo.totalPrice);
				$("#orderInfo_orderMemo_edit").val(orderInfo.orderMemo);
				$("#orderInfo_orderState_edit").val(orderInfo.orderState);
				$("#orderInfo_orderTime_edit").val(orderInfo.orderTime);
				$('#orderInfoEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除订单信息*/
function orderInfoDelete(orderId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "OrderInfo/OrderInfoController.aspx?action=delete",
			data : {
				orderId : orderId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "OrderInfo/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交订单信息表单给服务器端修改*/
function ajaxOrderInfoModify() {
	$.ajax({
		url :  basePath + "OrderInfo/OrderInfoController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#orderInfoEditForm")[0]),
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

    /*入住日期组件*/
    $('.orderInfo_liveDate_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd',
    	minView: 2,
    	weekStart: 1,
    	todayBtn:  1,
    	autoclose: 1,
    	minuteStep: 1,
    	todayHighlight: 1,
    	startView: 2,
    	forceParse: 0
    });
    /*预订时间组件*/
    $('.orderInfo_orderTime_edit').datetimepicker({
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

