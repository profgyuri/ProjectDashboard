using System.Reflection;
using Microsoft.Win32;

namespace ProjectDashboard.Library.Data;

public static class RegistryHelper
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

    public static void StartWithWindows(bool start)
    {
        var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
        if (start)
        {
            key.SetValue("ProjectDashboard", Assembly.GetExecutingAssembly().Location);
        }
        else
        {
            key.DeleteValue("ProjectDashboard", false);
        }
    }
}