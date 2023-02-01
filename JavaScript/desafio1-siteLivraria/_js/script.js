var romance = document.getElementById('romance');
var terror = document.getElementById('terror');
var culinaria = document.getElementById('culinaria');
var scifi = document.getElementById('sci-fi');


romance.addEventListener('click', function(e){
    document.getElementById('img1').src="https://cdn.pensador.com/img/imagens/19/ac/19_a_culpa_e_das_estrelas_c.jpg?auto_optimize=low";
    document.getElementById('nome1').innerHTML = 'A Culpa é das Estrelas';
    
    document.getElementById('img2').src="https://cdn.culturagenial.com/imagens/ps-eu-te-amo-livro-cke.jpg?auto_optimize=low";
    document.getElementById('nome2').innerHTML = 'PS.: Eu Te Amo';

    document.getElementById('img3').src="https://muraldoslivros.com/wp-content/uploads/2021/04/a-selecao-livro-amazon-1-1.jpg";
    document.getElementById('nome3').innerHTML = 'A Seleção';

    document.getElementById('img4').src="https://i0.wp.com/wp.ufpel.edu.br/artenosul/files/2022/06/capa-original.jpg?resize=333%2C500&ssl=1";
    document.getElementById('nome4').innerHTML = 'A Hipótese do Amor';
});

terror.addEventListener('click', function(e){
    document.getElementById('img1').src="https://images-na.ssl-images-amazon.com/images/I/91g9Dvtf+jL._AC._SR360,460.jpg";
    document.getElementById('nome1').innerHTML = 'IT: A Coisa';

    document.getElementById('img2').src="https://global.cdn.magazord.com.br/blulivro/img/2022/09/produto/62918/atras-de-voce.jpg?ims=fit-in/450x450/filters:fill(fff)";
    document.getElementById('nome2').innerHTML = 'Estou Atras de Você';

    document.getElementById('img3').src="https://global.cdn.magazord.com.br/blulivro/img/2022/07/produto/20490/115157-28296.jpg?ims=fit-in/450x450/filters:fill(fff)";
    document.getElementById('nome3').innerHTML = 'Love';

    document.getElementById('img4').src="https://global.cdn.magazord.com.br/blulivro/img/2022/07/produto/14838/80017-6239.jpg?ims=fit-in/450x450/filters:fill(fff)";
    document.getElementById('nome4').innerHTML = 'A Zona Morta';
});

culinaria.addEventListener('click', function(e){
    document.getElementById('img1').src="https://m.media-amazon.com/images/I/51rf+kqLPZL.jpg";
    document.getElementById('nome1').innerHTML = 'Todas as Técnica Culinárias';

    document.getElementById('img2').src="https://a-static.mlcdn.com.br/1500x1500/livro-culinaria-ayurvedica-para-o-seu-dia-a-dia/cliquebooks/436666-1/2d7bdc2f3faa5c5d91e0c115a1c241f3.jpg";
    document.getElementById('nome2').innerHTML = 'Culinária Ayurvédica';

    document.getElementById('img3').src="https://images-americanas.b2w.io/produtos/01/00/item/120341/0/120341045_1GG.jpg";
    document.getElementById('nome3').innerHTML = 'Culinária Funcional';

    document.getElementById('img4').src="https://www.satua.com.br/image/cache/catalog/_Coletivo/gosto-superior01-900x1050.jpg";
    document.getElementById('nome4').innerHTML = 'Gosto Superior';
});

scifi.addEventListener('click', function(e){
    document.getElementById('img1').src="https://m.media-amazon.com/images/I/41LjwBnjt1L.jpg";
    document.getElementById('nome1').innerHTML = 'Mundos Fantásticos';

    document.getElementById('img2').src="https://m.media-amazon.com/images/I/41-Tvsgjg-L.jpg";
    document.getElementById('nome2').innerHTML = 'Dimensão Sci-Fi';

    document.getElementById('img3').src="https://nerdlicious.com.br/wp-content/uploads/2022/06/livro-subterraneo-sci-fi-brasileiro.jpg";
    document.getElementById('nome3').innerHTML = 'Subterrâneo Revelação';

    document.getElementById('img4').src="https://scifi.blogfolha.uol.com.br/files/2019/01/parable-of-the-talents.jpg";
    document.getElementById('nome4').innerHTML = 'Parable of The Talents';
});



// --- Fazer uma função ---
// function mudaConteudo(src1, n1, src2, n2, src3, n3, src4, n4){
//     document.getElementById('img1').src= src1;
//     document.getElementById('nome1').innerHTML = n1;

//     document.getElementById('img2').src= src2;
//     document.getElementById('nome2').innerHTML = n2;

//     document.getElementById('img3').src= src3;
//     document.getElementById('nome3').innerHTML = n3;

//     document.getElementById('img4').src= src4;
//     document.getElementById('nome4').innerHTML = n4;
// }

function $(querySelector){
    return document.querySelector(querySelector);
}

