using System.Collections.Generic;
using TodoistCloneAPI.Models;

namespace TodoistCloneAPI.Shared.Interfaces.Repositories
{
    public interface IEtiquetaRepository
    {
        int AdicionarEtiqueta(Etiqueta etiqueta);
        int AtualizarEtiqueta(int idEtiqueta, Etiqueta etiqueta);
        int ExcluirEtiqueta(int idEtiqueta);
        Etiqueta ObterEtiquetaPorId(int idEtiqueta);
        IEnumerable<Etiqueta> ObterEtiquetas(int idUsuario);
    }
}
