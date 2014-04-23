<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.ZonaPais>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Eliminar</h2>

<h3>¿Realmente desea desvincular este país de su zona?</h3>
<fieldset>
    <legend>Paises de zona</legend>

    <div class="display-label">Zona</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Zona.nombre_zona) %>
    </div>

    <div class="display-label">Pais</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Pais.nombre_pais) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Eliminar" class="btn btn-default" /> 
        <a href="<%: Url.Action("Index", "ZonaPais") %>">
            <button type="button" class="btn btn-info">Regresar</button>
        </a>
        <%--<%: Html.ActionLink("Regresar", "Index") %>--%>
    </p>
<% } %>

</asp:Content>
