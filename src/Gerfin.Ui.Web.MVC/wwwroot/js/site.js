// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function abrirModal(titulo, conteudo, addValidacao = false, idForm = null) {
    $("#modal").attr("aria-labelledby", titulo);
    $("#modalTitle").html(titulo); 
    $("#resultModal").html(conteudo); 

    if (addValidacao)
        $.validator.unobtrusive.parse("#" + idForm);

    $("#modal").modal("show");
}