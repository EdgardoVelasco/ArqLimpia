using UserManagement.Models;

namespace UserManagement.Interfaces
{
    public interface IUsuarioService
    {
        Usuario? ObtenerUsuarioPorId(int id);  // Permite devolver null
        void CrearUsuario(Usuario usuario);
        void ActualizarUsuario(int id, Usuario usuario);
        void EliminarUsuario(int id);
    }
}