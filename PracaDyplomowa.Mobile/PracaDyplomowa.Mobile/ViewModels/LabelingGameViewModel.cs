using PracaDyplomowa.Mobile.Logic;
using PracaDyplomowa.Mobile.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PracaDyplomowa.Mobile.ViewModels
{
    public class LabelingGameViewModel : ViewModelBase
    {
        private readonly INavigation _navigation;
        private readonly LabelingGame _labelingGame;
        private ObservableCollection<LabelItem> _boardItems;
        private string _labelToFind;

        public ObservableCollection<LabelItem> BoardItems { get => _boardItems; set => SetField(ref _boardItems, value); }
        public string LabelToFind { get => _labelToFind; set => SetField(ref _labelToFind, value); }
        public ICommand ChooseImageCommand { get; set; }

        public LabelingGameViewModel(INavigation navigation)
        {
            _navigation = navigation;
            ChooseImageCommand = new Command<LabelItem>(ChooseImage);
            LabelToFind = "label";

            BoardItems = new ObservableCollection<LabelItem>(new List<LabelItem>()
            {
                new LabelItem {ImageUri = "PracaDyplomowa.Mobile.Assets.Labeling.aparat.png"},
                new LabelItem {ImageUri = "PracaDyplomowa.Mobile.Assets.Labeling.aparat.png"},
                new LabelItem {ImageUri = "PracaDyplomowa.Mobile.Assets.Labeling.aparat.png"},
                new LabelItem {ImageUri = "PracaDyplomowa.Mobile.Assets.Labeling.aparat.png"},
            });

            //_labelingGame = new LabelingGame(_boardItems);
        }

        private void ChooseImage(LabelItem obj)
        {
            if (obj == null)
            {
                return;
            }
        }

    }
}
