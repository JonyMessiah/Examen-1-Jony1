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

             List<Author> authors = am.GetRegisteredAuthors();
                List<Author> authorsFiltered = new List<Author>();
                foreach (var author in authors)
                {

                    if(author.FirstName.ToLower().Contains(searchName.ToLower()))
                    {

                        authorsFiltered.Add(author);
                        
                    }
                    
                }

                response.Data = authorsFiltered;
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


