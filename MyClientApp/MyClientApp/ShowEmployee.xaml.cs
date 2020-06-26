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
    public partial class ShowEmployee : ContentPage
    {
        private EmployeeServices empServices;
        public ShowEmployee()
        {
            InitializeComponent();
            empServices = new EmployeeServices();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            lvEmployee.ItemsSource = await empServices.GetData();
        }

        private async void btnAddEmployee_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEmployeePage());
        }

        private async void lvEmployee_Refreshing(object sender, EventArgs e)
        {
            lvEmployee.ItemsSource = await empServices.GetData();
            lvEmployee.IsRefreshing = false;
        }

        private async void lvEmployee_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var data = (Employee)e.Item;
            EditEmployeePage editPage = new EditEmployeePage();
            editPage.BindingContext = data;
            await Navigation.PushAsync(editPage);
        }
    }
}