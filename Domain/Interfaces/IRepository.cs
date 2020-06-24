using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.Entities;

namespace Domain.Interfaces
{
  public interface IRepository<T> where T : BaseEntity
  {
    void Insert(T obj);
    void Update(T obj);
    Task DeleteAsync(int id);
    ValueTask<T> SelectAsync(int id);
    Task<List<T>> SelectAsync();
  }
}