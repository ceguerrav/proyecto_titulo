<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Barco>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Eliminar</h2>

<h3>¿Realmente desea eliminar esto?</h3>
<fieldset>
    <legend>Barco</legend>
        
    <div class="display-label">Tipo de barco</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.TipoBarco.tipo_barco) %>
    </div>

    <div class="display-label">Línea naviera</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.LineaNaviera.linea_naviera) %>

    <div class="display-label">Nombre del barco</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nombre_barco) %>
    </div>

    <div class="display-label">Capacidad</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.capacidad) %>
    </div>

    <div class="display-label">Descripción</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcion) %>
    </div>

    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Eliminar" class="btn btn-default" /> 
        <a href="<%: Url.Action("Index", "Barco") %>">
            <button type="button" class="btn btn-info">Regresar</button>
        </a>
        <%--<%: Html.ActionLink("Regresar", "Index") %>--%>
    </p>
<% } %>

</asp:Content>
