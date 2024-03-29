﻿using PASEDM.ViewModels;
using System.Windows;
using PASEDM.Store;
using PASEDM.View;
using PASEDM.Services;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PASEDM.Data;
using Microsoft.Win32;
using Microsoft.Extensions.Hosting;

namespace PASEDM
{
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Server=localhost;Database=AppPASEDM;User Id=user1;Password=sa;TrustServerCertificate=True";

        private readonly IHost _host;


        public App()
        {
            #region Зависимости

            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<NavigationStore>();
                services.AddSingleton<ModalNavigationStore>();
                services.AddSingleton<UserStore>();
                services.AddSingleton<OpenFileDialog>();

                services.AddSingleton<CloseModalNavigationService>();

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
                    s.GetRequiredService<PASEDMDbContextFactory>(),
                    s.GetRequiredService<UserStore>()));

                services.AddTransient(s => new MyTasksViewModel(
                    s.GetRequiredService<PASEDMDbContextFactory>(),
                    s.GetRequiredService<UserStore>()));

                services.AddTransient(s => new ReferencesViewModel(
                    s.GetRequiredService<PASEDMDbContextFactory>(),
                    s.GetRequiredService<UserStore>()));

                services.AddTransient(s => new SettingsViewModel(
                    s.GetRequiredService<UserStore>()));

                services.AddTransient(s => new AccountConfirmationViewModel(
                    s.GetRequiredService<PASEDMDbContextFactory>(),
                    CreateAccountConfirmationNavigationService(s)));

                services.AddTransient(CreateCardViewModelMet);
                services.AddTransient(AddDocViewModelMet);
                services.AddTransient(ViewingCardViewModelMet);
                services.AddTransient(OutgoingViewModelMet);
                services.AddTransient(IncomingViewModelMet);
                services.AddTransient(MyDocumentsViewModelMet);
                services.AddTransient(CreateNavigationBarViewModel);

                services.AddSingleton<MainWindowViewModel>();

                services.AddSingleton(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainWindowViewModel>()
                });
            }).Build();
            #endregion
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            //DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(CONNECTION_STRING).Options;
            PASEDMDbContextFactory options = _host.Services.GetRequiredService<PASEDMDbContextFactory>();
            using (PASEDMContext dbContext = options.CreateDbContext())
            {
                //dbContext.Database.EnsureDeleted();
                //dbContext.Database.EnsureCreated();
                dbContext.Database.Migrate();
            }

            INavigationService initialNavigationService = _host.Services.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();
            base.OnExit(e);
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
        private static INavigationService CreateViewingCardNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<ViewingCardViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<ViewingCardViewModel>());
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
        private ViewingCardViewModel ViewingCardViewModelMet(IServiceProvider serviceProvider)
        {
            CompositeNavigationService navigationService = new(
                serviceProvider.GetRequiredService<CloseModalNavigationService>(),
                CreateIncomingNavigationService(serviceProvider));

            return new ViewingCardViewModel(
                serviceProvider.GetRequiredService<IncomingViewModel>(),
                navigationService,
                serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                serviceProvider.GetRequiredService<UserStore>());
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
                CreateIncomingNavigationService(serviceProvider));

            ParameterNavigationService<IncomingViewModel, CreateCardViewModel> parameterCreateCardNavigationService = new(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                (parameter) => new CreateCardViewModel(
                    navigationService,
                    serviceProvider.GetRequiredService<OutgoingViewModel>(),
                    parameter,
                    serviceProvider.GetRequiredService<UserStore>(),
                    serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                    serviceProvider.GetRequiredService<OpenFileDialog>()));

            ParameterNavigationService<IncomingViewModel, ViewingCardViewModel> parameterViewingCardNavigationService = new(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                (parameter) => new ViewingCardViewModel(
                    parameter,
                    navigationService,
                    serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                    serviceProvider.GetRequiredService<UserStore>()));

            return new IncomingViewModel(
                parameterCreateCardNavigationService,
                parameterViewingCardNavigationService,
                CreateIncomingNavigationService(serviceProvider),
                serviceProvider.GetRequiredService<PASEDMDbContextFactory>(),
                serviceProvider.GetRequiredService<UserStore>());
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