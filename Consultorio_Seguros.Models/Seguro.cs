using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Seguros.Models
{
    public class Seguro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(50)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(150)]
        public string Nombre { get; set; }

        [RegularExpression("^(([1-9]{1}|[\\d]{2,})(\\.[\\d]+)?)$", ErrorMessage = "Solo se permiten numeros.")]
        public string Asegurada { get; set; }

        [RegularExpression("^(([1-9]{1}|[\\d]{2,})(\\.[\\d]+)?)$", ErrorMessage = "Solo se permiten numeros.")]
        public string Prima { get; set; }

    }
}
