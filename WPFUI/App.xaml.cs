using PASEDM.ViewModels;
using System.Windows;
using PASEDM.Store;
using PASEDM.View;
using PASEDM.Services;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PASEDM.Data;
using PASEDM.Infrastructure.Command;

namespace PASEDM
{
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Server=localhost;Database=AppPASEDM;User Id=user1;Password=sa;TrustServerCertificate=True";
        private readonly IServiceProvider _serviceProvider;
        private readonly PASEDMDbContextFactory _deferredContextFactory;

        public App()
        {
            //_deferredContextFactory = new PASEDMDbContextFactory(CONNECTION_STRING);

            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<NavigationStore>();
            services.AddSingleton<UserStore>();

            services.AddSingleton<PASEDMDbContextFactory>(s => new PASEDMDbContextFactory(CONNECTION_STRING));

            services.AddSingleton<INavigationService>(s => CreateEntryUserNavigationService(s));

            services.AddTransient<UserEntryViewModel>(s => new UserEntryViewModel(
                s.GetRequiredService<UserStore>(),
                CreateMainMenuNavigationService(s),
                CreateUserNewNavigationService(s),
                s.GetRequiredService<PASEDMDbContextFactory>()));
            services.AddTransient<UserGreatViewModel>(s => new UserGreatViewModel(
                CreateEntryUserNavigationService(s),
                s.GetRequiredService<PASEDMDbContextFactory>()));
            services.AddTransient<MenuViewModel>(s => new MenuViewModel(
                s.GetRequiredService<UserStore>(), 
                CreateEntryUserNavigationService(s)));
            services.AddTransient<NavigationBarViewModel>(CreateNavigationBarViewModel);
            services.AddSingleton<MainWindowViewModel>();

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainWindowViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(CONNECTION_STRING).Options;
            using (PASEDMContext dbContext = new PASEDMContext(options))
            {
                dbContext.Database.Migrate();
            }

            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        private INavigationService CreateMainMenuNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<MenuViewModel>(serviceProvider.GetRequiredService<NavigationStore>(), () => 
            serviceProvider.GetRequiredService<MenuViewModel>(), () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
        private INavigationService CreateUserNewNavigationService(IServiceProvider serviceProvider)
        {
            NavigationStore navigationStore = serviceProvider.GetRequiredService<NavigationStore>();

            return new NavigationService<UserGreatViewModel>(navigationStore, () =>
            serviceProvider.GetRequiredService<UserGreatViewModel>());
        }
        private INavigationService CreateEntryUserNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<UserEntryViewModel>
                (serviceProvider.GetRequiredService<NavigationStore>(), 
                () => serviceProvider.GetRequiredService<UserEntryViewModel>());
        }
        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(serviceProvider.GetRequiredService<UserStore>(),
                            CreateMainMenuNavigationService(serviceProvider),
                            CreateUserNewNavigationService(serviceProvider), 
                            CreateEntryUserNavigationService(serviceProvider));
        }
    }
}