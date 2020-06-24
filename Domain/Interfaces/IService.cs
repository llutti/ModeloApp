using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using FluentValidation;

namespace Domain.Interfaces
{
  public interface IService<T> where T : BaseEntity
  {
    T Post<V>(T obj) where V : AbstractValidator<T>;
    T Put<V>(T obj) where V : AbstractValidator<T>;
    Task DeleteAsync(int id);
    ValueTask<T> GetAsync(int id);
    Task<List<T>> GetAsync();
  }
}