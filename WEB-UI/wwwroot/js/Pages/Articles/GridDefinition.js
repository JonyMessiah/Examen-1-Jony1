const columnDefinitions = [
    { field: "title", headerName: "Article Title" },
    { field: "abstract", headerName: "Abstract" },
    { field: "publishedDate", headerName: "Published on" },
    { field: "authorInfo.firstName", headerName: "Author Name" },
    { field: "authorInfo.lastName", headerName: "Author Last Name" },
    { field: "authorInfo.charge", headerName: "Charge" }
];

const gridOptions = {
    columnDefs: columnDefinitions,
    rowData: [],
    rowSelection: 'single',

    //opciones
    defaultColDef: { sortable: true, filter: true },

    //EVENTOS
    onRowDoubleClicked: params => {
        ProcessRowDoubleClicked(params);
    }
};

function ProcessRowDoubleClicked(params) {
    var view = new ArticleList();
    view.showArticleDetails(params);
}

document.addEventListener('DOMContentLoaded', () => {
    const gridDiv = document.querySelector('#myGrid');
    new agGrid.Grid(gridDiv, gridOptions);
});