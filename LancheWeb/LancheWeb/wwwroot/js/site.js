
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