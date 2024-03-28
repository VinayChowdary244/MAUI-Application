using Application.ViewModels;

namespace Application.Views;

public partial class EmployeesList : ContentPage
{
	private EmployeesListViewModel _viewmodel;

    public EmployeesList()
    {
        InitializeComponent();

    }

    public EmployeesList(EmployeesListViewModel viewmodel)
	{
        _viewmodel = viewmodel;
        this.BindingContext = viewmodel;
        EmployeesList employeesList = new EmployeesList(viewmodel);

    }

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();

    //    _viewmodel.LoadEmployees();
    //    //_viewmodel.GetProductListCommand.Execute(null);

    //}
}