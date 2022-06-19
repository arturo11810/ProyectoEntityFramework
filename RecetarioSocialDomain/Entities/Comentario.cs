using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetarioSocialDomain.Entities
{
    public class Comentario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdComentario { get; set; }
        [Required]
        public DateTime? FechaComentario { get; set; }
        [Required]
        [StringLength(250)]
        public string Descripcion { get; set; }

        [Required]
        public int? IdPublicacion { get; set; }
        [Required]
        public int? IdUsuario { get; set; }
    }
}
