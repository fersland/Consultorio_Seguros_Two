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
    public interface ISeguroRepository
    {
        IEnumerable<Seguro> GetSeguros(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        Seguro GetSeguroById(string procedureName, DynamicParameters parameters, CommandType commandType= CommandType.StoredProcedure);
        void DMLSeguro(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
    }
}
