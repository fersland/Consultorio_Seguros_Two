using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Seguros.Models.ViewModel
{
    public class AseguradoVM
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string NombreCliente { get; set; }
        public string Codigo { get; set; }
        public string NombreSeguro { get; set; }
        public string Asegurada { get; set; }
        public decimal Prima { get; set; }
    }
}
