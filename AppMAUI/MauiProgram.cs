using AppMAUI.ModelView;
using AppMAUI.Services;
using Microsoft.Extensions.Logging;
using Service.Services;

namespace AppMAUI;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddScoped<MainPage>();
        builder.Services.AddScoped<EmployeePage>();
        builder.Services.AddScoped<WebViewPage>();

        builder.Services.AddScoped<MainPageModelView>();
		builder.Services.AddScoped<EmployeModelView>();
        builder.Services.AddScoped<WebViewViewModel>();

        builder.Services.AddSingleton<IDisplayMessage, DisplayMessage>();
        builder.Services.AddSingleton<IWebService, WebService>();

        return builder.Build();
	}
}
