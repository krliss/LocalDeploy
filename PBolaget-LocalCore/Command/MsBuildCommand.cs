using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GitAppLocalCore.Models;

namespace GitAppLocalCore.Command
{
    public class MsBuildCommand : Command
    {
        private readonly string _codeRoot;
        private readonly Repository _repo;
        private readonly SemaphoreSlim _buildSemaphore = new SemaphoreSlim(1);
        private static readonly SemaphoreSlim GlobalSemaphore = new SemaphoreSlim(4);

        public MsBuildCommand(Settings settings, Repository repo) : base(settings.MsBuild)
        {
            _codeRoot = settings.CodeRootPath(repo);
            _repo = repo;
        }

        public async Task DbDeploy()
        {
            try
            {
                await _buildSemaphore.WaitAsync();
                await GlobalSemaphore.WaitAsync();

                if (_repo.DoDeploy)
                    await DbDeployInformationslagret();
                else
                {
                    var workdir = Path.Combine(_codeRoot, _repo.LocalPath);

                    var buildArgs = $"/T:\"{Path.Combine("Databas", "Databas")}\"";
                    await RunCmdAsync(buildArgs, workdir, true);

                    var sqlproj = Path.Combine("Databas", "Databas.sqlproj");
                    var profilePath = "Databas.dev.publish.xml";
                    var publishArgs = $"/t:Publish /p:SqlPublishProfilePath=\"{profilePath}\" \"{sqlproj}\"";
                    await RunCmdAsync(publishArgs, workdir, true);
                }
            }
            catch (Exception e)
            {
                WriteError($"Error when running DbDeploy\n{e.Message}");
                throw;
            }
            finally
            {
                GlobalSemaphore.Release();
                _buildSemaphore.Release();
            }
        }

        public async Task Publish()
        {
            try
            {
                await _buildSemaphore.WaitAsync();
                await GlobalSemaphore.WaitAsync();

                if (_repo.DoDeploy)
                    await PublishInformation();
                else
                {
                    var workdir = Path.Combine(_codeRoot, _repo.LocalPath);
                    var slnFile = Directory.EnumerateFiles(workdir).FirstOrDefault(file => file.EndsWith(".sln"));

                    var args = $"{slnFile} /verbosity:minimal /T:{_repo.LocalPath}_WebApi /p:DeployOnBuild=true /p:PublishProfile=\"{_repo.PublishProfile}\" /p:Configuration={_repo.Configuration} /p:SkipInvalidConfigurations=false";

                    await RunCmdAsync("nuget.exe", "restore", workdir, true);
                    await RunCmdAsync(args, workdir, true);
                }
            }
            catch (Exception e)
            {
                WriteError($"Error when running Publish\n{e.Message}");
                throw;
            }
            finally
            {
                GlobalSemaphore.Release();
                _buildSemaphore.Release();
            }
        }

        private async Task PublishInformation()
        {
            var workdir = Path.Combine(_codeRoot, _repo.LocalPath, "Information", "Source");
            var slnFile = Directory.EnumerateFiles(workdir).FirstOrDefault(file => file.EndsWith(".sln"));

            var args = $"{slnFile} /verbosity:minimal /p:DeployOnBuild=true /p:PublishProfile={_repo.PublishProfile} /p:Configuration={_repo.Configuration} /p:SkipInvalidConfigurations=false";

            await RunCmdAsync("nuget.exe", "restore", workdir, true);
            await RunCmdAsync(args, workdir, true);
        }

        private async Task DbDeployInformationslagret()
        {
            var workdir = Path.Combine(_codeRoot, _repo.LocalPath, "Information", "Source");

            var buildArgs = new[]
            {
                $"/T:\"{Path.Combine("Database", "Information", "Information")}\"",
                //$"/T:\"{Path.Combine("Database", "Information", "Information")}\"",
                //...
            };

            foreach (var arg in buildArgs)
                await RunCmdAsync(arg, workdir, true);

            var projFiles = new[]
            {
                Path.Combine("Database", "Information", "Information.sqlproj"),
                //Path.Combine("Database", "Information", "Information.sqlproj"),
                //...
            };

            foreach (var proj in projFiles)
                await RunCmdAsync($"/t:Publish /p:SqlPublishProfilePath=\"Dev.publish.xml\" \"{proj}\"", workdir, true);
        }

        private void WriteError(string error)
        {
            File.AppendAllText($"Repo_{_repo.LocalPath}.txt", $@"{DateTime.Now} - {error}");
        }

        public bool DbFileNotFound()
        {
            if (_repo.DoDeploy)
                return false;

            return !File.Exists(Path.Combine(_codeRoot, _repo.LocalPath, "Databas", "Databas.sqlproj"));
        }
    }
}
