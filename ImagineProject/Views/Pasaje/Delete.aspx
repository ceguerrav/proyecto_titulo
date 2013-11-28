<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Pasaje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Eliminar</h2>

<h3>¿Realmente desea eliminar esto?</h3>
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
        <%: Html.DisplayFor(model => model.Pasajero.nombres) %>
        <%: Html.DisplayFor(model => model.Pasajero.apellidos) %>
    </div>

    <div class="display-label">Pasaporte</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Pasajero.pasaporte) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Eliminar" /> |
        <%: Html.ActionLink("Regresar", "Index") %>
    </p>
<% } %>

</asp:Content>
