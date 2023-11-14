using Dapper;
using Npgsql;
using System.Data;
using UniVerse.Services.Interfaces;

namespace UniVerse.Services
{
    public class DbService : IDbService
    {
        private readonly IDbConnection _db;

        public DbService(IConfiguration configuration)
        {
            _db = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
  
        public async Task<int> EditData(string command, object parms)
        {
            int result;

            result = await _db.ExecuteAsync(command, parms);

            return result;
        }

        public async Task<List<T>> GetAll<T>(string command, object parms)
        {
            return (await _db.QueryAsync<T>(command, parms)).ToList();
        }

        public async Task<T> GetAsync<T>(string command, object parms)
        {
            return await _db.QueryFirstOrDefaultAsync<T>(command, parms);
        }
    }
}