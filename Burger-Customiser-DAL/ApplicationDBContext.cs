using Burger_Customiser_BLL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.Entity;

namespace Burger_Customiser_DAL {
    [DbConfigurationType(typeof(ApplicationDBConfiguration))]
    public class ApplicationDBContext : DbContext {

        public DbSet<Article> Article { get; set; }

        public ApplicationDBContext(ILogger logger, IConfiguration config) : base(config["Data:Database:ConnectionString"]) {
            logger.LogInformation("Successfully initialized Datbase Connection!");
        }
    }
}
