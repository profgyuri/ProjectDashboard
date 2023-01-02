namespace ProjectDashboard.Lib.Models;

public sealed class Solution
{
    public Guid Id { get; }
    public required string Name { get; set; }
    public required string SolutionPath { get; set; }
    public required string DebugPath { get; set; }
    public required string ReleasePath { get; set; }
    public required string PublishedPath { get; set; }

    private Solution()
    {
        Id = Guid.NewGuid();
    }
    
    public static Solution Create(string name, string solutionPath, string exePath, string debugPath, string releasePath, string publishedPath)
    {
        return new Solution
        {
            Name = name,
            SolutionPath = solutionPath,
            DebugPath = debugPath,
            ReleasePath = releasePath,
            PublishedPath = publishedPath
        };
    }
};