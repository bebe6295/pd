using PracaDyplomowa.Mobile.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracaDyplomowa.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuItemsGrid : ContentView
    {
        public static readonly BindableProperty MenuItemsProperty =
            BindableProperty.Create("MenuItems", typeof(ICollection<MainMenuItem>), typeof(ImageGrid), default, propertyChanged: (bindable, oldValue, newValue) => { ((MenuItemsGrid)bindable).GenerateMenu(newValue as ICollection<MainMenuItem>); });

        public ICollection<MainMenuItem> MenuItems
        {
            get => (ICollection<MainMenuItem>)GetValue(MenuItemsProperty);
            set => SetValue(MenuItemsProperty, value);
        }

        public MenuItemsGrid()
        {
            InitializeComponent();
        }

        private void GenerateMenu(ICollection<MainMenuItem> menuItems)
        {
            if (menuItems == null)
            {
                return;
            }

            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.5, GridUnitType.Star) });

            var items = menuItems.ToArray();

            for (int row = 0; row < items.Length; row++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                var menuItem = items[row];
                var button = new Button { Text = menuItem.Label, Command = menuItem.OnClickCommand, CommandParameter = menuItem, Padding = 64 };
                grid.Children.Add(button, 1, row + 1);
            }

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.5, GridUnitType.Star) });

            Content = grid;
        }
    }
}