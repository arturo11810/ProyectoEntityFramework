using RecetarioSocialDomain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetarioSocialData
{
    public partial class RecetarioSocialContext : DbContext
    {
        //Constructor que crea la base de datos, pasando el parametro del nombre
        public RecetarioSocialContext() : base("name=RecetarioSocial")
        {
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        //Representación de nuestras clases en tablas (crea el dbset para hacer las consultas en LINQ
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Receta> Recetas { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Publicacion> Publicaciones { get; set; }
        public virtual DbSet<Comentario> Comentarios{ get; set; }
        public virtual DbSet<Calificaciones> Calificaciones { get; set; }


        //
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Receta>().ToTable("Recetas");
            modelBuilder.Entity<Receta>().HasMany(x => x.Calificaciones).WithRequired().HasForeignKey(c => c.IdReceta).WillCascadeOnDelete(true);//llave foranea hacia calificaciones


            modelBuilder.Entity<Receta>().HasMany<Categoria>(r => r.Categorias).WithMany().Map(ru =>
            {
                ru.MapLeftKey("IdReceta");
                ru.MapRightKey("IdCategoria");
                ru.ToTable("CategoriaReceta");
            });

            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            
            modelBuilder.Entity<Publicacion>().ToTable("Publicaciones");
            modelBuilder.Entity<Publicacion>().HasMany(x => x.Comentarios).WithRequired().HasForeignKey(c => c.IdPublicacion).WillCascadeOnDelete(true);
            modelBuilder.Entity<Publicacion>().HasRequired(x => x.Receta).WithMany().HasForeignKey(x => x.IdReceta).WillCascadeOnDelete(true);

            modelBuilder.Entity<Comentario>().ToTable("Comentarios");
            
            modelBuilder.Entity<Calificaciones>().ToTable("Calificaciones");

            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            
            //modelBuilder.Entity<Usuarios>().HasMany(x => x.Calificaciones).WithRequired().HasForeignKey(c => c.IdUsuario).WillCascadeOnDelete(true);//llave foranea hacia Calificaciones
            //modelBuilder.Entity<Usuarios>().HasMany(x => x.Comentarios).WithRequired().HasForeignKey(c => c.IdUsuario).WillCascadeOnDelete(true);
            //modelBuilder.Entity<Usuarios>().HasMany(x => x.Recetas).WithRequired().HasForeignKey(c => c.IdUsuario).WillCascadeOnDelete(false);

        }
    }
}
