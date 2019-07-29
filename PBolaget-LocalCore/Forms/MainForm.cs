using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using GitAppLocalCore.Command;
using GitAppLocalCore.Models;

namespace GitAppLocalCore.Forms
{
    public partial class MainForm : Form
    {
        private readonly Settings _settings;
        private readonly ViewLog _log;
        private readonly AzureStorageEmulatorCommand _azure;
        private readonly List<WebJobHandler> _handlers = new List<WebJobHandler>();

        public MainForm()
        {
            _settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(Settings.Path));
            _settings.Repositories = JsonConvert.DeserializeObject<List<Repository>>(File.ReadAllText(Repository.Path));
            _log = new ViewLog(_settings);
            _azure = new AzureStorageEmulatorCommand(_settings);

            InitializeComponent();

            Closing += MainForm_Closing;
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (var h in _handlers)
            {
                try
                {
                    h.Kill();
                }
                catch (Exception)
                {
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RepoPanel.Controls.Remove(FetchButtonTemplate);
            RepoPanel.Controls.Remove(StatusLabelTemplate);
            RepoPanel.Controls.Remove(SyncButtonTemplate);
            RepoPanel.Controls.Remove(PublishButtonTemplate);
            RepoPanel.Controls.Remove(BranchLabelTemplate);
            RepoPanel.Controls.Remove(LocalPathLabelTemplate);
            RepoPanel.Controls.Remove(DBDeployButtonTemplate);
            RepoPanel.Controls.Remove(DeployLogsButtonTemplate);

            WebJobPanel.Controls.Remove(StartButtonTemplate);
            WebJobPanel.Controls.Remove(KillWebJobButtonTemplate);
            WebJobPanel.Controls.Remove(WebJobLogsTemplate);
            WebJobPanel.Controls.Remove(WebJobStatusTemplate);
            WebJobPanel.Controls.Remove(WebJobNameTempate);

            foreach (var repo in _settings.Repositories)
                AddRepo(repo);

            AzureEmulatorStart.PerformClick();

            FetchAllButton.PerformClick();

            SearchJobsButton.PerformClick();
        }

        #region GlobalButtons
        private void FetchAllButton_Click(object sender, EventArgs e)
        {
            foreach (var c in RepoPanel.Controls.Find(FetchButtonTemplate.Name, true))
            {
                var b = c as Button;
                b?.PerformClick();
            }
        }

        private void SyncAllButton_Click(object sender, EventArgs e)
        {
            foreach (var c in RepoPanel.Controls.Find(SyncButtonTemplate.Name, true))
            {
                var b = c as Button;
                b?.PerformClick();
            }
        }

        private void DeployAllButton_Click(object sender, EventArgs e)
        {
            foreach (var c in RepoPanel.Controls.Find(PublishButtonTemplate.Name, true))
            {
                var b = c as Button;
                b?.PerformClick();
            }
        }

        private void DBDeployAll_Click(object sender, EventArgs e)
        {
            foreach (var c in RepoPanel.Controls.Find(DBDeployButtonTemplate.Name, true))
            {
                var b = c as Button;
                b?.PerformClick();
            }
        }

        private void StartAllWebJobs_Click(object sender, EventArgs e)
        {
            foreach (var c in RepoPanel.Controls.Find(StartButtonTemplate.Name, true))
            {
                var b = c as Button;
                b?.PerformClick();
            }
        }

        private void StopAllWebJobs_Click(object sender, EventArgs e)
        {
            foreach (var c in RepoPanel.Controls.Find(KillWebJobButtonTemplate.Name, true))
            {
                var b = c as Button;
                b?.PerformClick();
            }
        }
        #endregion

        #region Repositories
        private void AddRepo(Repository repo)
        {
            var git = new GitCommand(_settings, repo);
            var msbuild = new MsBuildCommand(_settings, repo);

            var statusLabel = Clone(StatusLabelTemplate);
            var branchLabel = Clone(BranchLabelTemplate);
            var localPathLabel = Clone(LocalPathLabelTemplate);

            localPathLabel.Text = repo.LocalPath;

            var fetchButton = CreateFetchButton(git);
            var syncButton = CreateSyncButton(git);
            var publishButton = CreatePublishButton(msbuild);
            var dbDeployButton = CreateDbDeployButton(msbuild);
            var viewLogButton = CreateViewRepoLogButton(repo);

            AddRefreshRepoLabels(fetchButton, branchLabel, statusLabel, git);
            AddRefreshRepoLabels(syncButton, branchLabel, statusLabel, git);
            AddRefreshRepoLabels(publishButton, branchLabel, statusLabel, git);
            AddRefreshRepoLabels(dbDeployButton, branchLabel, statusLabel, git);
            AddRefreshRepoLabels(viewLogButton, branchLabel, statusLabel, git);
            AddRefreshRepoLabels(statusLabel, branchLabel, statusLabel, git);
            AddRefreshRepoLabels(branchLabel, branchLabel, statusLabel, git);
            AddRefreshRepoLabels(statusLabel, branchLabel, statusLabel, git);

            RepoPanel.Controls.Add(fetchButton);
            RepoPanel.Controls.Add(syncButton);
            RepoPanel.Controls.Add(publishButton);
            RepoPanel.Controls.Add(dbDeployButton);
            RepoPanel.Controls.Add(viewLogButton);
            RepoPanel.Controls.Add(localPathLabel);
            RepoPanel.Controls.Add(branchLabel);
            RepoPanel.Controls.Add(statusLabel);
        }

        private void AddRefreshRepoLabels(Control btn, Label branchLabel, Label statusLabel, GitCommand git)
        {
            btn.Click += async (sender, args) =>
            {
                branchLabel.Text = await git.GetBranch();
                var status = await git.GetStatus();
                statusLabel.Text = status.Item1;
                statusLabel.BackColor = status.Item2;
            };
        }

        private Button CreateViewRepoLogButton(Repository repo)
        {
            var viewLogButton = Clone(DeployLogsButtonTemplate);

            viewLogButton.Click += (sender, args) =>
            {
                var f = $"Repo_{repo.LocalPath}.txt";
                if(File.Exists(f))
                    _log.View(f);
            };

            return viewLogButton;
        }

        private Button CreateDbDeployButton(MsBuildCommand msBuild)
        {
            var dbDeployButton = Clone(DBDeployButtonTemplate);

            if (msBuild.DbFileNotFound())
            {
                dbDeployButton.Enabled = false;
                dbDeployButton.Font = new Font(dbDeployButton.Font, FontStyle.Strikeout);
            }
            else
            {
                dbDeployButton.Click += async (sender, args) =>
                {
                    try
                    {
                        dbDeployButton.Enabled = false;
                        dbDeployButton.Text = "Working";
                        dbDeployButton.BackColor = Color.LightGoldenrodYellow;
                        await Task.Run(msBuild.DbDeploy);
                        dbDeployButton.BackColor = DBDeployButtonTemplate.BackColor;
                    }
                    catch (Exception)
                    {
                        dbDeployButton.BackColor = Color.LightCoral;
                    }
                    finally
                    {
                        dbDeployButton.Text = DBDeployButtonTemplate.Text;
                        dbDeployButton.Enabled = true;
                    }
                };
            }
            return dbDeployButton;
        }

        private Button CreatePublishButton(MsBuildCommand msBuild)
        {
            var publishButton = Clone(PublishButtonTemplate);

            publishButton.Click += async (sender, args) =>
            {
                try
                {
                    publishButton.Enabled = false;
                    publishButton.Text = "Working";
                    publishButton.BackColor = Color.LightGoldenrodYellow;
                    await Task.Run(msBuild.Publish);
                    publishButton.BackColor = PublishButtonTemplate.BackColor;
                }
                catch (Exception)
                {
                    publishButton.BackColor = Color.LightCoral;
                }
                finally
                {
                    publishButton.Text = PublishButtonTemplate.Text;
                    publishButton.Enabled = true;
                }
            };
            return publishButton;
        }

        private Button CreateSyncButton(GitCommand git)
        {
            var syncButton = Clone(SyncButtonTemplate);

            syncButton.Click += async (sender, args) =>
            {
                try
                {
                    syncButton.Enabled = false;
                    syncButton.Text = "Working";
                    syncButton.BackColor = Color.LightGoldenrodYellow;
                    await Task.Run(git.Sync);
                    syncButton.BackColor = SyncButtonTemplate.BackColor;
                }
                catch (Exception)
                {
                    syncButton.BackColor = Color.LightCoral;
                }
                finally
                {
                    syncButton.Text = SyncButtonTemplate.Text;
                    syncButton.Enabled = true;
                }
            };
            return syncButton;
        }

        private Button CreateFetchButton(GitCommand git)
        {
            var fetchButton = Clone(FetchButtonTemplate);

            fetchButton.Click += async (sender, args) =>
            {
                try
                {
                    fetchButton.Enabled = false;
                    fetchButton.Text = "Working";
                    fetchButton.BackColor = Color.LightGoldenrodYellow;
                    await Task.Run(git.Fetch);
                    fetchButton.BackColor = FetchButtonTemplate.BackColor;
                }
                catch (Exception)
                {
                    fetchButton.BackColor = Color.LightCoral;
                }
                finally
                {
                    fetchButton.Text = FetchButtonTemplate.Text;
                    fetchButton.Enabled = true;
                }
            };
            return fetchButton;
        }
        #endregion

        #region Azure
        private async void AzureEmulatorStart_Click(object sender, EventArgs eventArgs)
        {
            try
            {
                AzureEmulatorStart.Enabled = false;
                AzureEmulatorStart.Text = "Working";
                await Task.Run(() => _azure.Start());
            }
            finally
            {
                var status = await _azure.GetStatus();
                AzureEmulatorLabel.Text = status.Item1;
                AzureEmulatorLabel.BackColor = status.Item2;
                AzureEmulatorStart.Enabled = true;
                AzureEmulatorStart.Text = "Start";
            }
        }

        private async void AzureEmulatorStop_Click(object sender, EventArgs eventArgs)
        {
            try
            {
                AzureEmulatorStop.Enabled = false;
                AzureEmulatorStop.Text = "Working";
                await Task.Run(() => _azure.Stop());
            }
            finally
            {
                var status = await _azure.GetStatus();
                AzureEmulatorLabel.Text = status.Item1;
                AzureEmulatorLabel.BackColor = status.Item2;
                AzureEmulatorStop.Enabled = true;
                AzureEmulatorStop.Text = "Stop";
            }
        }

        private async void AzureEmulatorLabel_Click(object sender, EventArgs eventArgs)
        {
            var status = await _azure.GetStatus();
            AzureEmulatorLabel.Text = status.Item1;
            AzureEmulatorLabel.BackColor = status.Item2;
        }
        #endregion


        #region WebJobs
        private void SearchJobsButton_Click(object sender, EventArgs e)
        {
            var jobs = WebJobHandler.GetHandlers(_settings);
            var nonExistingJobs = jobs.Where(h1 => _handlers.All(h2 => h1.FullPath != h2.FullPath));
            foreach (var handler in nonExistingJobs)
                AddWebJob(handler);
        }

        private void AddWebJob(WebJobHandler handler)
        {
            var statusLabel = Clone(WebJobStatusTemplate);
            var nameLabel = Clone(WebJobNameTempate);

            nameLabel.Text = handler.Name;

            var startButton = CreateRunButton(statusLabel, handler);
            var killButton = CreateKillButton(handler);
            var logButton = CreateWebJobLogButtton(handler.Name);

            _handlers.Add(handler);

            WebJobPanel.Controls.Add(startButton);
            WebJobPanel.Controls.Add(killButton);
            WebJobPanel.Controls.Add(logButton);
            WebJobPanel.Controls.Add(statusLabel);
            WebJobPanel.Controls.Add(nameLabel);
        }

        private Button CreateRunButton(Label statusLabel, WebJobHandler handler)
        {
            var runButton = Clone(StartButtonTemplate);
            runButton.Click += async (sender, args) =>
            {
                try
                {
                    runButton.Enabled = false;
                    runButton.BackColor = StartButtonTemplate.BackColor;
                    statusLabel.Text = "Running";
                    statusLabel.BackColor = Color.LightGreen;
                    await Task.Run(() => handler.Run());
                }
                catch (Exception)
                {
                    runButton.BackColor = Color.LightCoral;
                }
                finally
                {
                    statusLabel.Text = WebJobStatusTemplate.Text;
                    statusLabel.BackColor = WebJobStatusTemplate.BackColor;
                    runButton.Enabled = true;
                }
            };
            return runButton;
        }

        private Button CreateKillButton(WebJobHandler handler)
        {
            var killButton = Clone(KillWebJobButtonTemplate);

            killButton.Click += async (sender, args) =>
            {
                try
                {
                    killButton.Enabled = false;
                    await Task.Run(() => handler.Kill());
                    killButton.BackColor = KillWebJobButtonTemplate.BackColor;
                }
                catch (Exception)
                {
                    killButton.BackColor = Color.LightCoral;
                }
                finally
                {
                    killButton.Enabled = true;
                }
            };

            return killButton;
        }

        private Button CreateWebJobLogButtton(string name)
        {
            var viewLogButton = Clone(WebJobLogsTemplate);

            viewLogButton.Click += (sender, args) =>
            {
                var f = $"WebJob_{name}.txt";
                if (File.Exists(f))
                    _log.View(f);
            };

            return viewLogButton;
        }
        #endregion

        private T Clone<T>(T ctrl) where T : Control
        {
            var clone = Activator.CreateInstance(typeof(T)) as T ?? throw new Exception($"Could not clone {ctrl}");
            clone.Name = ctrl.Name;
            clone.Text = ctrl.Text;
            clone.Margin = ctrl.Margin;
            clone.Padding = ctrl.Padding;
            clone.Font = ctrl.Font;
            clone.Size = ctrl.Size;
            clone.BackColor = ctrl.BackColor;

            return clone;
        }
    }
}
