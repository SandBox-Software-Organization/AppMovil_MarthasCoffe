using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MarthasCoffe.DataAccess;
using MarthasCoffe.DTO;
using MarthasCoffe.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarthasCoffe.ViewsModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly MarthasCoffeDbContext _context;

        [ObservableProperty]
        List<CategoriaDTO> categorias;

        [ObservableProperty]
        List<ProductoDTO> mejoresProductos;

        [ObservableProperty]
        CategoriaDTO categoriaSeleccionada;

        [ObservableProperty]
        ProductoDTO productoSeleccionado;

        [RelayCommand]
        async Task CategoriaEventSelected()
        {
            var uri = $"{nameof(ProductoCategoriaPage)}?id={CategoriaSeleccionada.IdCategoria}&descripcion={CategoriaSeleccionada.Descripcion}";
            await Shell.Current.GoToAsync(uri);
            CategoriaSeleccionada = null;
        }

        [RelayCommand]
        async Task ProductoEventSelected()
        {
            //await Shell.Current.DisplayAlert("Mensaje", string.Format("id:{0}", ProductoSeleccionado.IdProducto), "Aceptar");
            //ProductoSeleccionado = null;
            var uri = $"{nameof(DetalleProducto)}?id={ProductoSeleccionado.IdProducto}";
            await Shell.Current.GoToAsync(uri);
            ProductoSeleccionado = null;
        }

        public MainPageViewModel(MarthasCoffeDbContext context)
        {
            _context = context;
            List<CategoriaDTO> listCategoria = new List<CategoriaDTO>();
            List<ProductoDTO> listProducto = new List<ProductoDTO>();

            foreach (var item in _context.Categorias.ToList())
            {
                listCategoria.Add(new CategoriaDTO { IdCategoria = item.IdCategoria, Descripcion = item.Descripcion, Imagen = item.Imagen });
            }

            foreach (var item in _context.Productos.ToList().Take(4))
            {
                listProducto.Add(new ProductoDTO { IdProducto = item.IdProducto, Nombre = item.Nombre, Descripcion = item.Descripcion, Precio = item.Precio, Imagen = item.Imagen });
            }

            Categorias = listCategoria;
            MejoresProductos = listProducto;
        }


    }
}
