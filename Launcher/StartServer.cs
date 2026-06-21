using System;
using System.Diagnostics;
using System.IO;

internal static class StartServer
{
    private static int Main()
    {
        string root = AppDomain.CurrentDomain.BaseDirectory;
        string serverDir = Path.Combine(root, "Server", "DfoServer", "bin", "Debug");
        string serverExe = Path.Combine(serverDir, "DfoServer.exe");

        if (!File.Exists(serverExe))
        {
            Console.Error.WriteLine("DfoServer.exe was not found:");
            Console.Error.WriteLine(serverExe);
            Console.Error.WriteLine();
            Console.Error.WriteLine("Build the project first, or download a repository copy that includes bin/Debug output.");
            Console.Error.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
            return 1;
        }

        try
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = serverExe,
                WorkingDirectory = serverDir,
                UseShellExecute = false
            };

            using (Process process = Process.Start(startInfo))
            {
                if (process == null)
                {
                    Console.Error.WriteLine("Failed to start DfoServer.exe.");
                    Console.Error.WriteLine("Press any key to exit...");
                    Console.ReadKey(true);
                    return 1;
                }

                process.WaitForExit();
                return process.ExitCode;
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Failed to start DfoServer.exe:");
            Console.Error.WriteLine(ex.Message);
            Console.Error.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
            return 1;
        }
    }
}