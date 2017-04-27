using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NATAB
{
	public partial class MainTabbedPage : TabbedPage
	{
		//cl_FilterUsers osztály példányosítása
		public static cl_FilterUsers cfu = new cl_FilterUsers();
		//Globális osztály deklarálása, inicializálása nullával
		public static List<GlobalClass> GlobalClassList = null;

		//Paraméteres konstruktor - ha a FilterPage-ből történik a példányosítás akkor paraméterben átadom
		//a szűrési értékeket tartalmazó osztályt, és beállítom aktuális oldalnak (a már leszűrt) felhasználók listáját (UserListPage)
		public MainTabbedPage(cl_FilterUsers pFilterClass)
		{
			InitializeComponent();

				//A MainTabbedPage oldal meghívásakor, a paraméterben kapott osztály átadása
				//az osztályon belül definiált példánynak
				cfu = pFilterClass;
	            this.CurrentPage = Children[1];
		}

		//Paraméter nélküli konstruktor
		public MainTabbedPage()
		{
			InitializeComponent();
		}


	}
}
