<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.TipoPasaje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Tipo de pasaje</legend>

    <table>
    <tr>
    <div class="display-label"><td><b>Tipo de pasaje: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.tipo_pasaje) %></td>
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
    <a href="<%: Url.Action("Edit", "TipoPasaje", new { id=Model.id_tipo_pasaje }) %>">
        <button type="button" class="btn btn-default">Editar</button>
    </a>
    <a href="<%: Url.Action("Index", "TipoPasaje") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>

    <%--<%: Html.ActionLink("Editar", "Edit", new { id=Model.id_tipo_pasaje }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>--%>
</p>

</asp:Content>
