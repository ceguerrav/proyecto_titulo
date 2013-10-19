﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Portico>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Eliminar</h2>

<h3>¿Realmente desea eliminar esto?</h3>
<fieldset>
    <legend>Portico</legend>

    <div class="display-label">Número de portico</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.numero_portico) %>
    </div>

    <div class="display-label">Descripción del portico</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcion_portico) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Eliminar" /> |
        <%: Html.ActionLink("Regresar", "Index") %>
    </p>
<% } %>

</asp:Content>
