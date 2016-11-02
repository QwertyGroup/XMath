using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Views.InputMethods;
using Android.Views;
using Android.Content;

using System;
using System.Collections.Generic;

// adding some small changes to commit on github
namespace XMath_1._1.x
{
	interface ILayout
	{
		string Operand1 { set; }
		string Sign { set; }
		string Operand2 { set; }
		string Answer { get; set; }
		string Result { set; }
		Color ResultColor { set; }
		string Score { set; }
		void UpdateHistory(List<History> history);
		event EventHandler AnswerEntered;
	}

	[Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/XMathTheme")]
	public class MainActivity : Activity, ILayout
	{
		TextView operand1TextView;
		TextView signTextView;
		TextView operand2TextView;
		EditText answerEditText;
		TextView resultTextView;
		TextView scoreTextView;
		ListView historyListView;
		Master master;

		#region OnCreate
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);
			InitializeElements();
			AddEventHandlers();
			if (master == null)
				master = new Master(this);
		}

		private void InitializeElements()
		{
			operand1TextView = FindViewById<TextView>(Resource.Id.operand1TextView);
			signTextView = FindViewById<TextView>(Resource.Id.signTextView);
			operand2TextView = FindViewById<TextView>(Resource.Id.operand2TextView);
			answerEditText = FindViewById<EditText>(Resource.Id.answerEditText);
			resultTextView = FindViewById<TextView>(Resource.Id.resultTextView);
			scoreTextView = FindViewById<TextView>(Resource.Id.scoreTextView);
			historyListView = FindViewById<ListView>(Resource.Id.historyListView);
		}

		private void AddEventHandlers()
		{
			answerEditText.KeyPress += AnswerEditText_KeyPress;

			historyListView.ItemLongClick += (object sender, AdapterView.ItemLongClickEventArgs e) =>
			{
				FragmentTransaction transaction = FragmentManager.BeginTransaction();
				ElapsedTimeDialog timeDialog = new ElapsedTimeDialog(sender, e, adapter);
				timeDialog.Show(transaction, "dialog fragment");
			};
		}
		#endregion

		#region ILayout
		public string Operand1 { set { operand1TextView.Text = value; } }
		public string Sign { set { signTextView.Text = value; } }
		public string Operand2 { set { operand2TextView.Text = value; } }
		public string Answer { get { return answerEditText.Text; } set { answerEditText.Text = value; } }
		public string Result { set { resultTextView.Text = value; } }
		public Color ResultColor { set { resultTextView.SetTextColor(value); } }
		public string Score { set { scoreTextView.Text = value; } }
		public MainActivity instance { get { return this; } }

		public event EventHandler AnswerEntered;

		private LVAdapter adapter;
		public void UpdateHistory(List<History> historyList)
		{
			adapter = new LVAdapter(this, historyList);
			historyListView.Adapter = adapter;
		}
		#endregion

		#region Events
		private void AnswerEditText_KeyPress(object sender, Android.Views.View.KeyEventArgs e)
		{
			e.Handled = false;
			if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
			{
				AnswerEntered(new object(), EventArgs.Empty);
				InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
				imm.HideSoftInputFromWindow(answerEditText.WindowToken, 0);
				e.Handled = true;
			}
			// == Return focus to answerEditText. Unfortunately it's not working ;(
			answerEditText.RequestFocus();
			answerEditText.ShowSoftInputOnFocus = true;
			//imm.ShowSoftInput(answerEditText, 0);
			// == == == == == == == == == == == == == == == == == == == == == == ==
		}
		#endregion

		#region Saving App
		//private void Load(Bundle bundle)
		//{
		//	if (bundle != null)
		//	{
		//		_counter = bundle.GetInt("click_count", 0);
		//	}
		//}


		//protected override void OnSaveInstanceState(Bundle outState)
		//{
		//	outState.PutInt("master", master);
		//	base.OnSaveInstanceState(outState);
		//}
		#endregion
	}
}
