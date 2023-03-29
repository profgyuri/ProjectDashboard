namespace ProjectDashboard.Lib.Notifications;

using MediatR;
using ProjectDashboard.Lib.Models;

internal class NewProjectCreatedNotification : INotification
{
    public Solution Solution { get; set; }

    public NewProjectCreatedNotification(Solution solution)
    {
        Solution = solution;
    }
}
