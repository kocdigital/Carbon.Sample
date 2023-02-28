using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using System.Reflection;

namespace Carbon.Sample.API.Infrastructure.Contexts.SampleContext
{
    public class SampleDBContextDesignFactory : IDesignTimeDbContextFactory<SampleDBContext>
    {
        public SampleDBContext CreateDbContext(string[] args)
        {

            var target = "PostgreSQL";
            var mssqlconnectionString = "Server=localhost,1433;Database=sampledb;User ID=sampledb_user;Password='thissamplepassword';Connect Timeout=30;";
            var postgreConnectionString = "Server=localhost;Database=postgres;User ID=postgres;Password=password;";


            var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name + "." + target;

            if (target == "PostgreSQL")
            {
                var optionsBuilder = new DbContextOptionsBuilder<SampleDBContext>()
                .UseNpgsql(postgreConnectionString, sql => sql.MigrationsAssembly(migrationsAssembly));

                return new SampleDBContext(optionsBuilder.Options);
            }
            else
            {
                var optionsBuilder = new DbContextOptionsBuilder<SampleDBContext>()
               .UseSqlServer(mssqlconnectionString, sql => sql.MigrationsAssembly(migrationsAssembly));

                return new SampleDBContext(optionsBuilder.Options);
            }

        }
    }
}
