using CanadaHolidaysChallenge.Core.ViewModel;

namespace CanadaHolidaysChallenge;

public partial class MainPage : ContentPage
{

	public MainPage(HolidayViewModel viewModel)
	{
		InitializeComponent();
		BindingContext=viewModel;
	}

	
}

