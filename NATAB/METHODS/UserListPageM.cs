using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NATAB
{
	public partial class UsersListPage
	{
		
		protected void Set_GlobalClassList(List<tbl_Users> pUsersList, List<tbl_Locations> pLocationsList)
		{
			MainTabbedPage.GlobalClassList = (from u in pUsersList
											  join loc in pLocationsList on u.LocationId equals loc.LocationId
											  select new GlobalClass()
											  {
												  //Users
												  UserId = u.UserId,

												  LocationId = u.LocationId,
												  UserName = u.UserName,
												  FirstName = u.FirstName,
												  LastName = u.LastName,
												  FullName = u.FullName,
												  Password = u.Password,
												  Age = u.Age,
												  Gendre = u.Gendre,
												  UserTypeIds = u.UserTypeIds,
												  NationalityId = u.NationalityId,
												  RegDate = u.RegDate,

												  //Locations
												  //public int LocationId { get; set; }
												  PlaceId = loc.PlaceId,

												  Latitude = loc.Latitude,
												  Longitude = loc.Longitude,

												  CountryName = loc.CountryName,
												  CountryShortName = loc.CountryShortName,

												  CityName = loc.CityName,

												  CityShortName = loc.CityShortName,
												  StreetName = loc.StreetName,
												  StreetShortName = loc.StreetShortName,

												  AdministrativeArea = loc.AdministrativeArea,
												  PostalCode = loc.PostalCode,
												  FormattedAddress = loc.FormattedAddress
											  }).ToList();
			}


			//protected List<GlobalClass> Filtering(List<GlobalClass> pDataList, cl_FilterUsers pFilterUser)
			//protected void Filtering(List<GlobalClass> pDataList, cl_FilterUsers pFilterUser)
			protected void Filtering()
			{
				List<GlobalClass> FilteredList = new List<GlobalClass>();

				if (FilterClass.NationalityId != null)
					MainTabbedPage.GlobalClassList = MainTabbedPage.GlobalClassList.Where(x => x.NationalityId == FilterClass.NationalityId).ToList();

				if (FilterClass.Gendre == 0)
					MainTabbedPage.GlobalClassList = MainTabbedPage.GlobalClassList.Where(x => x.Gendre == FilterClass.Gendre).ToList();

				if (FilterClass.Gendre == 1)
					MainTabbedPage.GlobalClassList = MainTabbedPage.GlobalClassList.Where(x => x.Gendre == FilterClass.Gendre).ToList();

				if (FilterClass.AgeFrom != null)
					MainTabbedPage.GlobalClassList = MainTabbedPage.GlobalClassList.Where(x => x.Age >= FilterClass.AgeFrom).ToList();

				if (FilterClass.AgeTo != null)
					MainTabbedPage.GlobalClassList = MainTabbedPage.GlobalClassList.Where(x => x.Age <= FilterClass.AgeTo).ToList();


				if (FilterClass.UserTypeIds != null)
				{
					foreach (var item in FilterClass.UserTypeIds.Split(','))
					{
						foreach (var contItem in MainTabbedPage.GlobalClassList.Where(x => x.UserTypeIds.Contains(item)).ToList())
						{
							FilteredList.Add(contItem);
						}
					}
				}

				//return FilteredList;
			}//End Filtering





	}//End class
}//End namespace
