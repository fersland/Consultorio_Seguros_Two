using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Seguros.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten numeros")]
        [StringLength(10, ErrorMessage = "La longitud de este campo es de 10 caracteres", MinimumLength = 10)]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(40, ErrorMessage = "La longitud permitida es de 2 a 40 caracteres", MinimumLength = 10)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo se permiten letras.")]
        public string Nombre { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten numeros")]
        [StringLength(10, ErrorMessage = "La longitud de este campo es de 10 numeros", MinimumLength = 10)]
        public string Telefono { get; set; }

        [Range(18,80, ErrorMessage = "La edad permitida debe ser de 18 a 80 años")]
        public int Edad { get; set; }
    }
}
