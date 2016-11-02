using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XMath_v._1._0
{
	public class Colors
	{
		public string CorrectBorderBrush { set; get; }
		public string CorrectForeground { set; get; }
		public string ErrorBorderBrush { set; get; }
		public string ErrorForeground { set; get; }

		public Colors()
		{
			CorrectBorderBrush = "#C7F464";
			CorrectForeground = "#C7F464";
			ErrorBorderBrush = "#FF6B6B";
			ErrorForeground = "#FF6B6B";
		}
	}

	interface IMainWindow
	{
		void SetTaskTextBoxText(string operation);
		int GetAnswerTextBoxText();
		void SetResultTextBoxText(bool res, string s);
		void UpdateScoreTextBoxText(string score);
		void HistoryAdd(int correctAnswer, Stopwatch sw);
	}

	public partial class MainWindow : Window, IMainWindow
	{
		Processor processor;
		Colors colors = new Colors();
		public MainWindow()
		{
			InitializeComponent();
			processor = new Processor(this);
		}

		public void SetTaskTextBoxText(string operation)
		{
			taskTextBox.Text = operation;
		}

		public int GetAnswerTextBoxText()
		{
			return (Regex.IsMatch(answerTextBox.Text, @"\d+") && answerTextBox.Text.Length < 10) ? Convert.ToInt32(answerTextBox.Text) : 0;
		}

		public void SetResultTextBoxText(bool res, string s)
		{
			if (res)
			{
				resultTextBox.Text = $"Correct{s}";
				resultTextBox.BorderBrush = (Brush)new BrushConverter().ConvertFrom(colors.CorrectBorderBrush);
				resultTextBox.Foreground = (Brush)new BrushConverter().ConvertFrom(colors.CorrectForeground);
			}
			else
			{
				resultTextBox.Text = $"Wrong{s}";
				resultTextBox.BorderBrush = (Brush)new BrushConverter().ConvertFrom(colors.ErrorBorderBrush);
				resultTextBox.Foreground = (Brush)new BrushConverter().ConvertFrom(colors.ErrorForeground);
			}
		}

		private void answerTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				processor.CheckAnswer();
				(sender as TextBox).Text = string.Empty;
			}
		}

		public void UpdateScoreTextBoxText(string score)
		{
			scoreTextBox.Text = score;
		}

		public void HistoryAdd(int correctAnswer, Stopwatch sw)
		{
			TextBox historyTextBox = new TextBox();
			historyTextBox.Background = taskTextBox.Background;
			historyTextBox.Foreground = taskTextBox.Foreground;
			historyTextBox.BorderBrush = taskTextBox.BorderBrush;
			historyTextBox.Height = taskTextBox.Height;
			historyTextBox.Width = taskTextBox.Width * 2;
			historyTextBox.HorizontalContentAlignment = taskTextBox.HorizontalContentAlignment;
			historyTextBox.VerticalContentAlignment = taskTextBox.VerticalContentAlignment;
			historyTextBox.FontFamily = taskTextBox.FontFamily;
			historyTextBox.FontSize = taskTextBox.FontSize;
			historyTextBox.Margin = new Thickness(5, 5, 5, 5);
			historyTextBox.IsReadOnly = true;
			historyTextBox.SelectionBrush = taskTextBox.SelectionBrush;

			if (Regex.IsMatch(answerTextBox.Text, @"\d+"))
				if (Convert.ToInt32(answerTextBox.Text) == correctAnswer)
				{
					historyTextBox.Text = $"{taskTextBox.Text}{answerTextBox.Text} (time: {sw.ElapsedMilliseconds / 1000} s)";
					historyTextBox.BorderBrush = (Brush)new BrushConverter().ConvertFrom(colors.CorrectBorderBrush);
					historyTextBox.Foreground = (Brush)new BrushConverter().ConvertFrom(colors.CorrectForeground);
				}
				else
				{
					historyTextBox.Text = $"{taskTextBox.Text}{answerTextBox.Text} (correct: {correctAnswer})";
					historyTextBox.BorderBrush = (Brush)new BrushConverter().ConvertFrom(colors.ErrorBorderBrush);
					historyTextBox.Foreground = (Brush)new BrushConverter().ConvertFrom(colors.ErrorForeground);
				}

			if (Regex.IsMatch(answerTextBox.Text, @"\d+"))
				historyListBox.Items.Insert(0, historyTextBox);
		}
	}
}
