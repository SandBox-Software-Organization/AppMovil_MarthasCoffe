﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarthasCoffe.ViewsModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        public string usuario = string.Empty;
        [ObservableProperty]
        public string password = string.Empty;

        [RelayCommand]
        private async Task Login()
        {
            if (Usuario == "Marthas" && Password == "123")
            {
                Preferences.Set("logueado", "si");
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Mensaje", "No se encontraron coincidencias", "Aceptar");
            }
        }
    }
}
