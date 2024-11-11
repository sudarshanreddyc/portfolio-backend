using Dapper;
using Microsoft.Data.SqlClient;
using Portfolio.Models;

namespace Portfolio.Repositories
{
    public class SkillsRepository : IRepository<Skills>
    {
        private readonly string? _connectionString;

        public SkillsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PortfolioConnection");
        }

        public IEnumerable<Skills> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            var result = connection.Query<Skills>("EXEC sp_GetSkillsData;");
            return result;
        }

        public IEnumerable<SkillsGroup> GetAllGrouped()
        {
            using var connection = new SqlConnection(_connectionString);
            var result = connection.Query<Skills>("EXEC sp_GetSkillsData;")
                .GroupBy(s => s.Category)
                .Select(g => new SkillsGroup
                {
                    Category = g.Key,
                    Skills = g.ToList()
                }).ToList();
            return result;
        }

        public void Add(Skills skills)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("Exec sp_AddSkillsData(@SkillName, @Proficiency);", skills);
        }

        public void Update(Skills skills)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("Exec sp_EditSkillsData(@Id, @SkillName, @Proficiency);", skills);
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute("Exec sp_DeleteSkillsData(@Id);", new { Id = id });
        }
    }

}
