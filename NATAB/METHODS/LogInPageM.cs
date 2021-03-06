﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NATAB
{
	public partial class LogInPage
	{
		/// <summary>
		/// Is the valid user. - Paraméterben kapott felhasználónév jelszó páros validálása
		/// </summary>
		/// <returns>The valid user.</returns>
		/// <param name="List">List.</param>
		/// <param name="pUserName">P user name.</param>
		/// <param name="pPassword">P password.</param>
		public async Task<bool> IsValidUser(List<tbl_Users> List, string pUserName, string pPassword)
		{
			bool ValidUser = false;
			var s = (from u in List
					 where u.UserName == pUserName &&
					 u.Password == pPassword
					 select u).ToList().Count;

			if (s == 1)
				ValidUser = true;
			
			return ValidUser;
		}
	}
}
