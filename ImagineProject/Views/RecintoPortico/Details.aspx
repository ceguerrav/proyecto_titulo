<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.RecintoPortico>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

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
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id_recinto=Model.id_recinto,id_portico=Model.id_portico}) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
