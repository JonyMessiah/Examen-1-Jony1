function ArticleList() {
    this.InitView = function () {
        //Asignar Eventos
        $('#btnSearch').click(function () {
            var view = new ArticleList();
            view.SearchArticles();
        });
        $('#btnNewArticle').click(function () {
            location.href = '/Articles/CreateArticle'
        });

        $('#btnSendEmail').click(function () {
            var articles = new ArticleList();
            articles.SubmitEmail();
        });
    }

    this.SubmitEmail = function () {
        //EMAIL
        var email = $('#txtEmail').val();
        var apiUrl = API_URL_BASE + "/api/Communications/SendEmail?emailAddress=" + email;

        //ENVIAR EL EMAIL

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: apiUrl,
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            hasContent: true
        }).done(function (data) {
            swal.fire({
                title: 'Mensaje',
                text: 'Gracias por contactarnos, nos pondremos en contacto!',
                icon: 'info'
            });
            //se Cierra el Modal
            $('#myModal').modal('toggle');
        }).fail(function (error) {
            swal.fire({
                title: 'Mensaje',
                text: 'Se presentó un error en el proceso, por favor contacte al administrador',
                icon: 'error'
            });
        });
    }

    this.SearchArticles = function () {
        //Acceder al API para traer los datos hacia nuestro Grid

        //Obtener la frase de busqueda que digitó el user
        //llamar al API y hacer el filtro basado en esa frase

        var searchPhrase = $('#txtSearch').val();
        var APIURL = API_URL_BASE + "/api/Article/GetArticlesBySearchPhrase?searchPhrase=" + searchPhrase;

        $.ajax({
            url: APIURL,
            method: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json"
        }).done(function (result) {
            console.log("Data que me llego a la funcion en el done");
            console.log(result);
            if (result.result === "OK")
                gridOptions.api.setRowData(result.data);
            else {
                Swal.fire({
                    icon: 'error',
                    title: 'Error de Ejecucion',
                    text: 'Hubo un error! ' + result.message
                })
            }
        }).fail(function (error) {
            console.log(error)
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Something went wrong! ' + error
            })
        });
    }

    this.showArticleDetails = function (params) {
        $('#articleTitle').html('<h3>' + params.data.title + '</h3>');

        $('#myModal').modal('toggle');
    }
}

$(document).ready(function () {
    var view = new ArticleList();
    view.InitView();
});