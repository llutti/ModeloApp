using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.Data.Context
{
  public class SqlLiteContext : BaseContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        // optionsBuilder.UseMySql("Server=[SERVIDOR];Port=[PORTA];Database=modelo;Uid=[USUARIO];Pwd=[SENHA]");
        optionsBuilder.UseSqlite("Data Source=modeloApp.db");
      }
    }

  }
}
