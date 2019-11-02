using PracaDyplomowa.Mobile.Extensions;
using PracaDyplomowa.Mobile.Logic;
using PracaDyplomowa.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            BindableProperty.Create(nameof(Items), typeof(ObservableCollection<LabelItem>), typeof(ImageGrid), new ObservableCollection<LabelItem>(),
                propertyChanged: (bindable, oldValue, newValue) => { 
                    ((ImageGrid)bindable).GenerateGrid(newValue as IEnumerable<ISource>); 
                });

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ImageGrid), default,
                propertyChanged: (bindable, oldValue, newValue) => {
                    ((ImageGrid)bindable).GenerateGrid(((ImageGrid)bindable).Items); 
            });

        public ObservableCollection<LabelItem> Items
        {
            get => (ObservableCollection<LabelItem>)GetValue(ItemsProperty);
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

        private void GenerateGrid(IEnumerable<ISource> items)
        {
            if (items == null || !items.Any())
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