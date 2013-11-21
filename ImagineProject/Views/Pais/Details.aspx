<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Pais>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>País</legend>

    <table>
    <tr>
    <div class="display-label"><td><b>Nombre oficial: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.nombre_oficial) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Nombre país: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.nombre_pais) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Codigo ISO: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.cod_iso) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Tipo de division: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.TipoDivision.tipo_division) %></td>
    </div>
    </tr>
    </table>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_pais }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
