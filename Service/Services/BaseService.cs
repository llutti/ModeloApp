using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using Infra.Data.Context;
using Infra.Data.Repository;

namespace Service.Services
{
  public class BaseService<T> : IService<T> where T : BaseEntity
  {
    private BaseRepository<T> repository;

    public BaseService(BaseContext context)
    {
      repository = new BaseRepository<T>(context);
    }

    public T Post<V>(T obj) where V : AbstractValidator<T>
    {
      Validate(obj, Activator.CreateInstance<V>());

      repository.Insert(obj);

      return obj;
    }

    public T Put<V>(T obj) where V : AbstractValidator<T>
    {
      Validate(obj, Activator.CreateInstance<V>());

      repository.Update(obj);

      return obj;
    }

    public Task DeleteAsync(int id)
    {
      if (id == 0)
      {
        throw new ArgumentException("The id can't be zero.");
      }

      return repository.DeleteAsync(id);
    }

    public ValueTask<T> GetAsync(int id)
    {
      if (id == 0)
      {
        throw new ArgumentException("The id can't be zero.");
      }

      return repository.SelectAsync(id);
    }

    public Task<List<T>> GetAsync() => repository.SelectAsync();

    private void Validate(T obj, AbstractValidator<T> validator)
    {
      // if (obj == null)
      // {
      //   throw new Exception("Registro não detectado!");
      // }

      validator.ValidateAndThrow(obj);
    }
  }
}