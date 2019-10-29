using System.Diagnostics;
using GitAppLocalCore.Models;

namespace GitAppLocalCore.Command
{
    public class ViewLog
    {
        private readonly string _logViewer;

        public ViewLog(Settings settings)
        {
            _logViewer = settings.LogViewer;
        }

        public void View(string file)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = _logViewer,
                    Arguments = file,
                    UseShellExecute = false
                }
            };
            process.Start();
        }
    }
}
