using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using GitAppLocalCore.Models;

namespace GitAppLocalCore.Forms
{
    public partial class GlobalSettingsForm : Form
    {
        private Settings _settings;

        public GlobalSettingsForm()
        {
            InitializeComponent();
        }

        private void GlobalSettingsForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Settings.Path))
                    File.Copy("Settings.default.json", Settings.Path);

                var data = File.ReadAllText(Settings.Path);
                _settings = JsonConvert.DeserializeObject<Settings>(data);
                GitPath.Text = _settings.GitPath;
                AzureStorageEmulatorPath.Text = _settings.AzureStorageEmulatorPath;
                WwwRootPath.Text = _settings.WwwRootPath;
                OtherRootPath.Text = _settings.OtherRootPath;
                CoreRootPath.Text = _settings.CoreRootPath;
                ProxyRootPath.Text = _settings.ProxyRootPath;
                MsBuild.Text = _settings.MsBuild;
                LogViewer.Text = _settings.LogViewer;

                InstallCredentials();

                if (SettingsValid())
                    Close();
            }
            catch (Exception)
            {
                Application.Exit();
            }
        }

        private void InstallCredentials()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Nuget", "CredentialProviders");
            var file = "CredentialProvider.Vss.exe";

            if (!File.Exists(Path.Combine(path, file)))
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                File.Copy(file, Path.Combine(path, file));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _settings.GitPath = GitPath.Text;
            _settings.AzureStorageEmulatorPath = AzureStorageEmulatorPath.Text;
            _settings.WwwRootPath = WwwRootPath.Text;
            _settings.OtherRootPath = OtherRootPath.Text;
            _settings.CoreRootPath = CoreRootPath.Text;
            _settings.ProxyRootPath = ProxyRootPath.Text;
            _settings.MsBuild = MsBuild.Text;
            _settings.LogViewer = LogViewer.Text;

            if (SettingsValid())
            {
                var data = JsonConvert.SerializeObject(_settings, Formatting.Indented);
                File.WriteAllText(Settings.Path, data);
                Close();
            }
        }

        private bool SettingsValid()
        {
            var result = true;

            if (!File.Exists(_settings.GitPath))
            {
                GitPath.BackColor = Color.LightCoral;
                result = false;
            }
            if (!File.Exists(_settings.AzureStorageEmulatorPath))
            {
                AzureStorageEmulatorPath.BackColor = Color.LightCoral;
                result = false;
            }
            if (!Directory.Exists(_settings.WwwRootPath))
            {
                WwwRootPath.BackColor = Color.LightCoral;
                result = false;
            }
            if (!Directory.Exists(_settings.OtherRootPath))
            {
                OtherRootPath.BackColor = Color.LightCoral;
                result = false;
            }
            if (!Directory.Exists(_settings.CoreRootPath))
            {
                CoreRootPath.BackColor = Color.LightCoral;
                result = false;
            }
            if (!Directory.Exists(_settings.ProxyRootPath))
            {
                ProxyRootPath.BackColor = Color.LightCoral;
                result = false;
            }
            if (!File.Exists(_settings.MsBuild))
            {
                MsBuild.BackColor = Color.LightCoral;
                result = false;
            }
            if (!File.Exists(_settings.LogViewer))
            {
                LogViewer.BackColor = Color.LightCoral;
                result = false;
            }

            return result;
        }
    }
}