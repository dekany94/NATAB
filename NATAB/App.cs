using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using System.Globalization;

using Xamarin.Forms.Maps;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NATAB
{
	public partial class App : Application
	{
		static NATABDatabase database;

		public static NATABDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new NATABDatabase(DependencyService.Get<IFileHelper_Dependency>().GetLocalFilePath("NATABSQLite.db3"));
				}
				return database;
			}
		}

		//public static NavigationPage Set_NavBar(ContentPage pContentPage)
		public static void Set_NavBar(ContentPage pContentPage)
		{
			var nav = new NavigationPage(pContentPage);
			nav.BarBackgroundColor = Color.FromHex("2b9ed8");
			nav.BarTextColor = Color.White;

			//return nav;
			App.Current.MainPage = nav;
		}

		//public static NavigationPage Set_NavBar(TabbedPage pTabbedPage)
		public static void Set_NavBar(TabbedPage pTabbedPage)
		{
			var nav = new NavigationPage(pTabbedPage);
			nav.BarBackgroundColor = Color.FromHex("2b9ed8");
			nav.BarTextColor = Color.White;

			//return nav;
			App.Current.MainPage = nav;
		}



		public App()
		{
			//Kezdő oldal létrehozása (WelcomePage)
			//MainPage = Set_NavBar(new WelcomePage());
			Set_NavBar(new WelcomePage());
		}



		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
