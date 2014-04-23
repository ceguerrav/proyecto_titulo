<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Barco>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Barco</legend>

    <table>

    <tr>
    <div class="display-label"><td><b>Tipo de barco:</b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.TipoBarco.tipo_barco) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Linea naviera: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.LineaNaviera.linea_naviera) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Nombre del barco: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.nombre_barco) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Capacidad: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.capacidad) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Descripción: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.descripcion) %></td>
    </div>
    </tr>
    </table>

</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_barco }) %> |
    <%--<a href="<%: Url.Action("Index", "Barco") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>--%>
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
