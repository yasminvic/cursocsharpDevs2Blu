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
        html.classList.add('card', 'col-4', 'my-4', 'bg-dark'); //add varias classes de uma vez com js, usando jquery é de outro jeito
        
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

    /*const chara = {
        id: character.id,
        name: character.name,
        status: character.status,
        species: character.species,
        type: character.type,
        gender: character.gender,
        origin: character.origin,
        location: character.location,
        image: character.image,
        episode:character.episode,
        url: character.url,
        created: character.created,
    };*/
}