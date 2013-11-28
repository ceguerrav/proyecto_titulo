<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.ZonaPais>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Paises de zona</legend>

    <table>
    <tr>
    <div class="display-label"><td><b>Zona: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.Zona.nombre_zona) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Pais: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.Pais.nombre_pais) %></td>
    </div>
    </tr>
    </table>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new {  id_zona=Model.id_zona, id_pais=Model.id_pais }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
