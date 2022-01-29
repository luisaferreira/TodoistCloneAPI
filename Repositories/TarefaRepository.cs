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
                throw new Exception($"Erro ao adicionar tarefa: {e.Message}");
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
                throw new Exception($"Erro ao atualizar tarefa: {e.Message}");
            }
        }

        public int ExcluirTarefa(int idTarefa)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("DELETE FROM Tarefa");
                sql.AppendLine($"WHERE Id = '{idTarefa}'");

                return _DataBase.ExecutaQuery(sql.ToString());
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao excluir tarefa: {e.Message}");
            }
        }

        public Tarefa ObterTarefaPorId(int idTarefa)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("SELECT Id, IdProjeto, Nome, Descricao, DataExecucao, Concluido FROM Tarefa");
                sql.AppendLine($"WHERE Id = '{idTarefa}'");

                var retornoSQL = _DataBase.ExecutaSelect(sql.ToString());

                if (retornoSQL.Tables.Count > 0 && retornoSQL.Tables[0].Rows.Count > 0)
                {
                    var linha = retornoSQL.Tables[0].Rows[0];

                    var tarefa = new Tarefa()
                    {
                        Id = Convert.ToInt32(linha["Id"]),
                        IdProjeto = Convert.ToInt32(linha["IdProjeto"]),
                        Nome = linha["Nome"].ToString(),
                        Descricao = linha["Descricao"] != DBNull.Value ? linha["Descricao"].ToString() : "",
                        DataExecucao = linha["DataExecucao"] != DBNull.Value ? Convert.ToDateTime(linha["DataExecucao"]) : Convert.ToDateTime("01/01/0001 00:00:00"),
                        Concluido = Convert.ToBoolean(linha["Concluido"])
                    };

                    return tarefa;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao obter tarefa por id: {e.Message}");
            }
        }

        public IEnumerable<Tarefa> ObterTarefasPorIdProjeto(int idProjeto)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("SELECT Id, IdProjeto, Nome, Descricao, DataExecucao, Concluido FROM Tarefa");
                sql.AppendLine($"WHERE IdProjeto = '{idProjeto}'");

                var retornoSQL = _DataBase.ExecutaSelect(sql.ToString());
                if (retornoSQL.Tables.Count > 0 && retornoSQL.Tables[0].Rows.Count > 0)
                {
                    var linhas = retornoSQL.Tables[0].Rows;
                    var tamanho = retornoSQL.Tables[0].Rows.Count;
                    var tarefas = new List<Tarefa>();
                    Tarefa tarefa;

                    for (int i = 0; i < tamanho; i++)
                    {
                        tarefa = new Tarefa()
                        {
                            Id = Convert.ToInt32(linhas[i]["Id"]),
                            IdProjeto = Convert.ToInt32(linhas[i]["IdProjeto"]),
                            Nome = linhas[i]["Nome"].ToString(),
                            Descricao = linhas[i]["Descricao"] != DBNull.Value ? linhas[i]["Descricao"].ToString() : "",
                            DataExecucao = linhas[i]["DataExecucao"] != DBNull.Value ? Convert.ToDateTime(linhas[i]["DataExecucao"]) : Convert.ToDateTime("01/01/0001 00:00:00"),
                            Concluido = Convert.ToBoolean(linhas[i]["Concluido"])
                        };

                        tarefas.Add(tarefa);
                    }

                    return tarefas;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao obter tarefas por id de projeto: {e.Message}");
            }
        }
    }
}
