<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Tag>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Tag</legend>

    <div class="display-label">Identificador</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.identificador) %>
    </div>

    <div class="display-label">Pasajero</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Pasajero.pasaporte) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_tag }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
