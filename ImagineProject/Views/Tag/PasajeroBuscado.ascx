<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Pasajero>" %>


    <div class="display-label">Pasajero: </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nombres) %>
        <%: Html.DisplayFor(model => model.apellidos) %>
    </div>

    <div class="display-label">Dirección: </div>
    <div class="display-field">
    <%: Html.DisplayFor(model => model.Ciudad.DivisionAdministrativa.Pais.TipoDivision.tipo_division) %>: 
        <%: Html.DisplayFor(model => model.Ciudad.DivisionAdministrativa.nombre) %>
        <%: Html.DisplayFor(model => model.Ciudad.nombre) %>
        <%: Html.DisplayFor(model => model.direccion) %>
    </div>

    <div class="display-label">E-mail:</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.e_mail) %>
    </div>

    <div class="display-label">E-mail: </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.e_mail) %>
    </div>