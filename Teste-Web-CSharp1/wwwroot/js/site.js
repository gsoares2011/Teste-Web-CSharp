$(document).ready(function () {
    
});

function ListPontosTurísticos()
{
    var div = document.getElementById("Load");
    var div1 = document.getElementById("Pontos");

    div.style.display = "none";
    div1.style.display = "inline";

    $.post("Home/ListarPontosTuristicos ", function (objPontos) {
        console.log(objPontos);

        var div = $('#Pages'); //Recupera a Div de paginação
        var div1 = $('#PagesContent');

        let paginas = Math.round((objPontos.length / 2));

        for (let i = 0; i < paginas; i++) {

            if (i == 0) {
                div.append('<li class="nav-item">' +
                    '<a class= "nav-link active" href = "#' + 'p' + (i + 1) + '" data-toggle="tab">' +
                    '<i class="material-icons">' + (i + 1) + '</i>' +
                    '</a>' +
                    '</li>');
                div1.append('<div class="tab-pane active" id="' + 'p' + (i + 1) + '">' +
                                    '<table id="tbPontos' + (i + 1) + '">' +
                                    '<tr>' +
                                        '<th>Nome</th>' +
                                        '<th>Cidade</th>' +
                                        '<th>Estado</th>' +
                                        '<th>Data de Inclusão</th>' +
                                        '<th>Mais Informações</th>' +
                                    '</tr>' +
                                '</table>' +
                            '</div>');
            } else {
                div.append('<li class="nav-item">' +
                    '<a class= "nav-link" href = "#' + 'p' + (i + 1) + '" data-toggle="tab">' +
                    '<i class="material-icons">' + (i + 1) + '</i>' +
                    '</a>' +
                    '</li>');
                div1.append('<div class="tab-pane" id="' + 'p' + (i + 1) + '">' +
                                    '<table id="tbPontos' + (i + 1) + '">' +
                                    '<tr>' +
                                        '<th>Nome</th>' +
                                        '<th>Cidade</th>' +
                                        '<th>Estado</th>' +
                                        '<th>Data de Inclusão</th>' +
                                        '<th>Mais Informações</th>' +
                                    '</tr>' +
                                '</table>' +
                            '</div>');
            }

            $("#txtFiltroPonto").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $("#tbPontos" + (i + 1) + " tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        }

        let i = 1;
        let j = 1;
        while ((i - 1) < objPontos.length) {

            var div2 = $('#tbPontos' + j); //Recupera a table para exibir os dados
            var div3 = $('#modalPontos'); //Recupera o modal para detalhar os Pontos Turísticos

            let data = new Date(Date.parse(objPontos[i - 1].data_Inclusao));
            let formatData = ((data.getDate())) + "/" + ((data.getMonth() + 1)) + "/" + data.getFullYear();

            div2.append(
                '<tr>' +
                    '<td>' + objPontos[i - 1].nome + '</td>' +
                    '<td>' + objPontos[i - 1].cidade + '</td>' +
                    '<td>' + objPontos[i - 1].estado + '</td>' +
                    '<td>' + formatData + '</td>' +
                '<td><button class="btn btn-info" type="button" id="btnDetalhes" data-toggle="modal" data-target="#modal' + objPontos[i - 1].id + '" href="#">+ Detalhes</button></td>' +
                '</tr>');

            div3.append(
                '<div class="modal fade" id="modal' + objPontos[i - 1].id + '" tabindex="-1" role="dialog" aria-labelledby="DetalhesPontosTuristicos" aria-hidden="true">' +
                '<div class="modal-dialog modal-dialog-centered">' +
                '<div class="modal-content">' +
                '<div class="modal-header">' +
                '<h4 class="modal-title id="DetalhesPontosTuristicos"">' + objPontos[i - 1].nome + '</h4>' +
                '<button type="button" class="close" data-dismiss="modal" aria-label="Close" title="Fechar">' +
                '<span aria-hidden="true">&times;</span>' +
                '</button>' +
                '</div >' +
                '<div class="modal-body">' +
                '<div class="form-group">' +
                '<a>Descriçao</a>' +
                '<textarea type="text" class="form-control" name="txtDescricaoPonto" rows="4" cols="50" readonly/>' +
                objPontos[i - 1].descricao +
                '</textarea>' +
                '</div>' +
                '<a>Endereço ou Referência</a>' +
                '<div class="form-group">' +
                '<input type="text" class="form-control" name="txtLocalizacaoPonto" value="' + objPontos[i - 1].localizacao + '" readonly/>' +
                '</div>' +
                '<a>Cidade</a>' +
                '<div class="form-group">' +
                '<input type="text" class="form-control" name="txtCidadePonto" value="' + objPontos[i - 1].cidade + '" readonly/>' +
                '</div>' +
                '<a>Estado</a>' +
                '<div class="form-group">' +
                '<input type="text" class="form-control" name="txtEstadoPonto" value="' + objPontos[i - 1].estado + '" readonly/>' +
                '</div>' +
                '</div>' +
                '<div class="modal-footer">' +
                '<button type="button" class="btn btn-dark" data-dismiss="modal">Fechar</button>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>');

            if (i % 2 == 0) {
                j++;
            }
            i++;
        }
    });
};
