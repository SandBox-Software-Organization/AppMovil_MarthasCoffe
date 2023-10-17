using MarthasCoffe.ViewsModels;

namespace MarthasCoffe.Pages;

public partial class CompraExitosaPage : ContentPage
{
	public CompraExitosaPage(CompraExitosaViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}