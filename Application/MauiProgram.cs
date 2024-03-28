using Application.Views;
using Application.ViewModels;

using Microsoft.Extensions.Logging;
using Camera.MAUI;

namespace Application
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiCameraView()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<LocalDBService>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<EmployeesList>();
            builder.Services.AddTransient<AddEmployee>();

            builder.Services.AddTransient<EmployeesListViewModel>();
            builder.Services.AddTransient<AddEmployeeViewModel>();
            builder.Services.AddTransient<MainPageViewModel>();

            builder.Services.AddScoped<ILocalDbServices, LocalDBService>();






#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
