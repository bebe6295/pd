using PracaDyplomowa.Mobile.Extensions;
using PracaDyplomowa.Mobile.Logic;
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
        private readonly LabelingGame _labelingGame;
        private ObservableCollection<LabelItem> _boardItems;
        private string _labelToFind;

        public ObservableCollection<LabelItem> BoardItems { get => _boardItems; set => SetField(ref _boardItems, value); }
        public string LabelToFind { get => _labelToFind; set => SetField(ref _labelToFind, value); }
        public ICommand ChooseImageCommand { get; set; }

        public LabelingGameViewModel(INavigation navigation)
        {
            _navigation = navigation;
            var labelItems = GetLabelItems();
            _labelingGame = new LabelingGame(labelItems);

            ChooseImageCommand = new Command<LabelItem>(ChooseImage);
            LabelToFind = _labelingGame.CurrentLabelItem.Label;

            BoardItems = new ObservableCollection<LabelItem>(_labelingGame.BoardItems);

        }

        private void ChooseImage(LabelItem obj)
        {
            if (obj == null)
            {
                return;
            }
        }

        private IEnumerable<LabelItem> GetLabelItems()
        {
            var assembly = typeof(ImageResourceExtension).GetTypeInfo().Assembly;
            return assembly.GetManifestResourceNames()
                           .Where(x => x.StartsWith("PracaDyplomowa.Mobile.Assets.Labeling"))
                           .Select(x => new LabelItem { 
                            ImageUri = x,
                            Label = x.Replace(".png", "").Split('.').Last()
                           });
        }
    }
}
