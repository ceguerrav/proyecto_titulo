<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ImagineProject.Models.Pasajero>" %>


<div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title">Información Pasajero</h3>
  </div>
  <div class="panel-body">
    <div class="display-label">Pasajero </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nombres) %>
        <%: Html.DisplayFor(model => model.apellidos) %>
    </div>

    <div class="display-label">Dirección </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.direccion) %>,
        <%: Html.DisplayFor(model => model.Ciudad.nombre) %>,
        <%: Html.DisplayFor(model => model.Ciudad.DivisionAdministrativa.Pais.TipoDivision.tipo_division) %>: 
        <%: Html.DisplayFor(model => model.Ciudad.DivisionAdministrativa.nombre) %> -
        <%: Html.DisplayFor(model => model.Ciudad.DivisionAdministrativa.Pais.nombre_pais) %>
        
    </div>

    <div class="display-label">E-mail</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.e_mail) %>
    </div>

    <div class="display-label">Contacto </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.numero_contacto) %>
    </div>
  </div>
</div>