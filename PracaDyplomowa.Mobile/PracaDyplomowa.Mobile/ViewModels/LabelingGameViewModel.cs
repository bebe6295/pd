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
        private ICollection<LabelItem> _boardItems;
        private string _labelToFind;

        public ICollection<LabelItem> BoardItems { get => _boardItems; set => _boardItems = value; }
        public string LabelToFind { get => _labelToFind; set => _labelToFind = value; }
        public ICommand ChooseImageCommand { get; set; }

        public LabelingGameViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _labelingGame = new LabelingGame();
            ChooseImageCommand = new Command<LabelItem>(ChooseImage);

            _boardItems = new List<LabelItem>()
            {
                new LabelItem {ImageUri = "PracaDyplomowa.Mobile.Assets.Labeling.aparat.png"}
            };
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
