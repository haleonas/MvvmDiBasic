using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvvmDiBasic.Services;
using MvvmDiBasic.ViewModels;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;

namespace MvvmDiBasic
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; set; } = null!;
        public IConfiguration Configuration { get; set; } = null!;

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<ITestService, TestService>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appSettings.json");

            Configuration = builder.Build();

            var services = new ServiceCollection();
            ConfigureServices(services);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ServiceProvider = services.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
