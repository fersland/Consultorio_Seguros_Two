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
    public interface ISeguroRepository
    {
        IEnumerable<Seguro> GetAll();
        Seguro GetById(int id);
        void Insert(Seguro seguro);
        void Update(int id, Seguro seguro);
        void Delete(int id);
    }
}
