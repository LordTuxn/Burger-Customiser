using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.Entity;

namespace Burger_Customiser_DAL {
    public class ApplicationDBConfiguration : DbConfiguration {

        public ApplicationDBConfiguration() {
            // Register ADO.NET provider
            var dataSet = (DataSet)ConfigurationManager.GetSection("Data.Database");
            dataSet.Tables[0].Rows.Add(
                "MySQL Data Provider",
                ".Net Framework Data Provider for MySQL",
                "MySql.Data.MySqlClient",
                typeof(MySqlClientFactory).AssemblyQualifiedName
            );

            // Register Entity Framework provider
            SetProviderServices("MySql.Data.MySqlClient", new MySqlProviderServices());
            SetDefaultConnectionFactory(new MySqlConnectionFactory());
        }
    }
}
