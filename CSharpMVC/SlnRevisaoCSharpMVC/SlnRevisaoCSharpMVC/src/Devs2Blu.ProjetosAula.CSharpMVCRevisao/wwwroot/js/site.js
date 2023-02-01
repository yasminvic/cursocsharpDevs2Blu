$(document).ready(() => {
    //quando clicar no botao
    $('#btn-search').click((e) => {
        e.preventDefault();
        let nameInput = $('#input-search').val();
        $.ajax({
            //ele vai
            //action       //controller    //parametro da url
            url: `/cards/search/${nameInput}`,//essa url está sendo como parametro la no controller, no partialview SearchCard
            dataType: 'html',
            success: (htmlPartialView) => {
                //ele vai carrgar dentro de searchcard o response que retornar(que seria o card que foi pesquisado)
                $('#content-list').html(htmlPartialView);
            }
        });
    });
});
