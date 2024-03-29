using Application.Models;
using Camera.MAUI;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using CommunityToolkit.Mvvm.Input;


namespace Application.ViewModels
{
    [QueryProperty(nameof(EmployeeProp), "EmployeeDetail")]

    public partial class AddEmployeeViewModel : ObservableObject
    {
        [ObservableProperty]
        private Employee _employeeProp = new Employee();

        [ObservableProperty]
        private Employee _employee = new Employee();

        public string DateValue;
        private bool IsPhotoAdded;

        //public Employee EmployeeDetails { get; set; }

        private readonly ILocalDbServices _dbService;

        private int _editCustomerId;
        private ListView listView;
        public AddEmployeeViewModel(ILocalDbServices dBService)
        {

           // InitializeListView();
            _dbService = dBService;
            //task.run(async () => listview.itemssource = await _dbservice.getemployees());
            CaptureEmployeePhotoCommand = new Command(DoCaptureEmployeePhoto, () => MediaPicker.IsCaptureSupported);

        }

       

        //private void InitializeComponent()
        //{
        //    throw new NotImplementedException();
        //}

        // private void InitializeListView()
        // {
        //     listView = new ListView();
        //}

        //private void cameraView_CamerasLoaded(object sender, EventArgs e)
        //{
        //    cameraVIew.Camera = cameraVIew.Cameras.First();
        //    MainThread.BeginInvokeOnMainThread(async () =>
        //    {
        //        await cameraVIew.StopCameraAsync();
        //        await cameraVIew.StartCameraAsync();
        //    });
        //}

        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    clickedImage.Source = cameraVIew.GetSnapShot(Camera.MAUI.ImageFormat.PNG);
        //}


        public ICommand CaptureEmployeePhotoCommand { get; }


        private async void DoCaptureEmployeePhoto()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                CompleteEmployeePhotoPath = await _dbService.LoadPhotoAsync(photo);
                Console.WriteLine("Employee Photo Captured" + CompleteEmployeePhotoPath);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }



        

        private string employeePhotoPath;
        public string CompleteEmployeePhotoPath
        {
            get => employeePhotoPath;
            set
            {
                SetProperty(ref employeePhotoPath, value);
                HasPhoto = !string.IsNullOrEmpty(value);
            }
        }

        private bool _hasPhoto;
        public bool HasPhoto
        {
            get => _hasPhoto;
            set => SetProperty(ref _hasPhoto, value);

        }

        //------------------------------------------------------------------------trial code---------------------
        //public async void SaveButton_Clicked(object sender, EventArgs e)
        //{


        //    if (_editCustomerId == 0)
        //    {
        //        await _dbService.Create(new Employee
        //        {
        //            EmployeeName = Employee.EmployeeName,
        //            Email = Employee.Email,
        //            Mobile = Employee.Mobile,
        //            Department = Employee.Department,
        //            JoinedDate = Employee.JoinedDate,
        //            Image =CompleteEmployeePhotoPath


        //        });
        //    }
        //    else
        //    {
        //        await _dbService.Update(new Employee
        //        {
        //            Id = _editCustomerId,
        //            EmployeeName = Employee.EmployeeName,
        //            Email = Employee.Email,
        //            Mobile = Employee.Mobile,
        //            Department = Employee.Department,
        //            JoinedDate = Employee.JoinedDate,
        //            Image = CompleteEmployeePhotoPath

        //        });

        //        _editCustomerId = 0;
        //    }

        //    //nameEntryField.Text = string.Empty;
        //    //emailEntryField.Text = string.Empty;
        //    //mobileEntryField.Text = string.Empty;

           
        //    listView.ItemsSource = await _dbService.GetEmployees();

        //}
        //--------------------------------------------trial code---------------------------------
        [RelayCommand]
        async Task SaveButton()
        {

            if (EmployeeProp.EmployeeName == "" || 
                EmployeeProp.Email == "" ||
                EmployeeProp.Department == "" ||
                EmployeeProp.Mobile == "" ||
                EmployeeProp.Image == "" ||
                EmployeeProp.EmployeeName is null ||
                EmployeeProp.Email is null ||
                EmployeeProp.Department is null ||
                EmployeeProp.Mobile is null ||
                EmployeeProp.Image is null )

            {
                await Shell.Current.DisplayAlert("Alert!", "You missed some details", "OK");
                return;
            }

            int response = -1;

            if (EmployeeProp.Id == 0)
            {
                EmployeeProp.Image = CompleteEmployeePhotoPath;
                //response = await _dbService.Update(EmployeeProp);
            }

            if (_editCustomerId == 0)
            {
                await _dbService.Create(new Employee
                {
                    EmployeeName = EmployeeProp.EmployeeName,
                    Email = EmployeeProp.Email,
                    Mobile = EmployeeProp.Mobile,
                    Department = EmployeeProp.Department,
                    JoinedDate = EmployeeProp.JoinedDate,
                    Image = CompleteEmployeePhotoPath


                });
            }
            else
            {
                await _dbService.Update(new Employee
                {
                    Id = _editCustomerId,
                    EmployeeName = EmployeeProp.EmployeeName,
                    Email = EmployeeProp.Email,
                    Mobile = EmployeeProp.Mobile,
                    Department = EmployeeProp.Department,
                    JoinedDate = EmployeeProp.JoinedDate,
                    Image = CompleteEmployeePhotoPath

                });

                _editCustomerId = 0;
            }

            //nameEntryField.Text = string.Empty;
            //emailEntryField.Text = string.Empty;
            //mobileEntryField.Text = string.Empty;


            listView.ItemsSource = await _dbService.GetEmployees();

        }

        //private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    var customer = (Customer)e.Item;
        //    var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

        //    switch (action)
        //    {
        //        case "Edit":
        //            _editCustomerId = customer.Id;
        //            nameEntryField.Text = customer.CustomerName;
        //            emailEntryField.Text = customer.Email;
        //            mobileEntryField.Text = customer.Mobile;
        //            break;

        //        case "Delete":
        //            await _dbService.Delete(customer);
        //            listView.ItemsSource = await _dbService.GetCustomers();
        //            break;

        //    }
        //}
    }
}
