<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Viaje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Viaje</legend>

    <div class="display-label">Fecha de salida</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.fecha_salida) %>
    </div>

    <div class="display-label">Fecha de llegada</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.fecha_llegada) %>
    </div>

    <div class="display-label">Descripción</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcion) %>
    </div>

    <div class="display-label">Barco</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Barco.nombre_barco) %>
    </div>

    <div class="display-label">Tipo de viaje</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.TipoViaje.tipo_viaje) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_viaje }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
