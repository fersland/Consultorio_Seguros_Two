using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Seguros.Models
{
    public class Pelicula
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo no es requerido")]
        [StringLength(200)]
        public string Name { get; set; }

        [RegularExpression("^(([1-9]{1}|[\\d]{2,})(\\.[\\d]+)?)$", ErrorMessage = "Solo se permiten numeros.")]

        public string Age { get; set; }

        [RegularExpression("^(([1-9]{1}|[\\d]{2,})(\\.[\\d]+)?)$", ErrorMessage = "Solo se permiten numeros.")]
        public decimal Amount { get; set; }
    }
}
