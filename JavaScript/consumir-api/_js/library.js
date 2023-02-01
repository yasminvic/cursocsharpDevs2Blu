// Confs
const scripts = $('#scripts').clone(); //sempre que carregar outro site, vai vir junto aquela div
//esse clone vai copiar essa div
//fazemos isso pra poder carregar os scripts dnv ao carregar a pag

//Functions
const getPagina = (url, target) => {
    //vai pegar o registro de fora e nos trazer
    //nao vai substituir, só vai add dentro
    $.ajax({
        url: `_views/${url}`, //já coloca o _views pq todas vao estar dentro desta pasta
        dataType: 'html',
        success: (pagina) =>{
            $(target).html(pagina);
                //.append(scripts); //carrega os scripts dps de carregar a pag
        }
    });

};


