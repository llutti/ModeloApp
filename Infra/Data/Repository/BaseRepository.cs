using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
  public class BaseRepository<T> : IRepository<T> where T : BaseEntity
  {
    private BaseContext context;

    public BaseRepository(BaseContext _context)
    {
      this.context = _context;
    }

    public void Insert(T obj)
    {
      context.Set<T>().Add(obj);
      context.SaveChanges();
    }

    public void Update(T obj)
    {
      context.Entry(obj).State = EntityState.Modified;
      context.SaveChanges();
    }

    public async Task DeleteAsync(int id)
    {
      context.Set<T>().Remove(await SelectAsync(id));
      context.SaveChanges();
    }

    public ValueTask<T> SelectAsync(int id) => context.Set<T>().FindAsync(id);

    public Task<List<T>> SelectAsync() => context.Set<T>().ToListAsync();
  }
}
