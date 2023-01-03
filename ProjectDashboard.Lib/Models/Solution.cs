using System.ComponentModel.DataAnnotations;

namespace ProjectDashboard.Lib.Models;

public sealed class Solution
{
    [Key] public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string SolutionPath { get; set; }
    public string ExePath { get; set; } = default!;
};