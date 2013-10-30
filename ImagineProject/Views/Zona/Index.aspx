<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.Zona>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Zonas</h2>

<p>
    <a href="<%: Url.Action("Create", "Zona") %>">
        <button class="linkAgregar">Agregar Nuevo</button>
    </a>
   <%-- <%: Html.ActionLink("Agregar nuevo", "Create") %>--%>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Nombre de zona
        </th>
        <th>
            Tipo de zona
        </th>
        <th></th>
    </tr>
    </thead>

    <tbody>
<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.nombre_zona) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.TipoZona.tipo_zona) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id=item.id_zona }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_zona })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.id_zona })%>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
