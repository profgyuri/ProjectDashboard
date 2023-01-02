namespace ProjectDashboard.Lib.Models;

public sealed class Solution
{
    public Guid Id { get; }
    public required string Name { get; set; }
    public required string SolutionPath { get; set; }
    public required string ExePath { get; set; }

    private Solution()
    {
        Id = Guid.NewGuid();
    }
    
    public static Solution Create(string name, string solutionPath, string exePath)
    {
        return new Solution
        {
            Name = name,
            SolutionPath = solutionPath,
            ExePath = exePath
        };
    }
};