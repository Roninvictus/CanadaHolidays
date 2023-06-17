using CanadaHolidaysChallenge.Core.Services;
using CanadaHolidaysChallenge.Core.ViewModel;
using Microsoft.Extensions.Logging;

namespace CanadaHolidaysChallenge;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<HolidayService>();
        builder.Services.AddSingleton<HolidayViewModel>();
        builder.Services.AddSingleton<MainPage>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
