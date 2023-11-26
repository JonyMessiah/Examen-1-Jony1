const crediticoForm = document.getElementById('crediticoForm');
const resultsContainer = document.getElementById('resultsContainer');
const data = this;


crediticoForm.addEventListener('submit', function (e) {
    // Evitar que la página se actualice
    e.preventDefault();
 

    fetch("https://localhost:7154/API/Creditico/Creditico", {
        method: "POST",
        body: new FormData(data)
    })
        .then(res => res.json())
        .then(function (data) {
            if (data.success) {
                window.location = '/LogIn/LogIn';
            } else {
                alert.style.display = 'block';
            }
        });
});
