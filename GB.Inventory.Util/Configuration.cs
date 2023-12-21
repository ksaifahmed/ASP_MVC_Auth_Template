using Microsoft.Extensions.Configuration;

namespace GB.Inventory.Util
{
    public class Configuration
    {
        private Configuration() { }

        private static Configuration Default = null;

        private static readonly object DefaultLock = new object();

        private IConfigurationRoot _Configuration;

        public static Configuration Instance
        {
            get
            {
                if (Default == null)
                {
                    lock (DefaultLock)
                    {
                        if (Default == null)
                        {
                            Default = new Configuration();
                            Default._Configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();
                        }
                    }
                }
                return Default;
            }
        }

        public string ConnectionString
        {
            get
            {
                return _Configuration.GetConnectionString("GBInventory");
            }
        }
    }
}