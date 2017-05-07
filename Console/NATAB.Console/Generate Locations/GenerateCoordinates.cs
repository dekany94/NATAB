using System;
using System.Collections.Generic;
using System.Linq;

namespace NATAB
{


	public class GenerateCoordinates
	{
		private Coordinate[] Calculate(int NumberOfRecord, Coordinate location1, Coordinate location2, Coordinate location3, Coordinate location4)
		{
			Coordinate[] allCoords = { location1, location2, location3, location4 };
			double minLat = allCoords.Min(x => x.Latitude);
			double minLon = allCoords.Min(x => x.Longitude);
			double maxLat = allCoords.Max(x => x.Latitude);
			double maxLon = allCoords.Max(x => x.Longitude);

			Random r = new Random();

			//replase 500 with your number
			Coordinate[] result = new Coordinate[NumberOfRecord];
			for (int i = 0; i < result.Length; i++)
			{
				Coordinate point = new Coordinate();
				do
				{
					point.Latitude = r.NextDouble() * (maxLat - minLat) + minLat;
					point.Longitude = r.NextDouble() * (maxLon - minLon) + minLon;
				} while (!IsPointInPolygon(point, allCoords));
				result[i] = point;
			}
			return result;
		}

		//took it from http://codereview.stackexchange.com/a/108903
		//you can use your own one
		private bool IsPointInPolygon(Coordinate point, Coordinate[] polygon)
		{
			int polygonLength = polygon.Length, i = 0;
			bool inside = false;
			// x, y for tested point.
			double pointX = point.Longitude, pointY = point.Latitude;
			// start / end point for the current polygon segment.
			double startX, startY, endX, endY;
			Coordinate endPoint = polygon[polygonLength - 1];
			endX = endPoint.Longitude;
			endY = endPoint.Latitude;
			while (i < polygonLength)
			{
				startX = endX;
				startY = endY;
				endPoint = polygon[i++];
				endX = endPoint.Longitude;
				endY = endPoint.Latitude;
				//
				inside ^= ((endY > pointY) ^ (startY > pointY)) /* ? pointY inside [startY;endY] segment ? */
						  && /* if so, test if it is under the segment */
						  (pointX - endX < (pointY - endY) * (startX - endX) / (startY - endY));
			}
			return inside;
		}


		//static List<Tuple<Coordinate, Coordinate>> TupleList = new List<Tuple<Coordinate, Coordinate>>();
		static List<Coordinate> List = new List<Coordinate>();
		static EuropePoints EU = new EuropePoints();

		/// <summary>
		/// Generate the specified pNumberOfRecords and pGC. - Koordináta típusú listával tér vissza
		/// </summary>
		/// <returns>The generate.</returns>
		/// <param name="pNumberOfRecords">P number of records.</param>
		/// <param name="pGC">P gc.</param>
		public static List<Coordinate> Generate(int pNumberOfRecords, GenerateCoordinates pGC)
		{
			var generatedCordArray = pGC.Calculate(pNumberOfRecords, EU.TopLeftCoord, EU.TopRightCoord, EU.BottomLeftCoord, EU.BottomRightCoord);

			for (int i = 0; i < generatedCordArray.Length; i++)
			{
				//! Write the generated coordinates
				//Console.WriteLine(
				//	String.Format(
				//		"{0} \t Latitude: {1} \t Longitude: {2}",
				//		i, generatedCordArray[i].Latitude, generatedCordArray[i].Longitude
				//	));

				//!Add them to the List
				List.Add(new Coordinate(generatedCordArray[i].Latitude, generatedCordArray[i].Longitude));
				//TupleList.Add(Tuple.Create(generatedCordArray[i].Latitude, generatedCordArray[i].Longitude));

			}

			return List;
		}



		/// <summary>
		/// Shows the content of the the. - Kiíratást végzi, generáláskor nincs használva
		/// </summary>
		/// <param name="pList">P list.</param>
		public static void Show_the_Content(List<Coordinate> pList)
		{
			Console.WriteLine("***********************Lista tartalma: ************************\n");
			foreach (Coordinate c in pList)
			{
				Console.WriteLine(String.Format("Latitude: {0, -20}Longitude: {1, -15}", c.Latitude, c.Longitude));
			}
			Console.WriteLine("****************************************************************");
		}


	}
}
