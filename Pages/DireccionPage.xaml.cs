using MarthasCoffe.ViewsModels;

namespace MarthasCoffe.Pages;

public partial class DireccionPage : ContentPage
{
	public DireccionPage(DireccionViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;

    }
}