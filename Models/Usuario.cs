using TodoistCloneAPI.Models.Shared;

namespace TodoistCloneAPI.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}
