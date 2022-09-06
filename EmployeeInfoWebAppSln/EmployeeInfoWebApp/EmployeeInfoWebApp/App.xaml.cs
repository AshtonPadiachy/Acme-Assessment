
using EmployeeInfoWebApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeInfoWebApp
{
    public partial class App : Application
    {

        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new EmployeeDetailsList())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = (Color)App.Current.Resources["blue"]
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
