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
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoRepository _ProjetoRepository;

        public ProjetoController(IProjetoRepository projetoRepository)
        {
            _ProjetoRepository = projetoRepository;
        }

        [HttpPost]
        [Route("/projetos")]
        public IActionResult AdicionarProjeto(Projeto projeto)
        {
            var retornoSQL = _ProjetoRepository.AdicionarProjeto(projeto);
            
            return StatusCode(201, retornoSQL);
        }

        [HttpPut]
        [Route("/projetos/{idProjeto}")]
        public IActionResult AtualizarProjeto(int idProjeto, Projeto projeto)
        {
            var retornoSQL = _ProjetoRepository.AtualizarProjeto(idProjeto, projeto);

            return StatusCode(200, retornoSQL);
        }

        [HttpDelete]
        [Route("/projetos/{idProjeto}")]
        public IActionResult ExcluirProjeto(int idProjeto)
        {
            var retornoSQL = _ProjetoRepository.ExcluirProjeto(idProjeto);

            return StatusCode(200, retornoSQL);
        }

        [HttpGet]
        [Route("/projeto/{idProjeto}")]
        public IActionResult ObterProjetoPorId(int idProjeto)
        {
            var projeto = _ProjetoRepository.ObterProjetoPorId(idProjeto);

            return StatusCode(200, projeto);
        }

        [HttpGet]
        [Route("/projetos/{idUsuario}")]
        public IActionResult ObterProjetos(int idUsuario)
        {
            var projetos = _ProjetoRepository.ObterProjetos(idUsuario);

            return StatusCode(200, projetos);
        }
    }
}
