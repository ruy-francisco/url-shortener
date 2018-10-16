using Domain.Contracts;
using Dapper;
using MySql.Data.MySqlClient;

namespace Repository.MySql
{
    public class UrlRepository : IUrlRepository
    {
        private readonly string _connectionString;

        public UrlRepository(string connectionString) {
            _connectionString = connectionString;
        }

        public int GetId(string url)
        {
            throw new System.NotImplementedException();
        }

        public int Save(string url)
        {
            throw new System.NotImplementedException();
        }
    }
}