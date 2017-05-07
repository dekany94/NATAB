using System;
using System.Collections.Generic;
using Newtonsoft;
using Newtonsoft.Json;

namespace NATAB
{
	public class Deserialize_From_JsonString
	{

		//public JsonClass jsonClass;
		public JsonClass.RootObject rootObject;

		public Deserialize_From_JsonString(string JSONString)
		{
			if (JSONString != string.Empty)
			{
				//Kapott string deserializálása, rootobject feltöltése
				rootObject = JsonConvert.DeserializeObject<JsonClass.RootObject>(JSONString);
			}
		}

		//Az inicializált adattag lekérdezésére szolgáló függvény, ha a feltöltés sikertelen volt null-al tér vissza!
		public JsonClass.RootObject Get_Deserialized_Object()
		{
			return (rootObject != null) ? rootObject : null;
		}
	}
}
