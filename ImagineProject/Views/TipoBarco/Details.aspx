<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.TipoBarco>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Tipo de barco</legend>

    <div class="display-label">Tipo de barco</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.tipo_barco) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_tipo_barco }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
