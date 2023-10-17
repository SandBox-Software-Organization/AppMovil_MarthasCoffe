using MarthasCoffe.ViewsModels;

namespace MarthasCoffe.Pages;

public partial class PerfilPage : ContentPage
{
	public PerfilPage(PerfilViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}