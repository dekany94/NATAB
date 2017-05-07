using System;
namespace NATAB
{
	//Teszt
	//decimal latitude = (decimal)47.475025;
	//decimal longitude = (decimal)19.050364;
	public class CallMethods
	{
		
		JsonClass.RootObject roResult;

		/// <summary>
		/// Paraméteres konstruktor, Webrequest segítségével lekéri az adott koordinátához tartozó részletes adatokat.
		/// Json string -el tér vissza
		/// </summary>
		/// <param name="pLatitude">P latitude.</param>
		/// <param name="pLongitude">P longitude.</param>
		public CallMethods(double pLatitude, double pLongitude)
		{

			GetJsonRequest req = new GetJsonRequest(pLatitude, pLongitude);

			string JsonString = req.Get_Json_From_Server_Request();

			//A kapott string deserializálása
			Deserialize_From_JsonString RootObject = new Deserialize_From_JsonString(JsonString);

			roResult = RootObject.Get_Deserialized_Object();
		}

		public JsonClass.RootObject Get_Root_Object()
		{
			return roResult;
		}

	}
}
