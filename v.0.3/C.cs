using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v._0._3
{
	static class C // Console
	{
		static public void Score()
		{
			Console.WriteLine("Score: {0}/{1}; Enter -1 to exit.", X.Score, X.I);
		}

		//	if (x.Res == x.Ans)
		//	{
		//		x.Score++;
		//		Console.WriteLine();
		//		Console.WriteLine("CORRECT :)");
		//		Console.WriteLine("Press any key!");
		//	}
		//	else
		//	{
		//		Console.WriteLine();
		//		Console.WriteLine("SRY :( Correct ans was: {0}.", x.Res);
		//		Console.WriteLine("Press any key.");
		//	}

		static public void LoopEnd()
		{
			Console.ReadKey();
			Console.Clear();
		}
	}
}
