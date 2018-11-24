using System;
using System.Collections.Generic;
using MarvelHeroesCN.ViewModels;
using Xamarin.Forms;

namespace MarvelHeroesCN
{
    public partial class DetalhesPage : ContentPage
    {
        private DetalhesViewModel ViewModel => BindingContext as DetalhesViewModel;

        public DetalhesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await ViewModel.LoadAsync();

        }
    }
}
