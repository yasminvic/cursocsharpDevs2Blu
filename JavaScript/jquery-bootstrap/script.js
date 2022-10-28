$(document).ready((e)=>{ //assim que carregar a página
    console.log('#  JQuery loaded.')
    $('#nome').val('Ramon Lisboa'); //muda o valor do id #nome

    $('#btnSalvar').click((e)=>{ //quando clicar no botão salvar
        e.preventDefault(); // mantem os mesmos valores, não atualiza a página
        var nome = $('#nome');
        var email = $('#email')
        console.log(`Nome: ${$('#nome').val()}`); // printar o valor do id #nome

        console.log(nome.val());
        console.log(email.val());
        if(nome.val() === "" ||
            email.val() === ""){
            $('#form').css({
                'border': '2px solid red'
            });
            console.log('false')
        }else{
            $('#form').css({
                'border': '2px solid green'
            });
            $('#nome-quadro').html(nome.val());
            $('#email-quadro').html(email.val());
            $('#quadro').show();
        }
    });

    $('#email').on('change', (e)=>{ //ao houver uma mudança no id #email
        // e.target == $(this)
        // console.log($(this).val());
        var email = e.target.value; // pega o valor do id #email
        console.log(email); // printa o email
        var valid = String(email) //verifica se o email é válido (regex)
            .toLowerCase()
            .match(
            /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
            );

            if(valid){ //se for válido printa isso
                console.log('Email válido');
                $('#email').css({
                    'background-color':'#ccc'
                });
                $('#nome').css({
                    'background-color':'#ccc'
                });
            } else { // se não printa isso
                console.log('Email inválido');
                e.target.focus();  
                $('#email').css({
                    'outline':'1px solid red'
                });       
            }
    });

    $('#quadro').on('mouseover', (e)=>{
        $('#quadro').addClass('animacao-quadro')
    })
    $('#quadro').on('mouseleave', (e)=>{
        $('#quadro').removeClass('animacao-quadro')
    })
});