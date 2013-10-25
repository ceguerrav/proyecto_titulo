<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.RegisterUserModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    DeleteUser
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Eliminar usuario</h2>

<h3>¿Realmente desea eliminar esto?</h3>
<fieldset>
    <legend>Eliminar usuario</legend>

    <div class="display-label">Rol</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.RoleName) %>
    </div>

    <div class="display-label">Nombre de usuario</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.UserName) %>
    </div>

    <div class="display-label">E-mail</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Email) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Eliminar" /> |
        <%: Html.ActionLink("Regresar", "ListUsers") %>
    </p>
<% } %>

</asp:Content>
