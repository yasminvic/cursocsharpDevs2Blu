const usuario = {
    nome: '',
    login: '',
    senha: ''
}

const LOGADO = 'userLogado';
const USER = 'user';

$(document).ready(() =>{
    console.log('JQuery loaded.')

    verificaLogin();

});









//Funcions

const getPagina = (page, target) =>{ //target é o local onde quer colocar
    $.ajax({
        url: page,
        datatype: 'html',
        success: (pResponse) =>{
            $(target).html(pResponse);
        }
    });
}

const realizaLogin = (user) =>{
    //localStorage é tipo um banco de dados do navegador
    localStorage.setItem(LOGADO, 'true'); //passar um valor pra variavel 
        //settar algo   //variavel  //valor a ser passado pra variavel
        //na parte Apliccation, essa variavel é chamada de key
        //e o valor de value
        //se carregar a página ainda fica salvo
    localStorage.setItem(USER, JSON.stringify(user));
    window.location.href = 'dashboard.html'; //redireciona para outra página
}

const realizaLogoff = (user) =>{
    localStorage.removeItem(LOGADO);
    localStorage.removeItem(USER);
}

const verificaLogin = ()=>{
    if(localStorage.getItem(LOGADO) == 'true'){
        console.log('Logado');
        return true;
    }else{
        console.log("Deslogado");
        return false;
    }
}

const getRegistroStorage = (key) =>{
    return localStorage.getItem(key); //retornar informações jason
}

const insertRegistroStorage = (key, value) =>{
    if (typeof value == usuario){
        localStorage.setItem(key, JSON.stringify(value)); // ????
    }
}