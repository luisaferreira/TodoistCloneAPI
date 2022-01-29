using System;
using System.Text;
using TodoistCloneAPI.Models;
using TodoistCloneAPI.Shared.Interfaces.Repositories;

namespace TodoistCloneAPI.Repositories
{
    public class TarefaEtiquetaRepository : ITarefaEtiquetaRepository
    {
        private readonly IDataBase _DataBase;

        public TarefaEtiquetaRepository(IDataBase dataBase)
        {
            _DataBase = dataBase;
        }

        public int AdicionarTarefaEtiqueta(TarefaEtiqueta tarefaEtiqueta)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TarefaEtiqueta(IdTarefa, IdEtiqueta)");
                sql.AppendLine($"VALUES ('{tarefaEtiqueta.IdTarefa}', '{tarefaEtiqueta.IdEtiqueta}')");

                return _DataBase.ExecutaQuery(sql.ToString());
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao adicionar tarefaEtiqueta: {e.Message}");
            }
        }

        public int ExcluirTarefaEtiqueta(int idTarefaEtiqueta)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("DELETE FROM TarefaEtiqueta");
                sql.AppendLine($"WHERE Id = '{idTarefaEtiqueta}'");

                return _DataBase.ExecutaQuery(sql.ToString());
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao excluir tarefaEtiqueta: {e.Message}");
            }
        }

        public TarefaEtiqueta ObterTarefaEtiquetaPorIdEtiqueta(int idEtiqueta)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("SELECT IdTarefa, IdEtiqueta FROM TarefaEtiqueta");
                sql.AppendLine($"WHERE IdEtiqueta = '{idEtiqueta}'");

                var retornoSQL = _DataBase.ExecutaSelect(sql.ToString());

                if (retornoSQL.Tables.Count > 0 && retornoSQL.Tables[0].Rows.Count > 0)
                {
                    var linha = retornoSQL.Tables[0].Rows[0];

                    var tarefaEtiqueta = new TarefaEtiqueta()
                    {
                        IdEtiqueta = Convert.ToInt32(linha["IdEtiqueta"]),
                        IdTarefa = Convert.ToInt32(linha["IdTarefa"])
                    };

                    return tarefaEtiqueta;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao obter tarefaEtiqueta por id de etiqueta: {e.Message}");
            }
        }

        public TarefaEtiqueta ObterTarefaEtiquetaPorIdTarefa(int idTarefa)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("SELECT IdTarefa, IdEtiqueta FROM TarefaEtiqueta");
                sql.AppendLine($"WHERE IdTarefa = '{idTarefa}'");

                var retornoSQL = _DataBase.ExecutaSelect(sql.ToString());

                if (retornoSQL.Tables.Count > 0 && retornoSQL.Tables[0].Rows.Count > 0)
                {
                    var linha = retornoSQL.Tables[0].Rows[0];

                    var tarefaEtiqueta = new TarefaEtiqueta()
                    {
                        IdEtiqueta = Convert.ToInt32(linha["IdEtiqueta"]),
                        IdTarefa = Convert.ToInt32(linha["IdTarefa"])
                    };

                    return tarefaEtiqueta;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao obter tarefaEtiqueta por id de tarefa: {e.Message}");
            }
        }
    }
}
