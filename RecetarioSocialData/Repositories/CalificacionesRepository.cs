using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetarioSocialDomain.Entities;

namespace RecetarioSocialData.Repositories
{
    public class CalificacionesRepository
    {
        //Variable para trabajar en el contexto de nuestra base de datos
        private RecetarioSocialContext _context;

        //Constructor
        public CalificacionesRepository()
        {
            this._context = new RecetarioSocialContext();
        }

        //Constructor que recibe el contexto (si ya existe el contexto)
        public CalificacionesRepository(RecetarioSocialContext context)
        {
            this._context = context;
        }

        //metodo para traer todas las calificaciones de una receta
        public List<Calificaciones> Get(int idreceta)
        {
            return this._context.Calificaciones.Where(c => (c.IdReceta == idreceta)).ToList();
            //return null;
        }

        //Método para insertar una nueva calificacion
        public void Insert(Calificaciones calificacionXReceta)
        {
            //verificar si el usuario ya habia calificado la receta
            this._context.Calificaciones.Add(calificacionXReceta);
            this._context.SaveChanges();
        }

        //Método para eliminar una calificacion por id
        public void Delete(Calificaciones calificacionXReceta)
        {
            var obj = this._context.Calificaciones.Find(calificacionXReceta.IdCalificacion);
            _context.Entry(obj).State = System.Data.Entity.EntityState.Deleted;

            this._context.SaveChanges();
        }

        //Método para editar una calificacion
        public void Update(Calificaciones calificacionXReceta)
        {
            var calificacionXreceta = this._context.Calificaciones.Find(calificacionXReceta.IdCalificacion);

            calificacionXreceta.Calificacion = calificacionXReceta.Calificacion;

            _context.Entry(calificacionXreceta).State = System.Data.Entity.EntityState.Modified;

            this._context.SaveChanges();
        }
    }
}
