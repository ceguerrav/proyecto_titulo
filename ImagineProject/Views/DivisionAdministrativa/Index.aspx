﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.DivisionAdministrativa>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Divisiones administrativas</h2>

<p>
    <%: Html.ActionLink("Agregar Nueva", "Create") %>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Nombre
        </th>
        <th>
            Pais
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
            <%: Html.DisplayFor(modelItem => item.Pais.nombre_pais) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id=item.id_division_administrativa }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_division_administrativa })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.id_division_administrativa })%>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
