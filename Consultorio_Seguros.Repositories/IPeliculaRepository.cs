using Consultorio_Seguros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Seguros.Repositories
{
    public interface IPeliculaRepository
    {
        IEnumerable<Pelicula> GetAll();
        Pelicula GetById(int id);
        void Insert(Pelicula pelicula);
        void Update(Pelicula pelicula, int id);
        void Delete(Pelicula pelicula, int id);
    }
}
