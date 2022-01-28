using System.Collections.Generic;
using TodoistCloneAPI.Models;

namespace TodoistCloneAPI.Shared.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        int AdicionarUsuario(Usuario usuario);
        int AtualizarUsuario(int idUsuario, Usuario usuario);
        Usuario ObterUsuarioPorId(int idUsuario);
        IEnumerable<Usuario> ObterUsuarios();
    }
}