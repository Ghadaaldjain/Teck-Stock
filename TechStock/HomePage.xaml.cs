using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TechStock
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            var imagesource = (UriImageSource)ImageSource.FromUri(new Uri("....."));
        }

        async void All_Tapped(System.Object sender, System.EventArgs e)
        {
            App.currentCategory = 1;

           await Navigation.PushAsync(new ProductsPage());
        }

        async void Laptops_Tapped(System.Object sender, System.EventArgs e)
        {
            App.currentCategory = 2;

            await Navigation.PushAsync(new ProductsPage());
        }

        async void Phones_Tapped(System.Object sender, System.EventArgs e)
        {
            App.currentCategory = 3;

            await Navigation.PushAsync(new ProductsPage());
        }

        async void Accessories_Tapped(System.Object sender, System.EventArgs e)
        {
            App.currentCategory = 4;

            await Navigation.PushAsync(new ProductsPage());
        }
    }
}
