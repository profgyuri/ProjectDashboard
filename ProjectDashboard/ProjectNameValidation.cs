using System.Globalization;
using System.Windows.Controls;

namespace ProjectDashboard;

public class ProjectNameValidation : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        var projectName = value as string;

        if (string.IsNullOrEmpty(projectName) || projectName.Length < 3)
        {
            return new ValidationResult(false, "Project name must be at least 3 characters long.");
        }

        return ValidationResult.ValidResult;
    }
}