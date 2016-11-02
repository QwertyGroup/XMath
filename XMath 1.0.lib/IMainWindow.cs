using System.Diagnostics;

namespace XMath_1._0.lib
{
	interface IMainWindow
	{
		void SetTaskTextBoxText(string operation);
		int GetAnswerTextBoxText();
		void SetResultTextBoxText(bool res, string s);
		void UpdateScoreTextBoxText(string score);
		void HistoryAdd(int correctAnswer, Stopwatch sw);
	}

}
