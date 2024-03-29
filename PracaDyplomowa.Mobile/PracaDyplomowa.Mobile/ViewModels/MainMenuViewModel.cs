﻿using PracaDyplomowa.Mobile.ViewModels.Base;
using PracaDyplomowa.Mobile.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracaDyplomowa.Mobile.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        public ICollection<MainMenuItem> MenuItems { get => menuItems; set => SetField(ref menuItems, value); }

        private readonly INavigation _navigation;
        private ICollection<MainMenuItem> menuItems;

        public MainMenuViewModel(INavigation navigation)
        {
            _navigation = navigation;

            MenuItems = InitializeMainMenuItems();
        }

        private async Task GoToPage(MainMenuItem mainMenuItem)
        {
            if (mainMenuItem is null)
            {
                return;
            }

            switch (mainMenuItem.Value)
            {
                case MainMenuValue.MatchingGame:
                    await _navigation.PushAsync(new MatchGamePage());
                    break;
                case MainMenuValue.LabelingGame:
                    await _navigation.PushAsync(new LabelingGameView());
                    break;
                case MainMenuValue.ColoringGame:
                    await _navigation.PushAsync(new ColoringGamePage());
                    break;
                case MainMenuValue.WritingGame:
                    await _navigation.PushAsync(new WritingGamePage());
                    break;
                case MainMenuValue.DrawingGame:
                    await _navigation.PushAsync(new DrawingGamePage());
                    break;
                default:
                    break;
            }
        }

        private ICollection<MainMenuItem> InitializeMainMenuItems()
        {
            var command = new Command<MainMenuItem>(async (menuItem) => await GoToPage(menuItem));

            return new List<MainMenuItem>
            {
                new MainMenuItem("Etykietowanie", MainMenuValue.LabelingGame, command),
                new MainMenuItem("Dopasowywanie", MainMenuValue.MatchingGame, command),
                new MainMenuItem("Kolory", MainMenuValue.ColoringGame, command),
                new MainMenuItem("Motoryka mała", MainMenuValue.WritingGame, command),
                new MainMenuItem("Rysowanie", MainMenuValue.DrawingGame, command),
            };
        }
    }
}
