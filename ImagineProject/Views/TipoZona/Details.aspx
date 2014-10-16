<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.TipoZona>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Tipo de Zona</legend>

    <table>
    <tr>
    <div class="display-label"><td><b>Tipo de zona: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.tipo_zona) %></td>
    </div>
    </tr>
    </table>
</fieldset>
<p>
    <a href="<%: Url.Action("Edit", "TipoZona", new { id=Model.id_tipo_zona }) %>">
        <button type="button" class="btn btn-default">Editar</button>
    </a>
    <a href="<%: Url.Action("Index", "TipoZona") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>
     
    <%--<%: Html.ActionLink("Editar", "Edit", new { id=Model.id_tipo_zona }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>--%>
</p>

</asp:Content>
