using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracaDyplomowa.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageGrid : ContentView
    {
        public ImageGrid()
        {
            InitializeComponent();
        }

        private void GenerateGrid(ICollection<object> items)
        {
            var grid = new Grid();

        }
    }
}