<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.RegisterRoleModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    RegisterRole
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Registrar rol</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true,"El rol no puede ser creado. Verifique la información requerida.") %>
    <fieldset>
        <legend>Nuevo Rol</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.RoleName)%>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.RoleName) %>
            <%: Html.ValidationMessageFor(model => model.RoleName) %>
        </div>

        <p>
            <input type="submit" value="Agragar" class="btn btn-primary" />
        </p>
    </fieldset>
<% } %>

<div>
    <a href="<%: Url.Action("ListRoles", "Account") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>
    <%--<%: Html.ActionLink("Regresar", "ListRoles") %>--%>
</div>

</asp:Content>
