<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.TipoDivision>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Tipos de división</h2>

<p>
    <%: Html.ActionLink("Agregar nuevo", "Create") %>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Tipo de división
        </th>
        <th></th>
    </tr>
    </thead>

    <tbody>
<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.tipo_division) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id=item.id_tipo_division }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_tipo_division })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.id_tipo_division })%>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
