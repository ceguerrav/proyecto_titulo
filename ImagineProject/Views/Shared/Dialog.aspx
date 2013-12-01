<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Operacion>" %>
<!doctype html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<title>Operación exitosa</title>
    	
    <link rel="stylesheet" href="../../Scripts/Dialog/themes/base/jquery.ui.all.css" />
	<script src="<%: Url.Content("~/Scripts/Dialog/jquery-1.9.1.js") %>" type="text/javascript"></script>
	<script src="<%: Url.Content("~/Scripts/Dialog/ui/jquery.ui.core.js") %>" type="text/javascript"></script>
	<script src="<%: Url.Content("~/Scripts/Dialog/ui/jquery.ui.widget.js") %>" type="text/javascript"></script>
	<script src="<%: Url.Content("~/Scripts/Dialog/ui/jquery.ui.mouse.js") %>" type="text/javascript"></script>
	<script src="<%: Url.Content("~/Scripts/Dialog/ui/jquery.ui.button.js") %>" type="text/javascript"></script>
	<script src="<%: Url.Content("~/Scripts/Dialog/ui/jquery.ui.draggable.js") %>" type="text/javascript"></script>
	<script src="<%: Url.Content("~/Scripts/Dialog/ui/jquery.ui.position.js") %>" type="text/javascript"></script>
	<script src="<%: Url.Content("~/Scripts/Dialog/ui/jquery.ui.resizable.js") %>" type="text/javascript"></script>
	<script src="<%: Url.Content("~/Scripts/Dialog/ui/jquery.ui.button.js") %>" type="text/javascript"></script>
	<script src="<%: Url.Content("~/Scripts/Dialog/ui/jquery.ui.dialog.js") %>" type="text/javascript"></script>
	<link rel="stylesheet" href="../../Scripts/Dialog/demos/demos.css">
	<script type="text/javascript">
        
	    $(function () {
	        $("#dialog-message").dialog({
	            modal: true,
	            buttons: {
	                Ok: function () {
	                    $(this).dialog("close");
	                    location.href = createURL();
	                }
	            }
	        });
	    });
	    function createURL() {
	        var port = document.location.port;
	        var controller = document.getElementById("controller").value;
	        var action = document.getElementById("action").value;
	        var url = "http://localhost:" + port + "/" + controller + "/" + action;
	        return url;
	    }
	</script>
</head>
<body>
    <%: Html.HiddenFor(model => model.Controller, new { id = "controller"} )%>
    <%: Html.HiddenFor(model => model.Action, new { id = "action"} )%>
    <div id="dialog-message" title="Operación exitosa">
	    <p>
		    <span class="ui-icon ui-icon-circle-check" style="float:left; margin:0 7px 50px 0;"></span>
		     <%: Html.DisplayFor(model => model.Message) %>
	    </p>
	    <p>
	    </p>
    </div>
</body>
</html>