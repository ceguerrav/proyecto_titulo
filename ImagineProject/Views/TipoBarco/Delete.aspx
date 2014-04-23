<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.TipoBarco>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Eliminar</h2>

<h3>¿Realmente desea eliminar esto?</h3>
<fieldset>
    <legend>Tipo de barco</legend>

    <div class="display-label">Tipo de barco</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.tipo_barco) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Eliminar" class="btn btn-default" /> 
        <a href="<%: Url.Action("Index", "TipoBarco") %>">
            <button type="button" class="btn btn-info">Regresar</button>
        </a>
       <%-- <%: Html.ActionLink("Regresar", "Index") %>--%>
    </p>
<% } %>

</asp:Content>
