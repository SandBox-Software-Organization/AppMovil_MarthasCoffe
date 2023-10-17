using MarthasCoffe.DataAccess;
using MarthasCoffe.ViewsModels;

namespace MarthasCoffe.Pages;

public partial class MainPage : ContentPage
{
    int count = 0;
    private readonly MarthasCoffeDbContext _context;

    public MainPage(MarthasCoffeDbContext context, MainPageViewModel viewModel)
	{
        _context = context;
        InitializeComponent();
        BindingContext = viewModel;
    }

	
}

