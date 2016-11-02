using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

using XMath_1._1.lib;

namespace XMath_1._1.x
{
	class Master
	{
		Random rnd = new Random();
		Stopwatch sw = new Stopwatch();
		ILayout layout;
		List<IOperation> operations = new List<IOperation>();
		List<History> history = new List<History>();

		int answer;
		int operand1;
		int operand2;
		char sign;
		int correct;
		int total;
		long secondsElapsed;

		#region Startup
		public Master(ILayout layout)
		{
			this.layout = layout;
			AddOperations();
			SetLimits();
			AddEventHandlers();
			CreateTask();
			UpdateTask();
		}

		private void AddOperations()
		{
			operations.Add(new Addition());
			operations.Add(new Subtraction());
			operations.Add(new Multiplication());
			operations.Add(new Division());
		}

		private void SetLimits()
		{
			IOperation operation = operations[0]; // Addition
			operation.DownLimit = 20;
			operation.UpLimit = 1000;

			operation = operations[1]; // Subtraction
			operation.DownLimit = 20;
			operation.UpLimit = 1000;

			operation = operations[2]; // Multiplication
			operation.DownLimit = 2;
			operation.UpLimit = 25;

			operation = operations[3]; // Division
			operation.DownLimit = 2;
			operation.UpLimit = 25;
		}

		private void AddEventHandlers()
		{
			layout.AnswerEntered += Layout_AnswerEntered;
		}
		#endregion

		#region Task Creation
		private void CreateTask()
		{
			IOperation operation = RandomOperation();
			operation.GetOperands(rnd, ref operand1, ref operand2);
			answer = operation.GetOperationResult(operand1, operand2);
			sign = operation.Sign;
			sw.Start();
		}

		private IOperation RandomOperation()
		{
			return operations[rnd.Next(operations.Count)];
		}
		#endregion

		#region Answer Checking
		private void CheckAnswer()
		{
			int answer = 0;
			bool result = false;
			if (!int.TryParse(layout.Answer, out answer)) return;
			sw.Stop();
			secondsElapsed = sw.ElapsedMilliseconds / 1000;
			total++;
			if (answer == this.answer)
			{
				result = true;
				correct++;
			}
			History tmpHistory = new History
			{
				Operand1 = operand1,
				Operand2 = operand2,
				Sign = sign,
				UserAnswer = answer,
				CorrectAnswer = this.answer,
				No = total,
				SecondsElapsed = secondsElapsed
			};
			sw.Reset();
			history.Insert(0, tmpHistory);
			UpdateResult(result);
			UpdateScore();
			UpdateHistory();
			CreateTask();
			UpdateTask();
		}
		#endregion

		#region UI
		private void UpdateTask()
		{
			layout.Operand1 = $"{operand1}";
			layout.Sign = $"{sign}";
			layout.Operand2 = $"{operand2}";
		}

		private void UpdateResult(bool result)
		{
			if (result)
			{
				layout.Result = $"Correct (Elapsed: {secondsElapsed} sec)";
				layout.ResultColor = Colors.Correct;
			}
			else
			{
				layout.Result = $"Wrong (Correct: {answer})";
				layout.ResultColor = Colors.Wrong;
			}
		}

		private void UpdateScore()
		{
			layout.Score = $"Score {correct}:{total}";
		}

		private void UpdateHistory()
		{
			layout.UpdateHistory(history);
		}

		private void Layout_AnswerEntered(object sender, EventArgs e)
		{
			CheckAnswer();
			layout.Answer = string.Empty;
		}
		#endregion
	}
}