using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMath_v._0._2
{
	class Program
	{
		static void Main()
		{
			Random rnd = new Random();
			int score = 0;

			for (int i = 0; true; i++)
			{
				Console.WriteLine("Score: {0}/{1}; Enter -1 to exit.", score, i);
				int a = rnd.Next(500);
				int b = rnd.Next(500);
				int res = 0;

				if (rnd.Next(2) % 2 == 0)
				{
					res = new Program().Plus(a, b);
				}
				else
				{
					res = new Program().Minus(a, b);
				}

				int ans = 0;

				try
				{
					ans = Convert.ToInt32(Console.ReadLine());
					if (ans == -1) { Environment.Exit(0); }
				}
				catch (Exception)
				{

				}

				if (res == ans)
				{
					score++;
					Console.WriteLine();
					Console.WriteLine("CORRECT :)");
					Console.WriteLine("Press any key!");
				}
				else
				{
					Console.WriteLine();
					Console.WriteLine("SRY :( Correct ans was: {0}.", res);
					Console.WriteLine("Press any key.");
				}
				Console.ReadKey();
				Console.Clear();
			}
		}

		private int Minus(int a, int b)
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

		private int Plus(int a, int b)
		{
			Console.Write("{0} + {1} = ", a, b);
			int res = a + b;
			return res;
		}
	}
}
