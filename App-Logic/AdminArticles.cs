using DataAccess.Crud;
using DTO.Models;

namespace App_Logic.Admins
{
    public class AdminArticles
    {
        public List<Article> GetAllArticles()
        {   
            ArticleCrud aCrud = new ArticleCrud();

            return aCrud.RetrieveAll<Article>();
        }

        public void CreateArticle(Article art) 
        {
            /*
             * 1- Recibir un articulo con los datos base
             * 2 - Conectar al API de Regulación y obtener datos para el articulo (ISBN, ISSN, otros...)
             *          2.1 Explorar el API,para verificar la estructura de datos que devuelve
             *          2.2 Modelar esa estructura en nuestra aplicacion (DTO)
             *          2.3 hacer el llamado y mapear los valores a nuestro DTO
             * 3 - Asignar esos datos en mi objeto de articulo (el que recibí por parametro)
             * 4 - Enviar a la BD para que se guarde el articulo completo. 
             */

            AdminRegulation adminReg = new AdminRegulation();

            ArticleRegulationInfo info = adminReg.GetArticleGeneratedInfo();

            var isbn = info.ISBN;

            //3
            art.ISBN = isbn;

            //4
            //Se crea primero el author en caso de que aún no exista en DB no dé problema al referenciar
            // por el ID en la tabla Article
            ArticleCrud aCrud = new ArticleCrud();
            AuthorCrud authorCrud = new AuthorCrud();

            authorCrud.Create(art.AuthorInfo);
            aCrud.Create(art);
        }

        public List<Article> GetArticlesByPhrase(string phrase)
        {
            ArticleCrud aCrud = new ArticleCrud();

            return aCrud.RetrieveBySearchPhrase<Article>(phrase);
        }

        public Article GetArticlesById(int id)
        {
            ArticleCrud aCrud = new ArticleCrud();

            return aCrud.RetrieveById<Article>(id);
        }
    }
}