﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Portico>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Editar</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Portico</legend>
            
            <%: Html.HiddenFor(model => model.id_portico) %>
            <%: Html.HiddenFor(model => model.estado) %>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.numero_portico) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.numero_portico) %>
            <%: Html.ValidationMessageFor(model => model.numero_portico) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.descripcion_portico) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.descripcion_portico) %>
            <%: Html.ValidationMessageFor(model => model.descripcion_portico) %>
        </div>

        <p>
            <input type="submit" value="Guardar" class="btn btn-default" />
        </p>
    </fieldset>
<% } %>

<div>   
    <a href="<%: Url.Action("Index", "Portico") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>
    <%--<%: Html.ActionLink("Regresar", "Index") %>--%>
</div>

</asp:Content>
