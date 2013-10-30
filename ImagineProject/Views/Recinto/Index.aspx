<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.Recinto>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Recintos</h2>

<p>
    <a href="<%: Url.Action("Create", "Recinto") %>">
        <button class="linkAgregar">Agregar Nuevo</button>
    </a>
    <%--<%: Html.ActionLink("Agregar nuevo", "Create") %>--%>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Nombre del recinto
        </th>
        <th>
            Descripción
        </th>
        <th>
            Barco
        </th>
        <th>
            Tipo de recinto
        </th>
        <th>
            Tipo de ambiente
        </th>
        <th></th>
    </tr>
    </thead>

    <tbody>
<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.nombre_recinto) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.descripcion) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Barco.nombre_barco) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.TipoRecinto.tipo_recinto) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.TipoAmbiente.tipo_ambiente) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id=item.id_recinto }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_recinto })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.id_recinto })%>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
