using PracaDyplomowa.Mobile.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PracaDyplomowa.Mobile.ViewModels
{
    public class LabelingGameViewModel
    {
        private readonly INavigation _navigation;
        private readonly LabelingGame _labelingGame;

        public ICollection<LabelItem> BoardItems { get; set; }
        public string LabelToFind { get; set; }
        public ICommand ChooseImageCommand { get; set; }

        public LabelingGameViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _labelingGame = new LabelingGame();
            ChooseImageCommand = new Command<LabelItem>(ChooseImage);
        }

        private void ChooseImage(object obj)
        {
            if (obj == null)
            {
                return;
            }
        }
        
    }
}
