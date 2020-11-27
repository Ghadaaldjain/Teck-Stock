using System;
using System.Collections.Generic;
using TechStock.models;
using Xamarin.Forms;

namespace TechStock
{
    public partial class ProductsPage : ContentPage
    {
        public ProductsPage()
        {
            InitializeComponent();

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                string Cat = App.currentCategory.ToString();
                bool CategorySelected = string.IsNullOrEmpty(Cat);

                if (!CategorySelected && Cat != "1")
                {
                    // var services_result = new List<Product>();

                    
                    var products = await App.DatabaseServiceClient.GetTable<Product>()
                           .Where(X => X.Category_id == Cat)
                           .ToListAsync();


                    // var services = await App.DatabaseServiceClient.GetTable<Product>().Where(X => services_ids.Contains(X.Id)).ToListAsync();
                    //if (services != null)
                    //l_arcResult.AddRange(cities)

                    //var services_2 = await App.DatabaseServiceClient.GetTable<OccasionServices>().CreateQuery(@"select s.Name from Service s inner join OccasionServices os on s.Id = os.Service_id")
                    //    .Where( os => os.Occasion_id == App.currentOccasion.Id).ToListAsync();

                    productList.ItemsSource = (System.Collections.IEnumerable)products;

                }
                else
                {
                    var products = await App.DatabaseServiceClient.GetTable<Product>().ToListAsync();
                    productList.ItemsSource = (System.Collections.IEnumerable)products;

                }
            }
            catch
            {
                var products = await App.DatabaseServiceClient.GetTable<Product>().ToListAsync();
                productList.ItemsSource = (System.Collections.IEnumerable)products;
            }

        }

        async void addToCart_Clicked(System.Object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            string CurrentProductId = button.CommandParameter.ToString();

            Console.Write(CurrentProductId);

            //bool currentUserEmpty = string.IsNullOrEmpty(App.currentUser.Email);
            //bool currentCartEmpty = string.IsNullOrEmpty(""+App.currentCart.Id);
            //App.currentProduct = (Product)productList.curr;

            if (App.currentCart.Id == null || App.currentCart.Id == string.Empty)
            {
                Cart cart = new Cart()
                    {
                        Id = Guid.NewGuid().ToString()
                    };
                    await App.DatabaseServiceClient.GetTable<Cart>().InsertAsync(cart);
                    App.currentCart = cart;

                CartProducts cart_products = new CartProducts()
                {
                    //Id = Guid.NewGuid().ToString(),
                    Cart_id = App.currentCart.Id,
                    Product_id = CurrentProductId
                };

                await App.DatabaseServiceClient.GetTable<CartProducts>().InsertAsync(cart_products);

                await DisplayAlert("Done"," Product Added", "Ok");
            }
            else
            {
                CartProducts cart_products = new CartProducts()
                {
                    //Id = Guid.NewGuid().ToString(),
                    Cart_id = App.currentCart.Id,
                    Product_id = CurrentProductId
                };

                await App.DatabaseServiceClient.GetTable<CartProducts>().InsertAsync(cart_products);

                await DisplayAlert("Done", " Product Added  ", "Ok");

            }
        }
        async void SearchBar_SearchButtonPressed(System.Object sender, System.EventArgs e)
        {
            //var ServiceSearched = countries.Where(c => c.Contains(CountriesSearchBar.Text));
            var products = await App.DatabaseServiceClient.GetTable<Product>().Where(x => x.Name == SearchProducts.Text).ToListAsync();

            productList.ItemsSource = products;
        }
    }
}
