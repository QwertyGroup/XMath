using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v._0._3
{
	static class X // XMath Logic
	{
		static public int I { get; internal set; }
		static public int Score { get; internal set; }
		static public int A { get; internal set; }
		static public int B { get; internal set; }
		static public int Res { get; internal set; }
		static public int Ans { get; internal set; }


		static public void Rise()
		{
			for (I = 0; true; I++)
			{
				C.Score();

				A = new Random().Next(500);
				B = new Random().Next(500);

				if (new Random().Next(2) % 2 == 0)
				{
					Res = Plus(A, B);
				}
				else
				{
					//Res = Minus(A, B);
				}

				C.LoopEnd();
			}
		}

		static private int Plus(int a, int b)
		{
			//Console.Write("{0} + {1} = ", a, b);
			int res = a + b;
			return res;
		}

		static private int Minus(int a, int b)
		{
			int res = 0;
			if (a >= b)
			{
				Console.Write("{0} - {1} = ", a, b);
				res = a - b;
			}
			else
			{
				Console.Write("{1} - {0} = ", a, b);
				res = b - a;
			}
			return res;
		}
	}
}
