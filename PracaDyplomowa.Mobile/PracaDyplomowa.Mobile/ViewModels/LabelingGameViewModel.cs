using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracaDyplomowa.Mobile.ViewModels
{
    public class LabelingGameViewModel
    {
        private readonly INavigation _navigation;

        public LabelingGameViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

        private async Task ChooseLabel(object obj)
        {
            await Task.Yield();
        }
        
    }

    public class LabelingGame
    {
        public ICollection<LabeledImage> LabeledImages { get; set; }

        public async Task MakeChoice()
        {
            await Task.Yield();
        }

        private async Task GenerateRound()
        {
            await Task.Yield();

        }
    }

    public class LabeledImage
    {
        public string Label { get; set; }
        public string ImageUrl { get; set; }
    }

    public enum GameState : byte
    {
        NotInitialized,
        WaitingForChoice,
        Error,
        Success,
        GameOver
    }
}
