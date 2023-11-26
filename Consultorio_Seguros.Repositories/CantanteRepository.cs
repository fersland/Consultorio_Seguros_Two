using Consultorio_Seguros.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Seguros.Repositories
{
    public class CantanteRepository : ICantanteRepository
    {
        public void DMLBase(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cantante> GetAll(string procedureName, DynamicParameters paramters, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public Cantante GetById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }
    }
}
