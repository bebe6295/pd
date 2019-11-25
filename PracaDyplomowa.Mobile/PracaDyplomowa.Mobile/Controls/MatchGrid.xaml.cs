using PracaDyplomowa.Mobile.Extensions;
using PracaDyplomowa.Mobile.Logic;
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
    public partial class MatchGrid : ContentView
    {
        public static readonly BindableProperty ItemsProperty =
            BindableProperty.Create(nameof(Items), typeof(ObservableCollection<Source>), typeof(MatchGrid), new ObservableCollection<Source>(),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((MatchGrid)bindable).GenerateGrid(newValue as IEnumerable<ISource>);
                });

        public static readonly BindableProperty SelectedProperty =
            BindableProperty.Create(nameof(Selected), typeof(Source), typeof(MatchGrid), null,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((MatchGrid)bindable).GenerateGrid(((MatchGrid)bindable).Items);
                });

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MatchGrid), default,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((MatchGrid)bindable).GenerateGrid(((MatchGrid)bindable).Items);
                });

        public ObservableCollection<Source> Items
        {
            get => (ObservableCollection<Source>)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        public Source Selected
        {
            get => (Source)GetValue(SelectedProperty);
            set => SetValue(SelectedProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public MatchGrid()
        {
            InitializeComponent();
        }

        public void GenerateGrid(IEnumerable<ISource> items)
        {
            if (items == null || !items.Any())
            {
                return;
            }

            var grid = new Grid();

            var arr = items.ToList();

            for (int row = 0; row < arr.Count; row++)
            {
                var item = arr[row];

                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

                var button = new ImageButton
                {
                    Command = Command,
                    CommandParameter = item,
                    Source = ImageSource.FromResource(item.ImageUri, typeof(ImageResourceExtension).GetTypeInfo().Assembly)
                };

                if (Selected == item)
                {
                    button.BorderColor = Color.Red;
                    button.BorderWidth = 2;
                }


                grid.Children.Add(button, 0, row);
            }

            Content = grid;
        }
    }
}