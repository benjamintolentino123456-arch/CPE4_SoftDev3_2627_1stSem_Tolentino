using CPE4_SoftDev3_2627_1stSem_Tolentino.Services;
using CPE4_SoftDev3_2627_1stSem_Tolentino.Shared.Services;
using Microsoft.Extensions.Logging;

namespace CPE4_SoftDev3_2627_1stSem_Tolentino
{
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

            // Add device-specific services used by the CPE4_SoftDev3_2627_1stSem_Tolentino.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
