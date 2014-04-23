<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Barco>" %>

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
        <legend>Barco</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_tipo_barco, "Tipo de barco") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_tipo_barco", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.id_tipo_barco) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_linea_naviera, "Linea naviera") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_linea_naviera", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.id_linea_naviera) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nombre_barco) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nombre_barco) %>
            <%: Html.ValidationMessageFor(model => model.nombre_barco) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.capacidad) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.capacidad) %>
            <%: Html.ValidationMessageFor(model => model.capacidad) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.descripcion) %>
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(model => model.descripcion) %>
            <%: Html.ValidationMessageFor(model => model.descripcion) %>
        </div>

        <p>
            <input type="submit" value="Agregar" class="btn btn-default" />
        </p>
    </fieldset>
<% } %>

<div>
    <a href="<%: Url.Action("Index", "Barco") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>
    <%--<%: Html.ActionLink("Regresar", "Index") %>--%>
</div>

</asp:Content>
