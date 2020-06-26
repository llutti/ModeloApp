using Infra.Data.Context;

using Microsoft.EntityFrameworkCore;

using System;
using System.IO;

namespace Application.Data.Context
{
  public class SqlLiteContext : BaseContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        var pathDB = Path.Combine("Data", "Database");

        if (Directory.Exists(pathDB) == false)
        {
          Directory.CreateDirectory(pathDB);
        }
        
        var fileDB = Path.Combine(pathDB, "modeloApp.db");

        optionsBuilder.UseSqlite($"Data Source={fileDB}");
      }
    }

  }
}
