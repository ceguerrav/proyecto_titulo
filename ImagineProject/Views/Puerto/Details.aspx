<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Puerto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Puerto</legend>

    <table>
    <tr>
    <div class="display-label"><td><b>Nombre del puerto: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.nombre_puerto) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>País: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.Ciudad.DivisionAdministrativa.Pais.nombre_pais) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>
    <%: Html.DisplayFor(model => model.Ciudad.DivisionAdministrativa.Pais.TipoDivision.tipo_division) %>: 
    </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.Ciudad.DivisionAdministrativa.nombre) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Ciudad: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.Ciudad.nombre) %></td>
    </div>
    </tr>
    </table>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_puerto }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
