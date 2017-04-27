using System;
using System.IO;
using NATAB.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace NATAB.Droid
{
	//A Shared Projektben definiált IFileHelper_Dependency Interface implementálása
	//android specifikus környezetben
	public class FileHelper : IFileHelper_Dependency
	{
		public string GetLocalFilePath(string filename)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return Path.Combine(path, filename);
		}
	}
}
