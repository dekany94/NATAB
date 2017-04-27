using System;
using SQLite;

namespace NATAB
{
	public class tbl_Locations
	{
		[PrimaryKey, AutoIncrement, NotNull]
		public int LocationId { get; set; }
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


		public tbl_Locations()
		{
		}
	}
}
