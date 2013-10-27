﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.Ciudad>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Ciudades</h2>

<p>
    <%: Html.ActionLink("Agregar nuevo", "Create") %>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Nombre ciudad
        </th>
        <th>
            División administrativa
        </th>
        <th></th>
    </tr>
    </thead>

    <tbody>
<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.nombre) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.DivisionAdministrativa.nombre) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id=item.id_ciudad }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_ciudad }) %> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.id_ciudad }) %>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
