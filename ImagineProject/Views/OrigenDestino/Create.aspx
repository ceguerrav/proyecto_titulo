<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.OrigenDestino>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Agregar</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<!-- date_picker -->
<script src="<%: Url.Content("~/Script/jquery-1.6.4.min.js") %>" type="text/javascript"></script>	
<link href="/Scripts/date_picker/themes/ui-lightness/jquery-ui-1.8.10.custom.css" rel="stylesheet"  type="text/css" />
<!-- <link rel="stylesheet" href="/Scripts/date_picker/estilos-datepicker.css"> -->
<script src="<%: Url.Content("~/Scripts/date_picker/ui/jquery.ui.core.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/date_picker/ui/jquery.ui.datepicker.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/date_picker/ui/i18n/jquery.ui.datepicker-es.js") %>" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $("#fecha_salida").datepicker();
    });
</script>
<script type="text/javascript">
    $(function () {
        $("#fecha_llegada").datepicker();
    });
</script>
    <!-- date_picker -->

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Origen, destino y escalas</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_puerto, "Puerto") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_puerto", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.id_puerto) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_viaje, "Viaje") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_viaje", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.id_viaje) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.prioridad) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.prioridad) %>
            <%: Html.ValidationMessageFor(model => model.prioridad) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.fecha_llegada) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.fecha_llegada, new { id = "fecha_llegada" })%>
            <%: Html.ValidationMessageFor(model => model.fecha_llegada) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.fecha_salida) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.fecha_salida, new { id = "fecha_salida" })%>
            <%: Html.ValidationMessageFor(model => model.fecha_salida) %>
        </div>

        <p>
            <input type="submit" value="Agregar" class="btn btn-default" />
        </p>
    </fieldset>
<% } %>

<div>
    <a href="<%: Url.Action("Index", "OrigenDestino") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>
    <%--<%: Html.ActionLink("Regresar", "Index") %>--%>
</div>

</asp:Content>
