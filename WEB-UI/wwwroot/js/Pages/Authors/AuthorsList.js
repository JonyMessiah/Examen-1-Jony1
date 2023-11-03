function AuthorsList() {
    this.InitView = function () {
        //Asignar Eventos
        $('#btnSearch').click(function () {
            var view = new AuthorsList();
            view.SearchAuthors();
        });
    }


    this.SearchAuthors = function () {
        //Acceder al API para traer los datos hacia nuestro Grid

        //Obtener la frase de busqueda que digitó el user
        //llamar al API y hacer el filtro basado en esa frase

        var searchName = $('#txtSearch').val();
        var APIURL = API_URL_BASE + "/api/Author/GetAuthorsByName?searchName=" + searchName;

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

    this.showAuthorsDetails = function (params) {
        $('#authorsName').html('<h3>' + params.data.title + '</h3>');

        $('#myModal').modal('toggle');
    }
}

$(document).ready(function () {
    var view = new AuthorsList();
    view.InitView();
});