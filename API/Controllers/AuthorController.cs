﻿using DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App_Logic;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        [HttpGet]
        public List<Author> GetAllRegisteredAuthors()
        {
            AdminRegulation am = new AdminRegulation();
            return am.GetRegisteredAuthors();
        }
    }
}
