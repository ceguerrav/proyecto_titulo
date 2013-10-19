<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Pasaje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Pasaje</legend>

    <div class="display-label">Número de boleto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.numero_boleto) %>
    </div>

    <div class="display-label">Viaje</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Viaje.descripcion) %>
    </div>

    <div class="display-label">Tipo de pasaje</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.TipoPasaje.tipo_pasaje) %>
    </div>

    <div class="display-label">Pasajero</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Pasajero.pasaporte) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_pasaje }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
