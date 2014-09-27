<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Reporte10
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
            url: "/Reportes/Reporte10",
            data: {
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

<h2>Reporte10</h2>

<fieldset>
    <legend>Destinos más y menos visitados</legend>

        <div class="editor-label">
            <%: Html.Label("anio","Año Llegada Desde") %>
        </div>
        <div class="editor-field">
            <input type="text" id="txt_anio1" />
        </div>

        <div class="editor-label">
            <%: Html.Label("anio","Año Llegada Hasta") %>
        </div>
        <div class="editor-field">
            <input type="text" id="txt_anio2" />
        </div>
   

        <div class="editor-label">
            <%: Html.Label("anio","Año Salida Desde") %>
        </div>
        <div class="editor-field">
            <input type="text" id="txt_anio3" />
        </div>

        <div class="editor-label">
            <%: Html.Label("anio","Año Salida Hasta") %>
        </div>
        <div class="editor-field">
            <input type="text" id="txt_anio4" />
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
