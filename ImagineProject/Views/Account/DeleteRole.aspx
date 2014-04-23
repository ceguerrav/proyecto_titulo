<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.RegisterRoleModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    DeleteRole
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Eliminar Rol</h2>

<h3>¿Realmente desea eliminar esto?</h3>
<fieldset>
    <legend>Rol</legend>

    <div class="display-label">Nombre del rol</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.RoleName) %>
    </div>
</fieldset>
<fieldset>
    <legend>Usuarios del rol <%: Html.DisplayFor(model => model.RoleName) %></legend>
    <table>
    <tr>
        <th>
            Usuario
        </th>
    </tr>

    <% foreach (string item in ViewBag.usuarios) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item)  %>
        </td>
    </tr>
    <% } %>
</table>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Eliminar" class="btn btn-default" /> 
        <a href="<%: Url.Action("ListRoles", "Account") %>">
            <button type="button" class="btn btn-info">Regresar</button>
        </a>
        <%--<%: Html.ActionLink("Regresar", "ListRoles") %>--%>
    </p>
<% } %>

</asp:Content>
