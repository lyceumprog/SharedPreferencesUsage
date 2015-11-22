
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Mono.Data.Sqlite;

namespace SharedPreferencesUsage
{
	[Activity (Label = "TextActivity")]			
	public class TextActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.TextLayout);

			string dbPath = System.IO.Path.Combine(System.Environment.GetFolderPath
				(System.Environment.SpecialFolder.Personal),"fuel_db.sqlite"
			); // Конечный путь к файлу БД

			var sharedPref = Application.Context.GetSharedPreferences 
				("settings", FileCreationMode.Private); // доступ к файлу настроек

			SqliteConnection connection = new SqliteConnection ("Data source=" + dbPath);
			SqliteCommand command = connection.CreateCommand ();

			connection.Open ();
			command.CommandText = "SELECT text FROM " + 
				sharedPref.GetString ("language", "ru_") + "information"; // Создание запроса в БД на основе выбранного языка
			var reader = command.ExecuteReader ();
			reader.Read ();

			TextView tv = FindViewById<TextView> (Resource.Id.textView1);
			tv.Text = reader [0].ToString ();

			reader.Close ();

			connection.Close ();

			// Create your application here
		}
	}
}

