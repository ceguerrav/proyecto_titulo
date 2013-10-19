<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.TipoViaje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Agregar</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Tipo de viaje</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.tipo_viaje) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.tipo_viaje) %>
            <%: Html.ValidationMessageFor(model => model.tipo_viaje) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.descripcion) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.descripcion) %>
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
