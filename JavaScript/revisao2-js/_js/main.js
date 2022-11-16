var listCharacter = new Array(); //lista com todos os personagens

//essa função fica escutando quando carregar
//se mudassemos o load ali para outro parametro funcionaria diferente, 
//nao chamaria a função quando carregasse dai
addEventListener('load', function(){
    getAPI(URL_API_CHARACTER, criaListaCharacter); //chama função que faz comunicação com a api
                            //o parametro dessa função está sendo passado lá função getAPI
});



const criaListaCharacter = (data) =>{
    let main = getElement('main');

    console.log(data);

    listCharacter = new Array();
    //pra cada personagem dentro de results dentro de data
    data.results.forEach(character => {
        let html = document.createElement('div'); //div do card
        html.classList.add('card', 'col-3', 'my-4', 'bg-dark', 'ms-1'); //add varias classes de uma vez com js, usando jquery é de outro jeito
        
        //se clicar no card, executa essa função que faz aparecer o modal
        html.addEventListener('click', () => mostraDetalhesCharacter(character)); //passando uma function

        let htmlBody = `
        <div class="card-header">
            <img class="card-img-top" src="${character.image}" alt="${character.name}">
        </div>
        <div class="card-body bg-white">
            <h1 class="text-primary text-center">${character.name}</h1>
        </div>`; //criando cardbody e card header

        html.innerHTML = htmlBody; //innerHTML interpreta o texto como html
                                    //ent vai pegar esse htmlbody, add no html e interpretar como código
        main.appendChild(html);//appendando um objeto filho
        listCharacter.push(character);//appendando personagem dentro da lista

    });
    //assim que carregar a api, gerar a paginação tbm
    gerarPaginacao(data.info);
}


const mostraDetalhesCharacter = (character) =>{
    let div = document.createElement('div'); //cria div

    getElement('#modal-body').innerHTML = ''; //apaga oq estiver dentro pra não repetir infinitamente

    div.classList.add('card', 'col-12', 'my-4', 'bg-dark'); //estiliza div

    let cardBody = `
    <div class="card-header">
        <img class="card-img-top" src="${character.image}" alt="${character.name}">
    </div>
    <div class="card-body bg-white">
        <h1 class="text-primary text-center">${character.name}</h1>
        <article>
            <ul class="list-group">
                <li class="list-group-item">${character.name}</li>
                <li class="list-group-item">${character.status}</li>
                <li class="list-group-item">${character.species}</li>
                <li class="list-group-item">${character.gender}</li>
                <li class="list-group-item">${character.origin.name}</li>
                <li class="list-group-item">${character.location.name}</li>
                <li class="list-group-item">${character.url}</li>
                <li class="list-group-item">${character.created}</li>
              </ul>
        </article>
    </div>
    `; //cria body e header do card

    div.innerHTML = cardBody; //interpreta o html e add na div

    getElement('#modal-body').appendChild(div); //add div dentro do body do modal

    //.modal é um recurso do bootstrap, que utiliza JQuery, por isso foi preciso colocar $
    $('#charModal').modal('show'); //abre caixinha pro personagem quando clicar nele
};


const gerarPaginacao = (info, currentPage=null) =>{
    let pag = getElement('#pagination'); // pegando a paginação lá embaixo
    
    pag.innerHTML = ""; //toda vez que gerar, apagar o conteudo antigo para nao repetir

    //criando previous na pagination
    let prevItem = novoItemPagination(info.prev, 'Previous');
    pag.appendChild(prevItem);//add item previous dentro da tag ul
    
    let indexPagination = (currentPage && currentPage > 5) ? currentPage - 5: 0; 

    //enquanto index for menor que o numero de páginas
    for (let index = indexPagination; index < info.pages; index++){
        //mostra os 5 primeiros
        if (currentPage == null && index < 5){
            //add item numero da pag
            let liItemPag = novoItemPagination(`${URL_API_CHARACTER}?page=${index +1}`, `${index+1}`);
            pag.appendChild(liItemPag); //add os numeros na pagination em si, na ul
        }
        //mostra os 5 últimos
        if (currentPage == null && index > (info.pages - 5) && index < info.pages){
            //add item numero da pag
            let liItemPag = novoItemPagination(`${URL_API_CHARACTER}?page=${index +1}`, `${index+1}`);
            pag.appendChild(liItemPag); //add os numeros na pagination em si, na ul
        }


        //item clicado 
        if (currentPage && !(indexPagination < (currentPage) && indexPagination < (info.pages - 5))){
            //add item numero da pag
            let liItemPag = novoItemPagination(`${URL_API_CHARACTER}?page=${index +1}`, `${index+1}`);
            pag.appendChild(liItemPag); //add os numeros na pagination em si, na ul
        }
    }

    //add item next 
    let nextItem = novoItemPagination(info.next, 'Next');
    pag.appendChild(nextItem); //add previous no nav
}

const novoItemPagination = (url, index) =>{
    //criando cada item da pagination
    let liItem = document.createElement('li');
    liItem.classList.add('page-item'); //estilizando li
    liItem.innerHTML = `<a onclick="irItemPaginacao('${url}')" class="page-link" href="#">${index}</a>`; //criando o link para cada pagina
    return liItem;
}

const irItemPaginacao = (url) =>{

}

let info = {
    count: 826,
    pages: 42,
    next: "https://rickandmortyapi.com/api/character/?page=2",
    prev: null
  };