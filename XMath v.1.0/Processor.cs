using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMath_v._1._0
{
	class Processor
	{
		Random rnd = new Random();
		Stopwatch sw = new Stopwatch();
		IOperation addition = new Addition();
		IOperation subtraction = new Subtraction();
		IOperation multiplication = new Multiplication();
		IOperation division = new Division();
		IMainWindow mainWindow;

		public Processor(MainWindow mainWindow)
		{
			this.mainWindow = mainWindow;
			SetLimits();
			CreateTask();
		}

		private void SetLimits()
		{
			addition.DownLimit = 20;
			addition.UpLimit = 1000;

			subtraction.DownLimit = 20;
			subtraction.UpLimit = 1000;

			multiplication.DownLimit = 2;
			multiplication.UpLimit = 25;

			division.DownLimit = 2;
			division.UpLimit = 25;
		}

		private int attempts;
		private void CreateTask()
		{
			int a = 0, b = 0;
			IOperation operation = RandomOperation();
			operation.GetOperands(rnd, ref a, ref b);
			answer = operation.GetOperationResult(a, b);
			mainWindow.SetTaskTextBoxText($"{a} {operation.Sign} {b} = ");
			mainWindow.UpdateScoreTextBoxText($"{score}:{attempts}");
			sw.Start();
		}

		private int score;
		private int answer;
		public void CheckAnswer()
		{
			sw.Stop();
			if (answer == mainWindow.GetAnswerTextBoxText())
			{
				mainWindow.SetResultTextBoxText(true, string.Empty);
				score++;
			}
			else
			{
				mainWindow.SetResultTextBoxText(false, $", {answer}");
			}
			attempts++;
			mainWindow.HistoryAdd(answer,sw);
			sw.Reset();
			CreateTask();
		}

		private IOperation RandomOperation()
		{
			switch (rnd.Next(4))
			{
				case 0: return addition;
				case 1: return subtraction;
				case 2: return multiplication;
				case 3: return division;
				default: return null;
			}
		}
	}
}
