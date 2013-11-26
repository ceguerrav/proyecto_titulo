<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Tag>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Agregar</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>


    <fieldset>
        <legend>Tag</legend>

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
                <input type="submit" value="Agregar" />
            </p>
        <% } %>

    </fieldset>

<div>
    <%: Html.ActionLink("Regresar", "Index") %>
</div>

</asp:Content>
