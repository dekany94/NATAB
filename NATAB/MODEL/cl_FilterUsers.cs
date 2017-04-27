using System;
namespace NATAB
{
	public class cl_FilterUsers
	{

		public int? AgeFrom { get; set; }
		public int? AgeTo { get; set; }
		public int? Gendre { get; set; } //0 = Férfi, 1 = Nő
		public string UserTypeIds { get; set; }
		public int? NationalityId { get; set; }


		public cl_FilterUsers()
		{
			this.AgeFrom = null;
			this.AgeTo = null;
			this.Gendre = null;
			this.UserTypeIds = string.Empty;    //"1,2,3,4,5,6,7,8";
			this.NationalityId = null;

		}
	}
}
