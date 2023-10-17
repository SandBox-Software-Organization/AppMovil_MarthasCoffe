using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MarthasCoffe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarthasCoffe.ViewsModels
{
    public partial class DireccionViewModel : ObservableObject
    {
        private readonly MarthasCoffeDbContext _context;

        [ObservableProperty]
        public string nombreDireccion;
        [ObservableProperty]
        public string nombreCompleto;
        [ObservableProperty]
        public string calle;
        [ObservableProperty]
        public string telefono;
        [ObservableProperty]
        public string estado;
        [ObservableProperty]
        public string ciudad;
        [RelayCommand]
        async Task GuardarEvent()
        {

            if (string.IsNullOrEmpty(NombreDireccion) ||
               string.IsNullOrEmpty(NombreCompleto) ||
               string.IsNullOrEmpty(Calle) ||
               string.IsNullOrEmpty(Telefono) ||
               string.IsNullOrEmpty(Estado) ||
               string.IsNullOrEmpty(Ciudad)
               )
            {
                await Shell.Current.DisplayAlert("Mensaje", "Debe ingresar todos los campos", "Aceptar");
                return;
            }
            _context.Direcciones.Add(new Modelos.Direccion
            {
                NombreDireccion = NombreDireccion,
                NombreCompleto = NombreCompleto,
                Calle = Calle,
                Telefono = Telefono,
                Estado = Estado,
                Ciudad = Ciudad
            });

            await _context.SaveChangesAsync();
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task GetBackEvent()
        {
            await Shell.Current.GoToAsync("..");
        }
        public DireccionViewModel(MarthasCoffeDbContext context)
        {
            _context = context;
        }
    }
}
