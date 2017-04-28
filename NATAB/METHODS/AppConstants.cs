using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace NATAB
{
	public static class AppConstants
	{
		////UserTypes - Felhasználói típúsok
		//Dictionary<string, int> UserTypes = new Dictionary<string, int>()
		//{
		//	{"swAltIsm", 1}, 						//"Általános ismerkedés"}, 			//General meeting
		//	{"swRandi", 2},							//"Randi"}, 						//Dating
		//	{"swBaratkozas", 3}, 					//"Barátkozás"}, 					//Social friend
		//	{"swSzabadidosPartner", 4},				//"Szabadidős partner"},			//Freetime partner
		//	{"swKirandulas", 5}, 					//"Kirándulás/Szabadtéri"},			//Outgoing/Trip
		//	{"swSport", 6}, 						//"Sport"},							//Sport
		//	{"swExtrem", 7}, 						//"Extrém tevékenység"},			//Extreme activity
		//	{"swFelfedez", 8}						//"Felfedezés, kaland, új helyek"},	//Discover city/new places
		//};

		public enum UserTypes : int
		{
			swAltIsm = 1,
			swRandi = 2,
			swBaratkozas = 3,
			swSzabadidosPartner = 4,
			swKirandulas = 5,
			swSport = 6,
			swExtrem = 7,
			swFelfedez = 8
		}


		public static string iUserTypeId(UserTypes pUserTypeId)
		{
			int rId = 0;
			switch (pUserTypeId)
			{
				case UserTypes.swAltIsm: rId = 1; break;
				case UserTypes.swRandi: rId = 2; break;
				case UserTypes.swBaratkozas: rId = 3; break;
				case UserTypes.swSzabadidosPartner: rId = 4; break;
				case UserTypes.swKirandulas: rId = 5; break;
				case UserTypes.swSport: rId = 6; break;
				case UserTypes.swExtrem: rId = 7; break;
				case UserTypes.swFelfedez: rId = 8; break;
			}

			return rId.ToString();
		}

		public static UserTypes sUserTypeId(int pUserTypeId)
		{
			UserTypes rId = 0;
			switch (pUserTypeId)
			{
				case 1: rId = UserTypes.swAltIsm; break;
				case 2: rId = UserTypes.swRandi; break;
				case 3: rId = UserTypes.swBaratkozas; break;
				case 4: rId = UserTypes.swSzabadidosPartner; break;
				case 5: rId = UserTypes.swKirandulas; break;
				case 6: rId = UserTypes.swSport; break;
				case 7: rId = UserTypes.swExtrem; break;
				case 8: rId = UserTypes.swFelfedez; break;
			}

			return rId;
		}


		public static Dictionary<string, int> dCultures = new Dictionary<string, int>
		{
			{"Albania" , 1},
			{"Algeria" , 2},
			{"Argentina" , 3},
			{"Armenia" , 4},
			{"Australia" , 5},
			{"Austria" , 6},
			{"Azerbaijan" , 7},
			{"Bahrain" , 8},
			{"Bangladesh" , 9},
			{"Belarus" , 10},
			{"Belgium" , 11},
			{"Belize" , 12},
			{"Bolivia" , 13},
			{"Bosnia and Herzegovina" , 14},
			{"Brazil" , 15},
			{"Bulgaria" , 16},
			{"Cambodia" , 17},
			{"Canada" , 18},
			{"Chile" , 19},
			{"China" , 20},
			{"Colombia" , 21},
			{"Costa Rica" , 22},
			{"Croatia" , 23},
			{"Czech Republic" , 24},
			{"Denmark" , 25},
			{"Dominican Republic" , 26},
			{"Ecuador" , 27},
			{"Egypt" , 28},
			{"El Salvador" , 29},
			{"Estonia" , 30},
			{"Ethiopia" , 31},
			{"Faroe Islands" , 32},
			{"Finland" , 33},
			{"France" , 34},
			{"Georgia" , 35},
			{"Germany" , 36},
			{"Greece" , 37},
			{"Greenland" , 38},
			{"Guatemala" , 39},
			{"Honduras" , 40},
			{"Hong Kong SAR China" , 41},
			{"Hungary" , 42},
			{"Iceland" , 43},
			{"India" , 44},
			{"Indonesia" , 45},
			{"Iran" , 46},
			{"Iraq" , 47},
			{"Ireland" , 48},
			{"Israel" , 49},
			{"Italy" , 50},
			{"Jamaica" , 51},
			{"Japan" , 52},
			{"Jordan" , 53},
			{"Kenya" , 54},
			{"Kuwait" , 55},
			{"Laos" , 56},
			{"Latvia" , 57},
			{"Lebanon" , 58},
			{"Libya" , 59},
			{"Liechtenstein" , 60},
			{"Lithuania" , 61},
			{"Luxembourg" , 62},
			{"Macau SAR China" , 63},
			{"Macedonia" , 64},
			{"Malta" , 65},
			{"Mexico" , 66},
			{"Monaco" , 67},
			{"Montenegro" , 68},
			{"Morocco" , 69},
			{"Nepal" , 70},
			{"Netherlands" , 71},
			{"New Zealand" , 72},
			{"Nicaragua" , 73},
			{"Nigeria" , 74},
			{"Norway" , 75},
			{"Oman" , 76},
			{"Pakistan" , 77},
			{"Panama" , 78},
			{"Paraguay" , 79},
			{"Peru" , 80},
			{"Philippines" , 81},
			{"Poland" , 82},
			{"Portugal" , 83},
			{"Puerto Rico" , 84},
			{"Qatar" , 85},
			{"Romania" , 86},
			{"Russia" , 87},
			{"Rwanda" , 88},
			{"Saudi Arabia" , 89},
			{"Serbia" , 90},
			{"Singapore" , 91},
			{"Slovakia" , 92},
			{"Slovenia" , 93},
			{"South Africa" , 94},
			{"South Korea" , 95},
			{"Spain" , 96},
			{"Sri Lanka" , 97},
			{"Sweden" , 98},
			{"Switzerland" , 99},
			{"Syria" , 100},
			{"Taiwan" , 101},
			{"Tajikistan" , 102},
			{"Thailand" , 103},
			{"Trinidad and Tobago" , 104},
			{"Tunisia" , 105},
			{"Turkey" , 106},
			{"Ukraine" , 107},
			{"United Arab Emirates" , 108},
			{"United Kingdom" , 109},
			{"United States" , 110},
			{"Uruguay" , 111},
			{"Uzbekistan" , 112},
			{"Venezuela" , 113},
			{"Vietnam" , 114},
			{"Yemen" , 115},
			{"Zimbabwe" , 116}
		};

		#region App Functions

		/// <summary>
		/// Dates the time SQL ite. Reference: http://techreadme.blogspot.hu/2012/11/sqlite-read-write-datetime-values-using.html
		/// </summary>
		/// <returns>The time SQL ite.</returns>
		/// <param name="datetime">Datetime.</param>
		public static string DateTimeSQLite(DateTime datetime)
		{
			string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}.{6}";
			return String.Format(dateTimeFormat,
			                     datetime.Year, 
			                     datetime.Month,
			                     datetime.Day,
			                     datetime.Hour,
			                     datetime.Minute,
			                     datetime.Second,
			                     datetime.Millisecond);
		}

		#endregion

		#region Load Metódusok

		/// <summary>
		/// Loads the picker. - Pickerek feltöltése -  Két paramétere van: pPicker -> A picker amit fel akarunk tölteni, pPickerType -> Picker típúsa
		/// </summary>
		/// <param name="pPicker">Define the picker which want to load</param>
		/// <param name="pPickerType">Define the picker type in string</param>
		public static void Load_Picker(Picker pPicker, string pPickerType)
		{

			switch (pPickerType)
			{
				case "Nationality" :
				{
					//A Nemzetiségek Picker feltöltése a dCultures Dictionary-ből
					//Amikor dictionary-n akarunk végig iterálni akkor az item visszatérési típusa KeyValuePair
					foreach (KeyValuePair<string, int> item in AppConstants.dCultures )
			        {
						pPicker.Items.Add(item.Key);
			        }
					break;	
				}

				case "Age" :
				{
					//A kor Picker itemek feltöltése 
					for (int i = 18; i< 100; i++)
					{
						pPicker.Items.Add(i.ToString());
					}
					break;
				}
				default:
					break;
			}
		}//End load picker


		/// <summary>
		/// Gendres to string. - Extension method - Convert Gendre int to string value
		/// </summary>
		/// <returns>The to string.</returns>
		/// <param name="pGendre">P gendre.</param>
		public static string GendreToString(this int pGendre)
		{
			return (pGendre == 0) ? "Férfi" : "Nő";
		}

		/// <summary>
		/// Customs the date time formate. - Extension method - Customize the datetime format
		/// </summary>
		/// <returns>The date time formate.</returns>
		/// <param name="pDateTime">P date time.</param>
		public static string CustomDateTimeFormate(this string pDateTime)
		{
			string FormattedDateTime = string.Empty;
			DateTime DateTime = DateTime.Parse(pDateTime);

			CultureInfo hu = new CultureInfo("hu-HU");
			DateTimeFormatInfo huDateTimeFormatInfo = hu.DateTimeFormat;

			FormattedDateTime = String.Format("Év: {0} Hónap: {1}\nNap: {2} Óra: {3}:{4}",
			                                DateTime.Year,
											huDateTimeFormatInfo.MonthNames[DateTime.Month - 1],
											DateTime.Day,
											DateTime.Hour,
											DateTime.Minute);

			return FormattedDateTime;
		}

		/// <summary>
		/// Gets the nationality name by string. - NationalityId alapján visszaadja a hozzá tartozó stringet
		/// </summary>
		/// <returns>The nationality name by string.</returns>
		/// <param name="pNationalityId">P nationality identifier.</param>
		public static string Get_NationalityName_By_Id(int pNationalityId)
		{
			string NationalityName = AppConstants.dCultures.FirstOrDefault(x => x.Value == pNationalityId).Key;

			return NationalityName;
		}
		#endregion





	}	
}
