<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.Pasaje>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Pasajes</h2>

<p>
    <a href="<%: Url.Action("Create", "Pasaje") %>">
        <button class="btn btn-primary">Agregar Nuevo</button>
    </a>
    <%--<%: Html.ActionLink("Agregar nuevo", "Create") %>--%>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Viaje
        </th>
        <th>
            Número de boleto
        </th>
        <th>
            Tipo de pasaje
        </th>
        <th>
            Pasaporte
        </th>
        <th>
            Pasajero
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
            <%: Html.DisplayFor(modelItem => item.numero_boleto) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.TipoPasaje.tipo_pasaje) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Pasajero.pasaporte) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Pasajero.nombres)%>
            <%: Html.DisplayFor(modelItem => item.Pasajero.apellidos)%>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id=item.id_pasaje }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_pasaje })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.id_pasaje })%>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
