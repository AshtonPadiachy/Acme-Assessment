using EmployeeInfoWebApp.Models;
using EmployeeInfoWebApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeInfoWebApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeDetailsList : ContentPage
    {
        public EmployeeDetailsList()
        {
            InitializeComponent();
        }
        protected  override void OnAppearing()
        {
            base.OnAppearing();

            EmployeeDatabase database = EmployeeDatabase.Instance;
            detailsView.ItemsSource = database.GetPerson();

            //detailsView.ItemsSource = await App.EmployManager.GetTaskAsync();
        }
        private async void detailsView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new EmployeeDetails
                {
                    BindingContext = e.SelectedItem as Person
                });
            }
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmployeeDetails
            {
                BindingContext = new Person()
            });

        }
    }
}