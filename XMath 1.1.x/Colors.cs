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
using Android.Graphics;

namespace XMath_1._1.x
{
	static public class Colors
	{
		static public Color Correct { get; } = Color.ParseColor("#2ecc71");
		static public Color Wrong { get; } = Color.ParseColor("#e74c3c");

		static public Color timeElapsedCorrectColor { get; } = Color.ParseColor("#27ae60");
		static public Color timeElapsedWrongColor { get; } = Color.ParseColor("#e74c3c");
	}
}