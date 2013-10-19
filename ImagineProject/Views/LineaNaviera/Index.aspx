<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.LineaNaviera>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Líneas navieras</h2>

<p>
    <%: Html.ActionLink("Agregar nuevo", "Create") %>
</p>
<table>
    <tr>
        <th>
            Linea naviera
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.linea_naviera) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id=item.id_linea_naviera }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_linea_naviera })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id=item.id_linea_naviera }) %>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
