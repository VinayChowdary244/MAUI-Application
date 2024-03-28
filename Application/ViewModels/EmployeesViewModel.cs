using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Application.Models;
using Application.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace EmployeeApp.ViewModels
{
    public partial class EmployeesViewModel : ObservableObject
    {
        ILocalDbServices _localDbServices;
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
        public EmployeesViewModel(ILocalDbServices localDbServices)
        {
          _localDbServices=localDbServices;
            LoadEmployees();
        }


        //private Employee selectedEmployee;

        //public Employee SelectedEmployee
        //{
        //    get { return selectedEmployee; }
        //    set
        //    {
        //        selectedEmployee = value;
        //        OnPropertyChanged();
        //        if(selectedEmployee == null)
        //        {
        //            return;
        //        }
        //        OnSelectedEmployee(value);

        //    }
        //}

        private async void OnSelectedEmployee(Employee employee)
        {
            try
            {
                if(employee == null)
                {
                    return;
                }
                else
                {
                    await Shell.Current.GoToAsync($"{nameof(AddEmployee)}?{nameof(AddEmployee.Id)}={employee.Id}");
                }

            }catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Error Occured", "Something went wrong while selecting the employee" + ex.Message, "OK");
            }
        }




        public async Task LoadEmployees()
        {
            try
            {
                var employees = await _localDbServices.GetEmployees();

                if (employees != null)
                {
                    Employees.Clear(); 

                    foreach (var employee in employees)
                    {
                        Employees.Add(employee);
                    }
                }
                else
                {
                    Console.WriteLine("No employees found."); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading employees: {ex.Message}"); 
            }
        }



        //[RelayCommand]
        //public async void AddUpdateEmployee()
        //{
        //    await AppShell.Current.GoToAsync(nameof(AddEmployee));
        //}


    }
}
