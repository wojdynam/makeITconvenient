using ComponentModules.BaseModule;

//using ComponentModules.Interfaces;

namespace ComponentModules.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        public Task<IEnumerable<Person>> GetByNameAsync(string name);
        
    }
}
