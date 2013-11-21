<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Tag>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Tag</legend>

    <table>
    <tr>
    <div class="display-label"><td><b>Identificador: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.identificador) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Pasajero: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.Pasajero.pasaporte) %></td>
    </div>
    </tr>
    </table>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_tag }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
