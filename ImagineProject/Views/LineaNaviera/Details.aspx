<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.LineaNaviera>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Linea naviera</legend>

    <table>
    <tr>
    <div class="display-label"><td><b>Linea naviera: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.linea_naviera) %></td>
    </div>
    </tr>
    </table>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_linea_naviera }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
