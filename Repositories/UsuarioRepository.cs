using System;
using System.Collections.Generic;
using System.Text;
using TodoistCloneAPI.Models;
using TodoistCloneAPI.Shared.Interfaces.Repositories;

namespace TodoistCloneAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly IDataBase _DataBase;

        public UsuarioRepository(IDataBase dataBase)
        {
            _DataBase = dataBase;
        }

        public int AdicionarUsuario(Usuario usuario)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Usuario(Nome, Email, Senha, Ativo)");
                sql.AppendLine($"VALUES ('{usuario.Nome}', '{usuario.Email}', '{usuario.Senha}', '{usuario.Ativo}')");

                return _DataBase.ExecutaQuery(sql.ToString());
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao adicionar usuário: {e.Message}");
            }
        }

        public int AtualizarUsuario(int idUsuario, Usuario usuario)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("UPDATE Usuario");
                sql.AppendLine($"SET Nome = '{usuario.Nome}', Email = '{usuario.Email}', Senha = '{usuario.Senha}', Ativo = '{Convert.ToInt32(usuario.Ativo)}'");
                sql.AppendLine($"WHERE Id = '{idUsuario}'");

                return _DataBase.ExecutaQuery(sql.ToString());
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao atualizar usuário: {e.Message}");
            }
        }

        public Usuario ObterUsuarioPorId(int idUsuario)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendLine("SELECT Id, Nome, Email, Senha, Ativo FROM Usuario");
                sql.AppendLine($"WHERE Id = '{idUsuario}'");

                var retornoSQL = _DataBase.ExecutaSelect(sql.ToString());
                if (retornoSQL.Tables.Count > 0 && retornoSQL.Tables[0].Rows.Count > 0)
                {
                    var linha = retornoSQL.Tables[0].Rows[0];

                    var usuario = new Usuario()
                    {
                        Id=Convert.ToInt32(linha["Id"]),
                        Nome = linha["Nome"].ToString(),
                        Email = linha["Email"].ToString(),
                        Senha = linha["Senha"].ToString(),
                        Ativo = Convert.ToBoolean(linha["Ativo"])
                    };

                    return usuario;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw new Exception($"Erro ao obter usuário por id: {e.Message}");
            }
        }

        public IEnumerable<Usuario> ObterUsuarios()
        {
            throw new NotImplementedException();
        }
    }
}