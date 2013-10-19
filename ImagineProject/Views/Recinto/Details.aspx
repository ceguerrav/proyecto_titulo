<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Recinto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Recinto</legend>

    <div class="display-label">Nombre del recinto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nombre_recinto) %>
    </div>

    <div class="display-label">Descripción</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcion) %>
    </div>

    <div class="display-label">Barco</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Barco.nombre_barco) %>
    </div>

    <div class="display-label">Tipo de recinto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.TipoRecinto.tipo_recinto) %>
    </div>

    <div class="display-label">Tipo de ambiente</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.TipoAmbiente.tipo_ambiente) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_recinto }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
