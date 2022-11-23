//Local Storage

const KEY_LIST_PKMN = 'LISTA_POKEMON';
const KEY_LIST_FAVORITO = 'POKEMON_FAVORITO';
const KEY_MEUS_POKEMONS = 'MEUS_POKEMONS';

const stg = {
    set: (key, value) => localStorage.setItem(key,value), //pode simplificar assim
    get: (key) =>{
        return localStorage.getItem(key);
    },
    setJson: (key, value) =>{
        //value é um objeto json
        let objStr = JSON.stringify(value);
        localStorage.setItem(key, objStr);

    },
    getJson: (key) =>{
        //retornar um json
        return JSON.parse(localStorage.getItem(key));
    },
    del: (key) =>{
        localStorage.removeItem(key);
    }
};

//Services API
const URL_API_PKMN = 'https://pokeapi.co/api/v2/pokemon/';

const getAPI = (url, fnCallBack) => {
    return $.ajax({
        url: url,
        dataType: 'json',
        success: (data) => fnCallBack(data)
    });
};

const getInfosAPIPromise = async (url) =>{
    return fetch(url)
                    .then(resp => resp.json()); //retorna json
}