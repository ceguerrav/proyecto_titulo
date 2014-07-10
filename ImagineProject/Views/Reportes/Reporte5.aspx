<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Reporte
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
        $("#txt_fecha_desde").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: '1940:' + new Date().getFullYear()
        });
    });
</script>

<script type="text/javascript">
    $(function () {
        $("#txt_fecha_hasta").datepicker({
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
            url: "/Reportes/Reporte5",
            data: {
                desde: $("#txt_fecha_desde").val(),
                hasta: $("#txt_fecha_hasta").val()
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

<h2>Reporte</h2>

    <fieldset>
        <legend>Visitas a recintos por horario</legend>

        <div class="editor-label">
            <%: Html.Label("fecha","Fecha desde") %>
        </div>
        <div class="editor-field">
            <input type="text" id="txt_fecha_desde" />
        </div>

        <div class="editor-label">
            <%: Html.Label("fecha","Fecha hasta") %>
        </div>
        <div class="editor-field">
            <input type="text" id="txt_fecha_hasta" />
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
