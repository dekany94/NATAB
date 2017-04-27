using System;
using System.Threading.Tasks;
using SQLite;

namespace NATAB
{
	public partial class NATABDatabase
	{
		readonly SQLiteAsyncConnection Database;

		//Adatbázis konstruktor létrehozása
		public NATABDatabase(string dbPath)
		{
			Database = new SQLiteAsyncConnection(dbPath);
			//Osztály alapján táblaséma létrehozása

			//Database.CreateTableAsync<tbl_Users>().Wait();
			Database.CreateTablesAsync<tbl_Users, tbl_Locations>().Wait();
		}

	}
}
