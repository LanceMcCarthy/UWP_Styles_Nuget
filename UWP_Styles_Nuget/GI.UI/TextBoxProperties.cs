using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GI.UI
{
    public sealed class TextBoxProperties : DependencyObject
    {
        public static bool GetInitialized(DependencyObject obj)
        {
            return (bool) obj.GetValue(InitializedProperty);
        }

        public static void SetInitialized(DependencyObject obj, bool value)
        {
            obj.SetValue(InitializedProperty, value);
        }

        public bool Initialized
        {
            get { return (bool) GetValue(InitializedProperty); }
            set { SetValue(InitializedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Initialized.  This enables animation, styling, binding, etc...
        private static readonly DependencyProperty InitializedProperty =
            DependencyProperty.Register("Initialized", typeof(bool), typeof(TextBoxProperties), new PropertyMetadata(false,OnInitialized));



        private static void OnInitialized(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var AssociatedObject = (TextBox) d;
            AssociatedObject.GotFocus += AssociatedObject_GotFocus;
            AssociatedObject.LostFocus += AssociatedObject_LostFocus;
            AssociatedObject.TextChanged += AssociatedObject_TextChanged;
        }
        private static void AssociatedObject_LostFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            UpdateState(sender, false, true);
        }
        private static void AssociatedObject_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            UpdateState(sender, true, true);
        }

        private static void AssociatedObject_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateState(sender, true, false);
        }
        private static void UpdateState(object sender, bool _hasFocus, bool animate)
        {
            var AssociatedObject = (TextBox) sender;
            if (_hasFocus || !string.IsNullOrEmpty(AssociatedObject.Text))
            {
                VisualStateManager.GoToState(AssociatedObject, "NotEmpty", animate);
            }
            else
            {
                VisualStateManager.GoToState(AssociatedObject, "Empty", animate);
            }
        }
    }
}
