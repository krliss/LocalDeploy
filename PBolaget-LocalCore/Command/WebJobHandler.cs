using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using GitAppLocalCore.Models;

namespace GitAppLocalCore.Command
{
    public class WebJobHandler
    {
        private readonly string _wwwRoot;
        private readonly SemaphoreSlim _jobRunning = new SemaphoreSlim(1);
        private readonly string _path;
        private Process _process;

        public WebJobHandler(Settings settings, string path)
        {
            _wwwRoot = settings.WwwRootPath;
            _path = path;
        }

        public string FullPath => Path.Combine(_wwwRoot, _path);

        public string Name => Path.GetFileNameWithoutExtension(FullPath);

        public void Kill()
        {
            try
            {
                if (_process?.HasExited == false)
                {
                    _process.Kill();
                }
            }
            catch (Exception)
            {
            }
        }

        public void Run()
        {
            try
            {
                Kill();

                _jobRunning.Wait();

                _process = new Process { StartInfo = GetStartInfo() };

                _process.OutputDataReceived += (sender, args) =>
                {
                    using (var f = new StreamWriter($"WebJob_{Name}.txt", true))
                    {
                        f.Write(args.Data);
                    }
                };

                _process.Start();
                _process.BeginOutputReadLine();

                var error = _process.StandardError.ReadToEnd();
                _process.WaitForExit();
                _process.Close();

                if (error != string.Empty)
                {
                    throw new Exception($"Webjob {Name} error\n{error}");
                }
            }
            catch (Exception e)
            {
                WriteError($"Error when invoking Run\n{e.Message}");
                throw;
            }
            finally
            {
                _jobRunning.Release();
            }
        }

        private ProcessStartInfo GetStartInfo()
        {
            return new ProcessStartInfo
            {
                FileName = FullPath,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
        }

        private void WriteError(string error)
        {
            File.AppendAllText($"WebJob_{Name}.txt", $@"{DateTime.Now} - {error}");
        }

        public static WebJobHandler[] GetHandlers(Settings settings)
        {
            var allFiles = Directory.GetFiles(settings.WwwRootPath, "*.exe", SearchOption.AllDirectories);

            return allFiles
                .Where(file => !IsExcluded(file))
                .Select(file => new WebJobHandler(settings, file)).ToArray();
        }

        private static bool IsExcluded(string file)
        {
            var excluded = new []
            {
                "csc.exe", "csi.exe", "vbc.exe", "VBCSCompiler.exe"
            };

            return excluded.Any(file.EndsWith);
        }
    }
}