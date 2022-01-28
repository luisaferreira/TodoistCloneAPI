using TodoistCloneAPI.Models.Shared;

namespace TodoistCloneAPI.Models
{
    public class Etiqueta : Entity
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
    }
}
