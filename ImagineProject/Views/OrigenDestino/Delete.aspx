<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.OrigenDestino>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Eliminar</h2>

<h3>¿Realmente desea eliminar esto?</h3>
<fieldset>
    <legend>Origen, destino y escalas</legend>

    <div class="display-label">Puerto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Puerto.nombre_puerto) %>
    </div>

    <div class="display-label">Viaje</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Viaje.descripcion) %>
    </div>

    <div class="display-label">Prioridad</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.prioridad) %>
    </div>

    <div class="display-label">Fecha de llegada</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.fecha_llegada) %>
    </div>

    <div class="display-label">Fecha de salida</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.fecha_salida) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Eliminar" /> |
        <%: Html.ActionLink("Regresar", "Index") %>
    </p>
<% } %>

</asp:Content>
