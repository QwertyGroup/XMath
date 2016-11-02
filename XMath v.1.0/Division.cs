using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMath_v._1._0
{
	class Division : Operation
	{
		public Division()
		{
			Sign = '÷';
		}

		protected override int ProcessOperation(int a, int b)
		{
			return a / b;
		}

		protected override void RandomNumbers(Random rnd, ref int a, ref int b, int downLimit, int upLimit)
		{
			upLimit += 1 - downLimit;
			a = rnd.Next(upLimit) + downLimit;
			b = rnd.Next(upLimit) + downLimit;
			a = a * b;
		}
	}
}
