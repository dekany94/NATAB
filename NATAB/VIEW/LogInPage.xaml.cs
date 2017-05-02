using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NATAB
{
	public partial class LogInPage : ContentPage
	{

		public LogInPage()
		{
			InitializeComponent();
		}

		void tbBack_Clicked(object sender, System.EventArgs e)
		{
			//Vissza navigálás a WelcomePage-re
			//Application.Current.MainPage = App.Set_NavBar(new WelcomePage());
			App.Set_NavBar(new WelcomePage());

		}

		public async void btLogIn_Clicked(object sender, System.EventArgs e)
		{
			emValidLogin.IsVisible = false;

			List<tbl_Users> Users = await App.Database.Get_All_tbl_Users_Async();

			//Ellenőrizzük, hogy a mezők kivannak-e töltve
			if ((eUserName.Text != string.Empty && eUserName.Text != null) &&
			   ePassword.Text != string.Empty && ePassword.Text != null)
			{
				//Ellenőrizzük, hogy létező felhasználó-e helyes jelszóval
				if (await IsValidUser(Users, eUserName.Text, ePassword.Text))
				{
					//Ha igen (autentikálva van) beléptetem a főoldalra
					App.Set_NavBar(new MainTabbedPage());
				}
				else
				{
					emValidLogin.IsVisible = true;
					//"Ilyen felhasználó nem létezik, vagy helytelen felhasználónév, jelszó lett megadva!";
				}
			}











		}





	}
}
