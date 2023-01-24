using Microsoft.Extensions.Configuration;

namespace PlacesDB
{
    public sealed class DBConnection
    {
        public const string ThisConnection = "SQLServer";

        private static DBConnection _instance = null;
        private static readonly object instanceLock = new();
        private static IConfigurationRoot _configuration;

        public static string DbConnectionsDirectory
        {
            get
            {
                // Best practices - Use ConfigurationBuilder to build key-value paired configs stored in LocalApplicationData

                //LocalApplicationData is a good place to store configuration files.
                //Copy appsettings.json to the folder in documentPath
                var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                documentPath = Path.Combine(documentPath, "SuperMegaFunApp", "EFC");
                if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
                return documentPath;
            }
        }

        private DBConnection()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(DbConnectionsDirectory)
                .AddJsonFile("DbConnections.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();
        }

        public static IConfigurationRoot ConfigurationRoot
        {
            get
            {
                lock (instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new DBConnection();
                    }
                    return _configuration;
                }
            }
        }
    }
}