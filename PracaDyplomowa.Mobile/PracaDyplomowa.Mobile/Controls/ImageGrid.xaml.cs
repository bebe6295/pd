using PracaDyplomowa.Mobile.Extensions;
using PracaDyplomowa.Mobile.Logic;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracaDyplomowa.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageGrid : ContentView
    {
        public static readonly BindableProperty ItemsProperty =
            BindableProperty.Create("Items", typeof(ICollection<ISource>), typeof(ImageGrid), default,
                propertyChanged: (bindable, oldValue, newValue) => { ((ImageGrid)bindable).GenerateGrid(newValue as ICollection<ISource>); });

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(ImageGrid), default);

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(ImageGrid), default);

        public ICollection<ISource> Items
        {
            get => (ICollection<ISource>)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public ImageGrid()
        {
            InitializeComponent();
        }

        private void GenerateGrid(ICollection<ISource> items)
        {
            if (items == null)
            {
                return;
            }

            var grid = new Grid();

            var pairs = items.PairUp().ToArray();

            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            for (int row = 0; row < pairs.Length; row++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

                var pair = pairs[row].ToArray();
                for (int column = 0; column < pair.Length; column++)
                {
                    var item = pair[column];

                    grid.Children.Add(
                        new ImageButton
                        {
                            Command = Command,
                            CommandParameter = item,
                            Source = ImageSource.FromResource(item.ImageUri, typeof(ImageResourceExtension).GetTypeInfo().Assembly)
                        }, column, row); ;
                }
            }

            Content = grid;
        }
    }
}