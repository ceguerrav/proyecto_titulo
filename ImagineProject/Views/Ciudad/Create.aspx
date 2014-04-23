<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Ciudad>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Agregar</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/CascadeDropDownListCiudad.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Ciudad</legend>

        <!--- Cascade DropDownList --->
         <div class="editor-label">
            <%: Html.LabelFor(model => model.DivisionAdministrativa.id_pais) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("ddl_pais",ViewBag.ddl_pais as SelectList,"--- Seleccione país ---",new { id = "id_pais"})%>
            <%: Html.ValidationMessageFor(model => model.DivisionAdministrativa.id_pais)%>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_division_administrativa, "División adminsitrativa") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_division_administrativa", ViewBag.ddl_division as SelectList, new { id = "id_division" })%>
            <%: Html.ValidationMessageFor(model => model.id_division_administrativa)%>
        </div>
        <!--- Cascade DropDownList --->

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nombre) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nombre) %>
            <%: Html.ValidationMessageFor(model => model.nombre) %>
        </div>

        <p>
            <input type="submit" value="Agregar" class="btn btn-default" />
        </p>
    </fieldset>
<% } %>

<div>
    <a href="<%: Url.Action("Index", "Ciudad") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>
    <%--<%: Html.ActionLink("Regresar", "Index") %>--%>
</div>

</asp:Content>
