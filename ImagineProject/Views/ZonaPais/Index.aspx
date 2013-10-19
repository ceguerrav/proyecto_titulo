<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.ZonaPais>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Paises de zona</h2>

<p>
    <%: Html.ActionLink("Agregar nuevo", "Create") %>
</p>
<table>
    <tr>
        <th>
            Zona
        </th>
        <th>
            Pais
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Zona.nombre_zona) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Pais.nombre_pais) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id_zona = item.id_zona, id_pais = item.id_pais })%> |
            <%: Html.ActionLink("Detalles", "Details", new { id_zona = item.id_zona, id_pais = item.id_pais })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id_zona = item.id_zona, id_pais = item.id_pais })%>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
