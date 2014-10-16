<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Pasaje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Pasaje</legend>

    <table>
    <tr>
    <div class="display-label"><td><b>Número de boleto: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.numero_boleto) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Viaje</b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.Viaje.descripcion) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Tipo de pasaje: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.TipoPasaje.tipo_pasaje) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Pasajero: </b></td></div>
    <div class="display-field">
        <td>
        <%: Html.DisplayFor(model => model.Pasajero.nombres) %>
        <%: Html.DisplayFor(model => model.Pasajero.apellidos) %>
        </td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Pasaporte: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.Pasajero.pasaporte) %></td>
    </div>
    </tr>

    </table>
</fieldset>
<p>
    <a href="<%: Url.Action("Edit", "Pasaje", new { id=Model.id_pasaje }) %>">
        <button type="button" class="btn btn-default">Editar</button>
    </a>
    <a href="<%: Url.Action("Index", "Pasaje") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>

    <%--<%: Html.ActionLink("Editar", "Edit", new { id=Model.id_pasaje }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>--%>
</p>

</asp:Content>
