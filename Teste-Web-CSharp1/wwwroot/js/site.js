$(document).ready(function () {

});

function montaTabela(data, columns) {

    var table = $('#root').tableSortable({
        data: data,
        columns: columns,
        searchField: '#searchField',
        responsive: {
            1100: {
                columns: {
                    nome: 'Nome',
                    localizacao: 'Localização ou Referência',
                    cidade: 'Cidade',
                    estado: 'Estado',
                    id: 'Mais Informações',
                },
            },
        },
        rowsPerPage: 5,
        pagination: true,
        onPaginationChange: function (nextPage, setPage) {
            setPage(nextPage);
        },
        formatCell: function (row, key) {
            if (key === 'id') {
                return $('<button data-toggle="modal" data-target="#modal' + row[key] + '" href="#"></button>').addClass('btn btn-info').text("+ Detalhes");
            }
            return row[key];
        }
    });

    $('#changeRows').on('change', function () {
        table.updateRowsPerPage(parseInt($(this).val(), 10));
    })

    $('#rerender').click(function () {
        table.refresh(true);
    })

    $('#distory').click(function () {
        table.distroy();
    })

    $('#refresh').click(function () {
        table.refresh();
    })

    $('#setPage2').click(function () {
        table.setPage(1);
    })
}

function ListPontosTuristicos() {
    var div = document.getElementById("Load");
    var div1 = document.getElementById("Pontos");

    div.style.display = "none";
    div1.style.display = "inline";

    $.get("/pontosTuristicos", function (objPontos) {

        let i = 1;
        while ((i - 1) < objPontos.length) {

            var div3 = $('#modalPontos'); //Recupera o modal para detalhar os Pontos Turísticos


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

            i++;
        }

        var data = objPontos;

        var columns = {
            nome: 'Nome',
            localizacao: 'Localização ou Referência',
            cidade: 'Cidade',
            estado: 'Estado',
            id: 'Mais Informações',
        }

        montaTabela(data, columns);

    });
}


