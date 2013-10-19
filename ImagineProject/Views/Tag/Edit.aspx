<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Tag>" %>

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
        <legend>Tag</legend>

            <%: Html.HiddenFor(model => model.id_tag) %>
            <%: Html.HiddenFor(model => model.fecha_registro) %>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_pasajero, "Pasajero") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_pasajero", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.id_pasajero) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.identificador) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.identificador) %>
            <%: Html.ValidationMessageFor(model => model.identificador) %>
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
