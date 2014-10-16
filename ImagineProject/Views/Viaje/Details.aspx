<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Viaje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Viaje</legend>

    <table>
    <tr>
    <div class="display-label"><td><b>Fecha de salida: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.fecha_salida) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Fecha de llegada: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.fecha_llegada) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Descripción: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.descripcion) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Barco: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.Barco.nombre_barco) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Tipo de viaje</b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.TipoViaje.tipo_viaje) %></td>
    </div>
    </tr>
    </table>
</fieldset>
<p>
    <a href="<%: Url.Action("Edit", "Viaje", new { id=Model.id_viaje }) %>">
        <button type="button" class="btn btn-default">Editar</button>
    </a>
    <a href="<%: Url.Action("Index", "Viaje") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>

    <%--<%: Html.ActionLink("Editar", "Edit", new { id=Model.id_viaje }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>--%>
</p>

</asp:Content>
