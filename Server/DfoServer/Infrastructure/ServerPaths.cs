using System;
using System.Configuration;

namespace DfoServer.Infrastructure
{
    public static class ServerPaths
    {
        private static readonly string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public static string DatabasePath
        {
            get
            {
                var configured = ConfigurationManager.AppSettings["InventoryDatabasePath"];
                return string.IsNullOrWhiteSpace(configured)
                    ? System.IO.Path.Combine(BaseDirectory, "Data", "inventory.db")
                    : System.IO.Path.Combine(BaseDirectory, configured);
            }
        }

        public static string SchemaFilePath => System.IO.Path.Combine(BaseDirectory, "Sqlite", "item_schema.sql");
    }
}
