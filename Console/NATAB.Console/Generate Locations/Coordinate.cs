using System;
namespace NATAB
{
	public class Coordinate
	{
		public double Latitude { set; get; }
		public double Longitude { set; get; }

		public Coordinate(double Latitude, double Longitude)
		{
			this.Latitude = Latitude;
			this.Longitude = Longitude;
		}

		public Coordinate()
		{

		}
	}
}