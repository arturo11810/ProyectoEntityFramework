using RecetarioSocialData;
using RecetarioSocialData.Repositories;
using RecetarioSocialDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetarioSocialServices.Services
{
    public class RecetasCtrl
    {
        private readonly RecetasRepository _RecetasRepository;
        private readonly CalificacionesRepository _CalificacionesRepository;
        private readonly CategoriasRepository _CategoriasRepository;
        //constructor
        public RecetasCtrl(RecetarioSocialContext RSC)
        {
            this._RecetasRepository = new RecetasRepository(RSC);
            this._CalificacionesRepository = new CalificacionesRepository(RSC);
            this._CategoriasRepository = new CategoriasRepository(RSC);
        }
        //Constructor que recibe el repositorio 
        public RecetasCtrl(RecetasRepository repository, CalificacionesRepository repository2, CategoriasRepository repository3)
        {
            this._RecetasRepository = repository;
            this._CalificacionesRepository = repository2;
            this._CategoriasRepository = repository3;
        }

        //Método para obtener todas las receta, recetas por usuario, recetas por titulo, recetas visibles o invisible, el tiempo maximo de preparacion y el numero minimo de porciones de la receta
        public List<Receta> Get(int? idUsuario, string titulo, bool? estado, int? tiempoMaximoPreparacion, int? numeroMinimoPorciones)
        {
            var ListaRecetas= this._RecetasRepository.Get(null, idUsuario, titulo, estado, tiempoMaximoPreparacion,numeroMinimoPorciones).ToList();
            
            return ListaRecetas;
        }

        public Receta GetById(int id)//obtiene una receta en especifico
        {
            var result =this._RecetasRepository.Get(id, null,null,null,null,null).ToList();

            if (result.Count != 1)//si encuntra mas de uno o ninguno retornara nulo
                return null;
            return result.First();//si lo encontró retornará el objeto de tipo Receta
        }

        //Método para insertar una nueva receta
        public Receta Insert(byte[] Imagen, string titulo, string ingredientes, string instrucciones, string TextoExtra, bool Estado, int idUsuario, List<int> lstCategorias, short? tiempopreparacion = null, byte? porciones = null)
        {
            #region Validaciones
            #endregion
            try
            {
                if (validaciones(titulo)&& validaciones(ingredientes)&&validaciones(instrucciones)&& validaciones(TextoExtra)&&validarnumeros(idUsuario)&&porciones!=null)
                {
                    //aplicar validaciones
                    //verificar si existe el usuario
                    //verificar si existe el estado
                    var entity = new Receta();
                    entity.Titulo = titulo;
                    entity.Imagen = Imagen;
                    entity.Ingredientes = ingredientes;
                    entity.Instrucciones = instrucciones;
                    entity.TextoExtra = TextoExtra;
                    entity.TiempoPreparacionMinutos = tiempopreparacion;
                    entity.Porciones = porciones;
                    entity.Estado = Estado;

                    //insertar las categorias de esta receta (puede estar vacio)
                    List<Categoria> lista = new List<Categoria>();
                    foreach (var categoria in lstCategorias)
                    {
                        var categoriaEncontrada = (this._CategoriasRepository.Get(categoria, null)).First();
                        lista.Add(categoriaEncontrada);
                    }

                    entity.Categorias = lista;
                    //calificaciones y publicaciones no se insertan desde aqui sino desde sus entidades
                    entity.IdUsuario = idUsuario;

                    this._RecetasRepository.Insert(entity);

                    return entity;
                }
                else { return null; }
            }
            catch (Exception ex) { return null; }
        }

        
        //Metodo eliminar una receta (al estar en casacada se eliminarian sus calificaciones y categorias asociadas)
        public void Delete(int id)
        {

            var entity = new Receta();
            entity.IdReceta = id;

            this._RecetasRepository.Delete(entity);

            //return entity;
        }

        //Metodo editar una receta
        public Receta Update(int id,byte[] imagen, string titulo, string ingredientes, string instrucciones, string TextoExtra, bool Estado, int idUsuario, List<int> lstCategorias, short? tiempopreparacion = null, byte? porciones = null)
        {
            //aplicar validaciones
            //verificar si existe el estado
            var entity = new Receta();
            entity.IdReceta = id;
            entity.Titulo = titulo;
            entity.Imagen = imagen;
            entity.Ingredientes = ingredientes;
            entity.Instrucciones = instrucciones;
            entity.TextoExtra = TextoExtra;
            entity.TiempoPreparacionMinutos = tiempopreparacion;
            entity.Porciones = porciones;
            entity.Estado = Estado;
            entity.IdUsuario = idUsuario;
            //insertar nuevas categorias
            List<Categoria> lista = new List<Categoria>();
            foreach (var categoria in lstCategorias)
            {
                var categoriaEncontrada = (this._CategoriasRepository.Get(categoria,null).ToList()).First();
                if (categoriaEncontrada!=null) { lista.Add(categoriaEncontrada); }
            }
            entity.Categorias = lista;

            this._RecetasRepository.Update(entity);

            return entity;
        }





        //*********************Agregar lo referente a las calificaciones por receta***********************
        


        //Método para insertar una nueva calificacion
        public Calificaciones InsertCalification(int idReceta, int idUsuario, byte Calificacion)
        {
            #region Validaciones
            #endregion
            //validar que la calificacion sea correcta (entre 1 y 5)
            var entity = new Calificaciones();
            entity.IdReceta = idReceta;
            entity.IdUsuario = idUsuario;
            entity.Calificacion = Calificacion;

            this._CalificacionesRepository.Insert(entity);

            return entity;
        }

        //Metodo eliminar una calificacion
        public void DeleteCalification(int idCalificacion)
        {
            var entity = new Calificaciones();
            entity.IdCalificacion = idCalificacion;

            this._CalificacionesRepository.Delete(entity);

           
        }

        //Editar una calificacion
        public Calificaciones UpdateCalification(int idCalification,byte calification)
        {

            var entity = new Calificaciones();
            entity.IdCalificacion = idCalification;
            entity.Calificacion = calification;

            this._CalificacionesRepository.Update(entity);

            return entity;
        }





        public bool validaciones(string dato)
        {
            if ((!string.IsNullOrEmpty(dato)) && (!string.IsNullOrWhiteSpace(dato)))
            {
                return true;
            }
            else { return false; }
        }

        public bool validarnumeros(int? dato)
        {
            if (dato>=0 || dato==null)
            {
                return true;
            }
            else { return false; }
        }
    }
}
