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
    public class CategoriasCtrl
    {
        private readonly CategoriasRepository _repository;
        //constructor
        public CategoriasCtrl(RecetarioSocialContext RSC)
        {
            this._repository = new CategoriasRepository(RSC);
        }
        //Constructor que recibe el repositorio 
        public CategoriasCtrl(CategoriasRepository repository)
        {
            this._repository = repository;
        }


        //Método para obtener las categorias
        public List<Categoria> Get(string Nombre)
        {
            return this._repository.Get(null, Nombre).ToList();
        }

        //obtener una categoria por id
        public Categoria GetByIdOrName(int? id)
        {
            return (this._repository.Get(id,null).ToList()).First();
        }

        //Método para insertar nueva categoria
        public Categoria Insert(string Nombre)
        {
            #region Validaciones
            #endregion
            //validar que el nombre sea correcto

            var entity = new Categoria();
            entity.Nombre = Nombre;

            this._repository.Insert(entity);

            return entity;
        }

        
        //Metodo eliminar una categoria
        public void Delete(int id)
        {
            //verificar si existe la categoria
            var entity = new Categoria();
            entity.IdCategoria = id;

            this._repository.Delete(entity);

            //return entity;
        }


    }
}
