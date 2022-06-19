using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetarioSocialDomain.Entities
{
    public class Receta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdReceta { get; set; }//el ? se usa para que el campo sea nullable, esto para hacer las busquedas y mandar id como null), ya que por si mismos los int no pueden ser nulos
        public byte[] Imagen { get; set; }
        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }
        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string Ingredientes { get; set; }
        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string Instrucciones { get; set; }
        [StringLength(150)]
        public string TextoExtra { get; set; }//Texto que aveces complementa al titulo
        public short? TiempoPreparacionMinutos { get; set; } 
        public byte? Porciones { get; set; }//hasta 255

        
        [Required]
        public bool? Estado { get; set; }//si es visible o oculto

        [Required]
        public int IdUsuario { get; set; }//para la llave foranea
        

        //para la relacion mucho a muchos
        public virtual List<Categoria> Categorias { get; set; }

        //para la relacion uno a muchos
        public virtual List<Calificaciones> Calificaciones { get; set; }
        

        //calculado
        [NotMapped]
        public decimal? Calificacion 
        {
            get
            {
                if (Calificaciones != null)
                {
                    if (Calificaciones.Count() > 0)
                    {
                        decimal suma = (Calificaciones.Sum(p => p.Calificacion));
                        decimal resultado= (suma/ Calificaciones.Count());
                        return resultado;
                    }
                    else { return null; }
                }
                else { return null; }
            }
        }

        [NotMapped]
        public string EstadoReceta
        {
            get
            {
                if (Estado == true)
                {
                    return "Visible";
                }
                else { return "Oculta"; }
            }
        }

    }

}
