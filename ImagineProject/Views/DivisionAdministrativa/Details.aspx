<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.DivisionAdministrativa>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>División Administrativa</legend>

    <table>
    <tr>
    <div class="display-label"><td><b>Nombre: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.nombre) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>País: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.Pais.nombre_pais) %></td>
    </div>
    </tr>
    </table>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_division_administrativa }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
