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
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetAll();

        Cliente GetById(int id);

        void Insert(Cliente cliente);
        void Update(int id, Cliente cliente);
        void Delete(int id);
    }
}
