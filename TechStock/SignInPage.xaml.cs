using System;
using System.Collections.Generic;
using TechStock.models;
using Xamarin.Forms;
using System.Linq;

namespace TechStock
{
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
        }
        private async void loginButton_Clicked(System.Object sender, System.EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if (isEmailEmpty || isPasswordEmpty)
            {
                await DisplayAlert("Error", "Email and password cannot be empty", "Ok");
            }
            else
            {
                var user = (await App.DatabaseServiceClient.GetTable<Users>().Where(u => u.Email == emailEntry.Text).ToListAsync()).FirstOrDefault();

                if (user != null)
                {
                    if (user.Password == passwordEntry.Text)
                    {
                        App.currentUser = user;


                        await Navigation.PushAsync(new SettingsPage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Email or password are incorrect", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Email or password are incorrect", "Ok");
                }


            }
        }
    }
}

