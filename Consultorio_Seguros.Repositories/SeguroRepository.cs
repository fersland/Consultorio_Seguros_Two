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
        
        public Seguro GetById(int id)
        {
            using(var conn = _connection)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                return conn.QueryFirst<Seguro>("GetSeguroById", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Seguro> GetAll()
        {
            using(var conn = _connection)
            {
                return conn.Query<Seguro>("GetSeguros", commandType: CommandType.StoredProcedure);
            }
        }

        public void Insert(Seguro seguro)
        {
            using(var conn = _connection)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Codigo", seguro.Codigo, DbType.String);
                parameters.Add("@Nombre", seguro.Nombre, DbType.String);
                parameters.Add("@Asegurada", seguro.Asegurada, DbType.String);
                parameters.Add("@Prima", seguro.Prima, DbType.String);
                conn.Execute("InsertSeguro", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(int id, Seguro seguro)
        {
            using (var conn = _connection)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                parameters.Add("@Codigo", seguro.Codigo, DbType.String);
                parameters.Add("@Nombre", seguro.Nombre, DbType.String);
                parameters.Add("@Asegurada", seguro.Asegurada, DbType.String);
                parameters.Add("@Prima", seguro.Prima, DbType.String);
                conn.Execute("UpdateSeguro", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (var conn = _connection)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                conn.Execute("DeleteSeguro", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
