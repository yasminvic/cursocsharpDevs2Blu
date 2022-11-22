const comentarioBtn = (nome_character) =>{
    if(listCom == null){
        listCom = new Array();
    }
    //pegando os valore do form
    let nome = $('#input-coment'); 
    let desc = $('#textarea-coment');

    //criando objeto para o comentario
    let comentario ={
      nome: nome.val(),
      desc: desc.val(),
      nomecharacter: nome_character //pegando nome do personagem pra poder mostrar só comentários de tal personagem
    };
  
    //add na lista
    listCom.push(comentario);
  
    //add no localstorage
    setJSONItem(LISTA_COM, listCom);

    alert('Comentário postado com sucesso !');
    nome.val() = '';
    desc.val() = '';
};

const mostraComentarios = (nome_character) =>{
    let div = document.createElement('div');

    //pega os comentarios da localstorage
    listCom = getJSONItem(LISTA_COM);

    listCom.forEach((comentario) => {
        //se o comentario for sobre o personagem que na pag estamos, entao mostra esse comentario
        if (comentario.nomecharacter == nome_character){
            let divCom = document.createElement('div');

            let divBody = `
                            <div id="header-div">
                                <h1>${comentario.nome}</h1>
                            </div>
                            <div id="body-div">
                                <p>${comentario.desc}</p>
                            </div>
            `;

            divCom.innerHTML = divBody;

            div.appendChild(divCom);

        }
    });

    //retorna div com todos os comentarios de tal personagem
    return div;
}
  