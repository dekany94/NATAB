using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NATAB
{
	public partial class SignUpPage
	{
		/// <summary>
		/// Validate the Username. - Felhasználónév validáció - A függvény visszatérési értéke true, ha érvényes a felhasználónév, különben false
		/// </summary>
		/// <returns>The user name.</returns>
		/// <param name="pUserName">P user name.</param>
		public async Task<bool> Valid_UserName_Async(string pUserName)
		{
			bool Valid = true;
			//meg kell számolni, hogy létezik-e olyan felhasználó akinek ugyan ez a felhasználó neve
			try
			{
				List<tbl_Users> AllUser = await App.Database.Get_All_tbl_Users_Async();

				if (AllUser != null)
				{
					foreach (var item in AllUser)
					{
						if (item.UserName == pUserName)
						{
							Valid = false; break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				dynamic StackTrace = ex.StackTrace;
				dynamic Message = ex.Message;
			}

			return Valid;
		}

		/// <summary>
		/// Valids the password. - Jelszó validáció
		/// </summary>
		/// <returns><c>true</c>, if password was valided, <c>false</c> otherwise.</returns>
		/// <param name="pPassword">P password.</param>
		public bool ValidPassword(string pPassword)
		{
			var hasNumber = new Regex(@"[0-9]+");           //Tartalmaz számot
			var hasUpperChar = new Regex(@"[A-Z]+");        //Tartalmaz nagybetűt
			var hasMinimum8Chars = new Regex(@".{8,}");     //Tartalmaz számot

			bool isValidated = hasNumber.IsMatch(pPassword) &&
								 hasUpperChar.IsMatch(pPassword) &&
								hasMinimum8Chars.IsMatch(pPassword);
			return isValidated;
		}	



		/// <summary>
		/// Gets the user type identifiers. - User típus Id-k meghatározása
		/// </summary>
		/// <returns>The user type identifiers.</returns>
		public string Get_UserTypeIds()
		{
			string UserTypeIds = string.Empty;

			if (swAltIsm.IsToggled)
			{
				UserTypeIds += AppConstants.iUserTypeId(AppConstants.UserTypes.swAltIsm);
			}

			if (swRandi.IsToggled)
			{
				if (UserTypeIds != string.Empty)
					UserTypeIds += ",";
				UserTypeIds += AppConstants.iUserTypeId(AppConstants.UserTypes.swRandi);
			}

			if (swBaratkozas.IsToggled)
			{
				if (UserTypeIds != string.Empty)
					UserTypeIds += ",";
				UserTypeIds += AppConstants.iUserTypeId(AppConstants.UserTypes.swBaratkozas);
			}

			if (swSzabadidosPartner.IsToggled)
			{
				if (UserTypeIds != string.Empty)
					UserTypeIds += ",";
				UserTypeIds += AppConstants.iUserTypeId(AppConstants.UserTypes.swSzabadidosPartner);
			}

			if (swKirandulas.IsToggled)
			{
				if (UserTypeIds != string.Empty)
					UserTypeIds += ",";
				UserTypeIds += AppConstants.iUserTypeId(AppConstants.UserTypes.swKirandulas);
			}

			if (swSport.IsToggled)
			{
				if (UserTypeIds != string.Empty)
					UserTypeIds += ",";
				UserTypeIds += AppConstants.iUserTypeId(AppConstants.UserTypes.swSport);
			}

			if (swExtrem.IsToggled)
			{
				if (UserTypeIds != string.Empty)
					UserTypeIds += ",";
				UserTypeIds += AppConstants.iUserTypeId(AppConstants.UserTypes.swExtrem);
			}

			if (swFelfedez.IsToggled)
			{
				if (UserTypeIds != string.Empty)
					UserTypeIds += ",";
				UserTypeIds += AppConstants.iUserTypeId(AppConstants.UserTypes.swFelfedez);
			}

			return UserTypeIds;
		}


		/// <summary>
		/// Resets the error messages. - Hiba üzenetek láthatoságának elrejtése
		/// </summary>
		public void Reset_ErrorMessages()
		{
			emFirstName.IsVisible = false;
			emLastName.IsVisible = false;
			emUserName.IsVisible = false;
			emValidUserName.IsVisible = false;
			emPassword.IsVisible = false;
			emValidUserType.IsVisible = false;
			emAge.IsVisible = false;
			emNationality.IsVisible = false;
			emValidPassword.IsVisible = false;
		}

		/// <summary>
		/// Validates the form. - Form validálás
		/// </summary>
		/// <returns>The form.</returns>
		public async Task<bool> Validate_Form_Async()
		{
			bool Valid = true;
			//Két vizsgálat szükséges:
			//1. Az entry kontrolok úgy működnek, hogy default állapotukban null értéket kapnak.
			//2. Ha viszont a beírt szöveg kerül törlésre, akkor az értéke string.Empty lesz
			//emiatt a string.Empty-t is vizsgálnunk kell

			if (eFirstName.Text == null || eFirstName.Text == string.Empty)
			{ emFirstName.IsVisible = true; Valid = false; }

			if (eLastName.Text == null || eLastName.Text == string.Empty)
			{ emLastName.IsVisible = true; Valid = false; }

			if (eUserName.Text == null || eUserName.Text == string.Empty)
			{ emUserName.IsVisible = true; Valid = false; }
			else
			{
				//Felhasználónév duplikáció ellenörzése
				if (!await Valid_UserName_Async(eUserName.Text))
				{ emValidUserName.IsVisible = true; Valid = false; }
			}

			if (eFirstName.Text == null || eFirstName.Text == string.Empty)
			{ emFirstName.IsVisible = true; Valid = false; }

			if (ePassword.Text == null || ePassword.Text == string.Empty)
			{ emPassword.IsVisible = true; Valid = false; }

			if (pickAge.SelectedIndex == -1)
			{ emAge.IsVisible = true; Valid = false; }

			if (pickNationality.SelectedIndex == -1)
			{ emNationality.IsVisible = true; Valid = false; }

			//Minimum egy keresési cél megadása kötelező
			if (Get_UserTypeIds() == string.Empty)
			{ emValidUserType.IsVisible = true; Valid = false; }

			//A Password validácót csak akkor futtatjuk, ha van megadva érték
			//(Különben null reference exception-t dob a ValidPassword()
			if (ePassword.Text != null && ePassword.Text != string.Empty)
			{
				if(!ValidPassword(ePassword.Text))
				{ emValidPassword.IsVisible = true; Valid = false; }
			}
				

			return Valid;
		}

		public async void SetDataItem()
		{
			if (await Validate_Form_Async())
			{
				//tbl_Users osztály példányosítása, a felhasználói adatok tárolásához
				tbl_Users User = new tbl_Users();

				//3. Hozzáférés a formon lévő adatokhoz, osztály adattagjainak feltöltése
				User.UserName = eUserName.Text;
				User.FirstName = eFirstName.Text;
				User.LastName = eLastName.Text;
				User.FullName = eFirstName.Text + " " + eLastName.Text;
				User.Password = ePassword.Text;

				//SelectedIndex -1 abban az esetben, ha nincsen kiválasztva semmi
				if (pickAge.SelectedIndex != -1)
				{
					User.Age = int.Parse(pickAge.Items[pickAge.SelectedIndex]);
				}

				if (swGendre.IsToggled)
				{ User.Gendre = 1; } //Nő = 1
				else { User.Gendre = 0; } //Férfi = 0

				if (pickNationality.SelectedIndex != -1)
				{
					User.NationalityId = AppConstants.dCultures[pickNationality.Items[pickNationality.SelectedIndex]];
				}

				User.UserTypeIds = Get_UserTypeIds();
				User.RegDate = AppConstants.DateTimeSQLite(DateTime.Now);

				//Rekord adatbázisba mentése
				await App.Database.Save_Item_tbl_Users_Async(User);
				//Sikeres regisztráció, a felhasználót beléptetjuk az alkalmazásba
				//Application.Current.MainPage = App.Set_NavBar(new MainTabbedPage());
				App.Set_NavBar(new MainTabbedPage());
			}
		}





	}
}
