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
    public class AseguradoRepo : IAseguradoRepo
    {
        private readonly IDbConnection _connection;

        public AseguradoRepo(IDbConnection cc)
        {
            this._connection = cc;
        }

        public void DMLAsegurado(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            _connection.Execute(procedureName, parameters, commandType: commandType);
        }

        public Asegurado GetAseguradoById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _connection.QueryFirstOrDefault<Asegurado>(procedureName, parameters, commandType: commandType);
        }

        public IEnumerable<AseguradoVM> GetAsegurados(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _connection.Query<AseguradoVM>(procedureName, parameters, commandType: commandType);
        }

        public IEnumerable<Cliente> GetClientes(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _connection.Query<Cliente>(procedureName, parameters, commandType: commandType);
        }

        public IEnumerable<Seguro> GetSeguros(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _connection.Query<Seguro>(procedureName, parameters, commandType: commandType);
        }
    }
}
