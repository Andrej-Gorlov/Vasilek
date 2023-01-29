function openModal(parameters) {
    const id = parameters.data;
    const url = parameters.url;
    const modal = $('#modal');

    if (id === undefined || url === undefined) {
        alert('”пссс.... что-то пошло не так')
        return;
    }

    $.ajax({
        type: 'GET',
        url: url,
        data: { "ProductId": id },
        success: function (model) {
            modal.find(".modal-dialog").html(model);
            modal.modal('show')
        },
        failure: function () {
            modal.modal('hide')
        },
        error: function (model) {
            alert(model.responseText);
        }
    });
};