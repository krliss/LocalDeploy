using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GitAppLocalCore.Command
{
    public abstract class Command
    {
        private readonly string _cmdPath;

        protected Command(string cmdPath)
        {
            _cmdPath = cmdPath;
        }

        public async Task<string> RunCmdAsync(string args, string workingDirectory, bool outputErrors = false)
        {
            return await RunCmdAsync(_cmdPath, args, workingDirectory, outputErrors);
        }

        public async Task<string> RunCmdAsync(string cmd, string args, string workingDirectory, bool outputErrors = false)
        {
            Debug.WriteLine($"Run {workingDirectory} {cmd} {args}");

            var process = new Process
            {
                StartInfo =
                {
                    WorkingDirectory = workingDirectory,
                    FileName = cmd,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            process.Start();
            var output = await process.StandardOutput.ReadToEndAsync();
            var error = await process.StandardError.ReadToEndAsync();
            process.WaitForExit();

            if (error == string.Empty && process.ExitCode != 0)
            {
                error = output;
            }

            Debug.WriteLine($"Done {workingDirectory} {cmd} {args}");

            if (error != string.Empty && outputErrors)
            {
                throw new Exception($"Error when running {workingDirectory} {cmd} {args}\n{output}\n{output}\n");
            }

            return output;
        }
    }
}
