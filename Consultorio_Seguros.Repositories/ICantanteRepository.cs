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
    public interface ICantanteRepository
    {
        IEnumerable<Cantante> GetAll(string procedureName, DynamicParameters paramters, CommandType commandType = CommandType.StoredProcedure);
        Cantante GetById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        void DMLBase(string procedureName, DynamicParameters parameters, CommandType commandType= CommandType.StoredProcedure);
    }
}
