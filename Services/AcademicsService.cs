using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.Services
{
    public class AcademicsService : IService<Academics>
    {
        private readonly IRepository<Academics> _repository;

        public AcademicsService(IRepository<Academics> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Academics> GetAll() => _repository.GetAll();

        public void Add(Academics academics) => _repository.Add(academics);

        public void Update(Academics academics) => _repository.Update(academics);

        public void Delete(int id) => _repository.Delete(id);
    }

}
