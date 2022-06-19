using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetarioSocialData;
using RecetarioSocialData.Repositories;
using RecetarioSocialDomain.Entities;

namespace RecetarioSocialServices.Services
{
    public class PublicacionesCtrl
    {
        private readonly PublicacionesRepository _PublicacionesRepository;
        private readonly ComentariosRepository _ComentariosRepository;

        //constructor
        public PublicacionesCtrl(RecetarioSocialContext RSC)
        {
            this._PublicacionesRepository = new PublicacionesRepository(RSC);
            this._ComentariosRepository = new ComentariosRepository(RSC);

        }
        //Constructor que recibe el repositorio de publicaciones
        public PublicacionesCtrl(PublicacionesRepository PublicacionesRepository, ComentariosRepository ComentariosRepository, RecetasRepository RecetasRepository)
        {
            this._PublicacionesRepository = PublicacionesRepository;
            this._ComentariosRepository = ComentariosRepository;

        }

        //Método para obtener todas las publicaciones, las de una receta, las de un usuario o las que su receta tenga un estado determinado (se pueden enviar fechas para saber las publicaciones en un rango)
        public List<Publicacion> Get(int? idReceta, int? idUsuario, bool? estadoReceta, DateTime? from, DateTime? to, string tituloReceta, int? tiempoMaximoPreparacion, int? numeroMinimoPorciones)
        {
            return this._PublicacionesRepository.Get(null, from, to, idReceta, idUsuario, estadoReceta, tituloReceta,tiempoMaximoPreparacion,numeroMinimoPorciones).OrderByDescending(p => p.FechaHoraPublicacion).ToList();
        }

        //Método para buscar una publicacion en especifico por su id
        public Publicacion GetById(int id)
        {
            var result = this._PublicacionesRepository.Get(id, null, null,null,null,null,null,null,null);
            if (result.Count != 1)
                return null;
            return result.First();
        }


        //Método para insertar nueva publicacion
        public Publicacion Insert(DateTime FechaHora, string descripcion, int idReceta)
        {
            #region Validaciones
            #endregion
            //validar que exista la receta y que la fecha sea correcta: pendiente

            var entity = new Publicacion();
            entity.FechaHoraPublicacion = FechaHora;
            entity.Descripcion = descripcion;
            entity.IdReceta = idReceta;

            this._PublicacionesRepository.Insert(entity);

            return entity;
        }


        //Metodo eliminar una publicacion por su id
        public void Delete(int id)
        {
            //verificar si existe 
            var entity = new Publicacion();
            entity.IdPublicacion = id;

            this._PublicacionesRepository.Delete(entity);

            //return entity;
        }

        //modificar una publicacion
        public Publicacion Update(int id, string descripcion)
        {
            //aplicar validaciones
            //verificar si existe la publicacion
            var entity = new Publicacion();
            entity.IdPublicacion = id;
            entity.Descripcion = descripcion;
            //el id de la receta y la fecha no cambian


            this._PublicacionesRepository.Update(entity);

            return entity;
        }





        //******************************* para los comentarios **********************************

        //Método para obtener todos los comentarios de una publicacion del mas reciente al mas viejo
        //(En teroria no se usa por que al buscar una publicacion ya trae implicita una lista de comentarios)
        public List<Comentario> GetCommentsOnPublication(int? id_publicacion)
        {
            return this._ComentariosRepository.Get(id_publicacion).OrderByDescending(p => p.FechaComentario).ToList();
        }


        //Método para insertar nuevo comentario
        public Comentario InsertComment(DateTime FechaHora, string descripcion, int idPublicacion,int idUsuario)
        {
            #region Validaciones
            #endregion

            var entity = new Comentario();
            entity.FechaComentario = FechaHora;
            entity.Descripcion = descripcion;
            entity.IdPublicacion = idPublicacion;
            entity.IdUsuario = idUsuario;

            this._ComentariosRepository.Insert(entity);

            return entity;
        }


        //Metodo eliminar un comentario de una publicacion
        public void DeleteComment(int id)
        {
            var entity = new Comentario();
            entity.IdComentario = id;

            this._ComentariosRepository.Delete(entity);

            //return entity;
        }

        //modificar un comentario
        public Comentario UpdateComment(int id,string descripcion)
        {
            //aplicar validaciones
            //verificar si existe el comentario
            var entity = new Comentario();
            entity.IdComentario = id;
            entity.Descripcion = descripcion;


            this._ComentariosRepository.Update(entity);

            return entity;
        }
    }
}
