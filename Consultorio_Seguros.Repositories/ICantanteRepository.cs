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
    public interface ICantanteRepository
    {
        IEnumerable<Cantante> GetAll();
        Cantante GetById(int id);
        void Insert(Cantante cliente);
        void Update(int id, Cantante cliente);
        void Delete(int id);
    }
}
