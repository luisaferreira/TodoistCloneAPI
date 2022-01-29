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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _UsuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _UsuarioRepository = usuarioRepository;
        }

        [HttpPost]
        [Route("/usuarios")]
        public IActionResult AdicionarUsuario(Usuario usuario)
        {
            var retornoSQL = _UsuarioRepository.AdicionarUsuario(usuario);

            return StatusCode(201, retornoSQL);
        }

        [HttpPut]
        [Route("/usuarios/{idUsuario}")]
        public IActionResult AtualizarUsuario(int idUsuario, Usuario usuario)
        {
            var retornoSQL = _UsuarioRepository.AtualizarUsuario(idUsuario, usuario);

            return StatusCode(200, retornoSQL);
        }

        [HttpDelete]
        [Route("/usuarios/{idUsuario}")]
        public IActionResult ExcluirUsuario(int idUsuario)
        {
            var retornoSQL = _UsuarioRepository.ExcluirUsuario(idUsuario);

            return StatusCode(200, retornoSQL);
        }
        [HttpGet]
        [Route("/usuarios/{idUsuario}")]
        public IActionResult ObterUsuarioPorId(int idUsuario)
        {
            var usuario = _UsuarioRepository.ObterUsuarioPorId(idUsuario);

            return StatusCode(200, usuario);
        }
    }
}
