
$("document").ready(function () {
    $("#id_pais").change(function () {
        var id_pais = $(this).val();
        $.getJSON("/Ciudad/GetDivisiones", { id_pais: id_pais }, function (carData) {
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
