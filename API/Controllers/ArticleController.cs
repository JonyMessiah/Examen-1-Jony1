using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO.Models;
using App_Logic.Admins;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        [HttpGet]
        public string GetInitialMessage()
        {
            return "Este es el valor de retorno ";
        }

        [HttpGet]
        public List<Article> GetArticles()
        {
            AdminArticles adminArticles = new AdminArticles();

            return adminArticles.GetAllArticles();
        }
        [HttpGet]
        public API_Response GetArticlesBySearchPhrase(string searchPhrase)
        {
            API_Response response = new API_Response();
            try
            {
                AdminArticles adminArticles = new AdminArticles();

                response.Data = adminArticles.GetArticlesByPhrase(searchPhrase);
                response.Result = "OK";
                return response;
            }
            catch (Exception ex)
            {
                response.Result = "ERROR";
                response.Message = "Error al obtener los articulos " + ex.Message;
                return response;
            }
        }

        [HttpGet]
        public Article GetArticlesByArticleId(int articleId)
        {
            AdminArticles adminArticles = new AdminArticles();

            return adminArticles.GetArticlesById(articleId);
        }

        [HttpPost]
        public string CreateArticle(Article art)
        {
            AdminArticles adminArticles = new AdminArticles();

            adminArticles.CreateArticle(art);

            return "OK";

        }

    }
}
