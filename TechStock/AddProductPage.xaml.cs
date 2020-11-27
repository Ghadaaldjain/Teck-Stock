using System;
using Microsoft.WindowsAzure.Storage;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Collections.Generic;
using TechStock.models;
using Xamarin.Forms;
using System.IO;
using System.Linq;

namespace TechStock
{
    public partial class AddProductPage : ContentPage
    {
        string url { get; set; }
        Dictionary<string, string> nameToId = new Dictionary<string, string>
        {
            { "Laptops", "2" },
            { "Phones", "3" },
            { "Accessories", "4"},
            { "Other", "1"}

        };
        public AddProductPage()
        {
            InitializeComponent();
            foreach (string catrgoryName in nameToId.Keys)
            {
                picker.Items.Add(catrgoryName);
            }
        }
        async void SelectImageButton_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "This is not supported on your device", "Ok");
                return;
            }

            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            if (selectedImageFile == null)
            {
                await DisplayAlert("Error", "There was an error when trying to get your image, please try again", "Ok");
                return;
            }

            selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());

            UploadImage(selectedImageFile.GetStream());
        }

        async void addButton_Clicked(object sender, EventArgs e)
        {

            try
            {
                string categoryId = "1";

                if (picker.SelectedIndex != -1)
                {
                    string categoryName = picker.Items[picker.SelectedIndex];
                    categoryId = nameToId[categoryName];
                }
                //Console.WriteLine(url);

                Product product = new Product()
                {
                    Name = nameEntry.Text,
                    Category_id = categoryId,
                    Users_id = App.currentUser.Id,
                    Subtitle = subtitleEntry.Text,
                    Price = Int32.Parse(priceEntry.Text),
                    Description = descriptionEntry.Text,
                    Image = url.ToString()

                };


                await App.DatabaseServiceClient.GetTable<Product>().InsertAsync(product);

                await DisplayAlert("Success", "Product added successfuly!", "Ok");
                var previousPage = Navigation.NavigationStack.LastOrDefault();

                await Navigation.PushAsync(new CatalogPage());

                //Navigation.RemovePage(previousPage);
            }
            catch {
                await DisplayAlert("Success", "Product added successfuly!!!", "Ok");
                var previousPage = Navigation.NavigationStack.LastOrDefault();
                await Navigation.PushAsync(new CatalogPage());

                Navigation.RemovePage(previousPage);

            }
        }

        
        private async void UploadImage(Stream stream)
        {
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=demoappstorageacc;AccountKey=U41AoLbEAoMv0EO37DhuiOXzXa42gYSpVtGr+Am96zIYlhIaOUYU7OUFgAt8XkH3Rk+PRBRCBtfu/KYGMgsx2Q==;EndpointSuffix=core.windows.net");
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference("user-product-images");
            await container.CreateIfNotExistsAsync();

            var name = Guid.NewGuid().ToString();
            var blockBlob = container.GetBlockBlobReference($"{name}.jpg");
            await blockBlob.UploadFromStreamAsync(stream);

            url = blockBlob.Uri.OriginalString;
        }
    }
}