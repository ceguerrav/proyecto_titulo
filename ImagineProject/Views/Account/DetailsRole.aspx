<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.RegisterRoleModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    DetailsRole
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles rol</h2>

<fieldset>
    <legend>Rol</legend>

    <div class="display-label">Nombre del Rol</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.RoleName) %>
    </div>
</fieldset>
<fieldset>
    <legend>Usuarios del rol "<%: Html.DisplayFor(model => model.RoleName) %>"</legend>
    <table>
    <% foreach (string item in ViewBag.usuarios) { %>
    <tr>
        <th>
            Nombre de usuario:
        </th>
        <td>
            <%: Html.DisplayFor(modelItem => item)  %>
        </td>
    </tr>
    <% } %>
</table>
</fieldset>
<p>
    <%: Html.ActionLink("Regresar", "ListRoles") %>
</p>

</asp:Content>
