<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Viaje>" %>

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
        <legend>Viaje</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_tipo_viaje, "Tipo de viaje") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_tipo_viaje", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.id_tipo_viaje) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_barco, "Barco") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_barco", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.id_barco) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.fecha_salida) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.fecha_salida, new { id = "fecha_salida" })%>
            <%: Html.ValidationMessageFor(model => model.fecha_salida) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.fecha_llegada) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.fecha_llegada, new { id = "fecha_llegada" })%>
            <%: Html.ValidationMessageFor(model => model.fecha_llegada) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.descripcion) %>
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(model => model.descripcion) %>
            <%: Html.ValidationMessageFor(model => model.descripcion) %>
        </div>

        <p>
            <input type="submit" value="Agregar" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Regresar", "Index") %>
</div>

</asp:Content>
