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

            loanTerm = loanTerm * 12;


  
         dtoCreditico.monthlyPayment = (totalLoanAmount * monthlyInterestRate) /
                                    (1 - Math.Pow((1 + monthlyInterestRate), -loanTerm));


            dtoCreditico.loanTerm = loanTerm.ToString();

            double incomePercentage = (dtoCreditico.monthlyPayment + currentLoanPayment) / monthlyIncome * 100;


            if (dtoCreditico.customerType.Equals("Fisico", StringComparison.OrdinalIgnoreCase))
            {

                dtoCreditico.commissionPercentage = incomePercentage.ToString();
                if (incomePercentage > 50)
                {

                    if (dependents == 0)
                    {

                        dtoCreditico.riskResult = "Riesgo Medio";
                        dtoCreditico.riskCriteria = "Ingresos mensuales superiores al 50 %, sin dependientes";
                        return "Riesgo Medio";



                    }
                    else
                    {
                        dtoCreditico.riskResult = "Riesgo Alto";
                        dtoCreditico.riskCriteria = "Ingresos mensuales superiores al 50 %, con dependientes";
                        return "Riesgo Alto";
                    }
                }
                else if (incomePercentage >= 30 && incomePercentage <= 50)
                {

                    if (dependents == 0)
                    {

                        dtoCreditico.riskResult = "Riesgo Bajo";
                        dtoCreditico.riskCriteria = "Ingresos mensuales superiores al 30 % y menor o igual al 50 %, sin dependientes";
                        return "Riesgo Bajo";
                    


                    } else if (dependents >= 5) {
                        dtoCreditico.riskResult = "Riesgo Alto";
                        dtoCreditico.riskCriteria = "Ingresos mensuales superiores al 30 % y menor o igual al 50 %, con 5 o más dependientes";
                        return "Riesgo Alto";

                    }
                    else
                    {
                        dtoCreditico.riskResult = "Riesgo Medio";
                        dtoCreditico.riskCriteria = "Ingresos mensuales superiores al 30 % y menor o igual al 50 %, con más de un dependiente pero menos de 5";
                        return "Riesgo Medio";


                    }
                }
                else
                {
               if (dependents >= 5)
                {
                    dtoCreditico.riskResult = "Riesgo Medio";
                    dtoCreditico.riskCriteria = "Ingresos mensuales inferiores al 30 %, con 5 o más dependientes";
                        return "Riesgo Medio";

                }
                dtoCreditico.riskResult = "Riesgo Bajo";
                    dtoCreditico.riskCriteria = "Ingresos mensuales inferiores al 30 %, con menos de 5 dependientes";
                    return "Riesgo Bajo";
                }
            }
            else if (dtoCreditico.customerType.Equals("Juridico", StringComparison.OrdinalIgnoreCase))
            {
            
        
                if (incomePercentage > 30)
                {

                    dtoCreditico.riskResult = "Riesgo Alto";
                    dtoCreditico.riskCriteria = "Ingresos mensuales superiores al 30 %.";
                    return "Riesgo Alto";
                }
                else if (incomePercentage >= 10 && incomePercentage <= 30)
                {
                    dtoCreditico.riskResult = "Riesgo Medio";
                    dtoCreditico.riskCriteria = "Ingresos mensuales superiores o iguales al 10 % e inferiores o iguales al 30 %.";
                    return "Riesgo Medio";
                }
                else
                {
                    dtoCreditico.riskResult = "Riesgo Bajo";
                    dtoCreditico.riskCriteria = "Ingresos mensuales inferiores al 10 %.";
                    return "Riesgo Bajo";
                }
            }

            return "Tipo de cliente no reconocido";
        }
    }
}
