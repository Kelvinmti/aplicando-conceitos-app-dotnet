function carregarModalNovaReceita() {
    $("#novaReceita").click(function () {
        $.get("Receitas/NovaReceita")
            .done(function (data) {
                abrirModal('Nova Receita', data, true, 'formNovaReceita');
            })
            .fail(function (error) {
                alert(error.responseText);
                console.log(error);
            });


    });
}