<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Barco>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Barco</legend>

    <div class="display-label">Tipo de barco</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.TipoBarco.tipo_barco) %>
    </div>

    <div class="display-label">Linea naviera</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.LineaNaviera.linea_naviera) %>
    </div>

    <div class="display-label">Nombre del barco</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nombre_barco) %>
    </div>

    <div class="display-label">Capacidad</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.capacidad) %>
    </div>

    <div class="display-label">Descripción</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcion) %>
    </div>

</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_barco }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
