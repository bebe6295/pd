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
        private ImageSource _letterSource;
        private Source _letter;
        private readonly MobileApiService _mobileApiService;
        private int tries = 0;
        private string _status;

        public string Status { get => _status; set => SetField(ref _status, value); }
        public int Tries { get => tries; set => SetField(ref tries, value); }

        public ICommand CheckIfMatchCommand { get; set; }
        public ImageSource LetterSource { get => _letterSource; set => SetField(ref _letterSource, value); }
        public Source Letter { get => _letter; set => SetField(ref _letter, value); }

        public WritingGameViewModel(MobileApiService mobileApiService)
        {
            var imageProvider = new LetterItemsProvider();
            _letters = imageProvider.GetGameItems().ToList();
            SetNewLetter();
            _mobileApiService = mobileApiService;
            CheckIfMatchCommand = new Command<byte[]>(CheckIfMatch);
        }

        private void SetNewLetter()
        {
            var letter = _letters.OrderBy(x => Guid.NewGuid()).First();
            var imageSource = ImageSource.FromResource(letter.ImageUri, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
            Letter = letter;
            LetterSource = imageSource;
        }

        private void CheckIfMatch(byte[] picture)
        {
            var letter = _mobileApiService.CheckWriting(picture);

            if (letter.ToLower() == Letter.Label.ToLower())
            {
                SetNewLetter();
                tries = 0;
                Status = "UDało się";
            }
            else if (tries++ > 3)
            {
                SetNewLetter();
                Status = "Spróbuj jeszcze raz";
            }
        }
    }
}
