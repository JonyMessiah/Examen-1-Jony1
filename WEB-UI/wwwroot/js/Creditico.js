const fileInput = document.getElementById('photo');
const registerForm = document.getElementById('registerForm');
const alert = document.getElementById('register-alert');

crediticoForm.addEventListener('submit', function (e) {
    alert.style.display = 'none';
    const data = this;
    e.preventDefault();
    const loanAmount = document.getElementById('loanAmount');
    console.log(loanAmount.value);
    const annualInterestRate = document.getElementById('annualInterestRate');
    console.log(annualInterestRate.value);
    const loanTerm = document.getElementById('loanTerm');
    console.log(loanTerm.value);
    const commissionPercentage = document.getElementById('commissionPercentage');
    console.log(commissionPercentage);
    const monthlyIncome = document.getElementById('monthlyIncome');
    console.log(monthlyIncome);
    const currentLoanPayment = document.getElementById('currentLoanPayment');
    console.log(currentLoanPayment);
    const dependents = document.getElementById('dependents');
    console.log(dependents);
   

    fetch("http://localhost:7154/API/Creditico/Creditico", {
        method: "POST",
        body: new FormData(data)
    }).then(res=>res.json())
        .then(function (data) {
            if (data.success) {
        
            } else {
                alert.style.display = 'block';
            }
        });
});

