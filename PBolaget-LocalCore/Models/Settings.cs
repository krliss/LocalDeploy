using Newtonsoft.Json;
using System.Collections.Generic;

namespace GitAppLocalCore.Models
{
    public class Settings
    {
        public const string Path = "Settings.json";

        public string GitPath { get; set; }

        public string AzureStorageEmulatorPath { get; set; }

        public string MsBuild { get; set; }

        public string WwwRootPath { get; set; }

        public string CodeRootPath(Repository repo)
        {
            switch (repo.ServiceType)
            {
                case ServiceType.I_Site:
                    return CoreRootPath;
                case ServiceType.Service:
                    return ProxyRootPath;
                case ServiceType.Other:
                default:
                    return OtherRootPath;
            }
        }

        public string CoreRootPath { get; set; }

        public string ProxyRootPath { get; set; }

        public string OtherRootPath { get; set; }

        public string LogViewer { get; set; }

        [JsonIgnore]
        public List<Repository> Repositories { get; set; }
    }

    public class Repository
    {
        public const string Path = "Repositories.json";

        public string LocalPath { get; set; }

        public string RemotePath { get; set; }

        public string Configuration { get; set; }

        public string PublishProfile { get; set; }

        public ServiceType ServiceType { get; set; }

        public bool DoDeploy { get; set; } = false;
    }

    public enum ServiceType
    {
        I_Site,
        Service,
        Other,
    }
}
