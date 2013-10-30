<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Pasajero>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Editar</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/CascadeDropDownListPasajero.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Pasajero</legend>

            <%: Html.HiddenFor(model => model.id_pasajero) %>
            <%: Html.HiddenFor(model => model.fecha_registro) %>
            <%: Html.HiddenFor(model => model.estado) %>

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
            <%: Html.DropDownList("id_ciudad", ViewBag.ddl_ciudad as SelectList, new { id = "id_ciudad" })%>
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
            <%: Html.EditorFor(model => model.sexo) %>
            <%: Html.ValidationMessageFor(model => model.sexo) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.fecha_nac) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.fecha_nac) %>
            <%: Html.ValidationMessageFor(model => model.fecha_nac) %>
        </div>
        <p>
            <input type="submit" value="Guardar" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Regresar", "Index") %>
</div>

</asp:Content>
