﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProjectDashboard.WPF.Resources;

internal sealed class CorneredButton : Button
{
    #region Border Radius Property
    public static readonly DependencyProperty BorderRadiusProperty =
        DependencyProperty.Register("BorderRadius", typeof(CornerRadius), typeof(CorneredButton),
            new PropertyMetadata(default(CornerRadius)));

    public CornerRadius BorderRadius
    {
        get => (CornerRadius) GetValue(BorderRadiusProperty);
        set => SetValue(BorderRadiusProperty, value);
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
        get => (Brush) GetValue(MouseOverBackgroundProperty);
        set => SetValue(MouseOverBackgroundProperty, value);
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
        get => (Brush) GetValue(PressedBackgroundProperty);
        set => SetValue(PressedBackgroundProperty, value);
    }
    #endregion
}