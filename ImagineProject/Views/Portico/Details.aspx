<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Portico>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Portico</legend>

    <div class="display-label">Número de portico</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.numero_portico) %>
    </div>

    <div class="display-label">Descripción del portico</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcion_portico) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_portico }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
