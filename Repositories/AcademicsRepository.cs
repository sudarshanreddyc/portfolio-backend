using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Portfolio.Models;

namespace Portfolio.Repositories
{
    public class AcademicsRepository : IRepository<Academics>
    {
        private readonly string? _connectionString;

        public AcademicsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PortfolioConnection");
        }

        public IEnumerable<Academics> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            var result = connection.Query<Academics>("EXEC sp_GetAcademicsData;").ToList();
            return result;
        }

        public void Add(Academics academics)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("Exec sp_AddAcademicsData(@Degree, @Institution, @StartDate, @EndDate);", academics);
        }

        public void Update(Academics academics)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("Exec sp_EditAcademicsData(@Id, @Degree, @Institution, @StartDate, @EndDate);", academics);
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("Exec sp_DeleteAcademicsData(@Id);", new { Id = id });
        }
    }
}
