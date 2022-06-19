using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetarioSocialDomain.Entities
{
    public class Publicacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdPublicacion { get; set; }
        [Required]
        public DateTime? FechaHoraPublicacion {get;set;}
        public string Descripcion { get; set; }//comentario extra debajo del titulo
        [Required]
        public int? IdReceta { get; set; }//la receta a la que hace referencia
        public virtual Receta Receta { get; set; }//para la llave foranea

        //para la relacion uno a muchos
        public virtual List<Comentario> Comentarios { get; set; }
    }
}
