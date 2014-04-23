<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Pais>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Editar</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>País</legend>

            <%: Html.HiddenFor(model => model.id_pais) %>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_tipo_division, "Tipo de división") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_tipo_division", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.id_tipo_division) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nombre_oficial) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nombre_oficial) %>
            <%: Html.ValidationMessageFor(model => model.nombre_oficial) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nombre_pais) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nombre_pais) %>
            <%: Html.ValidationMessageFor(model => model.nombre_pais) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.cod_iso) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.cod_iso) %>
            <%: Html.ValidationMessageFor(model => model.cod_iso) %>
        </div>

        <p>
            <input type="submit" value="Guardar" class="btn btn-default" />
        </p>
    </fieldset>
<% } %>

<div>
    <a href="<%: Url.Action("Index", "Pais") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>
    <%--<%: Html.ActionLink("Regresar", "Index") %>--%>
</div>

</asp:Content>
