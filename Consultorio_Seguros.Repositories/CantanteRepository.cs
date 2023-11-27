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
        private readonly IDbConnection _connection;

        public CantanteRepository(IDbConnection cc)
        {
            this._connection = cc;
        }

        public IEnumerable<Cantante> GetAll()
        {
            using (var db = _connection)
            {
                return db.Query<Cantante>("GetCantantes", commandType: CommandType.StoredProcedure);
            }
        }

        public Cantante GetById(int id)
        {
            using (var db = _connection)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                return db.QueryFirst<Cantante>("GetCantanteById", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Insert(Cantante cantante)
        {
            using (var connection = _connection)
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Nombre", cantante.Nombre, DbType.String);
                parameters.Add("@Cancion", cantante.Cancion, DbType.String);
                connection.Execute("InsertCantante", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(int id, Cantante cantante)
        {
            using (var connection = _connection)
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                parameters.Add("@Nombre", cantante.Nombre, DbType.String);
                parameters.Add("@Cancion", cantante.Cancion, DbType.String);
                connection.Execute("UpdateCantante", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (var connection = _connection)
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                connection.Execute("DeleteCantante", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
