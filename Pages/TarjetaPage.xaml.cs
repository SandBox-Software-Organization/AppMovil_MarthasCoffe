using MarthasCoffe.ViewsModels;

namespace MarthasCoffe.Pages;

public partial class TarjetaPage : ContentPage
{
	public TarjetaPage(TarjetaViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}