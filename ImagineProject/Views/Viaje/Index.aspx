<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.Viaje>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Viajes</h2>

<p>
    <%: Html.ActionLink("Agregar nuevo", "Create") %>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            fecha de salida
        </th>
        <th>
            fecha de llegada
        </th>
        <th>
            Descripción
        </th>
        <th>
            Barco
        </th>
        <th>
            Tipo de viaje
        </th>
        <th></th>
    </tr>
    </thead>

    <tbody>
<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.fecha_salida) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.fecha_llegada) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.descripcion) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Barco.nombre_barco) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.TipoViaje.tipo_viaje) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id=item.id_viaje }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_viaje })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.id_viaje })%>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
