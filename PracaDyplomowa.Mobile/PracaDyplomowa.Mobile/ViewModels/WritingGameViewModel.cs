using PracaDyplomowa.Mobile.Extensions;
using PracaDyplomowa.Mobile.Logic;
using PracaDyplomowa.Mobile.Services;
using PracaDyplomowa.Mobile.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace PracaDyplomowa.Mobile.ViewModels
{
    public class WritingGameViewModel : ViewModelBase
    {
        ICollection<Source> _letters;
        private ImageSource _letter;
        private readonly MobileApiService _mobileApiService;

        public ICommand MyProperty { get; set; }
        public ImageSource Letter { get => _letter; set => SetField(ref _letter, value); }

        public WritingGameViewModel(MobileApiService mobileApiService)
        {
            var imageProvider = new LetterItemsProvider();
            _letters = imageProvider.GetGameItems().ToList();
            SetNewLetter();
            _mobileApiService = mobileApiService;
        }

        private void SetNewLetter()
        {
            var letter = _letters.OrderBy(x => Guid.NewGuid()).First();
            var imageSource = ImageSource.FromResource(letter.ImageUri, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
            Letter = imageSource;
        }
    }
}
