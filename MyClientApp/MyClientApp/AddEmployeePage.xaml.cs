using MyClientApp.Models;
using MyClientApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyClientApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEmployeePage : ContentPage
    {
        private EmployeeServices empServices;
        public AddEmployeePage()
        {
            InitializeComponent();
            empServices = new EmployeeServices();
        }

        private async void btnTambah_Clicked(object sender, EventArgs e)
        {
            try
            {
                var newEmployee = new Employee
                {
                    EmpName = entryName.Text,
                    Designation = entryDesignation.Text,
                    Department = entryDepartment.Text,
                    Qualification = entryQualification.Text,
                    BirthDate = DateTime.Now
                };

                await empServices.InsertData(newEmployee);
                await DisplayAlert("Keterangan", $"Data Employee {newEmployee.EmpName} berhasil ditambahkan", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Kesalahan", ex.Message, "OK");
            }
        }
    }
}