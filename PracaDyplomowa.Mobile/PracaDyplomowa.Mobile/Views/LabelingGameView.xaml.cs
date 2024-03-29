﻿using PracaDyplomowa.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracaDyplomowa.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabelingGameView : ContentPage
    {
        public LabelingGameView()
        {
            InitializeComponent();
            BindingContext = new LabelingGameViewModel(Navigation);
        }
    }
}