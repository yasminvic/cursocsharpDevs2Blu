$(document).ready(()=>{
    console.log('JQuery is loaded.');

    //Inicializa parametros do sistema
    init();
    
       
    
});

const init = () => {
    // Carregar Views
    getView('home', '#root');

    //Carregar Eventos
    initializeEvents();

    // Carregar Servicos
    initializeServices();
};

const initializeServices = () =>{
    //Carregar / armazenar Pokemons no localStorage
    atualizarListaPKMNStorage();

    // * Destaques
    fillDestaques();


}

const initializeEvents = () =>{
    // # Meus Pokemons
    $('#pag-meus-pokemons').click(()=>getView('meus-pokemons','#root'));

    // Botao Pesquisar
    $('#btn-pesquisa').click((e)=>{
        e.preventDefault();
        let valorPesquisa = $('#input-pesquisa').val();
        //realizar pesquisa
    });
};

