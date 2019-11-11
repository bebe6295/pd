using PracaDyplomowa.Mobile.Logic;
using PracaDyplomowa.Mobile.Services;
using Xamarin.Forms;

namespace PracaDyplomowa.Mobile.ViewModels
{
    public class ColorsGameViewModel : ChooseGameViewModel
    {
        public ColorsGameViewModel(INavigation navigation) : base(navigation, new ColorItemsProvider())
        {
        }
    }
}
