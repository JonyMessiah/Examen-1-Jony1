using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class CrediticoDTO
    {

        public string customerType { get; set; }
        public string loanAmount { get; set; }
        public string AnnualInterestRate { get; set; }
        public string loanTerm { get; set; }

        public string commissionPercentage { get; set; }

        public string monthlyIncome { get; set; }

        public string currentLoanPayment { get; set; }

        public string dependents { get; set; }

        public double results { get; set; }

    }
}
