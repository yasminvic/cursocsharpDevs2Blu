// var = variavel global
//let = variavel local

//variaveis
const URL_VIACEP = "https://viacep.com.br/ws/@CEP/json/";

//chamada de arrow function
addEventListener('load', (e)=>{ //add event ao carregar a página
    console.log('Sistema carregado...');
    $('#bloco').style.display =  'none'; //display none para o id bloco

    //Registra evento CEP
    $('#cep').addEventListener('blur', (e)=>{ //quando o cep perde o focus
        var valorCampo = e.target.value;
        console.log(`O valor digitado foi '${valorCampo}'`)

        if(valorCampo.length >=8){
            $('#endereco').style.display = 'block';
            var urlcep = URL_VIACEP.replace('@CEP', valorCampo);

            getJson(urlcep).then((resp) =>{
                console.log(resp);
                //esse $ é nome da função lá embaixo
                $('#rua').value = resp.logradouro;
                $('#bairro').value = resp.bairro;
                $('#cidade').value = resp.localidade;
                $('#uf').value = resp.uf;
                e.target.value = resp.cep;
                $('#numero').focus(); //colocando focus no numero
            });
        }
    })

    $('#btn-salvar').addEventListener('click', (e) =>{
        console.log('click');
    });
});

const validaFormulario = () =>{
    if ($('#nome').value === ''){
        return false;
    }
};

//pega a url e transforma em resposta, que depois vai ser transformada em tipo json
//faz requisição pro servior atraves do fetch, e espera ele responder
function getJson(url){
    return fetch(url).then((resposta) => resposta.json()); //resposta e url são parametros
}

function $(querySelector){
    //retorna isso pra economizar tempo lá em cima
    return document.querySelector(querySelector);
}

// --- Introdução ---
// console.log('Script loaded.');
// var nome, idade;

// // nome = prompt("Informe seu nome");
// // console.log(`Nome: ${nome}`);

// // idade = prompt('Informe sua idade')
// // console.log(`Idade: ${idade}`);
// // alert('Olá Mundo');

// var bloco = document.getElementById('bloco'); 

// bloco.addEventListener('mouseover',function(e){ //add evento quando mouse estiver por cima
//     bloco.style.marginLeft = '5em';
//     bloco.style.backgroundColor = 'red';
// });

// bloco.addEventListener('mouseout',function(e){ //add evento quando mouse estiver fora
//     bloco.style.marginLeft = '0';
//     bloco.style.backgroundColor = 'blueviolet';
// });

// var textoBloco = document.querySelector('#bloco span');

// textoBloco.style.color = '#fff';

