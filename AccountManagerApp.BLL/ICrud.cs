using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountManagerApp.BLL;

public interface ICrud<T> where T : class
{
    public IAsyncEnumerable<T> GetAllAsync();
    public Task<T> AddAsync(T entity);
    public Task<T> UpdateAsync(T entity);
    public Task<T> DeleteAsync(T entity);
}
