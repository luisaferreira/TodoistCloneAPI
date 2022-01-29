using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoistCloneAPI.Models;

namespace TodoistCloneAPI.Shared.Interfaces.Repositories
{
    public interface ITarefaEtiquetaRepository
    {
        int AdicionarTarefaEtiqueta(TarefaEtiqueta tarefaEtiqueta);
        int ExcluirTarefaEtiqueta(int idTarefaEtiqueta);
        TarefaEtiqueta ObterTarefaEtiquetaPorIdTarefa(int idTarefa);
        TarefaEtiqueta ObterTarefaEtiquetaPorIdEtiqueta(int idEtiqueta);
    }
}
