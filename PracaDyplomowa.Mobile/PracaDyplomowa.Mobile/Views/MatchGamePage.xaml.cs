using PracaDyplomowa.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracaDyplomowa.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchGamePage : ContentPage
    {
        public MatchGamePage()
        {
            InitializeComponent();
            BindingContext = new MatchGameViewModel();
        }
    }
}