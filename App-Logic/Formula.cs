using System;
using DTO.Models;

namespace App_Logic
{
    public class Formula
    {
        public static string EvaluateRisk(CrediticoDTO dtoCreditico)
        {

  
            double loanAmount = Convert.ToDouble(dtoCreditico.loanAmount);
            double commissionPercentage = Convert.ToDouble(dtoCreditico.commissionPercentage);
            double annualInterestRate = Convert.ToDouble(dtoCreditico.AnnualInterestRate);
            double loanTerm = Convert.ToDouble(dtoCreditico.loanTerm);
            double monthlyIncome = Convert.ToDouble(dtoCreditico.monthlyIncome);
            double currentLoanPayment = Convert.ToDouble(dtoCreditico.currentLoanPayment);
            int dependents = Convert.ToInt32(dtoCreditico.dependents);

       
            double totalLoanAmount = loanAmount + (loanAmount * commissionPercentage / 100);

   
            double monthlyInterestRate = annualInterestRate / 12 / 100;

  
            double monthlyPayment = (totalLoanAmount * monthlyInterestRate) /
                                    (1 - Math.Pow((1 + monthlyInterestRate), -loanTerm));

 
            double incomePercentage = (monthlyPayment + currentLoanPayment) / monthlyIncome * 100;


            if (dtoCreditico.customerType.Equals("Fisico", StringComparison.OrdinalIgnoreCase))
            {
                if (incomePercentage > 50)
                {
                    return "Riesgo Alto";
                }
                else if (incomePercentage >= 30 && incomePercentage <= 50)
                {
                    return "Riesgo Medio";
                }
                else
                {
                    return "Riesgo Bajo";
                }
            }
            else if (dtoCreditico.customerType.Equals("Juridico", StringComparison.OrdinalIgnoreCase))
            {
            
                double toleranceAdjustedPercentage = incomePercentage - (incomePercentage * 0.20);

                if (toleranceAdjustedPercentage > 30)
                {
                    return "Riesgo Alto";
                }
                else if (toleranceAdjustedPercentage >= 10 && toleranceAdjustedPercentage <= 30)
                {
                    return "Riesgo Medio";
                }
                else
                {
                    return "Riesgo Bajo";
                }
            }

            return "Tipo de cliente no reconocido";
        }
    }
}
