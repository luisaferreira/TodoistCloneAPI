using System.Collections.Generic;
using TodoistCloneAPI.Models;

namespace TodoistCloneAPI.Shared.Interfaces.Repositories
{
    public interface IProjetoRepository
    {
        int AdicionarProjeto(Projeto projeto);
        int AtualizarProjeto(int idProjeto, Projeto projeto);
        int ExcluirProjeto(int idProjeto);
        Projeto ObterProjetoPorId(int idProjeto);
        IEnumerable<Projeto> ObterProjetos(int idUsuario);
    }
}
