using Microsoft.AspNetCore.Mvc;
using TodoistCloneAPI.Models;
using TodoistCloneAPI.Shared.Interfaces.Repositories;

namespace TodoistCloneAPI.Controllers
{
    [ApiController]
    [Route("/api")]
    public class TarefaEtiquetaController : ControllerBase
    {
        private readonly ITarefaEtiquetaRepository _TarefaEtiquetaRepository;

        public TarefaEtiquetaController(ITarefaEtiquetaRepository tarefaEtiquetaRepository)
        {
            _TarefaEtiquetaRepository = tarefaEtiquetaRepository;
        }

        [HttpPost]
        [Route("/tarefaEtiquetas")]
        public IActionResult AdicionarTarefaEtiqueta(TarefaEtiqueta tarefaEtiqueta)
        {
            var retornoSQL = _TarefaEtiquetaRepository.AdicionarTarefaEtiqueta(tarefaEtiqueta);

            return StatusCode(200, retornoSQL);
        }

        [HttpDelete]
        [Route("/tarefaEtiqueta/{idTarefasEtiquetas}")]
        public IActionResult ExcluirTarefaEtiqueta(int idTarefaEtiqueta)
        {
            var retornoSQL = _TarefaEtiquetaRepository.ExcluirTarefaEtiqueta(idTarefaEtiqueta);

            return StatusCode(200, retornoSQL);
        }

        [HttpGet]
        [Route("/tarefasEtiqueta/{idEtiqueta}")]
        public IActionResult ObterTarefaEtiquetaPorIdEtiqueta(int idEtiqueta)
        {
            var tarefaEtiqueta = _TarefaEtiquetaRepository.ObterTarefaEtiquetaPorIdEtiqueta(idEtiqueta);

            return StatusCode(200, tarefaEtiqueta);
        }

        [HttpGet]
        [Route("/tarefaEtiquetas/{idTarefa}")]
        public IActionResult ObterTarefaEtiquetaPorIdTarefa(int idTarefa)
        {
            var tarefaEtiqueta = _TarefaEtiquetaRepository.ObterTarefaEtiquetaPorIdEtiqueta(idTarefa);

            return StatusCode(200, tarefaEtiqueta);
        }
    }
}
