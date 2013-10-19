<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.DivisionAdministrativa>" %>

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
        <legend>División Administrativa</legend>

            <%: Html.HiddenFor(model => model.id_division_administrativa) %>
       
        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_pais, "País") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_pais", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.id_pais) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nombre) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nombre) %>
            <%: Html.ValidationMessageFor(model => model.nombre) %>
        </div>

        <p>
            <input type="submit" value="Guardar" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Regresar", "Index") %>
</div>

</asp:Content>
