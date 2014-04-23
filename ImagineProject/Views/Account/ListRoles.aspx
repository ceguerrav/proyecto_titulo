<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.RegisterRoleModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ListRoles
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Roles</h2>

<p>
    <a href="<%: Url.Action("RegisterRole", "Account") %>">
        <button class="btn btn-primary">Agregar Nuevo</button>
    </a>
    <%--<%: Html.ActionLink("Agregar nuevo", "RegisterRole") %>--%>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Rol
        </th>
        <th>
            Ususarios
        </th>
        <th></th>
    </tr>
    </thead>

    <tbody>
<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.RoleName) %>
        </td>
        <td>
            <%: Html.ActionLink("Ver", "DetailsRole", new { RoleName = item.RoleName })%> 
        </td>
        <td>
            <%: Html.ActionLink("Eliminar", "DeleteRole", new { RoleName = item.RoleName })%>
        </td>
    </tr>
<% } %>
</tbody>
</table>

</asp:Content>
