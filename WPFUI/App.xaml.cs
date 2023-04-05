using PASEDM.ViewModels;
using System.Windows;
using PASEDM.Store;
using PASEDM.View;
using PASEDM.Services;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace PASEDM
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<NavigationStore>();
            services.AddSingleton<UserStore>();

            services.AddSingleton<INavigationService>(s => CreateEntryUserNavigationService(s));

            services.AddSingleton<MainWindowViewModel>();

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainWindowViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();

        }


        protected override void OnStartup(StartupEventArgs e)
        {

            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        private INavigationService CreateMainMenuNavigationService(IServiceProvider serviceProvider)
        {
            UserStore userStore = serviceProvider.GetRequiredService<UserStore>();

            return new LayoutNavigationService<MenuViewModel>(serviceProvider.GetRequiredService<NavigationStore>(), () => 
            new MenuViewModel(userStore, 
            CreateEntryUserNavigationService(serviceProvider)), () => CreateNavigationBarViewModel(serviceProvider));
        }
        private INavigationService CreateUserNewNavigationService(IServiceProvider serviceProvider)
        {
            NavigationStore navigationStore = serviceProvider.GetRequiredService<NavigationStore>();

            return new NavigationService<UserGreatViewModel>(navigationStore, () =>
            new UserGreatViewModel(CreateEntryUserNavigationService(serviceProvider)));
        }

        private INavigationService CreateEntryUserNavigationService(IServiceProvider serviceProvider)
        {
            UserStore userStore = serviceProvider.GetRequiredService<UserStore>();

            return new NavigationService<UserEntryViewModel>
                (serviceProvider.GetRequiredService<NavigationStore>(), 
                () => new UserEntryViewModel(userStore, 
                CreateMainMenuNavigationService(serviceProvider), CreateUserNewNavigationService(serviceProvider)));
        }
        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            UserStore userStore = serviceProvider.GetRequiredService<UserStore>();

            return new NavigationBarViewModel(userStore,
                            CreateMainMenuNavigationService(serviceProvider),
                            CreateUserNewNavigationService(serviceProvider), 
                            CreateEntryUserNavigationService(serviceProvider));
        }
    }
}
