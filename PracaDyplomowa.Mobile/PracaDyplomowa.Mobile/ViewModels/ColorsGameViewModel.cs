using PracaDyplomowa.Mobile.Logic;
using PracaDyplomowa.Mobile.Services;
using PracaDyplomowa.Mobile.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace PracaDyplomowa.Mobile.ViewModels
{
    public class ColorsGameViewModel : ViewModelBase
    {
        private readonly INavigation _navigation;
        private readonly ColorGame _colorGame;
        private ObservableCollection<ColorItem> _boardItems;
        private string _labelToFind;
        private IGameItemsProvider<ColorItem> _ColorItemsProvider;

        public ObservableCollection<ColorItem> BoardItems { get => _boardItems; set => SetField(ref _boardItems, value); }
        public string LabelToFind { get => _labelToFind; set => SetField(ref _labelToFind, value); }
        public ICommand ChooseImageCommand { get; set; }

        public ColorsGameViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _ColorItemsProvider = new ColorItemsProvider();
            _colorGame = new ColorGame(_ColorItemsProvider.GetGameItems());

            ChooseImageCommand = new Command<ColorItem>(ChooseImage);
            LabelToFind = _colorGame.CurrentColorItem.Label;
            BoardItems = new ObservableCollection<ColorItem>(_colorGame.BoardItems);
        }

        private void ChooseImage(ColorItem ColorItem)
        {
            if (ColorItem == null)
            {
                return;
            }

            if (_colorGame.MakeChoice(ColorItem))
            {
                BoardItems = new ObservableCollection<ColorItem>(_colorGame.BoardItems);
                LabelToFind = _colorGame.CurrentColorItem.Label;
            }
        }
    }
}
