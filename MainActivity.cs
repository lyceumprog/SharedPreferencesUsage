using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SharedPreferencesUsage
{
	[Activity (Label = "SharedPreferencesUsage", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			new DatabaseCopy (this);
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it

			Button rus = FindViewById<Button> (Resource.Id.button1); // Кнопка изменения языка на русский
			Button tat = FindViewById<Button> (Resource.Id.button2); // Кнопка изменения языка на татарский
			Button eng = FindViewById<Button> (Resource.Id.button3); // Кнопка изменения языка на английский

			var sharedPref = Application.Context.GetSharedPreferences 
				("settings", FileCreationMode.Private); // СОздание файла настроек
			var prefEdit = sharedPref.Edit (); // Получение доступа к редактированию этого файла

			rus.Click += delegate { 
				prefEdit.PutString("language","ru_"); // изменение переменной language
				prefEdit.Apply(); // Сохранение изменений
			};

			tat.Click += delegate {
				prefEdit.PutString("language","tat_");
				prefEdit.Apply();
			};

			eng.Click += delegate {
				prefEdit.PutString("language","eng_");
				prefEdit.Apply();
			};

			Button next = FindViewById<Button> (Resource.Id.button4);

			next.Click += delegate {
				StartActivity(typeof(TextActivity));
			};

		}
	}
}


