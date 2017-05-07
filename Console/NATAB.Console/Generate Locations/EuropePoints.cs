using System;
namespace NATAB
{
	// 4, országot (koordinátákat) tartalmazó osztály
	public class EuropePoints
	{
		//Hollandia
		public Coordinate _TopLeftCoord = new Coordinate
		{
			Latitude = 52.629552,
			Longitude = 5.930887
		};

		//Szlovénia
		public Coordinate _BottomLeftCoord = new Coordinate
		{
			Latitude = 45.042049,
			Longitude = 15.143738
		};

		//Lengyelország
		public Coordinate _TopRightCoord = new Coordinate
		{
			Latitude = 53.161002,
			Longitude = 19.055167
		};

		//Románia
		public Coordinate _BottomRightCoord = new Coordinate
		{
			Latitude = 45.751060,
			Longitude = 24.091030
		};

		public Coordinate TopLeftCoord
		{
			get { return _TopLeftCoord; }
		}

		public Coordinate TopRightCoord
		{
			get { return _TopRightCoord; }
		}

		public Coordinate BottomLeftCoord
		{
			get { return _BottomLeftCoord; }
		}

		public Coordinate BottomRightCoord
		{
			get { return _BottomRightCoord; }
		}
	}
}
