using TodoistCloneAPI.Models.Shared;

namespace TodoistCloneAPI.Models
{
    public class Projeto : Entity
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public bool Favorito { get; set; }
        public string Cor { get; set; }
    }
}