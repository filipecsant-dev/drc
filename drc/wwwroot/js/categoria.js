$(document).ready(function () {

    $(".visu").on("click", function () {
        var id = $(this).attr("data-id");
        var root = window.location.href;
        var url = root + '/Visualizar/' + id;

        $.ajax({
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            url: url,
            success: (e) => {
                $("#Prod_Nome").html(e.nome);
                $("#Prod_Descricao").html(e.descricao);
                $("#Prod_Data_Cadastro").html(formatarData(e.data_Cadastro));
                $("#Prod_Data_Alteracao").html(formatarData(e.data_Alteracao));

                if (e.status == true) $("#Prod_Status").html("Ativo");
                else $("#Prod_Status").html("Desativado");



                $("#page1").hide(500);
                $("#page2").show(1000);
            },
            error: (e) => {
                console.log('error');
            }
        });
    });

    $("#voltar").on("click", function () {
        $("#page2").hide(500);
        $("#page1").show(1000);
    });


    $(".excluir").click(function () {
        var id = $(this).attr("data-id");
        var root = window.location.href;
        var url = root + '/Excluir/' + id;

        swal({
            title: "Atenção!",
            text: "Tem certeza que deseja excluir esse produto ?",
            icon: "warning",
            buttons: true,
        }).then(function (result) {
            if (result) {

                $.ajax({
                    type: 'POST',
                    contentType: 'application/json',
                    dataType: 'json',
                    url: url,
                    complete: (e) => {
                        location.reload();
                    }
                });

            } else {
                return;
            }
        });
    });

    $("Body").on("submit", 'form[name="Cadastro"]', function () {

        var form = $(this);
        var btn = form.find(':button');
        var url = window.location.href;

        if (verifica()) {

            btn.attr('disabled', true);

            $.post(url, form.serialize()).done(function (data) {
                if (data == true) {
                    swal({
                        title: "Sucesso!",
                        text: "Cadastrado com sucesso!",
                        icon: "warning"
                    }).then((result) => {
                        location.reload();
                    });
                } else {
                    swal({
                        title: "Erro",
                        text: "Oops, ocorreu um erro ao cadastrar.",
                        icon: "warning"
                    });
                    console.log(data);
                }

                btn.attr('disabled', false);
            });
        }


        return false;
    });

    $("Body").on("submit", 'form[name="Editar"]', function () {

        var form = $(this);
        var btn = form.find(':button');
        var root = window.location.href;
        var separa = root.split('/', 5);
        var url = separa[0] + "//" + separa[2] + '/' + separa[3] + '/' + separa[4];

        if (verifica()) {

            btn.attr('disabled', true);

            $.post(url, form.serialize()).done(function (data) {
                if (data == true) {
                    swal({
                        title: "Sucesso!",
                        text: "Alterado com sucesso!",
                        icon: "warning"
                    });
                } else {
                    swal({
                        title: "Erro",
                        text: "Oops, ocorreu um erro ao alterar.",
                        icon: "warning"
                    });
                    console.log(data);
                }

                btn.attr('disabled', false);
            });

            return false;
        }


        return false;
    });

    function verifica() {

        if ($("#Nome").val().length < 5) {
            alert('Nome curto.');
            return false;
        }

        if ($("#Nome").val().length > 50) {
            alert('Nome longo.');
            return false;
        }

        if ($("#Descricao").val().length < 5) {
            alert('Descrição curta');
            return false;
        }

        if ($("#Descricao").val().length > 50) {
            alert('Descrição longa.');
            return false;
        }

        return true;
    }



    function formatarData(date) {
        var data = date.substring(0, 10),
            dia = data.substring(8, 10),
            mes = data.substring(5, 7),
            ano = data.substring(0, 4);
        return dia + "/" + mes + "/" + ano;
    }

    function mascaraMoeda(v) {
        v = new String(v);
        var len = v.length;
        if (len > 6) {
            var x = len - 6
                , er = new RegExp('(\\d{' + x + '})(\\d)');
            v = v.replace(er, '$1.$2');
        }
        return v;
    }

});
