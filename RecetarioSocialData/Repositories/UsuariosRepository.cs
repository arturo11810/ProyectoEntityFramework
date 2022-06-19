using RecetarioSocialDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetarioSocialData.Repositories
{
    public class UsuariosRepository
    {
        //Variable para trabajar en el contexto de nuestra base de datos
        private RecetarioSocialContext _context;

        //Constructor
        public UsuariosRepository()
        {
            this._context = new RecetarioSocialContext();
        }

        //Constructor que recibe el contexto (si ya existe el contexto)
        public UsuariosRepository(RecetarioSocialContext context)
        {
            this._context = context;
        }

        //Método para obtener a un usuario por id o nombre u obtener a todos los usuarios.
        public List<Usuario> Get(int? id, string NombreUsuario)
        {
            var miConsulta = this._context.Usuarios.AsQueryable();//trae toda la tabla

            if (!string.IsNullOrWhiteSpace(NombreUsuario) && !string.IsNullOrEmpty(NombreUsuario))
                miConsulta = miConsulta.Where(t => t.NombreUsuario.Contains(NombreUsuario));//le aplica un where a la tabla
            if (id != null)//si el id no viene vacio buscará por id
                miConsulta = miConsulta.Where(c => c.IdUsuario == id);//donde el id que se esta buscando coincida con alguno de la bd
            
            return miConsulta.ToList();
        }


        //Método para insertar un nuevo usuario
        public void Insert(Usuario user)
        {
            this._context.Usuarios.Add(user);
            this._context.SaveChanges();
        }

        //Método para eliminar un usuario
        public void Delete(Usuario user)
        {
            var obj = this._context.Usuarios.Find(user.IdUsuario);
            _context.Entry(obj).State = System.Data.Entity.EntityState.Deleted;

            this._context.SaveChanges();
        }

        //Método para actualizar la informacion de un usuario
        public void Update(Usuario user)
        {
            var obj = this._context.Usuarios.Find(user.IdUsuario);
            obj.IdUsuario = user.IdUsuario;
            obj.Contrasena=user.Contrasena;
            obj.Nombre = user.Nombre;
            obj.PrimerApellido = user.PrimerApellido;
            obj.SegundoApellido = user.SegundoApellido;
            obj.FechaNacimiento = user.FechaNacimiento;
            obj.Correo = user.Correo;

            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;

            this._context.SaveChanges();
        }

    }
}
