using Application.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


namespace Application.ViewModels

{
    public partial class EmployeesListViewModel :ObservableObject
    {

        private readonly ILocalDbServices _localDb;

        [ObservableProperty]
        public bool isCollectionViewVisible = false;
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
        public EmployeesListViewModel(ILocalDbServices dbservice)
        {
            LoadEmployees();
            GetEmployeeList();
            _localDb = dbservice;
        }
        public EmployeesListViewModel()
        {
           
        }
        public void LoadEmployees()
        {

            var employees = App.Database.GetTableRows<Employee>("Employee").ToList();
            if (employees?.Count > 0)
            {
                Employees.Clear();
                foreach (var employee in employees)
                {
                    Employees.Add(employee);
                }
            }

        }


        [RelayCommand]
        public async void GetEmployeeList()
        {
            Employees.Clear();
            var emps = await _localDb.GetEmployees();
            if (emps?.Count > 0)
            {
                IsCollectionViewVisible = true;
                emps = emps.OrderBy(f => f.EmployeeName).ToList();
                foreach (var product in emps)
                {
                    Employees.Add(product);

                }
            }
            else
            {
                IsCollectionViewVisible = false;
                return;
            }
        }

    }
}
