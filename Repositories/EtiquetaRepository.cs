using System;
using System.Collections.Generic;
using System.Text;
using TodoistCloneAPI.Models;
using TodoistCloneAPI.Shared.Interfaces.Repositories;

namespace TodoistCloneAPI.Repositories
{
    public class EtiquetaRepository : IEtiquetaRepository
    {
        private readonly IDataBase _DataBase;

        public EtiquetaRepository(IDataBase dataBase)
        {
            _DataBase = dataBase;
        }

        public int AdicionarEtiqueta(Etiqueta etiqueta)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Etiqueta(IdUsuario, Nome, Cor)");
                sql.AppendLine($"VALUES ('{etiqueta.IdUsuario}', '{etiqueta.Nome}', '{etiqueta.Cor}')");

                return _DataBase.ExecutaQuery(sql.ToString());
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao adicionar etiqueta: {e.Message}");
            }
        }

        public int AtualizarEtiqueta(int idEtiqueta, Etiqueta etiqueta)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("UPDATE Etiqueta");
                sql.AppendLine($"SET IdUsuario = '{etiqueta.IdUsuario}', Nome = '{etiqueta.Nome}', Cor = '{etiqueta.Cor}'");
                sql.AppendLine($"WHERE Id = '{idEtiqueta}'");

                return _DataBase.ExecutaQuery(sql.ToString());
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao atualizar etiqueta: {e.Message}");
            }
        }

        public int ExcluirEtiqueta(int idEtiqueta)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("DELETE FROM Etiqueta");
                sql.AppendLine($"WHERE Id = '{idEtiqueta}'");

                return _DataBase.ExecutaQuery(sql.ToString());
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao excluir etiqueta: {e.Message}");
            }
        }

        public Etiqueta ObterEtiquetaPorId(int idEtiqueta)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("SELECT Id, IdUsuario, Nome, Cor FROM Etiqueta");
                sql.AppendLine($"WHERE Id = '{idEtiqueta}'");

                var retornoSQL = _DataBase.ExecutaSelect(sql.ToString());

                if (retornoSQL.Tables.Count > 0 && retornoSQL.Tables[0].Rows.Count > 0)
                {
                    var linha = retornoSQL.Tables[0].Rows[0];
                    
                    var etiqueta = new Etiqueta()
                    {
                        Id = Convert.ToInt32(linha["Id"]),
                        IdUsuario = Convert.ToInt32(linha["IdUsuario"]),
                        Nome = linha["Nome"].ToString(),
                        Cor = linha["Cor"].ToString()
                    };

                    return etiqueta;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao obter etiqueta por id: {e.Message}");
            }
        }

        public IEnumerable<Etiqueta> ObterEtiquetas(int idUsuario)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("SELECT Id, IdUsuario, Nome, Cor FROM Etiqueta");
                sql.AppendLine($"WHERE IdUsuario = '{idUsuario}'");

                var retornoSQL = _DataBase.ExecutaSelect(sql.ToString());

                if (retornoSQL.Tables.Count > 0 && retornoSQL.Tables[0].Rows.Count > 0)
                {
                    var linhas = retornoSQL.Tables[0].Rows;
                    var tamanho = retornoSQL.Tables[0].Rows.Count;
                    var etiquetas = new List<Etiqueta>();
                    Etiqueta etiqueta;

                    for (int i = 0; i < tamanho; i++)
                    {
                        etiqueta = new Etiqueta()
                        {
                            Id = Convert.ToInt32(linhas[i]["Id"]),
                            IdUsuario = Convert.ToInt32(linhas[i]["IdUsuario"]),
                            Nome = linhas[i]["Nome"].ToString(),
                            Cor = linhas[i]["Cor"].ToString()
                        };
                    }

                    return etiquetas;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao obter etiqueta: {e.Message}");
            }
        }
    }
}