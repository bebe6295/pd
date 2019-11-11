using PracaDyplomowa.Mobile.Services;
using Xamarin.Forms;

namespace PracaDyplomowa.Mobile.ViewModels
{
    public class LabelingGameViewModel : ChooseGameViewModel
    {
        public LabelingGameViewModel(INavigation navigation) : base(navigation, new LabelItemsProvider())
        {
        }
    }
}
