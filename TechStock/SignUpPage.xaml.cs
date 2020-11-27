using System;
using System.Collections.Generic;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using Xamarin.Forms;
using TechStock.models;
namespace TechStock
{
    public partial class SignUpPage : ContentPage
    {
        private static string queue_connection_string = ".....";
        private static string queue_name = "demoqueue";
        public SignUpPage()
        {
            InitializeComponent();
        }
        private async void registerButton_Clicked(object sender, EventArgs e)
        {


            Users user = new Users()
            {
                Email = emailEntry.Text,
                Mobile = Int32.Parse(mobileEntry.Text),
                Password = passwordEntry.Text

            };

            await App.DatabaseServiceClient.GetTable<Users>().InsertAsync(user);
            App.currentUser = user;
            await Navigation.PushAsync(new SettingsPage());

            var user_json = Newtonsoft.Json.JsonConvert.SerializeObject(new { Email = emailEntry.Text, Mobile = mobileEntry.Text });

            CloudStorageAccount queue_acc = CloudStorageAccount.Parse(queue_connection_string);

            CloudQueueClient queue_client = queue_acc.CreateCloudQueueClient();

            CloudQueue _queue = queue_client.GetQueueReference(queue_name);

            CloudQueueMessage _message = new CloudQueueMessage(user_json);
            _queue.AddMessage(_message);

        }

        async void LoginButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SignInPage());
        }

    }
}
