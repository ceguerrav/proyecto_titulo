<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Puerto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Eliminar</h2>

<h3>¿Realmente desea eliminar esto?</h3>
<fieldset>
    <legend>Puerto</legend>

    <div class="display-label">Nombre del puerto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nombre_puerto) %>
    </div>

    <div class="display-label">Ciudad</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Ciudad.nombre) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Eliminar" class="btn btn-default" /> 
        <a href="<%: Url.Action("Index", "Puerto") %>">
            <button type="button" class="btn btn-info">Regresar</button>
        </a>
        <%--<%: Html.ActionLink("Regresar", "Index") %>--%>
    </p>
<% } %>

</asp:Content>
