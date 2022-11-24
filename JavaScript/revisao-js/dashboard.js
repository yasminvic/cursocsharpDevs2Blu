const delay = (ms) => new Promise(resp => setTimeout(resp, ms));
const LISTA_CONTATOS = 'lista_contatos';
var listaContatos = new Array();

$(document).ready(()=>{
    $('#msg .alert').hide();
    //por conta do dash.html já ter o script main.js
    //nao precisa criar dnv o verificaLogin
    if(!verificaLogin()){ // se não estiver logado
        window.location.href = 'index.html'; //volta pro index
    };

    $('#btn-salvar').click((e)=>salvarContato());
    listarContatos();

    $('tr').click((e) =>{
        console.log(e.target.node.parentElement);
        var tdId = tr.find('td')[0];
        console.log(tdId);
    })
});


const salvarContato = () =>{
    let nome = $('#nome');
    let email = $('#email');
    let tamLista = (listaContatos == null) ? 0 : listaContatos.length;
    let idInsert = tamLista + 1;
    let msg = "Por favor, preencher todos os campos...";

    if(listaContatos == null){
        listaContatos = new Array();
    }

    if(nome.val() === "" || email.val() === ""){
        $('#msg .alert').html(`<h6>${msg}</h6>`); //vai aparecer essa mensagem
        $('.toast-body').html(msg);
        $('#msg .alert').fadeIn('slow', async ()=>{
            await delay(3000);
            $('#msg .alert').fadeOut('slow');
        });
        const toastLive = document.getElementById('livetoast');
        const toast = new bootstrap.Toast(toastLive);
        toast.show();
        return;
    }

    let contato = { id: idInsert,
                    nome: nome.val(), 
                    email: email.val()};

    listaContatos.push(contato);
    setJsonItem(LISTA_CONTATOS, listaContatos);
    listarContatos();

    nome.val("");
    email.val("");
}

//FUNCTIONS


const listarContatos = () =>{
    var listaHTML = $('#lista-contatos');
    listaHTML.html(""); //limpar lista
    listaContatos = new Array();
    listaContatos = getJsonItem(LISTA_CONTATOS);

    if(listaContatos == null || listaContatos.length <= 0) {
        return;
    }
    listaContatos.forEach(c =>{ //pra cada objeto dentro da lista, chamado de c
        var linha = document.createElement('tr'); //criando tag tr
        var colId = document.createElement('td');
        var colNome = document.createElement('td'); //criando tag td
        var colEmail = document.createElement('td');

        var colActions = document.createElement("td");
        colActions.html(`<div class="d-flex">
                                <button onclick="removeItemList(${c.id})" class="btn btn-sm btn-danger">&times;</button>
                            </div>`);

        $(colId).html(c.id);
        $(colNome).html(c.nome); //colocando o valor de c.nome dentro da coluna
        $(colEmail).html(c.email);
        $(linha).append(colId)
                .append(colNome)
                .append(colEmail) //por linha ser uma tag, entao usa append e nao push
                .append(colActions);
                $(listaHTML).append(linha); //tbody recebe os valores dessa variavel
    });
};

const removeItemList = (id) =>{
    var i = listaContatos.findIndex((c) => c.id === id);
    listaContatos.splice(i, 1);//apagando UM elemento i de acordo com index
    
    setJsonItem(LISTA_CONTATOS, listaContatos);
    listaContatos();
}