<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.TipoZona>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Tipo de Zona</legend>

    <div class="display-label">Tipo de zona</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.tipo_zona) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_tipo_zona }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
