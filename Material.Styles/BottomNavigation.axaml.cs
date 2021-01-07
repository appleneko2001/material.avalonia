using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Generators;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;

namespace Material.Styles
{
    /// <summary>
    /// A bottom navigation control (clone of TabControl).
    /// </summary>
    public class BottomNavigation : TabControl
    {
        public static readonly StyledProperty<ColorZoneMode> ModeProperty = AvaloniaProperty.Register<BottomNavigation, ColorZoneMode>(nameof(Mode));
         
        public ColorZoneMode Mode
        {
            get => GetValue(ModeProperty);
            set => SetValue(ModeProperty, value);
        } 


    }
}
