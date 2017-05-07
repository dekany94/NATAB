using System;
namespace NATAB
{
	public class Coordinate
	{
		//Szélesség, hosszúság tárolására, double típusú adattagok, automatikus Property-k
		public double Latitude { set; get; }
		public double Longitude { set; get; }

		//Paraméteres konstruktor, az adattagok inicializálását végzi
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