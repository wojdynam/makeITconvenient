using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace makeITconvenient.Services.Interfaces
{
    public interface IServices<T> where T : class
    {
        public Task<T> AddAsync(T service);
        public Task RemoveAsync(int id);
        public Task<T> EditAsync(T service);
        public Task<T> DetailsAsync(int id);

    }
}
