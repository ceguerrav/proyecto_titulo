<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.TipoRecinto>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Tipos de recintos</h2>

<p>
    <%: Html.ActionLink("Agregar nuevo", "Create") %>
</p>
<table>
    <tr>
        <th>
            Tipo de recinto
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.tipo_recinto) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id=item.id_tipo_recinto }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_tipo_recinto })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.id_tipo_recinto })%>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
