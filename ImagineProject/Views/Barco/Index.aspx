<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.Barco>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Barcos</h2>

<p>
    <%: Html.ActionLink("Agregar nuevo", "Create") %>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Nombre del barco
        </th>
        <th>
            Capacidad
        </th>
        <th>
            Descripcion
        </th>
        <th>
            Tipo de barco
        </th>
        <th>
            Linea naviera
        </th>
        <th></th>
    </tr>
    </thead>

    <tbody>
<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.nombre_barco) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.capacidad) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.descripcion) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.TipoBarco.tipo_barco) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.LineaNaviera.linea_naviera) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id=item.id_barco }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_barco })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.id_barco })%>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
