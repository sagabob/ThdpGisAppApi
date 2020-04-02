using System.Diagnostics;
using System.Reflection;

namespace TdpGisApi.Services.Utility
{
    public class VersionInformation
    {
        public string BuiltTag { get; set; }

        public string Version { get; set; }

        public string FileVersion { get; set; }

        public string ProductVersion { get; set; }
    }

    public class VersionUtility
    {
        public static VersionInformation GetVersion(VersionInformation versionInfo)
        {
            versionInfo.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            versionInfo.FileVersion =
                FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            versionInfo.ProductVersion =
                FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
            return versionInfo;
        }
    }
}