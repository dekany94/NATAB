using System;
using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;

namespace NATAB
{

	/// <summary>
	/// Generate users. 
	/// </summary>
	public class GenerateUsers
	{
		/// <summary>
		/// Reference: http://www.jerriepelser.com/blog/creating-test-data-with-nbuilder-and-faker/
		/// Generates the users. - Tesztfelhasználók generálása
		/// </summary>
		/// <param name="pNumberOfRecords">P number of records. - Generálandó rekordszám</param>
		/// <param name="Database">Database. - Adatbázis példány átadása</param>
		public static void Generate_Users(int pNumberOfRecords, NATABDatabase Database)
		{
			Random rnd = new Random();

			var User = Builder<tbl_Users>.CreateListOfSize(pNumberOfRecords)
			                             .All()
									 
			                             .With(c => c.UserId = 0)
									 
			                             .With(c => c.LocationId = Faker.NumberFaker.Number(rnd.Next()))
			                             .With(c => c.FullName = Faker.NameFaker.MaleName())
			                             //.With(c => c.FullName = Faker.NameFaker.FemaleName())

			                              
			                             .With(c => c.FirstName = c.FullName.Split(' ')[0])
			                             .With(c => c.LastName = c.FullName.Split(' ')[1])

			                             .With(c => c.UserName = c.FirstName.ToLower() + rnd.Next(1, 99).ToString())
			                             .With(c => c.Password = Faker.StringFaker.AlphaNumeric(10))

									 
			                             .With(c => c.Age = Faker.NumberFaker.Number(18, 100))
									 
			                             .With(c => c.Gendre = 0)

										 .With(c => c.UserTypeIds = Generate_Random_UserTypes(rnd))
			                             .With(c => c.NationalityId = Faker.NumberFaker.Number(1, 116))
										 //.With(c => c.RegDate = Faker.DateTimeFaker.DateTime().ToString().Remove((Faker.DateTimeFaker.DateTime().ToString()).Length - 4, 3)).Build();
			                             .With(c => c.RegDate = Faker.DateTimeFaker.DateTime().ToString()).Build();

			List<tbl_Users> UsersList = User.ToList();

			//Idegen kulcs referencia biztosítása, legmagasabb Id lekérdezése
			int i = Database.Get_Max_UserId_Async();

			foreach (tbl_Users item in UsersList)
			{
				item.LocationId = i+1;
			}

			//Felhasználó rekord elmentése
			Database.Save_List_tbl_Users_Async(UsersList);

		}


		/// <summary>
		/// Generates the random user types. - Felhasználótípusok generálása, (minden új felhasználó létrehozásakor meghívódik)
		/// </summary>
		/// <returns>The random user types.</returns>
		/// <param name="rnd">Random.</param>
		public static string Generate_Random_UserTypes(Random rnd)
		{
			string Result = string.Empty;

			//Random rnd = new Random();

			//Generálandó szám meghatározása, a for ciklus határa - (Hány random számot generáljon a függvény) - 1-8 között vehet fel értéket
			//Int típusú tömb deklarálása, memória allokálás
			int NumberOfUserTypes = rnd.Next(1, 8+1);
			int[] UserTypesIntArray = new int[NumberOfUserTypes];


			//A random számok generálása
			for (int i = 0; i < NumberOfUserTypes; i++)
			{
				int szam = rnd.Next(1, 8+1);

				for (int j = 0; j < i + 1; j++)
				{
					if (UserTypesIntArray[j] == szam)
					{ while (UserTypesIntArray.Contains(szam)) szam = rnd.Next(1, 8+1); }
				}
				UserTypesIntArray[i] = szam;
			}


			//Formázás: a generált számokat vesszővel szeparálom és egy stringet adok vissza
			for (int k = 0; k < NumberOfUserTypes; k++)
			{
				if (Result != string.Empty)
					Result += ",";

				Result += UserTypesIntArray[k];
			}

			return Result;
		}


	}
}
