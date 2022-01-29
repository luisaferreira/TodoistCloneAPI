using System.Collections.Generic;
using TodoistCloneAPI.Models;

namespace TodoistCloneAPI.Shared.Interfaces.Repositories
{
    public interface ITarefaRepository
    {
        int AdicionarTarefa(Tarefa tarefa);
        int AtualizarTarefa(int idTarefa, Tarefa tarefa);
        int ExcluirTarefa(int idTarefa);
        Tarefa ObterTarefaPorId(int idTarefa);
        IEnumerable<Tarefa> ObterTarefasPorIdProjeto(int idProjeto);
    }
}
