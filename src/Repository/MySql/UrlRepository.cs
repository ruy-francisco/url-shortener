using Domain.Contracts;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace Repository.MySql
{
    public class UrlRepository : IUrlRepository
    {
        private readonly string _connectionString;

        public UrlRepository() {
            _connectionString = string.Format("SERVER={0};DATABASE={1};UID={2};PASSWORD={3};SslMode=none",
                "sql2.freemysqlhosting.net", "sql2261698", "sql2261698", "eM9%jM1*");
        }

        public async Task<int> GetId(string url)
        {
            url = url.Trim();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "select id from url where full_url = @url order by id desc limit 1";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@url", url);
                    var dbResult = await command.ExecuteReaderAsync();

                    while (dbResult.Read())
                    {
                        var returnedId = dbResult.GetInt32(0);
                        return returnedId;
                    }

                    return 0;
                }
            }
        }

        public async Task<string> GetOriginalUrl(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "select full_url from url where id = @id limit 1";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@id", id);
                    var dbResult = await command.ExecuteReaderAsync();

                    var returnedUrl = string.Empty;

                    while (dbResult.Read())
                    {
                        returnedUrl = dbResult.GetString(0);
                    }

                    return returnedUrl;
                }
            }
        }

        public async Task<int> Save(string url)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "insert into url (full_url) values (@url)";

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@url", url);
                    var dbResult = await command.ExecuteNonQueryAsync();

                    return await GetId(url);
                }
            }
        }
    }
}