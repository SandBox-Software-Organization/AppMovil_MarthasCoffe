using MarthasCoffe.DataAccess;
using MarthasCoffe.ViewsModels;

namespace MarthasCoffe.Pages;

public partial class CarritoPage : ContentPage
{
    private CarritoViewModel _viewModel;
    private readonly MarthasCoffeDbContext _context;
    public CarritoPage(CarritoViewModel viewModel, MarthasCoffeDbContext contex)
	{

		InitializeComponent();
        _context = contex;
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        await _viewModel.ObtenerProductos();
        _viewModel.MostarTotal();
    }
}