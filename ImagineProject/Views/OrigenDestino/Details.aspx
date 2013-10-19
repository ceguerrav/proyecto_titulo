<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.OrigenDestino>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Origen, destino y escalas</legend>

    <div class="display-label">Puerto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Puerto.nombre_puerto) %>
    </div>

    <div class="display-label">Viaje</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Viaje.descripcion) %>
    </div>

    <div class="display-label">Prioridad</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.prioridad) %>
    </div>

    <div class="display-label">Fecha de llegada</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.fecha_llegada) %>
    </div>

    <div class="display-label">Fecha de salida</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.fecha_salida) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_orgen_detino }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
