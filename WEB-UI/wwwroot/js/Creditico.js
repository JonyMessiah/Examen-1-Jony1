const crediticoForm = document.getElementById('crediticoForm');
const resultsContainer = document.getElementById('resultsContainer');


crediticoForm.addEventListener('submit', function (e) {
    const data = this;
    e.preventDefault();

    fetch("https://localhost:7154/API/Creditico/Creditico", {
        method: "POST",
        body: new FormData(data)
    })


        .then(res => res.json())
        .then(function (data) {
            if (data.success) {
                resultsContainer.innerHTML = `
                <h2>Resultados del Crédito</h2>
                <p>Tipo de Cliente: ${data.customerType}</p>
                <p>Cuota mensual del préstamo: ${data.monthlyPayment}</p>
                <p>Cantidad de meses a pagar: ${data.loanTerm}</p>
                <p>Monto de comisión: ${data.commissionPercentage}</p>
                <p>Perfil de riesgo del cliente: ${data.riskResult}</p>
                <p>Criterio de evaluación: ${data.riskCriteria}</p>
            `;
          
            } else {
                alert.style.display = 'block';
            }
        });
});
