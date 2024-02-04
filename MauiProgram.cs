using Microsoft.Extensions.Logging;

namespace ServiceDisposalBlazorIssue;

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
			});

		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddSingleton<SingletonServiceThatRequiresDispose>();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		var mauiApp = builder.Build();

		mauiApp.Services.GetRequiredService<SingletonServiceThatRequiresDispose>();

		return mauiApp;
	}
}
