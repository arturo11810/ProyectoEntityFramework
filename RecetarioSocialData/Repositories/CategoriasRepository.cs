using RecetarioSocialDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetarioSocialData.Repositories
{
    public class CategoriasRepository
    {
        //Variable para trabajar en el contexto de nuestra base de datos
        private RecetarioSocialContext _context;

        
        //Constructor
        public CategoriasRepository()
        {
            this._context = new RecetarioSocialContext();
        }

        //Constructor que recibe el contexto (si ya existe el contexto)
        public CategoriasRepository(RecetarioSocialContext context)
        {
            this._context = context;
        }

        //traer todas las categorias o solo una en especifico
        public List<Categoria> Get(int? id, string Nombre)
        {
            var myQueryable = this._context.Categorias.AsQueryable();
            if (!string.IsNullOrWhiteSpace(Nombre) && !string.IsNullOrEmpty(Nombre))
            {
                myQueryable = myQueryable.Where(t => t.Nombre.Contains(Nombre));
            }
            if (id != null) { myQueryable = myQueryable.Where(t => t.IdCategoria == id); }

            return (myQueryable).ToList();
        }


        //Método para insertar un nueva categoria
        public void Insert(Categoria categoria)
        {
            this._context.Categorias.Add(categoria);
            this._context.SaveChanges();
        }

        //Método para eliminar una nueva categoria
        public void Delete(Categoria categoria)
        {
            var Categoria = this._context.Usuarios.Find(categoria.IdCategoria);
            _context.Entry(Categoria).State = System.Data.Entity.EntityState.Deleted;

            this._context.SaveChanges();
        }
    }
}
