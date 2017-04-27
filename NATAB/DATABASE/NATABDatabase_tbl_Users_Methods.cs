using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace NATAB
{
	public partial class NATABDatabase
	{
		/// <summary>
		/// Gets all tbl users async. - Összes felhasználó lekérése
		/// </summary>
		/// <returns>The all tbl users async.</returns>
		public Task<List<tbl_Users>> Get_All_tbl_Users_Async()
		{
			return Database.Table<tbl_Users>().ToListAsync();
		}

		/// <summary>
		/// Gets the item tbl users async. - Egy User lekérése id alapján
		/// </summary>
		/// <returns>The item tbl users async.</returns>
		/// <param name="pUserId">P user identifier.</param>
		public Task<tbl_Users> Get_Item_tbl_Users_Async(int pUserId)
		{
			return Database.Table<tbl_Users>().Where(i => i.UserId == pUserId).FirstOrDefaultAsync();
		}

		public Task<tbl_Users> Login_Users_Async(string pUserName, string pPassword)
		{
			return Database.Table<tbl_Users>().Where((i => i.UserName == pUserName && i.Password == pPassword)).FirstOrDefaultAsync();
		}

		//public Task<List<tbl_Users>> Get_Filtered_Item_tbl_Users_Async(cl_FilterUsers pFilter)
		//{
		//	return Database.Table<tbl_Users>().ToListAsync();
		//}


		/// <summary>
		/// Saves the item tbl users async. - Update & Insert depend on UserId
		/// </summary>
		/// <returns>The item tbl users async.</returns>
		/// <param name="item">Item.</param>
		public Task<int> Save_Item_tbl_Users_Async(tbl_Users item)
		{
			//ha nem nulla a UserId, ebben az esetben meglévő rekord, Update kell!
			if (item.UserId != 0)
			{
				return Database.UpdateAsync(item);
			}
			//Ha nulla a UserId akkor pedig Insert kell!
			else
			{
				return Database.InsertAsync(item);
			}
		}

		/// <summary>
		/// Saves the list tbl users async. - Több rekord mentése, paramétere lista
		/// </summary>
		/// <returns>The list tbl users async.</returns>
		/// <param name="pUsersList">P users list.</param>
		public Task<int> Save_List_tbl_Users_Async(List<tbl_Users> pUsersList)
		{
			return Database.InsertAllAsync(pUsersList);
		}

		/// <summary>
		/// Gets the max user identifier async. - Maximális UserId lekérdezése
		/// </summary>
		/// <returns>The max user identifier async.</returns>
		public int Get_Max_UserId_Async()
		{
			Task<tbl_Users> s = Database.Table<tbl_Users>().OrderByDescending(x => x.UserId).FirstOrDefaultAsync();

			return s.Result.UserId;
		}

		/// <summary>
		/// Deletes the item tbl users async. - User item törlése
		/// </summary>
		/// <returns>The item tbl users async.</returns>
		/// <param name="item">Item.</param>
		public Task<int> Delete_Item_tbl_Users_Async(tbl_Users item)
		{
			return Database.DeleteAsync(item);
		}
	}
}
