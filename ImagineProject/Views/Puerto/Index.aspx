<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.Puerto>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Puertos</h2>

<p>
    <%: Html.ActionLink("Agregar puerto", "Create") %>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Nombre del puerto
        </th>
        <th>
            Ciudad
        </th>
        <th></th>
    </tr>
    </thead>

    <tbody>
<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.nombre_puerto) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Ciudad.nombre) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id=item.id_puerto }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_puerto })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.id_puerto })%>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
