using System;
namespace NATAB
{
	public class GlobalClass
	{

		//Users
		public int UserId { get; set; }	

		public int LocationId { get; set; }
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName { get; set; }
		public string Password { get; set; }
		public int Age { get; set; }
		public int Gendre { get; set; } //0 = Férfi, 1 = Nő
		public string UserTypeIds { get; set; }
		public int NationalityId { get; set; }
		public string RegDate { get; set; }


		//Locations
		//public int LocationId { get; set; }
		public string PlaceId { get; set; }

		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public string CountryName { get; set; }
		public string CountryShortName { get; set; }

		public string CityName { get; set; }
		public string CityShortName { get; set; }

		public string StreetName { get; set; }
		public string StreetShortName { get; set; }

		public string AdministrativeArea { get; set; }
		public string PostalCode { get; set; }
		public string FormattedAddress { get; set; }








		public GlobalClass()
		{
		}


		public GlobalClass(int userId, int locationId, string userName, string firstName, string lastName, string fullName, string password, int age, int gendre, string userTypeIds, int nationalityId, string regDate, string placeId, double latitude, double longitude, string countryName, string countryShortName, string cityName, string cityShortName, string streetName, string streetShortName, string administrativeArea, string postalCode, string formattedAddress)
		{
			this.UserId = userId;
			LocationId = locationId;
			UserName = userName;
			FirstName = firstName;
			LastName = lastName;
			FullName = fullName;
			Password = password;
			Age = age;
			Gendre = gendre;
			UserTypeIds = userTypeIds;
			NationalityId = nationalityId;
			RegDate = regDate;
			PlaceId = placeId;
			Latitude = latitude;
			Longitude = longitude;
			CountryName = countryName;
			CountryShortName = countryShortName;
			CityName = cityName;
			CityShortName = cityShortName;
			StreetName = streetName;
			StreetShortName = streetShortName;
			AdministrativeArea = administrativeArea;
			PostalCode = postalCode;
			FormattedAddress = formattedAddress;
		}
	}
}
