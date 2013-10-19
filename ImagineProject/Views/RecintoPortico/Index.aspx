﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.RecintoPortico>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Porticos de recinto</h2>

<p>
    <%: Html.ActionLink("Agregar nuevo", "Create") %>
</p>
<table>
    <tr>
        <th>
            Portico
        </th>
        <th>
            Recinto
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Portico.descripcion_portico) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Recinto.nombre_recinto) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id_recinto=item.id_recinto,id_portico = item.id_portico }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id_recinto = item.id_recinto, id_portico = item.id_portico })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id_recinto = item.id_recinto, id_portico = item.id_portico })%>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
