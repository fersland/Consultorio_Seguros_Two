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
    public class ClienteRepo : IClienteRepo
    {
        private readonly IDbConnection _connection;

        public ClienteRepo(IDbConnection cc)
        {
            this._connection = cc;
        }

        public Cliente GetClienteById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _connection.QueryFirstOrDefault<Cliente>(procedureName, parameters, commandType: commandType);
        }

        public IEnumerable<Cliente> GetClientes(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _connection.Query<Cliente>(procedureName, parameters, commandType: commandType);
        }

        public void DMLCliente(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            _connection.Execute(procedureName, parameters, commandType: commandType);
        }

    }
}
