var listPers = new Array();
var listFav = new Array();
var listCom = new Array();

//recebe os comentarios no localstorage
var listComGet = new Array();

var todos = getId('btn-all');
var aluno = getId('btn-aluno');
var func = getId('btn-func');
var destaque = getId('destaque');


//add evento de load
addEventListener('load', function(){
    getId('favorite-characters').appendChild(criaCardFav());
});

//add evento de clique
aluno.addEventListener('click', function(){
    //destaque.hidden=true;
    comunAPI(URL_ALUNO, criaListaPers, 'Alunos');
});

func.addEventListener('click', function(){
    //destaque.hidden=true;
    comunAPI(URL_FUNC, criaListaPers, 'Funcionários');
});

todos.addEventListener('click', function(){
    //destaque.hidden = true;
    comunAPI(URL_CHARACTERS, criaListaPers, 'Personagens');
});


//add todos os personagens na lista
const criaListaPers = (data, title) => {
    listPers = new Array();
    listPers.push(title);
    data.forEach(character => {
        listPers.push(character);
    });

    //retira os personagens que nao tem foto
    if (listPers[0] == 'Alunos'){
        listPers.splice(12, listPers.length - 11);
        listPers.shift();
    
    }else if (listPers[0] == 'Funcionários'){
        listPers.splice(9, listPers.length - 8);
        listPers.shift();
    
    }else if (listPers[0] == 'Personagens'){
        listPers.splice(26, listPers.length - 25);
        listPers.shift();
    }  

    //funcao que constroe os cards  
    listaCharacters(title);
}

//construindo o card
const listaCharacters = (title) =>{
    //pegando e limpando a main
    let main = getId('main-content');
    main.innerHTML = ''; 

    //criando html
    let h1 = `<h1 class="text-center mt-4 title">Lista de ${title}</h1>`;

    //percorrendo a lista de personagens
    let div = percorreList(listPers);

    //add no main
    main.innerHTML = h1;
    main.appendChild(div);
};

//percorre lista de personagens e cria cards
const percorreList = (list) => {
    let div = document.createElement('div');
    list.forEach((character) => {

        //cor das casas
        let casa = `${character.house}`;
        let cor = '';
        if(casa === 'Gryffindor'){
            cor = 'danger';
        }else if(casa === 'Slytherin'){
            cor = 'success';
        }else if(casa === 'Hufflepuff'){
            cor = 'warning';
        }else if(casa === 'Ravenclaw'){
            cor = 'info';
        }else if(casa === ""){
            cor = 0;
        }

        //casa nula
        if (casa === ""){
            casa = 'No house';
            cor = 'light';
        }

        //criando html
        let card = document.createElement('div');
        let cardBody = `<div class="card-header bg-dark border-bottom border-light carta-header">
                    <h2 class="text-center title-card card-title">${character.name}</h2>
                </div>
                <div class="card-body bg-dark carta-body container">
                    <img src="${character.image}" alt="${character.name}" width="100" height="300" class="card-image card-img-top mt-2 mb-1 img-custom">
                    <h3 class="mt-3 p-2 text-${cor} text-center border border-${cor}">${casa}</h3> 
                    <input onclick="favoritarCharac('${character.name}', '${character.image}', '${character.house}')" type="image" src="_img/heart.png" id="btn-favorite" class="btn w-25 btn-sm mx-auto">
                </div>`
        
            
        //add event de clique
        card.addEventListener('click', () => criaPagCharac(character));

        //estilizando
        card.classList.add('card', 'col-3', 'my-4', 'border-secondary', 'bg-dark', 'ms-1', 'm-3', 'carta');
        div.classList.add('d-flex', 'container', 'row', 'justify-content-center');

        //append
        card.innerHTML = cardBody;
        div.appendChild(card);
    })
    return div;
};

const criaPagCharac = (character) =>{

    let main = getId('main-content');
    main.innerHTML = "";

    let div = document.createElement('div');
    let card = document.createElement('div');
    let form = document.createElement('form');


    card.classList.add('card', 'mb-3', 'bg-dark', 'bg-danger', 'mx-auto');
    card.style.width = '1000px';

    form.classList.add('border', 'border-secondary', 'mx-auto', 'mb-3', 'p-3', 'bg-dark', 'w-50');
    form.setAttribute('onsubmit', 'return true');//IMPORTANTE COLOCAR

    div.classList.add('container');

    let cardBody = `
    <div class="row g-0">
      <div class="col-md-4">
        <img src="${character.image}" id="img-charac" class="img-fluid rounded-start" alt="${character.name}">
      </div>
      <div class="col-md-8">
        <div class="card-body">
          <h5 class="card-title">${character.name}</h5>
          <ol class="list-group list-group-numbered">
            <li class="list-group-item d-flex justify-content-between align-items-start">
              <div class="ms-2 me-auto">
                <div class="fw-bold">Species</div>
                ${character.species}
              </div>
            </li>
            <li class="list-group-item d-flex justify-content-between align-items-start">
              <div class="ms-2 me-auto">
                <div class="fw-bold">House</div>
                ${character.house}
              </div>
            </li>
            <li class="list-group-item d-flex justify-content-between align-items-start">
              <div class="ms-2 me-auto">
                <div class="fw-bold">Date of Birth</div>
                ${character.dateOfBirth}
              </div>
            </li>
            <li class="list-group-item d-flex justify-content-between align-items-start">
              <div class="ms-2 me-auto">
                <div class="fw-bold">Gender</div>
                ${character.gender}
              </div>
            </li>
            <li class="list-group-item d-flex justify-content-between align-items-start">
              <div class="ms-2 me-auto">
                <div class="fw-bold">Ancestry</div>
                ${character.ancestry}
              </div>
            </li>
            <li class="list-group-item d-flex justify-content-between align-items-start">
              <div class="ms-2 me-auto">
                <div class="fw-bold">Patronus</div>
                ${character.patronus}
              </div>
            </li>
          </ol>
        </div>
      </div>
    </div>
                    `;

    let formbody = `
              <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Nome</label>
                <input id="input-coment" type="email" class="form-control" id="exampleFormControlInput1" required placeholder="Nome e Sobrenome">
              </div>
              <div class="mb-3">
                <label for="exampleFormControlTextarea1" class="form-label">Comentário</label>
                <textarea id="textarea-coment" class="form-control" id="exampleFormControlTextarea1" rows="3" required placeholder="Comentário, opinião ou observação sobre o site ou personagem."></textarea>
                <div class="d-grid gap-2">
                  <button onclick="comentarioBtn('${character.name}')" class="btn btn-outline-info mt-2" type="button">Enviar</button>
                </div>
              </div>
    `;

    card.innerHTML = cardBody;
    form.innerHTML = formbody;

    //let coment = 
    div.appendChild(card);
    div.appendChild(form);
    div.appendChild(mostraComentarios(`${character.name}`));

    main.append(div);
};



const criaCardFav = () =>{
    listFav = getJSONItem(LISTA_FAV);
    let div = percorreList(listFav);
    return div;
}

const favoritarCharac = (name, img, house) =>{
    let clicou = false;
    let btn = getId('btn-favorite');
    if(clicou == false){
        btn.setAttribute('src', '_img/heart-red.png');
        if(listFav == null){
            listFav = new Array();
        }
        //cria objeto para personagens favoritados
        personagem = {
            name: name,
            image: img,
            house: house
        };
        //add personagens favoritados na lista
        listFav.push(personagem);
        //add no localStorage
        setJSONItem(LISTA_FAV, listFav);
    }else{
        btn.setAttribute('src', '_img/heart.png');
        clicou = false;
    }
};



// obje = {
//     "name": "Minerva McGonagall",
//     "species": "human",
//     "gender": "female",
//     "house": "Gryffindor",
//     "dateOfBirth": "04-10-1925",
//     "ancestry": "",
//     "wand": {
//       "wood": "",
//       "core": "",
//       "length": null
//     },
//     "patronus": "tabby cat",
//     "hogwartsStudent": false,
//     "hogwartsStaff": true,
//     "image": "https://hp-api.herokuapp.com/images/mcgonagall.jpg"
//   };

 