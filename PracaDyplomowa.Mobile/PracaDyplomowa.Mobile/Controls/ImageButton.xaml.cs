using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracaDyplomowa.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageButton : ContentView
    {
        #region Properties
        public static readonly BindableProperty ImageSourceProperty =
            BindableProperty.Create("Source", typeof(ImageSource), typeof(ImageButton), default);

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(ImageButton), default);

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(ImageButton), default);

        public ImageSource Source
        {
            get => (ImageSource)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }
        #endregion

        public ImageButton()
        {
            InitializeComponent();
        }
    }
}