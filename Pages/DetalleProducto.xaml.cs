using MarthasCoffe.ViewsModels;

namespace MarthasCoffe.Pages;

public partial class DetalleProducto : ContentPage
{
	public DetalleProducto(DetalleProductoViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;

    }
}