using Application.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Maui.Controls;


namespace Application.ViewModels
{
    public partial class MainPageViewModel:ObservableObject
    {
        [RelayCommand]

        async  Task Navigate()
        {
            await Shell.Current.GoToAsync("AddEmployee");

        }

        [RelayCommand]

        async Task NavigateEmployeeList()
        {
            await Shell.Current.GoToAsync("EmployeesList");
        }

        //[RelayCommand]

        //async Task Navigate() => Shell.Current.GoToAsync(nameof(AddEmployee));

    }

}
