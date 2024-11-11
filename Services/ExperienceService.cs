using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.Services
{
    public class ExperienceService : IService<Experience>
    {
        private readonly IRepository<Experience> _repository;

        public ExperienceService(IRepository<Experience> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Experience> GetAll() => _repository.GetAll();

        public void Add(Experience experience) => _repository.Add(experience);

        public void Update(Experience experience) => _repository.Update(experience);

        public void Delete(int id) => _repository.Delete(id);
    }

}
