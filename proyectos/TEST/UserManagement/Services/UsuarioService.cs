using System.Collections.Generic;
using UserManagement.Interfaces;
using UserManagement.Models;

namespace UserManagement.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly List<Usuario> _usuarios = new List<Usuario>();

        public Usuario? ObtenerUsuarioPorId(int id)  // Se indica que puede retornar null
        {
            return _usuarios.Find(u => u.Id == id);  // Si no se encuentra, retornará null
        }

        public void CrearUsuario(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        public void ActualizarUsuario(int id, Usuario usuario)
        {
            var existente = ObtenerUsuarioPorId(id);
            if (existente != null)
            {
                existente.Nombre = usuario.Nombre;
                existente.Email = usuario.Email;
            }
        }

        public void EliminarUsuario(int id)
        {
            var usuario = ObtenerUsuarioPorId(id);
            if (usuario != null)
            {
                _usuarios.Remove(usuario);
            }
        }
    }
}