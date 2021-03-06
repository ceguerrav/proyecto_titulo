﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.OrigenDestino>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Origen, destino y escalas</h2>

<p>(El primer número de escala debe ser el origen y el último destino)</p>

<p>
    <a href="<%: Url.Action("Create", "OrigenDestino") %>">
        <button class="btn btn-primary">Agregar Nuevo</button>
    </a>
   <%-- <%: Html.ActionLink("Agregar", "Create") %>--%>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Viaje
        </th>
        <th>
            Puerto
        </th>
        <th>
            Número escala
        </th>
        <th>
            Fecha de llegada
        </th>
        <th>
            Fecha de salida
        </th>
        <th></th>
    </tr>
    </thead>

    <tbody>
<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Viaje.descripcion) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Puerto.nombre_puerto) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.prioridad) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.fecha_llegada) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.fecha_salida) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id=item.id_orgen_detino }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_orgen_detino })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.id_orgen_detino })%>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
