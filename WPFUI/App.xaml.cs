using PASEDM.ViewModels;
using System.Windows;
using PASEDM.Store;
using PASEDM.View;
using PASEDM.Services;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PASEDM.Data;
using PASEDM.Services.FTPClient;
using Microsoft.Win32;

namespace PASEDM
{
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Server=localhost;Database=AppPASEDM;User Id=user1;Password=sa;TrustServerCertificate=True";
        private const string CONNECTION_FTP_SERVER = "ftp://192.168.1.1/";
        private const string USER_FTP_SERVER = "us";
        private const string PASSWORD_FTP_SERVER = "1";
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            #region Зависимости
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ModalNavigationStore>();
            services.AddSingleton<UserStore>();
            services.AddSingleton<OpenFileDialog>();

            services.AddSingleton<CloseModalNavigationService>();

            services.AddSingleton(s => new FtpClient(CONNECTION_FTP_SERVER, USER_FTP_SERVER, PASSWORD_FTP_SERVER));

            services.AddSingleton(s => new PASEDMDbContextFactory(CONNECTION_STRING));

            services.AddSingleton(s => CreateEntryUserNavigationService(s));

            services.AddTransient(s => new UserEntryViewModel(
                s.GetRequiredService<UserStore>(),
                CreateNotificationsNavigationService(s),
                CreateUserNewNavigationService(s),
                s.GetRequiredService<PASEDMDbContextFactory>()));

            services.AddTransient(s => new UserCreateViewModel(
                CreateEntryUserNavigationService(s),
                s.GetRequiredService<PASEDMDbContextFactory>()));

            services.AddTransient(s => new NotificationsViewModel(
                s.GetRequiredService<PASEDMDbContextFactory>(),
                CreateIncomingNavigationService(s),
                s.GetRequiredService<UserStore>()));

            services.AddTransient(s => new JournalViewModel(
                s.GetRequiredService<UserStore>()));

            services.AddTransient(s => new MyTasksViewModel(
                s.GetRequiredService<PASEDMDbContextFactory>(),
                s.GetRequiredService<UserStore>()));

            services.AddTransient(s => new ReferencesViewModel(
                s.GetRequiredService<UserStore>()));

            services.AddTransient(s => new SettingsViewModel(
                s.GetRequiredService<UserStore>()));

            services.AddTransient(s => new AccountConfirmationViewModel(
                s.GetRequiredService<PASEDMDbContextFactory>(),
                CreateAccountConfirmationNavigationService(s)));

            services.AddTransient(CreateCardViewModelMet);
            services.AddTransient(AddDocViewModelMet);
            services.AddTransient(OutgoingViewModelMet);
            services.AddTransient(IncomingViewModelMet);
            services.AddTransient(MyDocumentsViewModelMet);
            services.AddTransient(CreateNavigationBarViewModel);

            services.AddSingleton<MainWindowViewModel>();

            services.AddSingleton(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainWindowViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();
            #endregion
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(CONNECTION_STRING).Options;
            using (PASEDMContext dbContext = new(options))
            {
                //dbContext.Database.EnsureDeleted();
                //dbContext.Database.EnsureCreated();
                dbContext.Database.Migrate();
            }

            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        private static INavigationService CreateUserNewNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<UserCreateViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<UserCreateViewModel>());
        }
        private static INavigationService CreateEntryUserNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<UserEntryViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<UserEntryViewModel>());
        }
        private static INavigationService CreateNotificationsNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<NotificationsViewModel>(
                serviceProvider.GetRequiredService<UserStore>(),
                serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<NotificationsViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
        private static INavigationService CreateJournalNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<JournalViewModel>(
                serviceProvider.GetRequiredService<UserStore>(),
                serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<JournalViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
        private static INavigationService CreateMyDocumentsNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<MyDocumentsViewModel>(
                serviceProvider.GetRequiredService<UserStore>(),
                serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<MyDocumentsViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
        private static INavigationService CreateMyTasksNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<MyTasksViewModel>(
                serviceProvider.GetRequiredService<UserStore>(),
                serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<MyTasksViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
        private static INavigationService CreateReferencesNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<ReferencesViewModel>(
                serviceProvider.GetRequiredService<UserStore>(),
                serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ReferencesViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
        private static INavigationService CreateSettingsNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<SettingsViewModel>(
                serviceProvider.GetRequiredService<UserStore>(),
                serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<SettingsViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
        private static INavigationService CreateAccountConfirmationNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<AccountConfirmationViewModel>(
                serviceProvider.GetRequiredService<UserStore>(),
                serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<AccountConfirmationViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
        private static INavigationService CreateIncomingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<IncomingViewModel>(
                serviceProvider.GetRequiredService<UserStore>(),
                serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<IncomingViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
        private static INavigationService CreateOutgoingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<OutgoingViewModel>(
                serviceProvider.GetRequiredService<UserStore>(),
                serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<OutgoingViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
        private static INavigationService CreateCardNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<CreateCardViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<CreateCardViewModel>());
        }
        private static INavigationService CreateAddDocNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<AddDocViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddDocViewModel>());
        }
        private AddDocViewModel AddDocViewModelMet(IServiceProvider serviceProvider)
        {
            CompositeNavigationService navigationService = new(
                serviceProvider.GetRequiredService<CloseModalNavigationService>(),
                CreateMyDocumentsNavigationService(serviceProvider));

            return new AddDocViewModel(
                navigationService,
                serviceProvider.GetRequiredService<MyDocumentsViewModel>(),
                serviceProvider.GetRequiredService<UserStore>(),
                serviceProvider.GetRequiredService<PASEDMDbContextFactory>());
        }
        private CreateCardViewModel CreateCardViewModelMet(IServiceProvider serviceProvider)
        {
            CompositeNavigationService navigationService = new(
                serviceProvider.GetRequiredService<CloseModalNavigationService>(),
                CreateOutgoingNavigationService(serviceProvider));

            return new CreateCardViewModel(
                navigationService,
                serviceProvider.GetRequiredService<OutgoingViewModel>(),
                serviceProvider.GetRequiredService<IncomingViewModel>(),
                serviceProvider.GetRequiredService<UserStore>(),
                serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                serviceProvider.GetRequiredService<OpenFileDialog>());
        }
        private OutgoingViewModel OutgoingViewModelMet(IServiceProvider serviceProvider)
        {
            CompositeNavigationService navigationService = new(
                serviceProvider.GetRequiredService<CloseModalNavigationService>(),
                CreateOutgoingNavigationService(serviceProvider));

            ParameterNavigationService<OutgoingViewModel, CreateCardViewModel> parameterNavigationService = new(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                (parameter) => new CreateCardViewModel(
                    navigationService,
                    parameter,
                    serviceProvider.GetRequiredService<IncomingViewModel>(),
                    serviceProvider.GetRequiredService<UserStore>(),
                    serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                    serviceProvider.GetRequiredService<OpenFileDialog>()));


            return new OutgoingViewModel(
                parameterNavigationService,
                CreateCardNavigationService(serviceProvider),
                CreateOutgoingNavigationService(serviceProvider),
                serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                serviceProvider.GetRequiredService<UserStore>()
                );
        }
        private IncomingViewModel IncomingViewModelMet(IServiceProvider serviceProvider)
        {
            CompositeNavigationService navigationService = new(
                serviceProvider.GetRequiredService<CloseModalNavigationService>(),
                CreateOutgoingNavigationService(serviceProvider));

            ParameterNavigationService<IncomingViewModel, CreateCardViewModel> parameterNavigationService = new(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                (parameter) => new CreateCardViewModel(
                    navigationService,
                    serviceProvider.GetRequiredService<OutgoingViewModel>(),
                    parameter,
                    serviceProvider.GetRequiredService<UserStore>(),
                    serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                    serviceProvider.GetRequiredService<OpenFileDialog>()));


            return new IncomingViewModel(
                parameterNavigationService,
                CreateIncomingNavigationService(serviceProvider),
                serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                serviceProvider.GetRequiredService<UserStore>()
                );
        }
        private MyDocumentsViewModel MyDocumentsViewModelMet(IServiceProvider serviceProvider)
        {
            CompositeNavigationService navigationService = new(
                serviceProvider.GetRequiredService<CloseModalNavigationService>(),
                CreateMyDocumentsNavigationService(serviceProvider));

            ParameterNavigationService<MyDocumentsViewModel, AddDocViewModel> parameterNavigationService = new(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                (parameter) => new AddDocViewModel(
                    navigationService,
                    parameter,
                    serviceProvider.GetRequiredService<UserStore>(),
                    serviceProvider.GetRequiredService<PASEDMDbContextFactory>()));


            return new MyDocumentsViewModel(
                parameterNavigationService,
                CreateMyDocumentsNavigationService(serviceProvider),
                CreateAddDocNavigationService(serviceProvider),
                serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                serviceProvider.GetRequiredService<UserStore>()
                );
        }
        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(
                serviceProvider.GetRequiredService<UserStore>(),
                CreateIncomingNavigationService(serviceProvider),
                CreateOutgoingNavigationService(serviceProvider),
                CreateNotificationsNavigationService(serviceProvider),
                CreateEntryUserNavigationService(serviceProvider),
                CreateJournalNavigationService(serviceProvider),
                CreateMyDocumentsNavigationService(serviceProvider),
                CreateMyTasksNavigationService(serviceProvider),
                CreateReferencesNavigationService(serviceProvider),
                CreateSettingsNavigationService(serviceProvider),
                CreateAccountConfirmationNavigationService(serviceProvider));
        }
    }
}