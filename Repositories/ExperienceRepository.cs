using Dapper;
using Microsoft.Data.SqlClient;
using Portfolio.Models;

namespace Portfolio.Repositories
{
    public class ExperienceRepository : IRepository<Experience>
    {
        private readonly string? _connectionString;

        public ExperienceRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PortfolioConnection");
        }

        public IEnumerable<Experience> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            var result = connection.Query<Experience>("EXEC sp_GetExperienceData;").ToList();
            return result;
        }

        public void Add(Experience experience)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("Exec sp_AddExperienceData(@JobTitle, @Company, @StartDate, @EndDate, @Responsibilities);", experience);
        }

        public void Update(Experience experience)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("Exec sp_EditExperienceData(@Id, @JobTitle, @Company, @StartDate, @EndDate, @Responsibilities);", experience);
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("Exec sp_DeleteExperienceData(@Id);", new { Id = id });
        }
    }

}
