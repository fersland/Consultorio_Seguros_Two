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

        public IEnumerable<AseguradoVM> GetAll()
        {
            using (var conn = _connection)
            {
                return conn.Query<AseguradoVM>("GetAsegurados", commandType: CommandType.StoredProcedure);
            }
        }

        public Asegurado GetById(int id)
        {
            using (var conn = _connection)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                return conn.QueryFirst<Asegurado>("", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Insert(Asegurado asegurado)
        {
            using(var conn = _connection)
            {
                if (asegurado == null)
                {
                    throw new ArgumentNullException("Este dato ya existe.");
                }
                else
                {
                    conn.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@ClienteId", asegurado.ClienteId, DbType.Int32);
                    parameters.Add("@SeguroId", asegurado.SeguroId, DbType.Int32);
                    conn.Execute("InsertAsegurado", parameters, commandType: CommandType.StoredProcedure);
                }
            }            
        }

        public void Update(int id, Asegurado asegurado)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
