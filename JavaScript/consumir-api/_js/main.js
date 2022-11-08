//Confs
const URL_API = 'https://pokeapi.co/api/v2/pokemon/';

$(document).ready(() =>{
    getPagina('home.html', 'main');
})

const getPokemonList = (offset = null, limit = null) =>{
    //usando esses parametros porque a api pede
}

//URL: 'https://pokeapi.co/api/v2/pokemon/';
const getPokemon = () => {
    getPagina('getPokemon.html', 'main');
    $.ajax({
        url: URL_API, //vai carregar a api
        dataType: 'json', //pq agora estamos mexendo na api, que é json
        success: (data) =>{ //parametro data é prórprio do success, retornando uma função (arrow function) interna com os dados
            let listPkm = document.createElement('div'); //criando div
            $(listPkm).addClass('row'); //add uma class do bootstrap na div
            $('#getPokemon').html(listPkm); //adicionando div dentro do site

            
            data.results.forEach((p, i) => { //pra cada pokemon dentro de data
                //p: proprio pokemon
                //i: indice dele
                //pega detro do data só o .results
                let li = document.createElement('div'); //cria elemento div
                let card = document.createElement('div'); //os cards vao servir pra colocar as infos dos pokemons
                let cardHeader = document.createElement('div');
                let cardBody = document.createElement('div');

                //add elemntos dentro das divs
                
                $(li).addClass('col-4'); //add class do boostrap pra cada pokemon

                //estilizando com bootstrap
                $(card).addClass('card');
                $(cardHeader).addClass('card-header');
                $(cardBody).addClass('card-body');

                $(cardHeader).attr('id', `ch-pkm${i}`);//adicionando um atributo dentro, cada id é o indice do pokemon
                

                $(cardBody).html(`<h1>${p.name}</h1>`);//cria h1 para cada pokemon

                //add cardheader e cardbody dentro de card
                $(card).append(cardHeader)
                    .append(cardBody);
                
                //add card dentro de li
                $(li).append(card);

                
                
                $(listPkm).append(li); //add li dentro de ul
                getIMGPokemon(p.url, `#ch-pkm${i}`); //pra cada pokemon vamos fazer uma tag img
                
            });
        }
    });
};

////URL: 'https://pokeapi.co/api/v2/pokemon/';
const getIMGPokemon = (url, target) =>{
    //pra cada pokemon vamos fazer uma tag img
    return $.ajax({
        url: url,
        dataType: 'json',
        success: (data) => {
            let dataHtml = document.createElement('img');
            $(dataHtml).addClass('card-img-top');
            $(dataHtml).attr('src', data.sprites.front_default); //ad atributo na img, pegando sprites dentro de data e front_default dentro de sprites

            $(dataHtml).css({width: '256px'});//estiliza img

            $(target).append(dataHtml); //id recebe o elemenyo img
        } 
    });
};