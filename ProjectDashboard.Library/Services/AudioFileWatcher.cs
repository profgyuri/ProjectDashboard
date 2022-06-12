namespace ProjectDashboard.Library.Services;

using ProjectDashboard.Library.Models;
using System.Diagnostics;

public class AudioFileWatcher : IService
{
    private readonly FileSystemWatcher _fileSystemWatcher;

    public string Name { get; set; }

    public AudioFileWatcher()
    {
        Name = "Audio File Watcher";
        _fileSystemWatcher = new FileSystemWatcher()
        {
            Filters = { "*.aa", "*.aax", "*.aac", "*.aiff", "*.ape", "*.dsf", "*.flac", "*.m4a", "*.m4b", "*.m4p", "*.mp3",
                "*.mpc", "*.mpp", "*.ogg", "*.oga", "*.wav", "*.wma", "*.wv", "*.webm" },
            Path = @"e:\Letöltés\",
            IncludeSubdirectories = true,
            EnableRaisingEvents = true
        };
        _fileSystemWatcher.Created += NewFileCreated;
    }

    private void NewFileCreated(object sender, FileSystemEventArgs e)
    {
        //start Mp3tag.exe with the filename as parameter
        var process = new Process();
        try
        {
            process.StartInfo.FileName = @"C:\Program Files (x86)\Mp3tag\Mp3tag.exe";
            process.StartInfo.Arguments = $"\"{e.FullPath}\"";
            process.Start();
            process.WaitForExit();
        }
        catch(Exception){
            //just to avoid crashes
        }
    }
}
