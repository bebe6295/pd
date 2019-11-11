using PracaDyplomowa.Mobile.Logic;
using PracaDyplomowa.Mobile.Services;
using PracaDyplomowa.Mobile.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace PracaDyplomowa.Mobile.ViewModels
{
    public class ChooseGameViewModel : ViewModelBase
    {
        private readonly INavigation _navigation;
        private readonly ChooseGame<Source> _chooseGame;
        private ObservableCollection<Source> _boardItems;
        private string _labelToFind;
        private IGameItemsProvider<Source> _itemProvider;

        public ICommand ChooseImageCommand { get; set; }
        public string LabelToFind { get => _labelToFind; set => SetField(ref _labelToFind, value); }
        public ObservableCollection<Source> BoardItems { get => _boardItems; set => SetField(ref _boardItems, value); }

        public ChooseGameViewModel(INavigation navigation, IGameItemsProvider<Source> itemProvider)
        {
            _navigation = navigation;
            _itemProvider = itemProvider;
            _chooseGame = new ChooseGame<Source>(_itemProvider.GetGameItems());

            LabelToFind = _chooseGame.CurrentItem.Label;
            ChooseImageCommand = new Command<Source>(ChooseImage);
            BoardItems = new ObservableCollection<Source>(_chooseGame.BoardItems);
        }

        private void ChooseImage(Source item)
        {
            if (item == null)
            {
                return;
            }

            if (_chooseGame.MakeChoice(item))
            {
                BoardItems = new ObservableCollection<Source>(_chooseGame.BoardItems);
                LabelToFind = _chooseGame.CurrentItem.Label;
            }
        }
    }
}
