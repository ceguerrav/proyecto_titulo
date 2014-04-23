<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Puerto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Agregar</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/CascadeDropDownListPuerto.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Puerto</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nombre_puerto) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nombre_puerto) %>
            <%: Html.ValidationMessageFor(model => model.nombre_puerto) %>
        </div>

        <!--- Cascade DropDownList --->
         <div class="editor-label">
            <%: Html.LabelFor(model => model.Ciudad.DivisionAdministrativa.id_pais) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("ddl_pais",ViewBag.ddl_pais as SelectList,"--- Seleccione país ---",new { id = "id_pais"})%>
             <%: Html.ValidationMessageFor(model => model.Ciudad.DivisionAdministrativa.id_pais)%>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Ciudad.id_division_administrativa, "División adminsitrativa") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("ddl_division", ViewBag.ddl_division as SelectList, new { id = "id_division" })%>
            <%: Html.ValidationMessageFor(model => model.Ciudad.id_division_administrativa)%>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_ciudad, "Ciudad") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_ciudad", ViewBag.ddl_ciudad as SelectList, new { id = "id_ciudad" })%>
            <%: Html.ValidationMessageFor(model => model.id_ciudad) %>
        </div>
        <!--- Cascade DropDownList --->

        <p>
            <input type="submit" value="Agregar" class="btn btn-default" />
        </p>
    </fieldset>
<% } %>

<div>
    <a href="<%: Url.Action("Index", "Puerto") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>
    <%--<%: Html.ActionLink("Regresar", "Index") %>--%>
</div>

</asp:Content>
