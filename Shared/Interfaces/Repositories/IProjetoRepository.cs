using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoistCloneAPI.Models;

namespace TodoistCloneAPI.Shared.Interfaces.Repositories
{
    public interface IProjetoRepository
    {
        int AdicionarProjeto(Projeto projeto);
        int AtualizarProjeto(int idProjeto, Projeto projeto);
        Projeto ObterProjetoPorId(int idProjeto);
        IEnumerable<Projeto> ObterProjetos();
    }
}
