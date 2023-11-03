using DataAccess.Dao;
using DataAccess.Mapper;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class ArticleCrud : CrudFactory
    {
        private ArticleMapper articleMapper;

        //Constructor
        public ArticleCrud() : base() 
        {
            articleMapper = new ArticleMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass entityDTO)
        {
            SqlOperation operation = articleMapper.GetCreateStatement(entityDTO);
            dao.ExecuteStoredProcedure(operation);
        }

        public override void Delete(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            List<T> lstResults = new List<T>();
            SqlOperation operation = articleMapper.RetrieveAllStatement();

            List<Dictionary<string, object>> dataResults = dao.ExecuteStoredProcedureWithQuery(operation);

            if (dataResults.Count > 0)
            {
                var dtoObjects = articleMapper.BuildObjects(dataResults);

                foreach (var ob in dtoObjects)
                {
                    lstResults.Add((T)Convert.ChangeType(ob, typeof(T)));
                }
            }
            return lstResults;
        }

        public override T RetrieveById<T>(int id)
        {
            var dataResults = dao.ExecuteStoredProcedureWithQuery(articleMapper.RetrieveByIdStatement(id));

            var objArt = articleMapper.BuildObject(dataResults[0]);

            return (T)Convert.ChangeType(objArt, typeof(T));
        }

        public override void Update(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public List<T> RetrieveBySearchPhrase<T>(string phrase)
        {
            var lstResults = new List<T>();

            var dataResults = dao.ExecuteStoredProcedureWithQuery(articleMapper.GetRetrieveByPhraseStatement(phrase));

            if (dataResults.Count > 0)
            {
                var objPo = articleMapper.BuildObjects(dataResults);

                foreach (var po in objPo)
                {
                    lstResults.Add((T)Convert.ChangeType(po, typeof(T)));
                }
            }
            return lstResults;
        }
    }
}
