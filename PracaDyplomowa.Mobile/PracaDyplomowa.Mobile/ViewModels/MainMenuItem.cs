using System.Windows.Input;

namespace PracaDyplomowa.Mobile.ViewModels
{
    public class MainMenuItem
    {
        public string Label { get; set; }
        public MainMenuValue Value { get; set; }
        public ICommand OnClickCommand { get; set; }

        public MainMenuItem(string label, MainMenuValue value, ICommand onClickCommand)
        {
            Label = label;
            Value = value;
            OnClickCommand = onClickCommand;
        }
    }
}
