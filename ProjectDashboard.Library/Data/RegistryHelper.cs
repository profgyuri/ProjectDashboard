using Microsoft.Win32;

namespace ProjectDashboard.Library.Data;

internal static class RegistryHelper
{
    internal static string? GetRiderPath()
    {
        try
        {
            var riderInstalls = Registry.CurrentUser.OpenSubKey(@"Software\JetBrains\Rider");
            var latest = riderInstalls.GetSubKeyNames().Last(x => x.StartsWith("v") && !x.EndsWith("Any"));
            var installPath = riderInstalls.OpenSubKey(latest).GetValue("InstallDir");
            var exepath = Path.Combine(installPath.ToString(), "bin", "rider64.exe");
            return exepath;
        }
        catch (Exception)
        {
            return null;
        }
    }
}