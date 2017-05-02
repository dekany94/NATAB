using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using System.Linq;

namespace NATAB
{
	public partial class MapPage : ContentPage
	{
		public MapPage()
		{
			InitializeComponent();
		}


		protected override void OnAppearing()
		{
			base.OnAppearing();


			//Map Declaration
			var map = new Map(
				MapSpan.FromCenterAndRadius(
						new Position(49.1961, 16.6040), Distance.FromMiles(200)))
			{
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};








			//Pin definitions - Pinek elhelyezése a térképen
			if (MainTabbedPage.GlobalClassList != null)
			{
				foreach (GlobalClass item in MainTabbedPage.GlobalClassList)
				{
					// Pin Declaration
					var position = new Position(item.Latitude, item.Longitude); // Latitude, Longitude
					var pin = new Pin
					{
						Type = PinType.Place,
						Position = position,
						Label = String.Format("{0} - {1} éves, ({2})",item.FullName, item.Age, AppConstants.GendreToString(item.Gendre)),  
						Address = item.FormattedAddress
					};

					map.Pins.Add(pin);
				}

				var stack = new StackLayout { Spacing = 0 };
				stack.Children.Add(map);
				Content = stack;
			}

		}








	}
}
