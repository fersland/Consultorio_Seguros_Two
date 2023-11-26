using Consultorio_Seguros.Models;
using Consultorio_Seguros.Models.ViewModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Seguros.Repositories
{
    public interface IAseguradoRepository
    {
        IEnumerable<AseguradoVM> GetAsegurados(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        Asegurado GetAseguradoById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        void DMLAsegurado(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
    }
}
