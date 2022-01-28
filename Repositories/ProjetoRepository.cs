using System;
using System.Collections.Generic;
using System.Text;
using TodoistCloneAPI.Models;
using TodoistCloneAPI.Shared.Interfaces.Repositories;

namespace TodoistCloneAPI.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly IDataBase _DataBase;
        public ProjetoRepository(IDataBase dataBase)
        {
            _DataBase = dataBase;
        }

        public int AdicionarProjeto(Projeto projeto)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Projeto(IdUsuario, Nome, Favorito, Cor)");
                sql.AppendLine($"VALUES ('{projeto.IdUsuario}','{projeto.Nome}', '{Convert.ToInt32(projeto.Favorito)}', '{projeto.Cor}' )");

                return _DataBase.ExecutaQuery(sql.ToString());
            }
            catch (Exception e)
            { 
                throw new Exception($"Erro ao adicionar projeto: {e.Message}");
            }
        }

        public int AtualizarProjeto(int idProjeto, Projeto projeto)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("UPDATE Projeto");
                sql.AppendLine($"SET IdUsuario = '{projeto.IdUsuario}', Nome = '{projeto.Nome}', Favorito = '{Convert.ToInt32(projeto.Favorito)}', Cor = '{projeto.Cor}'");
                sql.AppendLine($"WHERE Id = '{idProjeto}'");

                return _DataBase.ExecutaQuery(sql.ToString());
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao atualizar projeto: {e.Message}");
            }
        }

        public int ExcluirProjeto(int idProjeto)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("DELETE FROM Projeto");
                sql.AppendLine($"WHERE Id = '{idProjeto}'");

                return _DataBase.ExecutaQuery(sql.ToString());
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao excluir projeto: {e.Message}");
            }
        }

        public Projeto ObterProjetoPorId(int idProjeto)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("SELECT Id, IdUsuario, Nome, Favorito, Cor FROM Projeto");
                sql.AppendLine($"WHERE Id = '{idProjeto}'");

                var retornoSQL = _DataBase.ExecutaSelect(sql.ToString());

                if (retornoSQL.Tables.Count > 0 && retornoSQL.Tables[0].Rows.Count > 0)
                {
                    var linha = retornoSQL.Tables[0].Rows[0];

                    var projeto = new Projeto()
                    {
                        Id = Convert.ToInt32(linha["Id"]),
                        IdUsuario = Convert.ToInt32(linha["IdUsuario"]),
                        Nome = linha["Nome"].ToString(),
                        Cor = linha["Cor"].ToString(),
                        Favorito = Convert.ToBoolean(linha["Favorito"])
                    };

                    return projeto;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao obter projeto por id: {e.Message}");
            }
        }

        public IEnumerable<Projeto> ObterProjetos(int idUsuario)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("SELECT Id, IdUsuario, Nome, Favorito, Cor FROM Projeto");
                sql.AppendLine($"WHERE IdUsuario = '{idUsuario}'");

                var retornoSQL = _DataBase.ExecutaSelect(sql.ToString());

                if (retornoSQL.Tables.Count > 0 && retornoSQL.Tables[0].Rows.Count > 0)
                {
                    var linhas = retornoSQL.Tables[0].Rows;
                    var tamanho = retornoSQL.Tables[0].Rows.Count;
                    var projetos = new List<Projeto>();
                    Projeto projeto;

                    for (int i = 0; i < tamanho; i++)
                    {
                        projeto = new Projeto()
                        {
                            Id = Convert.ToInt32(linhas[i]["Id"]),
                            IdUsuario = Convert.ToInt32(linhas[i]["IdUsuario"]),
                            Nome = linhas[i]["Nome"].ToString(),
                            Favorito = Convert.ToBoolean(linhas[i]["Favorito"]),
                            Cor = linhas[i]["Cor"].ToString()
                        };

                        projetos.Add(projeto);
                    }

                    return projetos;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao obter projetos: {e.Message}");
            }
        }
    }
}
