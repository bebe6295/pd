using PracaDyplomowa.Mobile.Logic;
using PracaDyplomowa.Mobile.Services;
using PracaDyplomowa.Mobile.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace PracaDyplomowa.Mobile.ViewModels
{
    public class MatchGameViewModel : ViewModelBase
    {
        private Source _selectedFigure;
        private Source _selectedBorder;
        private ObservableCollection<Source> _borders;
        private ObservableCollection<Source> _figures;

        public Source SelectedBorder { get => _selectedBorder; set => SetField(ref _selectedBorder, value); }
        public Source SelectedFigure { get => _selectedFigure; set => SetField(ref _selectedFigure, value); }

        public ObservableCollection<Source> Borders { get => _borders; set => SetField(ref _borders, value); }
        public ObservableCollection<Source> Figures { get => _figures; set => SetField(ref _figures, value); }

        private readonly IEnumerable<MatchItem> _matchItems;

        public ICommand SelectBorderCommand { get; }
        public ICommand SelectFigureCommand { get; }

        public MatchGameViewModel()
        {
            _matchItems = new MatchItemsProvider().GetMatchItems();

            SelectBorderCommand = new Command<Source>(SelectBorder);
            SelectFigureCommand = new Command<Source>(SelectFigure);

            var items = _matchItems.Take(4).ToList();
            Borders = new ObservableCollection<Source>(items.Select(x => x.Border).Take(3).OrderBy(x => Guid.NewGuid()));
            Figures = new ObservableCollection<Source>(items.Select(x => x.Figure).OrderBy(x => Guid.NewGuid()));
        }

        private void SelectBorder(Source source)
        {
            SelectedBorder = source;
            CheckMatch();
        }

        private void SelectFigure(Source source)
        {
            SelectedFigure = source;
            CheckMatch();
        }

        private void CheckMatch()
        {
            if (SelectedBorder != null && SelectedFigure != null && SelectedFigure.Label.Equals(SelectedBorder.Label, System.StringComparison.CurrentCultureIgnoreCase))
            {
                Borders = new ObservableCollection<Source>(Borders.Where(x => x != SelectedBorder));
                Figures = new ObservableCollection<Source>(Figures.Where(x => x != SelectedFigure));

                if (!Borders.Any())
                {
                    var items = _matchItems.Take(4).ToList();
                    Borders = new ObservableCollection<Source>(items.Select(x => x.Border).Take(3).OrderBy(x => Guid.NewGuid()));
                    Figures = new ObservableCollection<Source>(items.Select(x => x.Figure).OrderBy(x => Guid.NewGuid()));
                }
            }
        }
    }
}
