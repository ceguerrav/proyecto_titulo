
$("document").ready(function () {
    $("#id_pais").change(function () {
        var id_pais = $(this).val();
        $.getJSON("/Puerto/GetDivisiones", { id_pais: id_pais }, function (carData) {
            var select = $("#id_division");
            select.html('');
            $.each(carData, function (index, itemData) {
                select.append($('<option/>', {
                    value: parseInt(itemData.Value),
                    text: itemData.Text
                }));
            });
        });
    });
});


$("document").ready(function () {
    $("#id_division").change(function () {
        var id_division = $(this).val();
        $.getJSON("/Puerto/GetCiudades", { id_division: id_division }, function (carData) {
            var select = $("#id_ciudad");
            select.html('');
            $.each(carData, function (index, itemData) {
                select.append($('<option/>', {
                    value: parseInt(itemData.Value),
                    text: itemData.Text
                }));
            });
        });
    });
});
 