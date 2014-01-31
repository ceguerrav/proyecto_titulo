﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

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
            url: "/Reportes/Reporte1",
            //'@Url.Action("Reporte", "Reportes")',
            data: {
                id_barco: $("#id_barco").val(),
                id_viaje: $("#id_viaje").val(),
                fecha: $("#txt_fecha").val() 
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
        <legend>Visitas por día</legend>

        <div class="editor-label">
            <%: Html.Label("id_barco","Barco") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_barco", ViewBag.id_barco as SelectList, "--- Seleccione barco ---", new { id = "id_barco" })%>
        </div>

         <div class="editor-label">
            <%: Html.Label("id_viaje","Viaje") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_barco", ViewBag.id_viaje as SelectList, "--- Seleccione Viaje ---", new { id = "id_viaje" })%>
        </div>

        <div class="editor-label">
            <%: Html.Label("fecha","Fecha") %>
        </div>
        <div class="editor-field">
            <input type="text" id="txt_fecha" />
        </div>

        <p>
            <input type="button" value="Buscar" id="btn_buscar" onclick="javascript:buscarAjax();"/>
        </p>

    </fieldset>

    <div id="contenido">
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
