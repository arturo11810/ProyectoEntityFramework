using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetarioSocialDomain.Entities
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdUsuario { get; set; }//La interrogación sirve para definir que es un dato nullable 
        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; }
        [Required]
        [StringLength(50)]
        public string Contrasena { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100)]
        public string PrimerApellido { get; set; }
        [Required]
        [StringLength(100)]
        public string SegundoApellido { get; set; }
        [Required]
        public DateTime? FechaNacimiento { get; set; }
        [StringLength(100)]
        public string Correo { get; set; }

        //para la relacion 
        //public virtual List<Calificaciones> Calificaciones { get; set; }
        //para la relacion 
        //public virtual List<Comentarios> Comentarios { get; set; }

        //para la relacion 
        //public virtual List<Recetas> Recetas { get; set; }
        

    }
}
