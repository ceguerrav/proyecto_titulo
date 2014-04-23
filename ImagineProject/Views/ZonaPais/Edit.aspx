﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.ZonaPais>" %>

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
        <legend>Paises de zona</legend>
          
            <%: Html.HiddenFor(model => model.id_zona) %>
            <%: Html.HiddenFor(model => model.id_pais) %>
            <%: Html.HiddenFor(model => model.estado) %>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_zona, "Zona") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_zona", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.id_zona) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_pais, "Pais") %>
        </div>
        <div class="editor-field">
            <%: Html.ListBox("id_pais", ViewBag.id_pais as MultiSelectList, new { Multiple = "multiple", id = "id_pais", @class="listbox" })%>
            <%: Html.ValidationMessageFor(model => model.id_pais) %>
        </div>

        <p>
            <input type="submit" value="Guardar" class="btn btn-default" />
        </p>
    </fieldset>
<% } %>

<div>
    <a href="<%: Url.Action("Index", "ZonaPais") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>
    <%--<%: Html.ActionLink("Regresar", "Index") %>--%>
</div>

</asp:Content>
