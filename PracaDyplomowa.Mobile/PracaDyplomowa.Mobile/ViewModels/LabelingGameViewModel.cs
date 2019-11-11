using PracaDyplomowa.Mobile.Logic;
using PracaDyplomowa.Mobile.Services;
using Xamarin.Forms;

namespace PracaDyplomowa.Mobile.ViewModels
{
    public class LabelingGameViewModel : ChooseGameViewModel<LabelItem>
    {
        public LabelingGameViewModel(INavigation navigation) : base(navigation, new LabelItemsProvider())
        {
        }
    }
}
