﻿
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System;
using System.Net.Http;
using System.Net;
using static System.Net.WebRequestMethods;
using System.Data.SqlClient;

using System.Data;
using System.Configuration;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using DTO;
using DTO.Models;

namespace API.Controllers
{

    [EnableCors("MyCorsPolicy")]
    [Route("API/Creditico/Creditico")]
    [ApiController]
    public class CrediticoController : Controller
    {
        [HttpPost]
        public ActionResult Creditico(IFormCollection form)
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


            Console.WriteLine($"loanTerm: {dtoCreditico.loanTerm}");


            return Json(new { success = true });


        }

    }

}