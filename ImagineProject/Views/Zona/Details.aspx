<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Zona>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Zona</legend>

    <div class="display-label">Nombre de zona</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nombre_zona) %>
    </div>

    <div class="display-label">Tipo de zona</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.TipoZona.tipo_zona) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_zona}) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
