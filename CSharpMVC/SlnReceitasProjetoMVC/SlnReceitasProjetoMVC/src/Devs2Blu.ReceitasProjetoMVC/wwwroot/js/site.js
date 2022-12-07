const getView = (nameview, target) => {
    let url = `/${nameview}`;
    let ajaxConfig = {
        url: url,
        dataType: 'html',
        success: (response) => {
            $(target).html(response);
        }
    };

    $.ajax(ajaxConfig);
}

$(document).ready((e) => {
    $('#btn-search').click((e) => {
        e.preventDefault();
        let receita = $('#input-search').val();
        let url = `/search/${receita}`;
        let ajaxConfig = {
            url: url,
            dataType: 'html',
            success: (response) => {
                $('#conten-list').html(response);
            }
        };

        $.ajax(ajaxConfig);
    })
})