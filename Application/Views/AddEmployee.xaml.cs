using Application.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Views;

public partial class AddEmployee : ContentPage
{
    private AddEmployeeViewModel _viewModel;
    //private string date;
    public AddEmployee(AddEmployeeViewModel viewModel)
	{
        //Employee.JoinedDate.MaximumDate = DateTime.Today;
        _viewModel = viewModel;
        this.BindingContext = viewModel;
    }

    //private void SaveButton_Clicked(object sender, EventArgs e)
    //{
    //    ((ViewModels.AddEmployeeViewModel)BindingContext).SaveButton_Clicked(sender, e);
    //}

    public AddEmployee()
    {
        InitializeComponent();
       
    }

    //void DatePicker_DateSelected(System.Object sender, Microsoft.Maui.Controls.DateChangedEventArgs e)
    //{
    //    //date = Employee.Date.ToString();
    //    //_viewModel.DateValue = date.Split()[0];
    //}


    protected override void OnAppearing()
    {
        base.OnAppearing();
        //SetImage();

    }



    //private void SetImage()
    //{
    //    if (_viewModel.EmployeeProp.Image is not null)
    //    {
    //        Binding employeeBinding = new Binding
    //        {
    //            Source = _viewModel.EmployeeProp,
    //            Path = _viewModel.EmployeeProp.Image
    //        };
    //        TakeEmpPhoto.Source = ImageSource.FromFile(_viewModel.EmployeeProp.Image);
    //        _viewModel.CompleteEmployeePhotoPath = _viewModel.EmployeeProp.Image;
    //        TakeEmpPhoto.IsVisible = true;
    //    }
    //}


}