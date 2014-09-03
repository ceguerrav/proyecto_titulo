<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Reporte6
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<!-- date_picker -->
<script src="<%: Url.Content("~/Script/jquery-1.6.4.min.js") %>" type="text/javascript"></script>	
<link href="../../Content/themes/base/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
<script src="<%: Url.Content("~/Scripts/date_picker/ui/jquery.ui.core.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/date_picker/ui/jquery.ui.datepicker.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/date_picker/ui/i18n/jquery.ui.datepicker-es.js") %>" type="text/javascript"></script>

<script type="text/javascript">
    $(function () {
        $("#txt_fecha").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: '1940:' + new Date().getFullYear()
        });
    });
</script>
<!-- date_picker -->

<script type="text/javascript">
    function buscarAjax() {
        $.ajax({
            url: "/Reportes/Reporte6",
            type: "post",
            async: true,
            cache: false,
            success: function (retorno) {
                $("#contenido").html(retorno);
            }
        });
    }
</script> 

<h2>Reporte6</h2>

<fieldset>
    <legend>Barcos con Mayor Cantidad de Pasajeros por Viajes</legend>

    <p>
       <input type="button" value="Buscar" id="btn_buscar" class="btn btn-default" onclick="javascript:buscarAjax();"/>
    </p>
</fieldset>

<div id="contenido">
</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
