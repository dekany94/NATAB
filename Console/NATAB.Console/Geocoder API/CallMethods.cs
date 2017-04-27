using System;
namespace NATAB
{
	//Teszt
	//decimal latitude = (decimal)47.475025;
	//decimal longitude = (decimal)19.050364;
	public class CallMethods
	{
		JsonClass.RootObject roResult;

		public CallMethods(double pLatitude, double pLongitude)
		{

			GetJsonRequest req = new GetJsonRequest(pLatitude, pLongitude);

			string JsonString = req.Get_Json_From_Server_Request();

			Deserialize_From_JsonString RootObject = new Deserialize_From_JsonString(JsonString);

			roResult = RootObject.Get_Deserialized_Object();
		}

		public JsonClass.RootObject Get_Root_Object()
		{
			return roResult;
		}

	}
}
