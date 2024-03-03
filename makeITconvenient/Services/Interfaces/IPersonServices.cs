using ComponentModules.Interfaces;
using makeITconvenient.Models;

namespace makeITconvenient.Services.Interfaces
{
    public interface IPersonServices:IServices<PersonDto>
    {
        public Task<IEnumerable<PersonDto>> SearchAsync(string name);
    }
}
