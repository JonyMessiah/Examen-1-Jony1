using DataAccess.Mapper;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;

namespace DataAccess.Crud
{
    public class AuthorCrud : CrudFactory
    {
        AuthorMapper mapper;

        //Constructor
        public AuthorCrud() : base()
        {
            mapper = new AuthorMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass entityDTO)
        {
            SqlOperation operation = mapper.GetCreateStatement(entityDTO);
            dao.ExecuteStoredProcedure(operation);
        }

        public override void Delete(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }
    }
}
