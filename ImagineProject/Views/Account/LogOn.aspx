<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Inicio.Master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<h2>Iniciar sesión</h2>
    <p>
        Introduzca su nombre de usuario y contraseña. <%: Html.ActionLink("Registrar", "RegisterUser") %> si no tiene una cuenta.
    </p>--%>

    <link href="../../Content/style_login.css" rel="stylesheet" type="text/css" />
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

    <section class="container">
    <div class="login">
    <h1>Ingresar a CruiseCheck</h1>
    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "¿No puedes inciar sesión?")%>
        <div>
            <fieldset>
                            
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.UserName) %>
                </div>
                <div class="editor-field">
                    <p><%: Html.TextBoxFor(m => m.UserName) %></p>
                    <%: Html.ValidationMessageFor(m => m.UserName) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Password) %>
                </div>
                <div class="editor-field">
                    <p><%: Html.PasswordFor(m => m.Password) %></p>
                    <%: Html.ValidationMessageFor(m => m.Password) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.CheckBoxFor(m => m.RememberMe) %>
                    <%: Html.LabelFor(m => m.RememberMe) %>
                </div>
                
                <p class="submit">
                    <input type="submit" value="Iniciar sesión" />
                </p>
            </fieldset>
        </div>
    <% } %>
    </div>
    </section>
</asp:Content>
