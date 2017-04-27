using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Xamarin.Forms;

namespace NATAB
{
	public class cultures
	{
		public string NationalityName { get; set; }
		public int Id { get; set; }
	}

	public partial class UsersListPage : ContentPage
	{
		cl_FilterUsers FilterClass;

		public UsersListPage()
		{
			InitializeComponent();
			FilterClass = new cl_FilterUsers();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			FilterClass = MainTabbedPage.cfu;


			List<tbl_Users> qUsersDataList = null;
			qUsersDataList = await App.Database.Get_All_tbl_Users_Async();

			List<tbl_Locations> qLocationsDataList = null;
			qLocationsDataList = await App.Database.Get_All_tbl_Locations_Async();


			if ((qUsersDataList != null) && (qLocationsDataList != null))
			{
				//Új GlobalClass collection létrehozása, Id-k kovertálása ember által értelmezhető szöveggé, + egyéb foqLocationsDataListnTabbedPage.GlobalClassList = 
				Set_GlobalClassList(qUsersDataList, qLocationsDataList);
			}

			//SZŰRÉS
			Filtering();
				
			//FORMÁZÁS
				var FormattedDataSource = (from gc in MainTabbedPage.GlobalClassList
										   select new
										   {
											   	FullName = gc.FullName,
											   	FormattedAddress = gc.FormattedAddress,
											   	Age = String.Format("Kor: {0}", gc.Age),
												RegDate = gc.RegDate.CustomDateTimeFormate(),
												Gendre = String.Format("Nem: {0}", gc.Gendre.GendreToString()),
												Nationality = AppConstants.Get_NationalityName_By_Id(gc.NationalityId)
										   }).ToList();

				listView.ItemsSource = FormattedDataSource;
			}//End - On Appearing


	}
}
