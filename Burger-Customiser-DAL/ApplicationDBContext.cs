using Burger_Customiser_BLL;
using Microsoft.Extensions.Configuration;
using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Burger_Customiser_DAL {
    [DbConfigurationType(typeof(ApplicationDBConfiguration))]
    public class ApplicationDBContext : DbContext {

        public DbSet<Article> Article { get; set; }

        public ApplicationDBContext(string connectionString) : base(connectionString) {}
    }

    public class ApplicationDBConfiguration : DbConfiguration {

        public ApplicationDBConfiguration() {
            SetProviderFactory("MySql.Data.MySqlClient", new MySqlClientFactory());
            SetProviderFactoryResolver(new MySqlProviderFactoryResolver());
        }
    }

    public class ApplicationDBContextFactory : IDbContextFactory<ApplicationDBContext> {
        public ApplicationDBContext Create() {
            return new ApplicationDBContext("server=127.0.0.1; uid=root; pwd=1234; database=testdatabase");
        }
    }
}
