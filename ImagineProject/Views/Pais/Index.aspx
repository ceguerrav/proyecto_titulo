﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ImagineProject.Models.Pais>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%--<script type="text/javascript">
    $.ajaxSetup({ cache: false });

    $(document).ready(function () {
        $(".detalle").live("click", function (e) {
            e.preventDefault();
            $("<div></div>")
      .addClass("dialog")
      .attr("id", $(this).attr("dialog-id"))
      .appendTo("body")
      .dialog({
          title: $(this).attr("dialog-title"),
          close: function () { $(this).remove() },
          modal: true,
          width: "auto"
      })
      .load(this.href);
        });

        $(".close").live("click", function (e) {
            e.preventDefault();
            $(this).closest(".dialog").dialog("close");
        });
    });
</script>FUNCIONA--%>

<h2>Países</h2>

<p>
    <a href="<%: Url.Action("Create", "Pais") %>">
        <button class="btn btn-primary">Agregar Nuevo</button>
    </a>
    <%--<%: Html.ActionLink("Agregar nuevo", "Create") %>--%>
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Nombre oficial
        </th>
        <th>
            Nombre país
        </th>
        <th>
            Codigo ISO
        </th>
        <th>
            Tipo de división
        </th>
        <th></th>
    </tr>
    </thead>

    <tbody>
<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.nombre_oficial) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.nombre_pais) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.cod_iso) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.TipoDivision.tipo_division) %>
        </td>
        <td>
            <%: Html.ActionLink("Editar", "Edit", new { id = item.id_pais })%> |
            <%: Html.ActionLink("Detalles", "Details", new { id = item.id_pais }, new { @class = "detalle" })%> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id=item.id_pais }) %>
        </td>
    </tr>
<% } %>
</tbody>
</table>

<div id="dialog"></div>

<%--<script type="text/javascript">
    $(function () {
        $('.detalle').click(function () {
            $('<div>Loading ...</div>').load(this.href).dialog();
            return false;
        });
    });
    </script>--%>

   <%-- <script language="javascript" type="text/javascript">  
        $(function () {  
            $('#dialog').dialog({  
                autoOpen: false,  
                width: 600,  
                buttons: {   
                    "Ok": function () { $(this).dialog("close"); },  
                    "Cancel": function () {$(this).dialog("close");}  
                }  
            });  
            $(".detalle").button().click(function () {  
                $('#dialog').dialog('open');  
                return false;                  
            });  
        });  
    </script> --%>


</asp:Content>
