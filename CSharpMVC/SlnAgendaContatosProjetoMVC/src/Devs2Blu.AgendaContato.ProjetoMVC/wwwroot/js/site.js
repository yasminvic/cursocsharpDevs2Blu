$(document).ready(() => {

    $('input[name="cep"]').change(() => {

        let cep = $('input[name="cep"]').val();
        if (cep.length == 8) {
            $.get(`https://viacep.com.br/ws/${cep}/json/`, (response) => {
                if (response.erro == true) {
                    alert("CEP inválido ! Tente novamente.");
                    return;
                }

                $('input[name="cep"]').val(response.cep);
                $('input[name="rua"]').val(response.logradouro);
                $('input[name="bairro"]').val(response.bairro);
                $('input[name="cidade"]').val(response.localidade);
                $('input[name="uf"]').val(response.uf);
            });
        }
        else if (cep.length > 8) {
            alert("CEP inválido ! Tente novamente.");
        }
        else {
            alert("CEP inválido ! Tente novamente.");
        }
    });

});
