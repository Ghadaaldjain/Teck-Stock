using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace TechStock
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
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


            TitleLabel.Text = "Settings";
            profile.Text = "User Profile";
            contactus.Text = "Contact Us";
            privacy.Text = "Privicy policy";
            signuot.Text = "Sign out";

        }
        async void user_profile_clicked(System.Object sender, System.EventArgs e)
        {
            //await Navigation.PushAsync(new UserProfile());
        }

        async void contact_us_clicked(System.Object sender, System.EventArgs e)
        {
                //await Navigation.PushAsync(new ContactUs());
        }

        async void privicy_policy_clicked(System.Object sender, System.EventArgs e)
        {
            //if (App.isArabic)
            //{
            //    await Navigation.PushAsync(new PrivacyPolicyAr());
            //}
            //else
            //{
            //    await Navigation.PushAsync(new PrivacyPolicy());
            //}

        }

        async void sign_out_clicked(System.Object sender, System.EventArgs e)
        {
            App.currentUser = null;

            var previousPage = Navigation.NavigationStack.LastOrDefault();

            await Navigation.PushAsync(new SignUpPage());

            Navigation.RemovePage(previousPage);

        }
    }
}
