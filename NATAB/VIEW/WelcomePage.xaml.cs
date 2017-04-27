using System;
using System.Diagnostics;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NATAB
{
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage()
		{
			InitializeComponent();
		}

		//protected override async void OnAppearing()
		//{
		//	base.OnAppearing();
		//}

		void btLogIn_Clicked(object sender, System.EventArgs e)
		{
			//LogInPage-re navigálás (Bejelentkezés)
			//Application.Current.MainPage = App.Set_NavBar(new LogInPage());
			App.Set_NavBar(new LogInPage());

			//await Navigation.PushModalAsync(new MainTabbedPage());

		}

		void btSignUp_Clicked(object sender, System.EventArgs e)
		{
			//SignUpPage-re navigálás (Regisztráció)
			//Application.Current.MainPage = App.Set_NavBar(new SignUpPage());
			App.Set_NavBar(new SignUpPage());
		}
	}
}
