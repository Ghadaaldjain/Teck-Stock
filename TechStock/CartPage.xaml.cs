using System;
using System.Collections.Generic;
using TechStock.models;
using Xamarin.Forms;

namespace TechStock
{
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (App.currentCart.Id != null)
            {

                var prodcucts_result = new List<Product>();

                var prodcucts_ids = await App.DatabaseServiceClient.GetTable<CartProducts>()
                       .Where(X => X.Cart_id == ("" + App.currentCart.Id))
                       .Select(x => x.Product_id)
                       .ToListAsync();

                var products = await App.DatabaseServiceClient.GetTable<Product>().Where(X => prodcucts_ids.Contains(X.Id)).ToListAsync();

                double total = 0;
                foreach (Product item in products)
                {
                    total += item.Price;
                }
                App.cartTotal = total;
                cartProductsList.ItemsSource = products;


                Total.Text = "Your Total is:  " + total + " SAR";


                invoiceBtn.Text = "Checkout";

            }
            else
            {
                invoiceBtn.Text = "Your Cart is empty";

            }

        }
    }
}
