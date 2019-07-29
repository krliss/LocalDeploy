using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GitAppLocalCore.Models;

namespace GitAppLocalCore.Command
{
    public class GitCommand : Command
    {
        private readonly string _codeRoot;
        private readonly Repository _repo;
        private readonly SemaphoreSlim _repoSemaphore = new SemaphoreSlim(1);
        private static readonly SemaphoreSlim GlobalSemaphore = new SemaphoreSlim(4);

        private string _workDir => Path.Combine(_codeRoot, _repo.LocalPath);


        public GitCommand(Settings settings, Repository repo) : base(settings.GitPath)
        {
            _codeRoot = settings.CodeRootPath(repo);
            _repo = repo;
        }

        public async Task Fetch()
        {
            try
            {
                await _repoSemaphore.WaitAsync();
                await GlobalSemaphore.WaitAsync();

                if (!Directory.Exists(_workDir))
                {
                    await Clone();
                }
                else
                {
                    await RunCmdAsync("fetch --all", _workDir, false);
                }
            }
            catch (Exception e)
            {
                WriteError($"Error when running Fetch\n{e.Message}");
                throw;
            }
            finally
            {
                GlobalSemaphore.Release();
                _repoSemaphore.Release();
            }
        }

        public async Task Sync()
        {
            try
            {
                await _repoSemaphore.WaitAsync();
                await GlobalSemaphore.WaitAsync();

                if (!Directory.Exists(_workDir))
                {
                    await Clone();
                }
                else if (await WorkTreeDirty())
                {
                    throw new Exception("Work tree dirty!");
                }
                else
                {
                    await RunCmdAsync("fetch -all", _workDir, false);
                    await RunCmdAsync("pull --rebase origin", _workDir, true);
                }
            }
            catch (Exception e)
            {
                WriteError($"Error when running Sync\n{e.Message}");
                throw;
            }
            finally
            {
                GlobalSemaphore.Release();
                _repoSemaphore.Release();
            }
        }

        private async Task Clone()
        {
            var clone = $"clone --recurse-submodules --branch Develop \"{_repo.RemotePath}\" \"{_repo.LocalPath}\"";

            await RunCmdAsync(clone, _codeRoot, false);
        }

        public async Task<Tuple<string, Color>> GetStatus()
        {
            try
            {
                await _repoSemaphore.WaitAsync();
                await GlobalSemaphore.WaitAsync();

                if (!Directory.Exists(_workDir))
                    return new Tuple<string, Color>("Not Cloned", Color.DimGray);
                
                if(await WorkTreeDirty())
                    return new Tuple<string, Color>("Dirty", Color.LightCoral);

                var branch = await Branch();
                var remoteExists = await RemoteExistsAsync(branch);

                if (!remoteExists)
                    return new Tuple<string, Color>("Local Head", Color.LightGreen);

                var behind = await BehindAsync(branch);
                var ahead = await AheadAsync(branch);

                if (behind > 0 && ahead > 0)
                    return new Tuple<string, Color>("Behind+Ahead", Color.LightCoral);

                if (behind > 0)
                    return new Tuple<string, Color>("Behind", Color.LightCoral);
               
                if (ahead > 0)
                    return new Tuple<string, Color>("Ahead", Color.LightBlue);

                return new Tuple<string, Color>("Head", Color.LightGreen);
            }
            catch (Exception e)
            {
                WriteError($"Error when running GetStatus\n{e.Message}");
                return new Tuple<string, Color>("Error", Color.Red);
            }
            finally
            {
                GlobalSemaphore.Release();
                _repoSemaphore.Release();
            }
        }

        public async Task<string> GetBranch()
        {
            try
            {
                await _repoSemaphore.WaitAsync();
                await GlobalSemaphore.WaitAsync();

                return Directory.Exists(_workDir) ? await Branch() : "No Branch";
            }
            catch (Exception e)
            {
                WriteError($"Error when running GetBranch\n{e.Message}");
                throw;
            }
            finally
            {
                GlobalSemaphore.Release();
                _repoSemaphore.Release();
            }
        }

        private Task<string> Branch() => GitCmdAsync("rev-parse --abbrev-ref HEAD");

        private Task<string> RevList(string branch) => GitCmdAsync($"rev-list --left-right --count {branch}...origin/{branch}");

        private Task<string> BranchList(string branch) => GitCmdAsync($"rev-parse --symbolic-full-name {branch}" + @"@{u}");

        private Task<string> Status() => GitCmdAsync("status");

        private async Task<int> AheadAsync(string branch)
        {
            var aheadOrBehind = (await RevList(branch)).Split('\t');
            if (aheadOrBehind.Length > 1 && int.TryParse(aheadOrBehind[0], out var ahead))
                return ahead;
            return 0;
        }

        private async Task<int> BehindAsync(string branch)
        {
            var aheadOrBehind = (await RevList(branch)).Split('\t');
            if (aheadOrBehind.Length > 1 && int.TryParse(aheadOrBehind[1], out var ahead))
                return ahead;
            return 0;
        }

        private async Task<bool> RemoteExistsAsync(string branch)
        {
            var list = await BranchList(branch);
            return list.Contains($"refs/remotes/origin/{branch}");
        }

        private async Task<bool> WorkTreeDirty()
        {
            var status = await Status();
            return status.Contains("nothing to commit, working tree clean") == false;
        }

        private async Task<string> GitCmdAsync(string args)
        {
            var result = await RunCmdAsync(args, _workDir);
            return result.Replace("\n", "");
        }

        private void WriteError(string error)
        {
            File.AppendAllText($"Repo_{_repo.LocalPath}.txt", $@"{DateTime.Now} - {error}");
        }
    }
}