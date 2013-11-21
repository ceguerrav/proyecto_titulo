<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.Pasajero>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Pasajeros</h2>

<p>
    <a href="<%: Url.Action("Create", "Pasajero") %>">
        <button class="linkAgregar">Agregar Nuevo</button>
    </a>
    <%--<%: Html.ActionLink("Agregar", "Create") %>--%>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Pasaporte
        </th>
        <th>
            Nombres
        </th>
        <th>
            Apellidos
        </th>
        <th>
            Direccion
        </th>
        <th>
            Numero_contacto
        </th>
        <th>
            E-mail
        </th>
        <th>
            Sexo
        </th>
        <th>
            Fecha de nacimiento
        </th>
        <th>
            País
        </th>
        <th></th>
    </tr>
    </thead>

    <tbody>
<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.pasaporte) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.nombres) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.apellidos) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.direccion) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.numero_contacto) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.e_mail) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.sexo) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.fecha_nac) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Ciudad.DivisionAdministrativa.Pais.nombre_pais) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id=item.id_pasajero }) %> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_pasajero })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.id_pasajero })%>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
