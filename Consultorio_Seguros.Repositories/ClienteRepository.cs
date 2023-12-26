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
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDbConnection _connection;        

        public ClienteRepository(IDbConnection cc)
        {
            this._connection = cc;
        }

        public Cliente GetById(int id)
        {
            using(var  db = _connection)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
        
                return db.QueryFirst<Cliente>("GetClienteById", parameters, commandType: CommandType.StoredProcedure);
            }            
        }

        public IEnumerable<Cliente> GetAll()
        {
            using(var db = _connection) { 
                return db.Query<Cliente>("GetClientes", commandType: CommandType.StoredProcedure);
            }
        }

        public void Insert(Cliente cliente)
        {   
            using (var connection = _connection)
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Cedula", cliente.Cedula, DbType.String);
                parameters.Add("@Nombre", cliente.Nombre, DbType.String);
                parameters.Add("@Telefono", cliente.Telefono, DbType.String);
                parameters.Add("@Edad", cliente.Edad, DbType.Int32);
                connection.Execute("InsertCliente", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(int id, Cliente cliente)
        {
            using (var connection = _connection)
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                parameters.Add("@Cedula", cliente.Cedula, DbType.String);
                parameters.Add("@Nombre", cliente.Nombre, DbType.String);
                parameters.Add("@Telefono", cliente.Telefono, DbType.String);
                parameters.Add("@Edad", cliente.Edad, DbType.Int32);
                connection.Execute("UpdateCliente", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (var connection = _connection)
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                connection.Execute("DeleteCliente", parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
