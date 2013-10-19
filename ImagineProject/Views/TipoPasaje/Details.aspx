﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.TipoPasaje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Tipo de pasaje</legend>

    <div class="display-label">Tipo de pasaje</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.tipo_pasaje) %>
    </div>

    <div class="display-label">Descripción</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcion) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_tipo_pasaje }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
