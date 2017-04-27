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
				rootObject = JsonConvert.DeserializeObject<JsonClass.RootObject>(JSONString);
			}
		}

		public JsonClass.RootObject Get_Deserialized_Object()
		{
			return (rootObject != null) ? rootObject : null;
		}
	}
}
