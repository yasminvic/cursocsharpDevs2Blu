$(document).ready(()=>{
    console.log('JQuery is loaded.');

    // Carregar Pagina
    $('#tipo-delta').click((e)=>{ //quando clica no link do nav
        $('#destaque').hide(); //esconde o carrossel

        getPagina('delta.html', 'main'); 
    });

    $('#tipo-texas').click((e) =>{
        getPagina('texas.html', 'main');
        $('#destaque').hide();
    });

    $('#tipo-chicago').click((e) =>{
        getPagina('chicago.html', 'main');
        $('#destaque').hide();
    })
});





/*Funcions*/

var getPagina = (page, target) => {
    $.ajax({
        url: page,
        datatype: 'html',
        success: (data) =>{
            $(target).html(data);
        }
    })
}