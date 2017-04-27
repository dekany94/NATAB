using System;
using System.IO;
using NATAB.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace NATAB.iOS
{
	//A Shared Projektben definiált IFileHelper_Dependency Interface implementálása
	//iOS specifikus környezetben
	public class FileHelper : IFileHelper_Dependency
	{
		public string GetLocalFilePath(string filename)
		{
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

			if (!Directory.Exists(libFolder))
			{
				Directory.CreateDirectory(libFolder);
			}

			return Path.Combine(libFolder, filename);
		}
	}
}
