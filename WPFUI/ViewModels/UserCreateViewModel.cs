﻿using PASEDM.Data;
using PASEDM.Infrastructure.Command;
using PASEDM.Models;
using PASEDM.Services;
using PASEDM.Services.PASEDMProviders;
using PASEDM.Services.PASEDMProviders.InterfaceProviders;
using PASEDM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PASEDM.ViewModels
{
    public class UserCreateViewModel : BaseViewModels
    {
        private IEmployeeProvider _employeeProvider;

        private PASEDMDbContextFactory _contextFactory;

        private ObservableCollection<Employee> _staff;

        private Employee _employee;

        private string _userName;
        private string _password;
        private string _replayPassword;
        private bool _isLoading;
        private bool _isChecked;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set //=> Set(ref _password, value);
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ReplayPassword
        {
            get
            {
                return _replayPassword;
            }
            set
            {
                _replayPassword = value;
                OnPropertyChanged(nameof(ReplayPassword));
            }
        }
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }
        public IEnumerable<Employee> Staff => _staff;
        public Employee Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
                OnPropertyChanged(nameof(Employee));
            }
        }

        public ICommand NavigateEntryUserCommand { get; }
        public ICommand CreateUserCommand { get; }

        public UserCreateViewModel (INavigationService entryInAccountNavigationService, PASEDMDbContextFactory deferredContextFactory)
        {
            _contextFactory = deferredContextFactory;

            GetStaff();

            NavigateEntryUserCommand = new NavigateCommand(entryInAccountNavigationService);

            CreateUserCommand = new CreateUserCommand(this, deferredContextFactory);
        }
        private async void GetStaff()
        {
            try
            {
                _employeeProvider = new DatabaseEmployeeProvider(_contextFactory);
                _staff = new ObservableCollection<Employee>();
                _employee = new Employee(_employeeProvider);

                foreach (var item in await _employee.GetAllEmployee())
                {
                    _staff.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Потеряно соединение с БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}