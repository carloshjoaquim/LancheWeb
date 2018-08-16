
function Increment(id) {
    let quantity = parseInt($(id).val());
    $(id).val(quantity + 1);
}

function Decrement(id) {
    let quantity = parseInt($(id).val());
    if (quantity > 0) {
        $(id).val(quantity - 1);
    }
}

function erro() {
    $('#alert').css("visibility", "visible");
    $('#alert').removeClass("alert-success");
    $('#alert').addClass("alert-danger");
    $('#alert').html("Ops... Houve um erro ao efetuar a requisição !");
}

function sucesso() {
    $('#alert').css("visibility", "visible");
    $('#alert').html("Cadastro efetuado com sucesso !");
}