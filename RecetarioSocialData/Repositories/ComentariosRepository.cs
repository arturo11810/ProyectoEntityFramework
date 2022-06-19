using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetarioSocialDomain.Entities;

namespace RecetarioSocialData.Repositories
{
    public class ComentariosRepository
    {
        //Variable para trabajar en el contexto de nuestra base de datos
        private RecetarioSocialContext _context;

        //Constructor
        public ComentariosRepository()
        {
            this._context = new RecetarioSocialContext();
        }

        //Constructor que recibe el contexto (si ya existe el contexto)
        public ComentariosRepository(RecetarioSocialContext context)
        {
            this._context = context;
        }

        //metodo para traer los comentarios de una publicacion
        //(No se usa por que la lista de comentarios de una publicacion ya esta implicita en ella)
        public List<Comentario> Get(int? id_publicacion)//espera un id pero tambien puede traer nulo
        {
            return this._context.Comentarios.Where(c => (c.IdPublicacion == id_publicacion)).ToList();
        }

        //Método para insertar un nuevo comentario
        public void Insert(Comentario comentarioxpublicacion)
        {
            this._context.Comentarios.Add(comentarioxpublicacion);
            this._context.SaveChanges();
        }

        //Método para eliminar un comentario
        public void Delete(Comentario comentarioxpublicacion)
        {
            var obj = this._context.Comentarios.Find(comentarioxpublicacion.IdComentario);
            _context.Entry(obj).State = System.Data.Entity.EntityState.Deleted;

            this._context.SaveChanges();
        }

        //Método para editar un comentario
        public void Update(Comentario comentarioxpublicacion)
        {
            var Comentarioxpublicacion = this._context.Comentarios.Find(comentarioxpublicacion.IdComentario);
            Comentarioxpublicacion.Descripcion = comentarioxpublicacion.Descripcion;

            _context.Entry(Comentarioxpublicacion).State = System.Data.Entity.EntityState.Modified;

            this._context.SaveChanges();
        }
    }
}
