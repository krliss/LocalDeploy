using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GitAppLocalCore.Models;

namespace GitAppLocalCore.Command
{
    public class AzureStorageEmulatorCommand : Command
    {
        private readonly SemaphoreSlim _azureSemaphore = new SemaphoreSlim(1);

        public AzureStorageEmulatorCommand(Settings settings) : base(settings.AzureStorageEmulatorPath)
        {
        }

        public async Task<Tuple<string, Color>> GetStatus()
        {
            try
            {
                await _azureSemaphore.WaitAsync();
                var result = await RunCmdAsync("status", string.Empty, true);
                if (result.Contains("IsRunning: True"))
                {
                    return new Tuple<string, Color>("Running", Color.LightGreen);
                }
                else
                {
                    return new Tuple<string, Color>("Halted", Color.LightCoral);
                }
            }
            catch (Exception e)
            {
                File.AppendAllText($"AzureEmulator.txt", $"{DateTime.Now} - Error when running status\n{e.Message}");
                return new Tuple<string, Color>("Error", Color.Red);
            }
            finally
            {
                _azureSemaphore.Release();
            }
        }

        public async Task Start()
        {
            try
            {
                await _azureSemaphore.WaitAsync();
                await RunCmdAsync("start", string.Empty, true);
            }
            catch (Exception e)
            {
                File.AppendAllText($"AzureEmulator.txt", $"{DateTime.Now} - Error when running start\n{e.Message}");
            }
            finally
            {
                _azureSemaphore.Release();
            }
        }

        public async Task Stop()
        {
            try
            {
                await _azureSemaphore.WaitAsync();
                await RunCmdAsync("stop", string.Empty, true);
            }
            catch (Exception e)
            {
                File.AppendAllText($"AzureEmulator.txt", $"{DateTime.Now} - Error when running stop\n{e.Message}");
            }
            finally
            {
                _azureSemaphore.Release();
            }
        }
    }
}
