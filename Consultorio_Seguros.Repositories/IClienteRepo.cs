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
    public interface IClienteRepo
    {
        IEnumerable<Cliente> GetClientes(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);

        Cliente GetClienteById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);

        void DMLCliente(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);

    }
}
