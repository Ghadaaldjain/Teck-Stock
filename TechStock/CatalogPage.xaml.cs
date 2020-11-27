using System;
using System.Collections.Generic;
using System.Linq;
using TechStock.models;
using Xamarin.Forms;

namespace TechStock
{
    public partial class CatalogPage : ContentPage
    {
        public CatalogPage()
        {
            InitializeComponent();

        }
        protected override async void OnAppearing()
        {
            // Remove LoginPage from NavigationStack
            if (Navigation.NavigationStack.Count > 0)
            {
                Page page = Navigation.NavigationStack.First();
                if (page != null && page != this)
                {
                    Navigation.RemovePage(page);
                }
            }
            base.OnAppearing();

            //bool isUserEmpty = string.IsNullOrEmpty(App.currentUser.Id.ToString());
            //ProductsList.ItemsSource = null;
            if (App.currentUser != null)
            {
                string userId = App.currentUser.Id;

                var products = await App.DatabaseServiceClient.GetTable<Product>()
                            .Where(X => X.Users_id == userId)
                            .ToListAsync();

                ProductsList.ItemsSource = products;
            }
            else {
                ProductsList.ItemsSource = null;

                    }


           
        }

        async void AddButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if (App.currentUser == null || App.currentUser.Id == string.Empty)
            {
                await DisplayAlert("Error", "Uploading products is only allowd for loged in users ", "Ok");
                return;
            }

                await Navigation.PushAsync(new AddProductPage());
               
            }
    }
}
