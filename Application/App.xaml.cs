
using Application.Views;

namespace Application
{
    public partial class App : IApplication
    {
        public App()
        {
            InitializeComponent();
            Database = new LocalDBService();

            MainPage = new AppShell();
            //MainPage = new NavigationPage(new MainPage());

        }

        public static LocalDBService Database { get; private set; }


      

       
      
    }
}
