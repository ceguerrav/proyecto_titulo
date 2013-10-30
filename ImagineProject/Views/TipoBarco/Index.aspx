<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.TipoBarco>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Tipos de barco</h2>

<p>
    <a href="<%: Url.Action("Create", "TipoBarco") %>">
        <button class="linkAgregar">Agregar Nuevo</button>
    </a>
    <%--<%: Html.ActionLink("Agregar nuevo", "Create") %>--%>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Tipo de barco
        </th>
        <th></th>
    </tr>
    </thead>

    <tbody>
<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.tipo_barco) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id=item.id_tipo_barco }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_tipo_barco })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.id_tipo_barco })%>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
