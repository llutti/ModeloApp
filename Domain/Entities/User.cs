using System;

namespace Domain.Entities
{
  public class User : BaseEntity
  {
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string Cpf { get; set; }
  }
}