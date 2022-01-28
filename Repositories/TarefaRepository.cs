using System;
using System.Collections.Generic;
using System.Text;
using TodoistCloneAPI.Models;
using TodoistCloneAPI.Shared.Interfaces.Repositories;

namespace TodoistCloneAPI.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        public readonly IDataBase _DataBase;

        public TarefaRepository(IDataBase dataBase)
        {
            _DataBase = dataBase;
        }

        public int AdicionarTarefa(Tarefa tarefa)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Tarefa(IdProjeto, Nome, Descricao, DataExecucao, Concluido)");
                sql.AppendLine($"VALUES ('{tarefa.IdProjeto}', '{tarefa.Nome}', '{tarefa.Descricao}', '{tarefa.DataExecucao}', '{tarefa.Concluido}')");
                
                return _DataBase.ExecutaQuery(sql.ToString());
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao adicionar usuário: {e.Message}");
            }
        }

        public int AtualizarTarefa(int idTarefa, Tarefa tarefa)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("UPDATE Tarefa");
                sql.AppendLine($"SET IdProjeto = '{tarefa.IdProjeto}', Nome = '{tarefa.Nome}', Descricao = '{tarefa.Descricao}', DataExecucao = '{tarefa.DataExecucao}'," +
                    $"Concluido = '{Convert.ToInt32(tarefa.Concluido)}'");
                sql.AppendLine($"WHERE Id = '{idTarefa}'");

                return _DataBase.ExecutaQuery(sql.ToString());
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao atualizar usuário: {e.Message}");
            }
        }

        public Tarefa ObterTarefaPorId(int idTarefa)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tarefa> ObterTarefas()
        {
            throw new NotImplementedException();
        }
    }
}
