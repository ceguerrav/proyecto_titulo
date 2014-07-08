<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Reporte7
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
            url: "/Reportes/Reporte7",
            //'@Url.Action("Reporte", "Reportes")',
            data: {
                linea_naviera: $("#linea_naviera").val(),
                anio1: $("#txt_anio1").val(),
                anio2: $("#txt_anio2").val()
            },
            type: "post",
            async: true,
            cache: false,
            success: function (retorno) {
                $("#contenido").html(retorno);
            }
        });
    }
</script> 

<h2>Reporte7</h2>

<fieldset>
    <legend>Barcos con más Viajes</legend>

        <div class="editor-label">
            <%: Html.Label("linea_naviera","Linea Naviera") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("linea_naviera", ViewBag.linea_naviera as SelectList, "--- Seleccione Linea Naviera ---", new { id = "linea_naviera" })%>
        </div>

        <div class="editor-label">
            <%: Html.Label("anio","Año Desde") %>
        </div>
        <div class="editor-field">
            <input type="text" id="txt_anio1" />
        </div>

        <div class="editor-label">
            <%: Html.Label("anio","Año Hasta") %>
        </div>
        <div class="editor-field">
            <input type="text" id="txt_anio2" />
        </div>

        <p>
            <input type="button" value="Buscar" id="btn_buscar" class="btn btn-default" onclick="javascript:buscarAjax();"/>
        </p>

</fieldset>

    <div id="contenido">
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
