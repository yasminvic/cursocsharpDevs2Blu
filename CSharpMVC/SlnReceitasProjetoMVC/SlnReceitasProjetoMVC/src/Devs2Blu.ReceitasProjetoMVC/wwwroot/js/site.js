const getView = (controller, nameview, target) => {
    let url = `/${controller}/${nameview}`;
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
        console.log(e)
        let receita = $('#input-search').val();
        $.ajax({
            url: `/receitas/search/${receita}`,
            dataType: 'html',
            success: (response) => {
                $('#content-list').html(response)
            }
        });
    })



})



const criaDescr = (id) => {
    console.log('oi');
    let idreceita = id;
    $.ajax({
        url: `/receitas/description/${idreceita}`,
        dataType: 'html',
        success: (response) => {
            $('content-list').html(response);
            console.log('oi');
        }
    });
    console.log('oi');
}
