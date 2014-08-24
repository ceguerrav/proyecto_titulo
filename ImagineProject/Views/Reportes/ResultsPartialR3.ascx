﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ImagineProject.Models.Reporte3>>" %>

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

<table class="display" id="tabla">
    <thead>
    <tr>
        <th>
            Año
        </th>
        <th>
            Pasaporte
        </th>
        <th>
            Pasajero
        </th>
        <th>
            Tipo de pasaje
        </th>
        <th>
            Cantidad pasajes
        </th>
    </tr>
    </thead>

    <tbody>
<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Anio) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Pasaporte) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Pasajero) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Tipo_pasaje) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Cant_pasajes) %>
        </td>
    </tr>
<% } %>
    </tbody>
</table>
<p></p>
<a href="<%: Url.Action("PDF", "Reportes") %>">
    <button class="btn btn-primary">Generar PDF</button>
</a>
    
</p>
