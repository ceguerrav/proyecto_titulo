<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.ZonaPais>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detlles</h2>

<fieldset>
    <legend>Paises de zona</legend>

    <div class="display-label">Zona</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Zona.nombre_zona) %>
    </div>

    <div class="display-label">Pais</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Pais.nombre_pais) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new {  id_zona=Model.id_zona, id_pais=Model.id_pais }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
