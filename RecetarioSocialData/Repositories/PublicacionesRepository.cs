using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetarioSocialDomain.Entities;

namespace RecetarioSocialData.Repositories
{
    public class PublicacionesRepository
    {

        //Variable para trabajar en el contexto de nuestra base de datos
        private RecetarioSocialContext _context;

        //Constructor
        public PublicacionesRepository()
        {
            this._context = new RecetarioSocialContext();
        }

        //Constructor que recibe el contexto (si ya existe el contexto)
        public PublicacionesRepository(RecetarioSocialContext context)
        {
            this._context = context;
        }
        public List<Publicacion> Get(int? id, DateTime? from, DateTime? to, int? idReceta, int? idUsuario, bool? estadoReceta,string tituloReceta, int? tiempoMaximoPreparacion, int? numeroMinimoPorciones)//espera un id pero tambien puede traer nulo
        {

            var myQueryable = this._context.Publicaciones.AsQueryable();
            if (!string.IsNullOrWhiteSpace(tituloReceta) && !string.IsNullOrEmpty(tituloReceta))
            {
                myQueryable = myQueryable.Where(t => t.Receta.Titulo.Contains(tituloReceta));
            }
            if (id != null) { myQueryable = myQueryable.Where(t => t.IdPublicacion == id); }
            if (estadoReceta != null) { myQueryable = myQueryable.Where(t => t.Receta.Estado == estadoReceta); }
            if (idReceta != null) { myQueryable = myQueryable.Where(t => t.IdReceta == idReceta); }
            if (idUsuario != null) { myQueryable = myQueryable.Where(t => t.Receta.IdUsuario == idUsuario); }
            if (from != null) { myQueryable = myQueryable.Where(t => t.FechaHoraPublicacion >= from); }
            if (to != null) { myQueryable = myQueryable.Where(t => t.FechaHoraPublicacion <= to); }
            if (tiempoMaximoPreparacion != null) { myQueryable = myQueryable.Where(t => t.Receta.TiempoPreparacionMinutos <= tiempoMaximoPreparacion); }
            if (numeroMinimoPorciones != null) { myQueryable = myQueryable.Where(t => t.Receta.Porciones >= numeroMinimoPorciones); }

            return (myQueryable).ToList();
        }
        //Método para insertar un nueva publicacion
        public void Insert(Publicacion publicacion)
        {

            this._context.Publicaciones.Add(publicacion);
            this._context.SaveChanges();
        }

        //Método para eliminar una publicacion
        public void Delete(Publicacion publicaciones)
        {
            var obj = this._context.Publicaciones.Find(publicaciones.IdPublicacion);
            _context.Entry(obj).State = System.Data.Entity.EntityState.Deleted;

            this._context.SaveChanges();
        }

        //Método para editar una publicacion (solo se puede modificar la descripcion)
        public void Update(Publicacion publicaciones)
        {
            var Publicaciones = this._context.Publicaciones.Find(publicaciones.IdPublicacion);
            Publicaciones.Descripcion = publicaciones.Descripcion;

            _context.Entry(Publicaciones).State = System.Data.Entity.EntityState.Modified;

            this._context.SaveChanges();
        }
    }
}
