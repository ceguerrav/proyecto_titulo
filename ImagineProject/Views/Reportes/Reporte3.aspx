<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Reporte8
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">
    function buscarAjax() {
        $.ajax({
            url: "/Reportes/Reporte3",
            data: {
                linea_naviera: $("#linea_naviera").val()
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
    <legend>Evolución de pasajes por año</legend>

        <div class="editor-label">
            <%: Html.Label("linea_naviera","Linea Naviera") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("linea_naviera", ViewBag.linea_naviera as SelectList, "--- Seleccione Linea Naviera ---", new { id = "linea_naviera" })%>
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
