<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.RecintoPortico>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Eliminar</h2>

<h3>¿Realmente desea eliminar esto?</h3>
<fieldset>
    <legend>Porticos de recinto</legend>

    <div class="display-label">Portico</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Portico.descripcion_portico) %>
    </div>

    <div class="display-label">Recinto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Recinto.nombre_recinto) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Eliminar" /> |
        <%: Html.ActionLink("Regresar", "Index") %>
    </p>
<% } %>

</asp:Content>
