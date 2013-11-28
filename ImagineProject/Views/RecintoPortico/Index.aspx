<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.RecintoPortico>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Porticos de recinto</h2>

<p>
    <a href="<%: Url.Action("Create", "RecintoPortico") %>">
        <button class="linkAgregar">Agregar Nuevo</button>
    </a>
    <%--<%: Html.ActionLink("Agregar nuevo", "Create") %>--%>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Barco
        </th>
        <th>
            Recinto
        </th>
        <th>
            Numero de Portico
        </th>
        <th>
            Portico
        </th>
        <th>
            Desvincular
        </th>
    </tr>
    </thead>

    <tbody>
<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Recinto.Barco.nombre_barco) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Recinto.nombre_recinto) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Portico.numero_portico) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Portico.descripcion_portico) %>
        </td>
        <td>
        <!--
            <%: Html.ActionLink("Editar", "Edit", new { id_recinto=item.id_recinto,id_portico = item.id_portico }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id_recinto = item.id_recinto, id_portico = item.id_portico })%> |
        -->
            <%: Html.ActionLink("Eliminar", "Delete", new { id_recinto = item.id_recinto, id_portico = item.id_portico })%>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
