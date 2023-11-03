using DataAccess.Dao;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ArticleMapper : ICrudStatements, IObjectMapper
    {
        public BaseClass BuildObject(Dictionary<string, object> row)
        {
            var article = new Article()
            {
                Id = int.Parse(row["Id"].ToString()),
                Title = row["Title"].ToString(),
                Abstract = row["Abstract"].ToString(),
                ISBN = row["ISBN"].ToString(),
                PublishedDate = DateTime.Parse(row["DatePublished"].ToString())
            };

            var aut = new Author()
            {
                Id = int.Parse(row["Author_Id"].ToString()),
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                Charge = row["Charge"].ToString()
            };

            article.AuthorInfo = aut;

            return article;
        }

        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var lstResult = new List<BaseClass>();

            foreach (var objRow in listRows)
            {
                var article = BuildObject(objRow);
                lstResult.Add(article);
            }
            return lstResult;
        }

        public SqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation();
            operation.ProcedureName = "PR_CREATE_ARTICLE";

            Article art = (Article) entityDTO;

            //agregar los parametros al operation
            operation.AddVarcharParam("Title", art.Title);
            operation.AddVarcharParam("Abstract", art.Abstract);
            operation.AddVarcharParam("ISBN", art.ISBN);
            operation.AddDateTimeParam("DatePublished", art.PublishedDate);
            operation.AddIntegerParam("Id_Author", art.AuthorInfo.Id);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation RetrieveAllStatement()
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_ALL_ARTICLES";

            return operation;
        }

        public SqlOperation RetrieveByIdStatement(int Id)
        {
            SqlOperation operation = new SqlOperation();

            operation.ProcedureName = "PR_GET_ARTICLE_BY_ID";

            operation.AddIntegerParam("article_id", Id);

            return operation;
        }

        //Método para hacer consultas por diferentes criterios de filtro
        //Cada criterio que queramos evaluar, va a ser un search type y el valor el
        //search phrase
        public SqlOperation GetRetrieveByPhraseStatement(string searchPhrase)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "PR_GET_ALL_ARTICLES_BY_PHRASE"
            };

            operation.AddVarcharParam("searchPhrase", searchPhrase);

            return operation;
        }

    }
}
