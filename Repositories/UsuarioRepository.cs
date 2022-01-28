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
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ObterUsuarios()
        {
            throw new NotImplementedException();
        }
    }
}