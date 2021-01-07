using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Mixins;
using Avalonia.Controls.Primitives;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;

namespace Material.Styles
{
    /// <summary>
    /// A bottom navigation action control (clone of MenuItem but designed for BottomNavigation).
    /// </summary>
    [PseudoClasses(":icon", ":pressed", ":selected")]
    public class BottomNavigationAction : HeaderedContentControl, ISelectable
    {
        /// <summary>
        /// Defines the <see cref="Icon"/> property.
        /// </summary>
        public static readonly StyledProperty<object> IconProperty =
            AvaloniaProperty.Register<BottomNavigationAction, object>(nameof(Icon));

        /// <summary>
        /// Defines the <see cref="IsSelected"/> property.
        /// </summary>
        public static readonly StyledProperty<bool> IsSelectedProperty =
            ListBoxItem.IsSelectedProperty.AddOwner<BottomNavigationAction>();


        static BottomNavigationAction()
        {
            SelectableMixin.Attach<BottomNavigationAction>(IsSelectedProperty);
            PressedMixin.Attach<BottomNavigationAction>();
            IconProperty.Changed.AddClassHandler<BottomNavigationAction>((x, e) => x.IconChanged(e));
            IsSelectedProperty.Changed.AddClassHandler<BottomNavigationAction>((x, e) => x.IsSelectedChanged(e));
        }

        /// <summary>
        /// Gets or sets the icon that appears in a <see cref="BottomNavigationAction"/>.
        /// </summary>
        public object Icon
        {
            get { return GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
         
        public BottomNavigationAction()
        { 

        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="BottomNavigationAction"/> is currently selected.
        /// </summary>
        public bool IsSelected
        {
            get { return GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        /// <summary>
        /// Called when the <see cref="Icon"/> property changes.
        /// </summary>
        /// <param name="e">The property change event.</param>
        private void IconChanged(AvaloniaPropertyChangedEventArgs e)
        {
            var oldValue = e.OldValue as ILogical;
            var newValue = e.NewValue as ILogical;

            if (oldValue != null)
            {
                LogicalChildren.Remove(oldValue);
                PseudoClasses.Remove(":icon");
            }

            if (newValue != null)
            {
                LogicalChildren.Add(newValue);
                PseudoClasses.Add(":icon");
            }
        }

        /// <summary>
        /// Called when the <see cref="IsSelected"/> property changes.
        /// </summary>
        /// <param name="e">The property change event.</param>
        private void IsSelectedChanged(AvaloniaPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue!)
            {
                Focus();
            }
        }
    }
}
