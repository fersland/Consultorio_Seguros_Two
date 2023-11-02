using Consultorio_Seguros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Seguros.Repositories
{
    public interface ISeguroRepo
    {
        IEnumerable<Seguro> GetSeguros();

        Cliente GetSeguroById(int id);

        void InsertSeguro(Seguro seguro);

        void UpdateSeguro(Seguro seguro);

        void DeleteSeguro(int id);

        void Save();
    }
}
