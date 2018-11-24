using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MarvelHeroesCN.Models;
using MarvelHeroesCN.Services;
using Xamarin.Forms;

namespace MarvelHeroesCN.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Personagem> Personagens { get; }
        public Command<Personagem> ExibirPersonagemCommand { get; }

        private MarvelApiService _marvelApiService;

        public MainViewModel()
        {
            Titulo = "Herois Marvel";

            Personagens = new ObservableCollection<Personagem>();
            ExibirPersonagemCommand = new Command<Personagem>(ExecuteExibirPersonagemCommand);
            _marvelApiService = new MarvelApiService();

        }

        private async void ExecuteExibirPersonagemCommand(Personagem personagem)
        {
            await Navigation.PushAsync<DetalhesViewModel>(false, personagem);
        }

        public override async Task LoadAsync()
        {
            Ocupado = true;
            try
            {
                var personagensMarvel = await _marvelApiService.GetPersonagensAsync();

                Personagens.Clear();

                foreach (var personagem in personagensMarvel)
                {
                    Personagens.Add(personagem);
                }

            }
            catch(Exception ex)
            {
                Debug.WriteLine("Erro", ex.Message);
            }
            finally
            {
                Ocupado = false;
            }
           
        }
    }
}
