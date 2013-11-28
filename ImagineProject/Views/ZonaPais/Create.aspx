<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.ZonaPais>" %>

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
        <legend>Paises de zona</legend>

        <p>Vincule un país a una zona</p>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_zona, "Zona") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_zona", ViewBag.id_zona as SelectList) %>
            <%: Html.ValidationMessageFor(model => model.id_zona) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_pais, "Pais") %>
        </div>
        <div class="editor-field">
            <%: Html.ListBox("id_pais", ViewBag.id_pais as MultiSelectList, new { Multiple = "multiple", id = "id_pais", @class="listbox" })%>
            <%: Html.ValidationMessageFor(model => model.id_pais) %>
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
