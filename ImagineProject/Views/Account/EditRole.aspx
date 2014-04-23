<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.RegisterRoleModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    EditRole
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Editar rol</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Rol</legend>
            
            <%: Html.HiddenFor(model => model.RoleName) %>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.RoleName) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.RoleName, new { @readonly = "readonly" })%>
            <%: Html.ValidationMessageFor(model => model.RoleName) %>
        </div>

        <table>
            <tr>
                <th>
                    Usuario
                </th>
                <th>
                    Agregar
                </th>
            </tr>

            <% foreach (string item in ViewBag.usuarios) { %>
            <tr>
                <td>
                    <%: Html.DisplayFor(modelItem => item)  %>
                </td>
                <td>
                    <%: Html.CheckBox(item)  %>
                </td>
            </tr>
            <% } %>
        </table>
        <p>
            <input type="submit" value="Guardar" class="btn btn-primary" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Regresar", "ListRoles") %>
</div>

</asp:Content>
