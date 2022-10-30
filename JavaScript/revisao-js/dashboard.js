const listaContatos = [];
listaContatos.push({nome:'Yasmin', email: 'yasmin@gmail.com'}); //appendando na lista

const listarContatos = () =>{
    var listaHTML = $('#lista-contatos');

    listaContatos.forEach(c =>{ //pra cada objeto dentro da lista, chamado de c
        var linha = document.createElement('tr'); //criando tag tr
        var colNome = document.createElement('td'); //criando tag td
        var colEmail = document.createElement('td');

        $(colNome).html(c.nome); //colocando o valor de c.nome dentro da coluna
        $(colEmail).html(c.email);
        $(linha).append(colNome).append(colEmail); //por linha ser uma tag, entao usa append e nao push
        $(listaHTML).append(linha) //tbody recebe os valores dessa variavel
    })
}

$(document).ready(()=>{
    //por conta do dash.html já ter o script main.js
    //nao precisa criar dnv o verificaLogin
    if(!verificaLogin()){ // se não estiver logado
        window.location.href = 'index.html' //volta pro index
    }

    listarContatos();
});