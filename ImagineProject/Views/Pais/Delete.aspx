<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Pais>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Eliminar</h2>

<h3>¿Realmente desea eliminar esto?</h3>
<fieldset>
    <legend>País</legend>

    <div class="display-label">Nombre oficial</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nombre_oficial) %>
    </div>

    <div class="display-label">Nombre país</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nombre_pais) %>
    </div>

    <div class="display-label">Codigo ISO</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.cod_iso) %>
    </div>

    <div class="display-label">Tipo de división</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.TipoDivision.tipo_division) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Eliminar" /> |
        <%: Html.ActionLink("Regresar", "Index") %>
    </p>
<% } %>

</asp:Content>
