using RecetarioSocialDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetarioSocialData.Repositories
{
    public class RecetasRepository
    {

        //Variable para trabajar en el contexto de nuestra base de datos
        private RecetarioSocialContext _context;


        //Constructor
        public RecetasRepository()
        {
            this._context = new RecetarioSocialContext();
        }
        //Constructor que recibe el contexto (si ya existe el contexto)
        public RecetasRepository(RecetarioSocialContext context)
        {
            this._context = context;
        }

        public List<Receta> Get(int? id, int? idUsuario, string titulo, bool? estado, int? tiempoMaximoPreparacion, int? numeroMinimoPorciones)//espera un id un usuario o que ambos vengan nulos
        {
            var myQueryable = this._context.Recetas.AsQueryable();
            if(!string.IsNullOrWhiteSpace(titulo) &&!string.IsNullOrEmpty(titulo))
            {
                myQueryable = myQueryable.Where(t => t.Titulo.Contains(titulo));
            }
            if (id != null) {myQueryable=myQueryable.Where(t=>t.IdReceta==id); }
            if (idUsuario != null) { myQueryable = myQueryable.Where(t => t.IdUsuario == idUsuario); }
            if (estado != null) { myQueryable = myQueryable.Where(t => t.Estado == estado); }
            if (tiempoMaximoPreparacion != null) { myQueryable = myQueryable.Where(t => t.TiempoPreparacionMinutos <= tiempoMaximoPreparacion); }
            if (numeroMinimoPorciones != null) { myQueryable = myQueryable.Where(t => t.Porciones >= numeroMinimoPorciones); }
            return (myQueryable).ToList();
        }

        //Método para insertar un nueva receta
        public void Insert(Receta receta)
        {
            this._context.Recetas.Add(receta);
            this._context.SaveChanges();
        }
        
        //Método para eliminar una receta
        public void Delete(Receta Receta)
        {
            var receta = this._context.Recetas.Find(Receta.IdReceta);
            _context.Entry(receta).State = System.Data.Entity.EntityState.Deleted;

            this._context.SaveChanges();
        }

        //Método para editar una receta
        public void Update(Receta Receta)
        {
            var receta = this._context.Recetas.Find(Receta.IdReceta);
            //receta.Id = Receta.Id;
            receta.Titulo = Receta.Titulo;
            receta.Imagen = Receta.Imagen;
            receta.Ingredientes = Receta.Ingredientes;
            receta.Instrucciones = Receta.Instrucciones;
            receta.TextoExtra = Receta.TextoExtra;
            receta.TiempoPreparacionMinutos = Receta.TiempoPreparacionMinutos;
            receta.Porciones = Receta.Porciones;
            receta.Estado = Receta.Estado;
            receta.IdUsuario = Receta.IdUsuario;
            receta.Categorias.Clear();
            receta.Categorias = Receta.Categorias;

            _context.Entry(receta).State = System.Data.Entity.EntityState.Modified;

            this._context.SaveChanges();
        }

    }
}
