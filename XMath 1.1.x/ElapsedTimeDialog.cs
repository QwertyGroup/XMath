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
	class ElapsedTimeDialog : DialogFragment
	{
		private AdapterView.ItemLongClickEventArgs e;
		private LVAdapter adapter;
		private TextView timeTextView;
		private TextView correctTextView;
		private TextView elapsedTextView;
		private TextView correctLabelTextView;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);

			var view = inflater.Inflate(Resource.Layout.ElapsedTimeDialog, container, false);

			timeTextView = view.FindViewById<TextView>(Resource.Id.timeTextView);
			elapsedTextView = view.FindViewById<TextView>(Resource.Id.elapsedTextView);
			correctTextView = view.FindViewById<TextView>(Resource.Id.correctTextView);
			correctLabelTextView = view.FindViewById<TextView>(Resource.Id.correctLabelTextView);

			Time();

			return view;
		}

		public ElapsedTimeDialog(object sender, AdapterView.ItemLongClickEventArgs e, LVAdapter adapter)
		{
			this.e = e;
			this.adapter = adapter;
		}

		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
			base.OnActivityCreated(savedInstanceState);
			Dialog.Window.Attributes.WindowAnimations = Resource.Style.TimeDialogAnimation;
		}

		private void Time()
		{
			timeTextView.Text = $"{adapter[e.Position].SecondsElapsed}";
			if (adapter[e.Position].UserAnswer == adapter[e.Position].CorrectAnswer)
			{
				timeTextView.SetTextColor(Colors.timeElapsedCorrectColor);
				timeTextView.SetPadding(10, 20, 3, 20);

				elapsedTextView.SetPadding(5, 20, 30, 20);

				correctLabelTextView.TextSize = 0;
				correctLabelTextView.SetPadding(25, 0, 3, 0);
				correctLabelTextView.Text = string.Empty;

				correctTextView.TextSize = 0;
				correctTextView.SetPadding(3, 0, 10, 0);
				correctTextView.Text = string.Empty;
			}
			else
			{
				timeTextView.SetTextColor(Colors.timeElapsedWrongColor);
				timeTextView.SetPadding(10, 20, 3, 10);

				elapsedTextView.SetPadding(5, 20, 30, 10);

				correctLabelTextView.TextSize = 28;
				correctLabelTextView.SetPadding(20, -15, 3, 25);
				correctLabelTextView.Text = "Correct: ";

				correctTextView.TextSize = 28;
				correctTextView.SetPadding(3, -15, 10, 25);
				correctTextView.Text = $"{adapter[e.Position].CorrectAnswer}";
			}
		}
	}
}