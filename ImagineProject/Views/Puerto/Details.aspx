<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Puerto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Puerto</legend>

    <div class="display-label">Nombre del puerto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nombre_puerto) %>
    </div>

    <div class="display-label">Ciudad</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Ciudad.nombre) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_puerto }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
