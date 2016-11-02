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

namespace XMath_1._1.x
{
	public class History
	{
		public int Operand1 { get; set; }
		public int Operand2 { get; set; }
		public char Sign { get; set; }
		public int UserAnswer { get; set; }
		public int CorrectAnswer { get; set; }
		public int No { get; set; }
		public long SecondsElapsed { get; set; }
	}

}