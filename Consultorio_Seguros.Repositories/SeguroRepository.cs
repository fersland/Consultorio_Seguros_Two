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
    public class SeguroRepository : ISeguroRepository
    {
        private readonly IDbConnection _connection;

        public SeguroRepository(IDbConnection cc)
        {
            this._connection = cc;
        }

        public void DMLSeguro(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            _connection.Execute(procedureName, parameters, commandType: commandType);
        }

        public Seguro GetSeguroById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _connection.QueryFirstOrDefault<Seguro>(procedureName, parameters, commandType: commandType);
        }

        public IEnumerable<Seguro> GetSeguros(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _connection.Query<Seguro>(procedureName, parameters, commandType: commandType);
        }
    }
}
