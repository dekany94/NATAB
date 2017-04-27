using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using SQLite;

namespace NATAB
{
	public static class GenerateLocations
	{

		public static List<tbl_Locations> Generate_tbl_Location_Records(List<Coordinate> pCoordinates)
		{
			List<tbl_Locations> Locations = new List<tbl_Locations>();


			foreach (Coordinate CoordItem in pCoordinates)
			{
				tbl_Locations Location = new tbl_Locations();

				//Call methods osztály példányosítása, CallMethods = Call WebRequiest, Call Deserialization
				CallMethods cm = new CallMethods(CoordItem.Latitude, CoordItem.Longitude);
				//CallMethods cm = new CallMethods(latitude, longitude);

				JsonClass.RootObject RootObject = cm.Get_Root_Object();


				if (RootObject.status == "OK")
				{

					JsonClass.Result Item0 = RootObject.results[0];

					//JsonClass.Result Item2 = RootObject.results[2];
					//JsonClass.Result Item3 = RootObject.results[3];
					//JsonClass.Result Item4 = RootObject.results[4];
					//JsonClass.Result Item5 = RootObject.results[5];

					Location.PlaceId = Item0.place_id;
					Location.Latitude = (double)Item0.geometry.location.lat;
					Location.Longitude = (double)Item0.geometry.location.lng;

					//0. elem bejárása, adatok kigyüjtése
					for (int i = 0; i<Item0.address_components.Count; i++)
					{
						//Ország
						if (Item0.address_components[i].types[0] == "country")
						{
							Location.CountryName = Item0.address_components[i].long_name;
							Location.CountryShortName = Item0.address_components[i].short_name;	
						}

						//Város
						if (Item0.address_components[i].types[0] == "locality")
						{
							Location.CityName = Item0.address_components[i].long_name;
							Location.CityShortName = Item0.address_components[i].short_name;
						}

						//Utca információk
						if (Item0.address_components[i].types[0] == "route")
						{
							Location.StreetName = Item0.address_components[i].long_name;
							Location.StreetShortName = Item0.address_components[i].short_name;
						}

						//Irányítószám
						if (Item0.address_components[i].types[0] == "postal_code")
						{
							Location.PostalCode = Item0.address_components[i].long_name;
						}

						//Formázott cím
						Location.FormattedAddress = Item0.formatted_address;
					}


					JsonClass.Result Item1 = RootObject.results[1];
					//1. elem bejárása, adatok kigyüjtése, ha létezik
					//Megye - Administrative area level 1
					for (int i = 0; i<Item1.address_components.Count; i++)
					{
						if (Item1.address_components[i].types[0] == "administrative_area_level_1")
						{
							Location.AdministrativeArea = Item1.address_components[i].long_name;
						}

						//PlaceId
						Location.PlaceId = Item1.place_id;
					}

					Locations.Add(Location);
				}//End status ok	

			}

			return Locations;
		}//End record generation


	}
}
