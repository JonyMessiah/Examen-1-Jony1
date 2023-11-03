function CreateArticle() {
    //Init view nos va a permitir inicializar funciones y eventos

    this.InitView = function () {
        $('#btnCreate').click(function () {
            //Llamar el metodo que ejecuta ese click del boton
            var view = new CreateArticle();
            view.SubmitArticleToCreate();
        });

        this.PopulateAuthors();
    }

    this.SubmitArticleToCreate = function () {
        //articulo
        var article = {};
        article.title = $('#txtTitle').val();
        article.abstract = $('#txtAbstract').val();
        article.publishedDate = $('#txtDate').val();
        article.isbn = "123";

        //author
        article.authorInfo = {};
        article.authorInfo.id = $('#authorName').find(":selected").val();


        //AUTHOR_LIST Esta declarada en el file site.js para poder utilizarla globalmente si se necesita
        var author = AUTHOR_LIST.find(au => {
            return au.id === parseInt($('#authorName').val());
        });

        article.authorInfo.firstName = author.firstName;
        article.authorInfo.lastName = author.lastName;
        article.authorInfo.charge = author.charge;

        //llamar al API para crear el articulo
        console.log("article", article);

        var apiUrl = API_URL_BASE + "/api/Article/CreateArticle";

        //Enviar los datos al API para que cree el Articulo
        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type':"application/json"
            },
            method: "POST",
            url: apiUrl,
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            data: JSON.stringify(article),
            hasContent: true
        }).done(function (data) {
            Swal.fire({
                title: "Success",
                icon: 'info',
                text: 'The Article was created succesfully'
            });
        }).fail(function (error) {
            Swal.fire({
                title: "Message",
                icon: 'error',
                text: 'There was an error creating the Article'
            });
        });
    }

    this.PopulateAuthors = function () {
        var apiUrl = API_URL_BASE + "/api/Author/GetAllRegisteredAuthors";

        $.ajax({
            url: apiUrl,
            method: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json"
        }).done(function (data) {
            //Guardar la lista y popular el dropdown
            //AUTHOR_LIST Esta declarada en el file site.js para poder utilizarla globalmente si se necesita
            AUTHOR_LIST = data;

            var select = $('#authorName');
            select.find('option').remove();

            for (var row in data) {
                select.append('<option value=' + data[row].id + '>' + data[row].firstName + ' ' + data[row].lastName + '</option>')
            }
        }).fail(function (error) {
            alert('ERROR!!');
        });
    }
}

$(document).ready(function () {
    var view = new CreateArticle();
    view.InitView();
});
