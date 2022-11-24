//Functions de apoio

var listaPokemons = new Array();

const fillDestaques = () => {
    let data = stg.getJson(KEY_LIST_PKMN);
    data.forEach((p,i) => {
        //controla quantos pokemons estamos pegando
        if(i > 3)
            return;


        let item = `<div class="col-3"> 
        <div class="card">
        <div class="card-header bg-danger">
            <img src="${p.img}"
        </div>
        <div class="card-body">
        <h3 class="text-white" >${p.name}</h3>
        </div>
    </div></div>`;
        $('#destaque').append(item);
    });
};

const getView = (viewName, target) => {
    let ajaxConfig = {
        url: `_views/${viewName}.html`,
        dataType: 'html',
        success: (response) => {
            $(target).html(response);
        }
    };

    $.ajax(ajaxConfig);
};

//armezenando todos os pokemons na localStorage
const atualizarListaPKMNStorage = (force=false) =>{
    if(!VerificarAtualizacaoLista() && !force){
        return;
    }
    //zera a lista
    listaPokemons = new Array();

    //conexão com a API
    getAPI(URL_API_PKMN, async (data) =>{ //data é oq a API retorna
        data.results.forEach((p) => { //é uma função assicrona
            //criando objeto do pokemons

            //a função getInfos... vai retorna uma promisse, com os dados dos da API, com o objeto pokemon
            //esse await significa que ele vai travar o código, parar tudo oq está acontecendo 
            //até que seje retornado algo
            //dps ele continua normal o fluxo
            getInfosAPIPromise(p.url).then(objPokemon =>{
                let pkmn = {
                    id: objPokemon.id,
                    name: objPokemon.name,
                    url: p.url, //poderia usar aqui objePokemon.url mas nao quisemon
                    img: objPokemon.sprites.front_default
                };
                //appendando na lista os pokemons
                listaPokemons.push(pkmn);
                //atualiza lista no localStorage
                stg.setJson(KEY_LIST_PKMN, listaPokemons);
            });
            
            
        }); 
        
        
    });
};

const VerificarAtualizacaoLista = () =>{
    //pra nao ficar criando a mesma lista várias vezes

    let listaPkmn = stg.getJson(KEY_LIST_PKMN);

    if(listaPkmn && listaPkmn.lenght > 0){
        return true;
    }else{
        return false;
    }
}
