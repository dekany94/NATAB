using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NATAB
{

	class MainClass
	{
		//SQLite adatbázis létrehozása
		static NATABDatabase DB_Generated;
		//Lokális gépen, adatbázis elérési útvonalának definiálása
		static string dbPath = "/Users/dekany/Desktop/generated_database/NATABSQLite_old.db3";

		public static NATABDatabase Database_Generated
		{
			get
			{
				if (DB_Generated == null)
				{
					DB_Generated = new NATABDatabase(dbPath);
				}
				return DB_Generated;
			}
		}

		//A main függvényt két lépésben kell lefuttatni. 
		//1. lépés Location generálás -> paraméter beállítása: rekordszám
		//2. Felhasználó generálás -> paraméterek beállítása: rekordszám, férfi/nő
		public static void Main(string[] args)
		{
			//************************************************************************************
			//#region LOCATIONS GENERÁLÁS
			//	var stopWatch = new Stopwatch();
			//	stopWatch.Start();

			//	////1. Random koordináták generálása, az előre megadott pontok által meghatározott sokszögön belül
			//	GenerateCoordinates gc = new GenerateCoordinates();
			//	List<Coordinate> qCoordList = GenerateCoordinates.Generate(1, gc);
			//	GenerateCoordinates.Show_the_Content(qCoordList);
			//	////************************************************************************************

			//	//2. Geocoder API meghívása, minden egyes koordinátához lekérjük a részletes adatokat
			//	List<tbl_Locations> tbl_Locations_List = GenerateLocations.Generate_tbl_Location_Records(qCoordList);

			//	//foreach (var item in tbl_Locations_List)
			//	//{
			//	//	Console.WriteLine(String.Format("Ország: {0}\tVáros: {1}\tUtca: {2}\tIrányítószám: {3}\tMegye: {4}",
			//	//	                                item.CountryName, item.CityName, item.StreetName, item.PostalCode, item.AdministrativeArea));
			//	//}



			//	Database_Generated.Save_List_tbl_Locations_Async(tbl_Locations_List);
			//	stopWatch.Start();

			//	Console.WriteLine(String.Format("Location-ök generálása befejeződött! Idő: {0} másodperc",
			//									stopWatch.Elapsed.TotalSeconds));
			//#endregion
			//************************************************************************************






			//************************************************************************************
			#region USERS GENERÁLÁS
				var stopWatchUser = new Stopwatch();
				stopWatchUser.Start();

				GenerateUsers.Generate_Users(1, Database_Generated);
				stopWatchUser.Start();

				Console.WriteLine(String.Format("Felhasználók generálása befejeződött! Idő: {0} másodperc",
												stopWatchUser.Elapsed.TotalSeconds));
			#endregion
			//************************************************************************************

		}
	}
}
