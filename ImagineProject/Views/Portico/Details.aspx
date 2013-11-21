<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Portico>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Portico</legend>

    <table>
    <tr>
    <div class="display-label"><td><b>Número de portico: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.numero_portico) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Descripción del portico: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.descripcion_portico) %></td>
    </div>
    </tr>
    </table>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_portico }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
