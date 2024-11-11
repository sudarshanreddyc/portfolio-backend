using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.Services
{
    public class SkillsService : IService<Skills>
    {
        private readonly IRepository<Skills> _repository;

        public SkillsService(IRepository<Skills> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Skills> GetAll() => _repository.GetAll();

        public void Add(Skills skills) => _repository.Add(skills);

        public void Update(Skills skills) => _repository.Update(skills);

        public void Delete(int id) => _repository.Delete(id);
    }

}
