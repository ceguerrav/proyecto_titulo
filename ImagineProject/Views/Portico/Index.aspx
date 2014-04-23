<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.Portico>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Porticos</h2>

<p>
    <a href="<%: Url.Action("Create", "Portico") %>">
        <button class="btn btn-primary">Agregar Nuevo</button>
    </a>
    <%--<%: Html.ActionLink("Agregar nuevo", "Create") %>--%>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Número de portico
        </th>
        <th>
            Dirección IP
        </th>
        <th></th>
    </tr>
    </thead>

    <tbody>
<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.numero_portico) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.descripcion_portico) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id=item.id_portico }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_portico })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.id_portico })%>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
