<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Pasajero>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Detalles</h2>

<fieldset>
    <legend>Pasajero</legend>

    <table>
    <tr>
    <div class="display-label"><td><b>Pasaporte: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.pasaporte) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Nombres: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.nombres) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Apellidos: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.apellidos) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>País: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.Ciudad.DivisionAdministrativa.Pais.nombre_pais) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>
    <%: Html.DisplayFor(model => model.Ciudad.DivisionAdministrativa.Pais.TipoDivision.tipo_division) %>: 
    </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.Ciudad.DivisionAdministrativa.nombre) %></td>
    </div>
    </tr>
        
    <tr>
    <div class="display-label"><td><b>Ciudad: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.Ciudad.nombre) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Direccion: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.direccion) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Numero de contacto: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.numero_contacto) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>E-mail: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.e_mail) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Sexo: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.sexo) %></td>
    </div>
    </tr>

    <tr>
    <div class="display-label"><td><b>Fecha de nacimiento: </b></td></div>
    <div class="display-field">
        <td><%: Html.DisplayFor(model => model.fecha_nac) %></td>
    </div>
    </tr>
    </table>
</fieldset>
<p>
    <%: Html.ActionLink("Editar", "Edit", new { id=Model.id_pasajero }) %> |
    <%: Html.ActionLink("Regresar", "Index") %>
</p>

</asp:Content>
