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
	class LVAdapter : BaseAdapter<History>
	{
		private List<History> items;
		private Context context;

		public LVAdapter(Context context, List<History> items)
		{
			this.context = context;
			this.items = items;
		}

		public override int Count
		{
			get { return items.Count; }
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override History this[int position]
		{
			get { return items[position]; }
		}


		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View row = convertView;

			if (row == null)
			{
				row = LayoutInflater.From(context).Inflate(Resource.Layout.ListView_row, null, false);
			}

			TextView numberTextView = row.FindViewById<TextView>(Resource.Id.numberTextView);
			TextView eventTextView = row.FindViewById<TextView>(Resource.Id.eventTextView);

			//numberTextView.Text = $"{items[position].No}. ";
			numberTextView.Text = string.Empty;
			if (items[position].CorrectAnswer == items[position].UserAnswer)
			{
				eventTextView.Text = $"{items[position].Operand1} {items[position].Sign} {items[position].Operand2} = {items[position].CorrectAnswer}";
				eventTextView.SetTextColor(Colors.Correct);
			}
			else
			{
				eventTextView.Text = $"{items[position].Operand1} {items[position].Sign} {items[position].Operand2} = {items[position].UserAnswer}";
				eventTextView.SetTextColor(Colors.Wrong);
			}

			return row;
		}
	}
}