<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.OrigenDestino>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Origen, destino y escalas</legend>

    <table>
    <tr>
    <div class="display-label"><td><b>Puerto: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.Puerto.nombre_puerto) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Viaje: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.Viaje.descripcion) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Prioridad: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.prioridad) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Fecha de llegada: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.fecha_llegada) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Fecha de salida: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.fecha_salida) %></td>
    </div>
    </tr>
    </table>
</fieldset>
<p>
    <a href="<%: Url.Action("Edit", "OrigenDestino", new { id=Model.id_orgen_detino }) %>">
        <button type="button" class="btn btn-default">Editar</button>
    </a>
    <a href="<%: Url.Action("Index", "OrigenDestino") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>

    <%--<%: Html.ActionLink("Editar", "Edit", new { id=Model.id_orgen_detino }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>--%>
</p>

</asp:Content>
