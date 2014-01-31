<%@ Control Language="C#" 
Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<ImagineProject.Models.Reporte1>>" %>
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
            Movimientos
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
<a href="<%: Url.Action("PDF", "Reportes") %>">
    <button class="linkAgregar">Generar PDF</button>
</a>