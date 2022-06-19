using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetarioSocialDomain.Entities
{
    public class Calificaciones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdCalificacion { get; set; }

        [Required]
        public int? IdReceta { get; set; }

        [Required]
        public int? IdUsuario { get; set; }

        [Required]
        public byte Calificacion { get; set; }


    }
}
