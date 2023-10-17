using MarthasCoffe.ViewsModels;
namespace MarthasCoffe.Pages;

public partial class ProductoCategoriaPage : ContentPage
{
	public ProductoCategoriaPage(ProductoCategoriaViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}