<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MembershipUserCollection>" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ListUsers
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Usuarios</h2>
<p>
    <%: Html.ActionLink("Agregar nuevo", "RegisterUser") %>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Rol
        </th>
        <th>
            Nombre de usuario
        </th>
        <th>
            Email
        </th>
        <th>
            Fecha de creación
        </th>
        <th>
            Fecha última actividad
        </th>
        <th></th>
    </tr>
    </thead>

    <tbody>
<% foreach (MembershipUser user in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => (Roles.GetRolesForUser(user.UserName).ToArray<String>())[0] ) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => user.UserName) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => user.Email) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => user.CreationDate ) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => user.LastActivityDate ) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "EditUser", new { userName = user.UserName })%> |
            <%: Html.ActionLink("Eliminar", "DeleteUser", new { userName = user.UserName })%>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
