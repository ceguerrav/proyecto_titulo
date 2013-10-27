<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.TipoPasaje>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Tipos de pasaje</h2>

<p>
    <%: Html.ActionLink("Agregar nuevo", "Create") %>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Tipo de pasaje
        </th>
        <th>
            Descripción
        </th>
        <th></th>
    </tr>
    </thead>

    <tbody>
<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.tipo_pasaje) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.descripcion) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id=item.id_tipo_pasaje }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_tipo_pasaje })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.id_tipo_pasaje })%>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
