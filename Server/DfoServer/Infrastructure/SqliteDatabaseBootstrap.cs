using System.Data.SQLite;
using System.IO;

namespace DfoServer.Infrastructure
{
    public static class SqliteDatabaseBootstrap
    {
        public static string Initialize(string databasePath, string schemaFilePath)
        {
            if (!File.Exists(databasePath))
                SQLiteConnection.CreateFile(databasePath);

            var connectionString = $"Data Source={databasePath};Version=3;";
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(File.ReadAllText(schemaFilePath), conn))
                    cmd.ExecuteNonQuery();
            }
            return connectionString;
        }
    }
}
