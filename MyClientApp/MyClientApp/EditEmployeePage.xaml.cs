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
    public partial class EditEmployeePage : ContentPage
    {
        private EmployeeServices empServices;
        public EditEmployeePage()
        {
            InitializeComponent();
            empServices = new EmployeeServices();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                var editEmp = new Employee
                {
                    EmpId = Convert.ToInt32(entryID.Text),
                    EmpName = entryName.Text,
                    Department = entryDepartment.Text,
                    Designation = entryDesignation.Text,
                    Qualification = entryQualification.Text,
                    BirthDate = DateTime.Now
                };
                await empServices.UpdateData(editEmp);
                await DisplayAlert("Keterangan", $"Data Employee berhasil diupdate", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Keterangan", ex.Message, "OK");
            }
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {

            try
            {
                var result = await DisplayAlert("Konfirmasi",
                               $"Apakah anda yakin akan delete data?", "Yes", "No");
                if (result)
                {
                    await empServices.DeleteData(entryID.Text);
                    await DisplayAlert("Keterangan", $"Data Employee berhasil delete", "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Keterangan", ex.Message, "OK");
            }
        }
    }
}