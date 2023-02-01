//Confs
const URL_CHARACTERS = 'https://hp-api.herokuapp.com/api/characters/';
const URL_ALUNO = 'https://hp-api.herokuapp.com/api/characters/students';
const URL_FUNC = 'https://hp-api.herokuapp.com/api/characters/staff';

//keys do localstorage
const LISTA_FAV = 'lista_favoritos';
const LISTA_COM = 'lista_comentario';

//realiza comunicação com a API
const comunAPI = (url, functionCallBack, title) =>{
    fetch(url).then(
                    (response) => response.json(), 
                    (error) => console.log(error)
                ).then(
                        (dataJson) => functionCallBack(dataJson, title),
                        (error) => console.log(error));
};

const getId = (id) => {
    return document.getElementById(id);
}

const getClass = (classe) => {
    return document.getElementsByClassName(classe);
}