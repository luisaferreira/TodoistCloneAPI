using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoistCloneAPI.Models;
using TodoistCloneAPI.Shared.Interfaces.Repositories;

namespace TodoistCloneAPI.Controllers
{
    [ApiController]
    [Route("/api")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _TarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _TarefaRepository = tarefaRepository;
        }

        [HttpPost]
        [Route("/tarefas")]
        public IActionResult AdicionarTarefa(Tarefa tarefa)
        {
            var retornoSQL = _TarefaRepository.AdicionarTarefa(tarefa);

            return StatusCode(201, retornoSQL);
        }

        [HttpPut]
        [Route("/tarefas/{idTarefa}")]
        public IActionResult AtualizarTarefa(int idTarefa, Tarefa tarefa)
        {
            var retornoSQL = _TarefaRepository.AtualizarTarefa(idTarefa, tarefa);

            return StatusCode(200, retornoSQL);
        }

        [HttpDelete]
        [Route("/tarefas/{idTarefa}")]
        public IActionResult ExcluirTarefa(int idTarefa)
        {
            var retornoSQL = _TarefaRepository.ExcluirTarefa(idTarefa);

            return StatusCode(200, retornoSQL);
        }

        [HttpGet]
        [Route("/tarefa/{idTarefa}")]
        public IActionResult ObterTarefaPorId(int idTarefa)
        {
            var tarefa = _TarefaRepository.ObterTarefaPorId(idTarefa);

            return StatusCode(200, tarefa);
        }

        [HttpGet]
        [Route("/tarefas/{IdProjeto}")]
        public IActionResult ObterTarefasPorIdProjeto(int idProjeto)
        {
            var tarefas = _TarefaRepository.ObterTarefasPorIdProjeto(idProjeto);

            return StatusCode(200, tarefas);
        }
    }
}
