<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Pasajero>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Agregar</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/CascadeDropDownListDireccion.js") %>" type="text/javascript"></script>

<!-- date_picker -->
<script src="<%: Url.Content("~/Script/jquery-1.6.4.min.js") %>" type="text/javascript"></script>	
<link href="../../Content/themes/base/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
<script src="<%: Url.Content("~/Scripts/date_picker/ui/jquery.ui.core.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/date_picker/ui/jquery.ui.datepicker.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/date_picker/ui/i18n/jquery.ui.datepicker-es.js") %>" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $("#fecha_nac").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: '1940:' + new Date().getFullYear()
        });
    });
</script>
<!-- date_picker -->

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Pasajero</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.pasaporte) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.pasaporte) %>
            <%: Html.ValidationMessageFor(model => model.pasaporte) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nombres) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nombres) %>
            <%: Html.ValidationMessageFor(model => model.nombres) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.apellidos) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.apellidos) %>
            <%: Html.ValidationMessageFor(model => model.apellidos) %>
        </div>

        <!--- Cascade DropDownList --->
         <div class="editor-label">
            <%: Html.LabelFor(model => model.Ciudad.DivisionAdministrativa.id_pais) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("ddl_pais",ViewBag.ddl_pais as SelectList,"--- Seleccione país ---",new { id = "id_pais"})%>
            <%: Html.ValidationMessageFor(model => model.Ciudad.DivisionAdministrativa.id_pais)%>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Ciudad.id_division_administrativa, "División adminsitrativa") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("ddl_division", ViewBag.ddl_division as SelectList, new { id = "id_division" })%>
            <%: Html.ValidationMessageFor(model => model.Ciudad.id_division_administrativa)%>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.id_ciudad, "Ciudad") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("id_ciudad", ViewBag.id_ciudad as SelectList, new { id = "id_ciudad" })%>
            <%: Html.ValidationMessageFor(model => model.id_ciudad) %>
        </div>
        <!--- Cascade DropDownList --->

        <div class="editor-label">
            <%: Html.LabelFor(model => model.direccion) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.direccion) %>
            <%: Html.ValidationMessageFor(model => model.direccion) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.numero_contacto) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.numero_contacto) %>
            <%: Html.ValidationMessageFor(model => model.numero_contacto) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.e_mail) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.e_mail) %>
            <%: Html.ValidationMessageFor(model => model.e_mail) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.sexo) %>
        </div>
        <div class="editor-field">
            <%--<%: Html.RadioButtonFor(model => model.sexo, true, new { id = "sexo_femenino" })%>
            <label for="sexo_femenino">F</label>
            <%: Html.RadioButtonFor(model => model.sexo, false, new { id = "sexo_masculino" })%>
            <label for="sexo_masculino">M</label>--%>
            <%= Html.RadioButton("sexo", "F", true) %> Femenino </br>
            <%= Html.RadioButton("sexo", "M", true) %> Masculino
            <%: Html.ValidationMessageFor(model => model.sexo) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.fecha_nac) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.fecha_nac, new { id = "fecha_nac" })%>
            <%: Html.ValidationMessageFor(model => model.fecha_nac) %>
        </div>

        <p>
            <input type="submit" value="Agregar" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Regresar", "Index") %>
</div>

</asp:Content>
