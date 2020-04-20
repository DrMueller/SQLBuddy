using System.Windows;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services;

namespace Mmu.SqlBuddy.WpfUI
{
    public partial class App
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            var assembly = typeof(App).Assembly;
            var windowConfig = WindowConfiguration.CreateWithDefaultIcon(assembly, "SQL Buddy", 800, 700);
            var appConfig = new WpfAppConfiguration(assembly, windowConfig);
            await AppStartService.StartAppAsync(appConfig);
        }
    }
}