using PracaDyplomowa.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracaDyplomowa.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColoringGamePage : ContentPage
    {
        public ColoringGamePage()
        {
            InitializeComponent();
            BindingContext = new ColorsGameViewModel(Navigation);
        }
    }
}