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
			//Ha autentikálva van

			List<tbl_Users> Users = await App.Database.Get_All_tbl_Users_Async();


			if (await ValidUserName(Users, eUserName.Text, ePassword.Text))
			{
				//Application.Current.MainPage = App.Set_NavBar(new MainTabbedPage());
				App.Set_NavBar(new MainTabbedPage());
			}
			else
			{
				//"Ilyen felhasználó nem létezik, vagy helytelen felhasználónév, jelszó lett megadva!";
			}








		}





	}
}
