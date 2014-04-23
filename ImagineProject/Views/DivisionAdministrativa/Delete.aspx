<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.DivisionAdministrativa>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Eliminar</h2>

<h3>¿Realmente desea eliminar esto?</h3>
<fieldset>
    <legend><%: Html.DisplayFor(model => model.Pais.TipoDivision.tipo_division) %></legend>

    <div class="display-label">Nombre</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nombre) %>
    </div>

    <div class="display-label">País</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Pais.nombre_pais) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Eliminar" class="btn btn-default" /> 
        <a href="<%: Url.Action("Index", "DivisionAdministrativa") %>">
            <button type="button" class="btn btn-info">Regresar</button>
        </a>
        <%--<%: Html.ActionLink("Regresar", "Index") %>--%>
    </p>
<% } %>

</asp:Content>
