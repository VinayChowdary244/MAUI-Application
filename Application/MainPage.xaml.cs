using Application.ViewModels;

namespace Application
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _viewmodel;

        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(MainPageViewModel viewmodel)
        {
            
            _viewmodel = viewmodel;
            this.BindingContext = viewmodel;
        }

        public void NavigateEmployeeList(Object sender, EventArgs  e)
        {
            Shell.Current.GoToAsync("EmployeesList");

        }




    }

}
