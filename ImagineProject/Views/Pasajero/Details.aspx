<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Pasajero>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detailles</h2>

<fieldset>
    <legend>Pasajero</legend>

    <div class="display-label">Pasaporte</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.pasaporte) %>
    </div>

    <div class="display-label">Nombres</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nombres) %>
    </div>

    <div class="display-label">Apellidos</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.apellidos) %>
    </div>
    
    <div class="display-label">Ciudad</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Ciudad.nombre) %>
    </div>

    <div class="display-label">Direccion</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.direccion) %>
    </div>

    <div class="display-label">Numero de contacto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.numero_contacto) %>
    </div>

    <div class="display-label">E-mail</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.e_mail) %>
    </div>

    <div class="display-label">Sexo</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.sexo) %>
    </div>

    <div class="display-label">Fecha_nac</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.fecha_nac) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_pasajero }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
