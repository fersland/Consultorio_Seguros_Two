using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio_Seguros.Models
{
    public class Asegurado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Clientes))]
        public int ClienteId { get; set; }
        public virtual Cliente Clientes { get; set; }

        [Required]
        [ForeignKey(nameof(Seguros))]
        public int SeguroId { get; set; }
        public virtual Seguro Seguros { get; set; }
    }
}
