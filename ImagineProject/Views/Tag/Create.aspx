<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Tag>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Create</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Tag</legend>
        
        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_pasajero, "Pasajero") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_pasajero", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.id_pasajero) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.identificador) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.identificador) %>
            <%: Html.ValidationMessageFor(model => model.identificador) %>
        </div>

        <p>
            <input type="submit" value="Agregar Tag ID" />
        </p>
    </fieldset>
<% } %>

<div>
    <a href="<%: Url.Action("Index", "Tag") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>
</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
