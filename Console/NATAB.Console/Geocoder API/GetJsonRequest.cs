using System;
using System.IO;
using System.Net;
using System.Text;

namespace NATAB
{
	public class GetJsonRequest
	{
		double latitude;
		double longitude;

		public GetJsonRequest(double lat, double lng)
		{
			this.latitude = lat;
			this.longitude = lng;
		}

		public string Get_Json_From_Server_Request()
		{

			string APIKey = "AIzaSyCrI37okwtB10wFb_RkZqOAkVAlBWyHlqw";
			//https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=YOUR_API_KEY

			//https://maps.googleapis.com/maps/api/geocode/json?latlng=46.9061800,19.6912800&sensor=true&key=AIzaSyCrI37okwtB10wFb_RkZqOAkVAlBWyHlqw
			String URL = string.Format("https://maps.googleapis.com/maps/api/geocode/json?latlng={0},{1}&sensor=true&key={2}",
									   latitude, longitude, APIKey);
			// Create a request for the URL.   
			WebRequest request = WebRequest.Create(URL);
			// If required by the server, set the credentials.  
			request.Credentials = CredentialCache.DefaultCredentials;
			// Get the response.  
			WebResponse response = request.GetResponse();
			// Display the status.  
			//Console.WriteLine(((HttpWebResponse)response).StatusDescription);
			// Get the stream containing content returned by the server.  
			Stream dataStream = response.GetResponseStream();
			// Open the stream using a StreamReader for easy access.  
			StreamReader reader = new StreamReader(dataStream);
			// Read the content.  
			string responseFromServer = reader.ReadToEnd();
			// Display the content.  
			//Console.WriteLine(responseFromServer);
			// Clean up the streams and the response.  
			reader.Close();
			response.Close();

			return responseFromServer;
		}
	}
}
