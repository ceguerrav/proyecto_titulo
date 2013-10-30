<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.Pais>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Países</h2>

<p>
    <a href="<%: Url.Action("Create", "Pais") %>">
        <button class="linkAgregar">Agregar Nuevo</button>
    </a>
    <%--<%: Html.ActionLink("Agregar nuevo", "Create") %>--%>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Nombre oficial
        </th>
        <th>
            Nombre país
        </th>
        <th>
            Codigo ISO
        </th>
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
            <%: Html.DisplayFor(modelItem => item.nombre_oficial) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.nombre_pais) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.cod_iso) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.TipoDivision.tipo_division) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id = item.id_pais })%> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_pais })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id=item.id_pais }) %>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
