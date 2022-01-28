using System;
using System.Collections.Generic;
using TodoistCloneAPI.Models;
using TodoistCloneAPI.Shared.Interfaces.Repositories;

namespace TodoistCloneAPI.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        public int AdicionarProjeto(Projeto projeto)
        {
            throw new NotImplementedException();
        }

        public int AtualizarProjeto(int idProjeto, Projeto projeto)
        {
            throw new NotImplementedException();
        }

        public Projeto ObterProjetoPorId(int idProjeto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Projeto> ObterProjetos()
        {
            throw new NotImplementedException();
        }
    }
}
