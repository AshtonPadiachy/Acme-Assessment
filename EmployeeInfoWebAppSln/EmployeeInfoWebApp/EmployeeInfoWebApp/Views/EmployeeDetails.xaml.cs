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
    public partial class EmployeeDetails : ContentPage
    {
      
        public EmployeeDetails()
        {
            InitializeComponent();
            
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            var employ = (Person)BindingContext;
            
            EmployeeDatabase database = EmployeeDatabase.Instance;
            database.SavePerson(employ);

            //await App.EmployManager.SaveTaskAsync(employ, isNewPerson);

            await Navigation.PopAsync();
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var employ = (Person)BindingContext;

            EmployeeDatabase database = EmployeeDatabase.Instance;
            database.DeletePerson(employ);

            //await App.EmployManager.DeleteTaskAsync(employ);

            await Navigation.PopAsync();
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}