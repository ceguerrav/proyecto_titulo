<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.Tag>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Etiquetas (Tag's)</h2>

<p>
    <%: Html.ActionLink("Agregar nuevo", "Create") %>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Identificador
        </th>
        <th>
            Pasajero
        </th>
        <th></th>
    </tr>
    </thead>

    <tbody>
<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.identificador) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Pasajero.pasaporte) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id=item.id_tag }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_tag })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.id_tag })%>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
