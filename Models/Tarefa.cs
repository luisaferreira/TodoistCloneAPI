using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoistCloneAPI.Models.Shared;

namespace TodoistCloneAPI.Models
{
    public class Tarefa : Entity
    {
        public int IdProjeto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataExecucao { get; set; }
        public bool Concluido { get; set; }
    }
}
