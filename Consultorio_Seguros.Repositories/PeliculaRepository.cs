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
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly IDbConnection _connection;

        public PeliculaRepository(IDbConnection dbConnection)
        {
            this._connection = dbConnection;
        }
                

        public IEnumerable<Pelicula> GetAll()
        {
            using(var db = _connection)
            {
                return db.Query<Pelicula>("GetPeliculas", commandType: CommandType.StoredProcedure);
            }
        }

        public Pelicula GetById(int id)
        {
            using (var db = _connection)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);

                return db.QueryFirst<Pelicula>("GetPeliculaById", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Insert(Pelicula pelicula)
        {
            using (var db = _connection)
            {
                db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Name", pelicula.Name, DbType.String);
                parameters.Add("@Age", pelicula.Age, DbType.Int32);
                parameters.Add("@Amount", pelicula.Amount, DbType.String);
                db.Execute("InsertPelicula", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(Pelicula pelicula, int id)
        {
            using (var db = _connection)
            {
                db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                parameters.Add("@Name", pelicula.Name, DbType.String);
                parameters.Add("@Age", pelicula.Age, DbType.Int32);
                parameters.Add("@Amount", pelicula.Amount, DbType.String);
                db.Execute("UpdatePelicula", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(Pelicula pelicula, int id)
        {
            using (var db = _connection)
            {
                db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                db.Execute("DeletePelicula", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
