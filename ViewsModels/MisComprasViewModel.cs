using CommunityToolkit.Mvvm.ComponentModel;
using MarthasCoffe.DataAccess;
using MarthasCoffe.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarthasCoffe.ViewsModels
{
    public partial class MisComprasViewModel : ObservableObject
    {
        private readonly MarthasCoffeDbContext _context;
        [ObservableProperty]
        ObservableCollection<CompraDTO> listaCompras = new ObservableCollection<CompraDTO>();

        public MisComprasViewModel(MarthasCoffeDbContext context)
        {
            _context = context;
        }

        public async Task ObtenerCompras()
        {

            var lista = await _context.Compras
                .Include(d => d.RefDireccion)
                .Include(t => t.RefTarjeta)
                .ToListAsync();

            if (lista.Any())
            {
                foreach (var item in lista)
                {
                    ListaCompras.Add(new CompraDTO
                    {
                        NumeroCompra = item.NumeroCompra,
                        Total = item.Total,
                        RefDireccion = new DireccionDTO
                        {
                            NombreDireccion = item.RefDireccion.NombreDireccion
                        },
                        RefTarjeta = new TarjetaDTO
                        {
                            NombreTarjeta = item.RefTarjeta.NombreTarjeta
                        },
                        FechaRegistro = item.FechaRegistro.ToString("dd/MM/yyyy")
                    });
                }
            }


        }

    }
}
