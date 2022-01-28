using Microsoft.AspNetCore.Mvc;
using TodoistCloneAPI.Models;
using TodoistCloneAPI.Shared.Interfaces.Repositories;

namespace TodoistCloneAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class EtiquetaController : ControllerBase
    {
        private readonly IEtiquetaRepository _EtiquetaRepository;   
        
        public EtiquetaController(IEtiquetaRepository etiquetaRepository)
        {
            _EtiquetaRepository = etiquetaRepository;
        }

        [HttpPost]
        [Route("/etiquetas")]
        public IActionResult AdicionarEtiqueta(Etiqueta etiqueta)
        {
            var retornoSQL = _EtiquetaRepository.AdicionarEtiqueta(etiqueta);

            return StatusCode(201);
        }

        [HttpPut]
        [Route("/etiquetas/{idEtiqueta}")]
        public IActionResult AtualizarEtiqueta(int idEtiqueta, Etiqueta etiqueta)
        {
            var retornoSQL = _EtiquetaRepository.AtualizarEtiqueta(idEtiqueta, etiqueta);

            return StatusCode(200, retornoSQL);
        }

        [HttpDelete]
        [Route("/etiquetas/{idEtiqueta}")]
        public IActionResult ExcluirEtiqueta(int idEtiqueta)
        {
            var retornoSQL = _EtiquetaRepository.ExcluirEtiqueta(idEtiqueta);

            return StatusCode(200, retornoSQL);
        }

        [HttpGet]
        [Route("/etiquetas/{idEtiqueta}")]
        public IActionResult ObterEtiquetaPorId(int idEtiqueta)
        {
            var etiqueta = _EtiquetaRepository.ObterEtiquetaPorId(idEtiqueta);
            
            return StatusCode(200, etiqueta);
        }

        [HttpGet]
        [Route("/etiquetas/{idUsuario}")]
        public IActionResult ObterEtiquetas(int idUsuario)
        {
            var etiquetas = _EtiquetaRepository.ObterEtiquetas(idUsuario);

            return StatusCode(200, etiquetas);
        }
    }
}
