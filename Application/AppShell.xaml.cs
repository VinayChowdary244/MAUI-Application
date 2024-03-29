using Application.Views;

namespace Application
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddEmployee), typeof(AddEmployee));

            Routing.RegisterRoute(nameof(EmployeesList), typeof(EmployeesList));

            Routing.RegisterRoute(nameof(NewPage1), typeof(NewPage1));







        }
    }
}
