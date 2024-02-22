using MyBooking.Application.Abstractions.Data;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooking.Infrastructure.Data
{
    internal sealed class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connString;

        public SqlConnectionFactory(string connString)
        {
            _connString = connString;
        }
        public IDbConnection CreateConnection()
        {
            var conn = new NpgsqlConnection(_connString);
            conn.Open();

            return conn;
        }
    }
}
