<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Recinto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Recinto</legend>

    <table>
    <tr>
    <div class="display-label"><td><b>Nombre del recinto: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.nombre_recinto) %></td>
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
    <div class="display-label"><td><b>Tipo de recinto: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.TipoRecinto.tipo_recinto) %></td>
    </div>
    </tr>
    
    <tr>
    <div class="display-label"><td><b>Tipo de ambiente: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.TipoAmbiente.tipo_ambiente) %></td>
    </div>
    </tr>
    </table>
</fieldset>
<p>
    <a href="<%: Url.Action("Edit", "Recinto", new { id=Model.id_recinto }) %>">
        <button type="button" class="btn btn-default">Editar</button>
    </a>
    <a href="<%: Url.Action("Index", "Recinto") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>

    <%--<%: Html.ActionLink("Editar", "Edit", new { id=Model.id_recinto }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>--%>
</p>

</asp:Content>
