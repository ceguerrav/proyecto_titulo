﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.TipoAmbiente>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Tipos de ambiente</h2>

<p>
    <a href="<%: Url.Action("Create", "TipoAmbiente") %>">
        <button class="btn btn-primary">Agregar Nuevo</button>
    </a>
    <%--<%: Html.ActionLink("Agregar nuevo", "Create") %>--%>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Tipo de ambiente
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
            <%: Html.DisplayFor(modelItem => item.tipo_ambiente) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.descripcion) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id=item.id_tipo_ambiente }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_tipo_ambiente })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.id_tipo_ambiente })%>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
