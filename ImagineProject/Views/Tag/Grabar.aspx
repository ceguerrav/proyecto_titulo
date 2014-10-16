<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Tag>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Grabar etiqueta</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>


    <fieldset>
        <legend>Tag: Seleccione un pasajero y genere un nuevo identificador, presionando el botón "Grabar Etiqueta".</legend>

            <% using (Html.BeginForm()) { %>
                <%: Html.ValidationSummary(true) %>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.id_pasajero, "Pasajero") %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownList("id_pasajero", String.Empty) %>
                <%: Html.ValidationMessageFor(model => model.id_pasajero) %>
            </div>      
                     
            <p>
                <input type="submit" value="Grabar Etiqueta" class="btn btn-default"  />
            </p>
        <% } %>

    </fieldset>

<div>
    <a href="<%: Url.Action("Index", "Tag") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>
    <%--<%: Html.ActionLink("Regresar", "Index") %>--%>
</div>

</asp:Content>
