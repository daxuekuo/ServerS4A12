using System;
using System.Configuration;
using System.IO;

namespace DfoServer.GameWorld
{
    public class GameWorldConfig
    {
        private const string DefaultPvfRelativePath = @"Data\Pvf\Script.pvf";

        public static string PvfArchivePath
        {
            get
            {
                var configuredPath = ResolveConfiguredPath(ConfigurationManager.AppSettings["PvfArchivePath"]);
                if (!string.IsNullOrWhiteSpace(configuredPath))
                    return configuredPath;

                var defaultPath = ResolveConfiguredPath(DefaultPvfRelativePath);
                if (!string.IsNullOrWhiteSpace(defaultPath))
                    return defaultPath;

                var fallbackArchive = FindFirstArchive(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Pvf"));
                if (!string.IsNullOrWhiteSpace(fallbackArchive))
                    return fallbackArchive;

                var legacyArchive = FindFirstArchive(AppDomain.CurrentDomain.BaseDirectory);
                if (!string.IsNullOrWhiteSpace(legacyArchive))
                    return legacyArchive;

                throw new FileNotFoundException("未找到 PVF 文件。请将 Script.pvf 放到 Data\\Pvf\\Script.pvf，或在 App.config 的 PvfArchivePath 中显式配置路径。");
            }
        }

        private static string ResolveConfiguredPath(string configuredPath)
        {
            if (string.IsNullOrWhiteSpace(configuredPath))
                return string.Empty;

            var fullPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configuredPath));
            return File.Exists(fullPath) ? fullPath : string.Empty;
        }

        private static string FindFirstArchive(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                return string.Empty;

            var archives = Directory.GetFiles(directoryPath, "*.pvf");
            return archives.Length > 0 ? archives[0] : string.Empty;
        }
    }
}