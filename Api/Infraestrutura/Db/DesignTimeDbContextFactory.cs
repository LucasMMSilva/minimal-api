using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MinimalApi.Infraestrutura.Db;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DbContexto>
{
    public DbContexto CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var conn = configuration.GetConnectionString("MySql")
                   ?? "Server=localhost;Database=nome_do_banco;User=usuario;Password=senha;";

        var optionsBuilder = new DbContextOptionsBuilder<DbContexto>();
        optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));

        return new DbContexto(optionsBuilder.Options, configuration);
    }
}