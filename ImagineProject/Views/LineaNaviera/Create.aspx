﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.LineaNaviera>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Agregar</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Linea naviera</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.linea_naviera) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.linea_naviera) %>
            <%: Html.ValidationMessageFor(model => model.linea_naviera) %>
        </div>

        <p>
            <input type="submit" value="Agregar" class="btn btn-default" />
        </p>
    </fieldset>
<% } %>

<div>
    <a href="<%: Url.Action("Index", "LineaNaviera") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>
    <%--<%: Html.ActionLink("Regresar", "Index") %>--%>
</div>
</asp:Content>
