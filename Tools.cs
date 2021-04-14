using System.IO;
using Microsoft.Extensions.Configuration;

namespace SaludCore
{
    public class Tools
    {
        public static string GetConnectionString(string name = "DefaultConnection")
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            IConfigurationSection sConnString = configuration.GetSection("DB").GetSection("conn");

            return sConnString.Value;

        }

    }
}
