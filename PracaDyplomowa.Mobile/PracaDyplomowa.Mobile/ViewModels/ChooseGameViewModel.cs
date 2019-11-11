using PracaDyplomowa.Mobile.Logic;
using PracaDyplomowa.Mobile.Services;
using PracaDyplomowa.Mobile.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace PracaDyplomowa.Mobile.ViewModels
{
    public class ChooseGameViewModel<T> : ViewModelBase where T : class, ISource
    {
        private readonly INavigation _navigation;
        private readonly ChooseGame<T> _chooseGame;
        private ObservableCollection<T> _boardItems;
        private string _labelToFind;
        private IGameItemsProvider<T> _itemProvider;

        public ICommand ChooseImageCommand { get; set; }
        public string LabelToFind { get => _labelToFind; set => SetField(ref _labelToFind, value); }
        public ObservableCollection<T> BoardItems { get => _boardItems; set => SetField(ref _boardItems, value); }

        public ChooseGameViewModel(INavigation navigation, IGameItemsProvider<T> itemProvider)
        {
            _navigation = navigation;
            _itemProvider = itemProvider;
            _chooseGame = new ChooseGame<T>(_itemProvider.GetGameItems());

            LabelToFind = _chooseGame.CurrentItem.Label;
            ChooseImageCommand = new Command<T>(ChooseImage);
            BoardItems = new ObservableCollection<T>(_chooseGame.BoardItems);
        }

        private void ChooseImage(T item)
        {
            if (item == null)
            {
                return;
            }

            if (_chooseGame.MakeChoice(item))
            {
                BoardItems = new ObservableCollection<T>(_chooseGame.BoardItems);
                LabelToFind = _chooseGame.CurrentItem.Label;
            }
        }
    }
}
