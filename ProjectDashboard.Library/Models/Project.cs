namespace ProjectDashboard.Library.Models;
using System.Diagnostics;
using System.Runtime.Serialization;
using CommunityToolkit.Mvvm.Input;
using ProjectDashboard.Library.Data;

[DataContract]
public abstract partial class Project
{
    /// <summary>
    ///     Name of the project.
    /// </summary>
    [DataMember]
    public string ProjectName { get; set; } = String.Empty;
}