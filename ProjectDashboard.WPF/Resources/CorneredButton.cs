using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProjectDashboard.WPF.Resources;

public sealed class CorneredButton : Button
{
    #region Border Radius Property
    public static readonly DependencyProperty BorderRadiusProperty =
        DependencyProperty.Register("BorderRadius", typeof(CornerRadius), typeof(CorneredButton), new PropertyMetadata(default(CornerRadius)));

    public CornerRadius BorderRadius
    {
        get { return (CornerRadius)GetValue(BorderRadiusProperty); }
        set { SetValue(BorderRadiusProperty, value); }
    }
    #endregion

    #region Mouse Over Background Property
    public static readonly DependencyProperty MouseOverBackgroundProperty =
        DependencyProperty.Register(
            "MouseOverBackground",
            typeof(Brush),
            typeof(CorneredButton),
            new PropertyMetadata(Brushes.Transparent));

    public Brush MouseOverBackground
    {
        get { return (Brush)GetValue(MouseOverBackgroundProperty); }
        set { SetValue(MouseOverBackgroundProperty, value); }
    }
    #endregion

    #region Pressed Background Property
    public static readonly DependencyProperty PressedBackgroundProperty =
        DependencyProperty.Register(
            "PressedBackground",
            typeof(Brush),
            typeof(CorneredButton),
            new PropertyMetadata(Brushes.Transparent));

    public Brush PressedBackground
    {
        get { return (Brush)GetValue(PressedBackgroundProperty); }
        set { SetValue(PressedBackgroundProperty, value); }
    }
    #endregion
}
