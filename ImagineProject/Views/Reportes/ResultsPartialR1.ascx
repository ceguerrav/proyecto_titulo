﻿<%@ Control Language="C#" 
Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ImagineProject.Models.Reporte1>>" %>

<link href="../../Content/DataTables-1.9.4/media/css/jquery.dataTables_themeroller.css" rel="stylesheet" type="text/css" />
<script src="<%: Url.Content("~/Scripts/jquery-1.10.2.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/modernizr-1.7.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/DataTables-1.9.4/media/js/jquery.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/DataTables-1.9.4/media/js/jquery.dataTables.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/DataTables-1.9.4/extras/ColReorder/media/js/ColReorderWithResize.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery-ui-1.10.3.custom.min.js") %>" type="text/javascript"></script>

<script type="text/javascript">
    $(document).ready(function () {
        $('#tabla').dataTable({
            "bJQueryUI": true,
            "sPaginationType": "full_numbers",
            "sDom": "Rlfrtip",
            "oLanguage": {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "No hay registros disponibles",
                "sLoadingRecords": "Por favor espere - cargando...",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sSearch": "Buscar: ",
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                }
            }
        });
    });
</script>

<h2>Detalles Reporte</h2>
<p>
    
</p>
<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Fecha
        </th>
        <th>
            Visitas
        </th>
        <th>
            Pasaporte
        </th>
        <th>
            Pasajero
        </th>
        <th>
            Barco
        </th>
        <th>
            Viaje
        </th>
        <th>
            Tipo recinto
        </th>
        <th>
            Tipo ambiente
        </th>
        <th>
            Nombre recinto
        </th>
    </tr>
    </thead>

    <tbody>
<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Fecha) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Cantidad_movimientos) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Pasaporte) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Nombre_completo) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Nombre_barco) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Viaje) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Tipo_recinto) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Tipo_ambiente) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Nombre_recinto) %>
        </td>
    </tr>
<% } %>
    </tbody>
</table>
<p></p>
<a href="<%: Url.Action("ExportData", "Reportes") %>">
    <button class="btn btn-primary">Exportar a excel</button>
</a>

<div><% if (Model.Count() > 0 )
        { %>
    <img src="/Reportes/GetGraficoRep1" alt="Visitas por día" width="1000" height="1000"  />
    <% } %>
</div>