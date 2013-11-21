<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Recinto>" %>

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
        <legend>Recinto</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nombre_recinto) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nombre_recinto) %>
            <%: Html.ValidationMessageFor(model => model.nombre_recinto) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.descripcion) %>
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(model => model.descripcion) %>
            <%: Html.ValidationMessageFor(model => model.descripcion) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_barco, "Barco") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_barco", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.id_barco) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_tipo_recinto, "Tipo de recinto") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_tipo_recinto", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.id_tipo_recinto) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_tipo_ambiente, "Tipo de ambiente") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_tipo_ambiente", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.id_tipo_ambiente) %>
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
