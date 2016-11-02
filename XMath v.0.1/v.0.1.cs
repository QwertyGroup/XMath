using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMath_v._0._1
{
	class Program
	{
		static void Main()
		{
			Random rnd = new Random();
			int score = 0;

			for (int i = 0; i < 10; i++)
			{
				int a = rnd.Next(500);
				int b = rnd.Next(500);
				int res = a + b;
				Console.WriteLine("{0}/{1}", score, i);
				Console.Write("{0} + {1} = ", a, b);
				int ans = 0;

				try
				{
					ans = Convert.ToInt32(Console.ReadLine());
				}
				catch (Exception)
				{

				}

				if (res == ans)
				{
					Console.WriteLine("CORRECT! :)");
					score++;
				}
				else
				{
					Console.WriteLine("SRY :(");
				}
				Console.ReadKey();
				Console.Clear();
			}
		}
	}
}
