using System;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;
using TechStock.models;
using System.Linq;

namespace TechStock
{
    public partial class App : Application
    {
        public static MobileServiceClient DatabaseServiceClient = new MobileServiceClient("https://demobackendwebapp.azurewebsites.net");
        //public static Category currentCategory = new Category();
        public static int currentCategory = new int();
        public static Users currentUser = new Users();
        public static Cart currentCart = new Cart();
        public static Product selectedProduct = new Product();
        public static double cartTotal = new double();

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
