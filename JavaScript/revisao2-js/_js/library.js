//Confs
const URL_API_CHARACTER = 'https://rickandmortyapi.com/api/character/';

//Functions
function getElement(q){
    return document.querySelector(q); //é o $ do jquery, só pra pegar qualquer elemento
}

const getAPI = (url, functionCallback) =>{ //pega a url e depois executa essa function call back
    //vai retornar json
    //.json é uma função
    //fetch faz uma requisão na api
    //o primeiro then pega o retorno e transformar em json
    //o segundo pega o retorno e usa ele como parametro para outra função
    fetch(url).then(
                    (response) => response.json(), //retorno deu certo
                    (error) => console.error(error) //requisão foi rejeitada
                    ).then(
                            dataJson => functionCallback(dataJson), //retorno deu certo
                            erro => console.error(erro) //requisão rejeitada
                            );
}

//Services



//Explicação Promisse
/*
Faz uma requisação GET, a promisse
Se funcionar, o servidor vai retornar uma função call back
Se não, ele retorna a promisse rejeitada


*/