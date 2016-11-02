using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using _TestClassLibrary_0;

namespace _TestApp_4
{
	[Activity(Label = "_TestApp_4", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);
			var v = new TestClass();
			v.Limit = 10;
			v.Method();
		}
	}
}

