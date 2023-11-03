const columnDefinitions = [
    { field: "firstName", headerName: "First name" },
    { field: "lastName", headerName: "Last Name" },
    { field: "charge", headerName: "Charge" }
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
    var view = new AuthorsList();
    view.showAuthorsDetails(params);
}

document.addEventListener('DOMContentLoaded', () => {
    const gridDiv = document.querySelector('#myGrid');
    new agGrid.Grid(gridDiv, gridOptions);
});