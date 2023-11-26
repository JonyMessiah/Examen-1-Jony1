﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System;
using System.Net.Http;
using System.Net;
using System.Data.SqlClient;

using System.Data;
using System.Configuration;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using DTO;
using DTO.Models;
using System.Diagnostics;
using App_Logic;

namespace API.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("API/Creditico/Creditico")]
    [ApiController]
    public class CrediticoController : Controller
    {
        [HttpPost]
        public ActionResult CrediticoForm(IFormCollection form)
        {
            CrediticoDTO dtoCreditico = new CrediticoDTO();

            dtoCreditico.AnnualInterestRate = Request.Form["loanAmount"];
            dtoCreditico.monthlyIncome = Request.Form["monthlyIncome"];
            dtoCreditico.commissionPercentage = Request.Form["commisionPercentage"];
            dtoCreditico.dependents = Request.Form["dependents"];
            dtoCreditico.loanAmount = Request.Form["loanAmount"];
            dtoCreditico.customerType = Request.Form["customerType"];
            dtoCreditico.currentLoanPayment = Request.Form["currentLoanPayment"];
            dtoCreditico.loanTerm = Request.Form["loanTerm"];

            Debug.WriteLine($"loanTerm: {dtoCreditico.loanTerm}");
            Debug.WriteLine("MIAU");

            // Calcular y evaluar el riesgo
            var result = Formula.EvaluateRisk(dtoCreditico);

            // Devolver los resultados junto con la indicación de éxito
            return Json(new
            {
                success = true,
                customerType = dtoCreditico.customerType,
                monthlyPayment = dtoCreditico.monthlyPayment,
                loanTerm = dtoCreditico.loanTerm,
                commissionPercentage = dtoCreditico.commissionPercentage,
                riskResult = dtoCreditico.riskResult,
              // riskCriteria = result.RiskCriteria
            });
        }
    }
}
