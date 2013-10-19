<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Ciudad>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Ciudad</legend>

    <div class="display-label">Nombre ciudad</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nombre) %>
    </div>

    <div class="display-label">División administrativa</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.DivisionAdministrativa.nombre) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_ciudad }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
