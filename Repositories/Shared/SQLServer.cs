using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TodoistCloneAPI.Shared.Interfaces.Repositories;

namespace TodoistCloneAPI.Repositories.Shared
{
    public class SQLServer : IDataBase
    {
        private readonly IConfiguration _Configuration;
        private string _Conexao { get; set; }

        public SQLServer(IConfiguration configuration)
        {
            _Configuration = configuration;
            _Conexao = configuration.GetSection($"ConnectionStrings:TodoistCloneAPI").Value;
        }

        public int ExecutaQuery(string sql)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(_Conexao))
                {
                    using (var sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        sqlCommand.Connection.Open();
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = sql;
                        sqlCommand.CommandTimeout = 300;
                        var id = Convert.ToInt32(sqlCommand.ExecuteScalar());
                        return id;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet ExecutaSelect(string sql)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(_Conexao))
                {
                    using (var dataAdapter = new SqlDataAdapter(sql, sqlConnection))
                    {
                        dataAdapter.SelectCommand.CommandTimeout = 300;

                        using (var dataSet = new DataSet())
                        {
                            dataAdapter.Fill(dataSet);
                            return dataSet;
                        }
                    }
                }
            }

            catch (Exception e)
            {
                throw new Exception($"Erro ao executar select: {e.Message}");
            }
        }
    }
}
