using PracaDyplomowa.Mobile.Extensions;
using PracaDyplomowa.Mobile.Logic;
using PracaDyplomowa.Mobile.Services;
using PracaDyplomowa.Mobile.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PracaDyplomowa.Mobile.ViewModels
{
    public class LabelingGameViewModel : ViewModelBase
    {
        private readonly INavigation _navigation;
        private readonly LabelGame _labelingGame;
        private ObservableCollection<LabelItem> _boardItems;
        private string _labelToFind;
        private IGameItemsProvider<LabelItem> _labelItemsProvider;

        public ObservableCollection<LabelItem> BoardItems { get => _boardItems; set => SetField(ref _boardItems, value); }
        public string LabelToFind { get => _labelToFind; set => SetField(ref _labelToFind, value); }
        public ICommand ChooseImageCommand { get; set; }

        public LabelingGameViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _labelItemsProvider = new LabelItemsProvider();
            _labelingGame = new LabelGame(_labelItemsProvider.GetGameItems());

            ChooseImageCommand = new Command<LabelItem>(ChooseImage);
            LabelToFind = _labelingGame.CurrentLabelItem.Label;
            BoardItems = new ObservableCollection<LabelItem>(_labelingGame.BoardItems);
        }

        private void ChooseImage(LabelItem labelItem)
        {
            if (labelItem == null)
            {
                return;
            }

            if(_labelingGame.MakeChoice(labelItem))
            {
                BoardItems = new ObservableCollection<LabelItem>(_labelingGame.BoardItems);
                LabelToFind = _labelingGame.CurrentLabelItem.Label;
            }
        }
    }
}
