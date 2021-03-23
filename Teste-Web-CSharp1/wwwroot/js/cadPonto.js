$(document).ready(function () {
    var combo = document.getElementById('cbCadEstados'); //Recupera o elemento select da página    

    //API do IBGE que retorna todos os Estados do Brasil.
    $.getJSON("https://servicodados.ibge.gov.br/api/v1/localidades/estados?orderBy=nome", function (data) {

        console.log(data);

        //Para cada estado retornado pela API, cria-se o elemento option com o valor = estado.id, com nome = estado.nome e com sigla = estado.sigla
        for (let i = 0; i < data.length; i++) {
            var option = document.createElement('option');
            option.appendChild(document.createTextNode(data[i].nome));
            option.appendChild(document.createTextNode(' ' + '-' + ' '));
            option.appendChild(document.createTextNode(data[i].sigla));
            option.value = data[i].id;
            combo.appendChild(option);
        }
    });
});

function PreencheCidades() {

    var idEstado = $('#cbCadEstados').children("option:selected").val();

    var select = document.getElementById("cbCadCidades");
    var length = select.options.length;
    for (i = length - 1; i > 0; i--) {
        select.options[i] = null;
    }

    if (idEstado != 0) {

        //API do IBGE que retorna todos as Cidades com base no parâmetro do Estado.
        $.getJSON("https://servicodados.ibge.gov.br/api/v1/localidades/estados/" + idEstado + "/distritos", function (result) {

            console.log(result);

            var combo = document.getElementById('cbCadCidades'); //Recupera o elemento select da página 

            //Para cada estado retornado pela API, cria-se o elemento option com o valor = cidade.id e com nome = cidade.nome
            for (let i = 0; i < result.length; i++) {
                var option = document.createElement('option');
                option.appendChild(document.createTextNode(result[i].nome));
                option.value = result[i].id;
                combo.appendChild(option);
            }
        });
    }
};

//Método responsável por verificar a integridade do nome do ponto turístico
function verificarNome() {
    //Busca o elemento da página
    var input = document.getElementById("txtPontoNome");

    console.log(input.value.length)

    //Se não tiver o tamanho especificado, altera a cor do campo para vermelho, caso contrário, altera para a cor padrão
    input.value.length <= 2 || input.value.length >= 21 ? (input.style.borderColor = "red", $('#txtPontoNome').tooltip('enable'), document.getElementById('btnCadastrar').disabled = true) : (input.style.borderColor = "#e2e2e2", $('#txtPontoNome').tooltip('disable'), document.getElementById('btnCadastrar').disabled = false);

};

//Método responsável por verificar a integridade da descrição do ponto turístico
function verificarDescricao() {
    //Busca o elemento da página
    var input = document.getElementById("txtDescricaoPonto");

    console.log(input.value.length)

    //Se não tiver o tamanho especificado, altera a cor do campo para vermelho, caso contrário, altera para a cor padrão
    input.value.length <= 4 || input.value.length >= 101 ? (input.style.borderColor = "red", $('#txtDescricaoPonto').tooltip('enable'), document.getElementById('btnCadastrar').disabled = true) : (input.style.borderColor = "#e2e2e2", $('#txtDescricaoPonto').tooltip('disable'), document.getElementById('btnCadastrar').disabled = false);

};

//Método responsável por verificar a integridade da descrição do ponto turístico
function verificarEndereco() {
    //Busca o elemento da página
    var input = document.getElementById("txtLocalizacaoPonto");

    console.log(input.value.length)

    //Se não tiver o tamanho especificado, altera a cor do campo para vermelho, caso contrário, altera para a cor padrão
    input.value.length <= 4 || input.value.length >= 61 ? (input.style.borderColor = "red", $('#txtLocalizacaoPonto').tooltip('enable'), document.getElementById('btnCadastrar').disabled = true) : (input.style.borderColor = "#e2e2e2", $('#txtLocalizacaoPonto').tooltip('disable'), document.getElementById('btnCadastrar').disabled = false);

};

//Verifica o formulário de cadastro por inteiro
function verificarFormularioCadastro() {
    //Verifica novamente todos os campos por segurança
    verificarNome(); verificarDescricao(); verificarEndereco();

    //Se todos os campos estiverem corretos permite o submit do formulário    
    if ($('#cbCadEstados').children("option:selected").val() != "" && $('#cbCadCidades').children("option:selected").val() != "") {
        //Realiza a requisição na controle
        $.ajax({
            type: 'post', //Tipo de acesso
            url: "CadastrarPontoTuristico", //Endereço da controle
            data: { //Dados a serem passados
                txtNome: $('#txtPontoNome').val().trim(),
                txtDescricao: $('#txtDescricaoPonto').val().trim(),
                txtEnderdeco: $('#txtLocalizacaoPonto').val().trim(),
                cbEstado: $('#cbCadEstados').children("option:selected").text(),
                cbCidade: $('#cbCadCidades').children("option:selected").text()
            },
            dataType: "text", //Tipo de dado
            success: function (resultData) //Se o post na controle der certo
            {
                $('#alertaSucesso').html(''); //Limpa o conteúdo do alerta
                //Cria um alerta com a mensagem da controladora e apresenta-o
                var alert = document.getElementById("alertaSucesso");
                var content = document.createTextNode(resultData);
                alert.appendChild(content);
                $('#alertaSucesso').show();
                $('#frmCadastroPontosTuristicos')[0].reset();
                PreencheCidades();
            }
        });
    }
    else {
        //Apresenta um alerta de erro ao usuário
        $('#alertaErro').show();
        $('#alertaSucesso').hide();
    }
}