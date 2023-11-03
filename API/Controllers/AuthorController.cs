using DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App_Logic;
using Microsoft.AspNetCore.Cors;
using App_Logic.Admins;

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

        [HttpGet]
        public API_Response GetAuthorsByName(string searchName)
        {
            API_Response response = new API_Response();
            try
            {
                AdminRegulation am = new AdminRegulation();

                response.Data = am.GetRegisteredAuthors();
                response.Result = "OK";
                return response;
            }
            catch (Exception ex)
            {
                response.Result = "ERROR";
                response.Message = "Error al obtener los autores " + ex.Message;
                return response;
            }
        }
    }


}


