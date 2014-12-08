<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ImagineProject.Models.Tag>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Create</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<script type="text/javascript">
    function buscarAjax() {
        $.ajax({
            url: "/Tag/BuscarPasajeroPorPasaporte",
            data: {
                txt_pasaporte: $("#txt_pasaporte").val()
            },
            type: "post",
            async: true,
            cache: false,
            success: function (retorno) {
                $("#contenido").html(retorno);
            }
        });
    }
  </script>

<% using (Html.BeginForm(null, null, FormMethod.Post, new { id = "BusquedaPasajero" })) { %>
    <%:Html.ValidationSummary(false) %>
    <fieldset>
            <legend>"Buscar pasajero (Ingrese pasaporte)"</legend>
        <div class="editor-label">
            <%: Html.Label("txt_pasaporte", "Pasaporte")%>
        </div>
        <div class="editor-field">
            <input type="text" id="txt_pasaporte"  class="required" />                
            <!--  Botón Busqueda de Pasajero-->
            <input type="button" value="Buscar" id="btn_buscar" class="btn btn-default" onclick="javascript:buscarAjax();"/>
        </div>        
        
     </fieldset>
<% } %>

<div id="contenido">
</div>
<!-- Separación entre formularuos-->

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Tag</legend>
        
         <!--Código antiguo: Carga los pasajeros en un DropDownList -->
         <!--
         <div class="editor-field">
            <%: Html.HiddenFor(model => model.id_pasajero) %>
            <%: Html.ValidationMessageFor(model => model.id_pasajero) %>
        </div>        
        -->

        <div class="editor-label">
            <%: Html.LabelFor(model => model.identificador) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.identificador) %>
            <%: Html.ValidationMessageFor(model => model.identificador) %>
        </div>

        <p>
            <input type="submit" value="Agregar Tag ID" class="btn btn-default" onclick="javascript:ValidarTag();" />
        </p>
    </fieldset>
<% } %>

<div>
    <a href="<%: Url.Action("Index", "Tag") %>">
        <button type="button" class="btn btn-info">Regresar</button>
    </a>
</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
