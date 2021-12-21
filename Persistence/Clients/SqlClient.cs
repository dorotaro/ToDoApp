using MySql.Data.MySqlClient;
using System;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence
{
    public class SqlClient : ISqlClient
    {
        private readonly string _connectionString;

        public SqlClient (string connectionString)
        {
            _connectionString = connectionString;
        }


        MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();

        public async Task Execute<T>(string query, object param)
        {
            using var connection = new MySqlConnection(_connectionString);
            
            connection.Open();
            
            await connection.ExecuteAsync(query, param);
        }

        public async Task<IEnumerable<T>> Query<T>(string query, object param=null)
        {
            using var connection = new MySqlConnection(_connectionString);
            
            connection.Open();
            
            return await connection.QueryAsync<T>(query, param);
        }
    }
}
