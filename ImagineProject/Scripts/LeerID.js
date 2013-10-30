    $(function() {
        $("#btn_generarId").click(function() {
            var id = $("#txt_id").val();
            updateResult(id);
            return false;
        });
    });


    function updateResult(id) {
        var url = "/Tag/Show/id=param-id"; // Establecer URL de la acción
        url = url.replace("param-id", id);
        $("#txt_id").load(url);
    }