using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NATAB
{
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage()
		{
			InitializeComponent();

			//A Kor, nemzetiségek Picker feltöltése - az AppConstatnsban lévő metódus meghívásával
			AppConstants.Load_Picker(pickAge, "Age");
			AppConstants.Load_Picker(pickNationality, "Nationality");

		}

		#region Events
		void tbBack_Clicked(object sender, System.EventArgs e)
		{
			//Vissza navigálás a WelcomePage-re
			//Application.Current.MainPage = new WelcomePage();

			//Application.Current.MainPage = App.Set_NavBar(new WelcomePage());
			App.Set_NavBar(new WelcomePage());
		}

		void swGendre_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
		{
			if (swGendre.IsToggled)
			{ lbGendre.Text = "Nő"; }
			else { lbGendre.Text = "Férfi"; }
		}




		public void tbRegistration_Clicked(object sender, System.EventArgs e)
		{
			try
			{
				//1. Set Error Messages Visibility false - Hibaüzenetek láthatóságának resetelése
				Reset_ErrorMessages();

				//2. Form Validáció -> Ebből hívódik a Felhasználó validáció,
				//Visszatérési értéke true, ha a form valid
				SetDataItem();

			}
			catch (Exception ex)
			{
				dynamic obj = ex.StackTrace;
			}

		}
		#endregion

	}
}
