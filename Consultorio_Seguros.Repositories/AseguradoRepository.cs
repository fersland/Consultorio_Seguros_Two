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
    public class AseguradoRepository : IAseguradoRepository
    {
        private readonly IDbConnection _connection;

        public AseguradoRepository(IDbConnection cc)
        {
            this._connection = cc;
        }

        public IEnumerable<AseguradoVM> GetAsegurados(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _connection.Query<AseguradoVM>(procedureName, parameters, commandType: commandType);
        }

        public Asegurado GetAseguradoById(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            return _connection.QueryFirstOrDefault<Asegurado>(procedureName, parameters, commandType: commandType);
        }

        public void DMLAsegurado(string procedureName, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            if(procedureName == null)
            {
                throw new ArgumentNullException("Este dato ya existe.");
            }
            else
            {
                _connection.Execute(procedureName, parameters, commandType: commandType);
            }
        }
    }
}
