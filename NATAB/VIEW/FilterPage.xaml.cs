using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NATAB
{
	public partial class FilterPage : ContentPage
	{
		public FilterPage()
		{
			InitializeComponent();

			//A Pickerek feltöltése az appconstants-ban lévő metódus meghívásával 
			AppConstants.Load_Picker(pickAgeFrom, "Age");
			AppConstants.Load_Picker(pickAgeTo, "Age");
			AppConstants.Load_Picker(pickNationality, "Nationality");
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();


			Set_Filter_Form();
		}

		public void Set_Filter_Form()
		{
			swGendre.IsToggled = MainTabbedPage.cfu.Gendre == 1 ? true : false;

			if (MainTabbedPage.cfu.AgeFrom != null)
				pickAgeFrom.SelectedIndex = (int.Parse(MainTabbedPage.cfu.AgeFrom.ToString()) - 18);

			if(MainTabbedPage.cfu.AgeTo != null)
				pickAgeTo.SelectedIndex = (int.Parse(MainTabbedPage.cfu.AgeTo.ToString()) - 18);


			//Nationality
			if (MainTabbedPage.cfu.NationalityId != null)
			{
				pickNationality.SelectedIndex = int.Parse(MainTabbedPage.cfu.NationalityId.ToString())-1;
			}

			//UserTypeIds
			if (MainTabbedPage.cfu.UserTypeIds != string.Empty)
			{
				Set_UserTypes_Switches(MainTabbedPage.cfu.UserTypeIds);
			}
		}

		public void Set_UserTypes_Switches(string pUserTypeIds)
		{
			bool MainSwitch = false;

			foreach (var item in pUserTypeIds.Split(','))
			{
				switch (int.Parse(item))
				{
					case 1:
						{
							Switch sw = view.FindByName<Switch>(AppConstants.sUserTypeId(1).ToString());
							sw.IsToggled = true; MainSwitch = true;
							break;
						}

					case 2:
						{
							Switch sw = view.FindByName<Switch>(AppConstants.sUserTypeId(2).ToString());
							sw.IsToggled = true; MainSwitch = true;
							break;
						}

					case 3:
						{
							Switch sw = view.FindByName<Switch>(AppConstants.sUserTypeId(3).ToString());
							sw.IsToggled = true; MainSwitch = true;
							break;
						}
					case 4:
						{
							Switch sw = view.FindByName<Switch>(AppConstants.sUserTypeId(4).ToString());
							sw.IsToggled = true; MainSwitch = true;
							break;
						}

					case 5:
						{
							Switch sw = view.FindByName<Switch>(AppConstants.sUserTypeId(5).ToString());
							sw.IsToggled = true; MainSwitch = true;
							break;
						}

					case 6:
						{
							Switch sw = view.FindByName<Switch>(AppConstants.sUserTypeId(6).ToString());
							sw.IsToggled = true; MainSwitch = true;
							break;
						}

					case 7:
						{
							Switch sw = view.FindByName<Switch>(AppConstants.sUserTypeId(7).ToString());
							sw.IsToggled = true; MainSwitch = true;
							break;
						}
					case 8:
						{
							Switch sw = view.FindByName<Switch>(AppConstants.sUserTypeId(8).ToString());
							sw.IsToggled = true; MainSwitch = true;
							break;
						}

					default:
						break;
				}

			}
			if (MainSwitch)
			{ swUserTypesVisible.IsToggled = true; }
		}


		void swGendre_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
		{
			if (swGendre.IsToggled)
			{
				lbGendre.Text = "Nő";
			}
			else
			{
				lbGendre.Text = "Férfi";
			}
		}

		void tbFilter_Clicked(object sender, System.EventArgs e)
		{
			cl_FilterUsers Filter = new cl_FilterUsers();

			//Kor (-tól:)
			if (pickAgeFrom.SelectedIndex != -1)
			{
				Filter.AgeFrom =  int.Parse(pickAgeFrom.Items[pickAgeFrom.SelectedIndex]);
			}

			//Kor (-tól:)
			if (pickAgeTo.SelectedIndex != -1)
			{
				Filter.AgeTo =  int.Parse(pickAgeTo.Items[pickAgeTo.SelectedIndex]);
			}

			//Nem
			if (swGendre.IsToggled)
			{ Filter.Gendre = 1; } //Nő = 1
			else { Filter.Gendre = 0; } //Férfi = 0

			//Nemzetiség
			if (pickNationality.SelectedIndex != -1)
			{
				Filter.NationalityId = AppConstants.dCultures[pickNationality.Items[pickNationality.SelectedIndex]];
			}

			//Felhasználó típúsok
			Filter.UserTypeIds = Get_UserTypeIds();

			//Felhasználók listájának megjelenítése szűrés osztály átadása
			App.Set_NavBar(new MainTabbedPage(Filter));
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


		public void Reset_UserTypes_Switches()
		{
			swAltIsm.IsToggled = false;
			swRandi.IsToggled = false;
			swBaratkozas.IsToggled = false;
			swSzabadidosPartner.IsToggled = false;
			swKirandulas.IsToggled = false;
			swKirandulas.IsToggled = false;
			swSport.IsToggled = false;
			swExtrem.IsToggled = false;
			swFelfedez.IsToggled = false;

		}


		void swUserTypesVisible_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
		{
			if (swUserTypesVisible.IsToggled)
			{
				gUserTypes.IsVisible = true;
			}
			else
			{
				gUserTypes.IsVisible = false;
				Reset_UserTypes_Switches();
			}
		}
	}
}
