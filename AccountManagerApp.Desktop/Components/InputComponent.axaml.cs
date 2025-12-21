using Avalonia;
using Avalonia.Controls;

namespace AccountManagerApp.Desktop.Components;

public partial class InputComponent : UserControl
{
    public static readonly StyledProperty<object> LabelProperty =
        AvaloniaProperty.Register<InputComponent, object>(nameof(Label));
    public object Label
    {
        get => GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public static readonly StyledProperty<object> ValueProperty =
            AvaloniaProperty.Register<InputComponent, object>(nameof(Value));
    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public InputComponent()
    {
        InitializeComponent();
    }
}

