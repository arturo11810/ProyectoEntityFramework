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
    public class UsuariosCtrl
    {
        private readonly UsuariosRepository _repository;
        //constructor
        public UsuariosCtrl(RecetarioSocialContext RSC)
        {
            this._repository = new UsuariosRepository(RSC);
        }
        //Constructor que recibe el repositorio 
        public UsuariosCtrl(UsuariosRepository repository)
        {
            this._repository = repository;
        }

        //Método para obtener todos los usuarios
        public List<Usuario> Get()
        {
            return this._repository.Get(null,null).ToList();
        }
        
        //Método para buscar una usuario por id o nombre de usuario
        public Usuario GetUser(int? id, string nombreUsuario)
        {
            var result = this._repository.Get(id,nombreUsuario);
            if (result.Count != 1)//si encuntra mas de uno o ninguno retornara nulo
                return null;
            return result.First();//si lo encontró retornará la lista
        }

        //Método para insertar un nuevo usuario
        public Usuario InsertUser(string usuario, string contrasena, string nombre, string PApellido, string SApellido, DateTime FNacimiento, string correo)
        {
            #region Validaciones
            #endregion
            //Validar que los campos sean correctos: pendiente
            //validar que el nombre de usuario no exista
            if ((this._repository.Get(null, usuario)).Count() == 0)
            {
                var entity = new Usuario();
                entity.NombreUsuario = usuario;
                entity.Contrasena = contrasena;
                entity.Nombre = nombre;
                entity.PrimerApellido = PApellido;
                entity.SegundoApellido = SApellido;
                entity.FechaNacimiento = FNacimiento;
                entity.Correo = correo;

                this._repository.Insert(entity);

                return entity;
            }
            else { return null; }
        }

        //Metodo eliminar un usuario
        public void DeleteUsuario(int id)
        {

            var entity = new Usuario();
            entity.IdUsuario = id;

            this._repository.Delete(entity);

            //return entity;
        }

        //Metodo editar un usuarioo
        public Usuario Update(int id, string contrasena, string nombre, string papellido, string sapellido, DateTime fecha_nacimiento, string correo)
        {
            //validar que los campos sean validos: pendiente

            var entity = new Usuario();
            entity.IdUsuario = id;
            //nombre de usuario se queda igual
            entity.Contrasena = contrasena;
            entity.Nombre = nombre;
            entity.PrimerApellido = papellido;
            entity.SegundoApellido = sapellido;
            entity.FechaNacimiento = fecha_nacimiento;
            entity.Correo = correo;

            this._repository.Update(entity);

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
    }
}
