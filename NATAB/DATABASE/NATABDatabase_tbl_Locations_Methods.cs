using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NATAB
{
	public partial class NATABDatabase
	{
		/// <summary>
		/// Gets all tbl locations async. - Összes Location lekérése 
		/// </summary>
		/// <returns>The all tbl locations async.</returns>
		public Task<List<tbl_Locations>> Get_All_tbl_Locations_Async()
		{
			return Database.Table<tbl_Locations>().ToListAsync();
		}

		/// <summary>
		/// Gets the item tbl locations async. - Egy Location lekérése Id alapján
		/// </summary>
		/// <returns>The item tbl locations async.</returns>
		/// <param name="pUserId">P user identifier.</param>
		public Task<tbl_Locations> Get_Item_tbl_Locations_Async(int pUserId)
		{
			return Database.Table<tbl_Locations>().Where(i => i.LocationId == pUserId).FirstOrDefaultAsync();
		}

		/// <summary>
		/// Saves the item tbl Location async. - Update & Insert depend on LocationId
		/// </summary>
		/// <returns>The item tbl Location async.</returns>
		/// <param name="item">Item.</param>
		public Task<int> Save_Item_tbl_Locations_Async(tbl_Locations item)
		{
			//ha nem nulla a UserId, ebben az esetben meglévő rekord, Update kell!
			if (item.LocationId != 0)
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
		/// Saves the list tbl locations async. - Több rekord mentése, paramétere tbl_Location típusú lista
		/// </summary>
		/// <returns>The list tbl locations async.</returns>
		/// <param name="pLocationsList">P locations list.</param>
		public Task<int> Save_List_tbl_Locations_Async(List<tbl_Locations> pLocationsList)
		{
			return Database.InsertAllAsync(pLocationsList);		
		}

		/// <summary>
		/// Deletes the item tbl users async. - Location törlése
		/// </summary>
		/// <returns>The item tbl users async.</returns>
		/// <param name="item">Item.</param>
		public Task<int> Delete_Item_tbl_Users_Async(tbl_Locations item)
		{
			return Database.DeleteAsync(item);
		}
	}
}
