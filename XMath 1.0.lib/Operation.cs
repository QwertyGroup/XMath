using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMath_v._1._0
{
	interface IOperation
	{
		int GetOperationResult(int a, int b);
		void GetOperands(Random rnd, ref int a, ref int b);
		int UpLimit { get; set; }
		int DownLimit { get; set; }
		char Sign { get; }
	}

	abstract class Operation : IOperation
	{
		public int UpLimit { get; set; }
		public int DownLimit { get; set; }
		public char Sign { get; protected set; }

		public Operation()
		{
			UpLimit = 20;
			DownLimit = 1;
		}

		public int GetOperationResult(int a, int b)
		{
			return ProcessOperation(a, b);
		}

		protected void GenerateRandomNumbers(Random rnd, ref int a, ref int b)
		{
			RandomNumbers(rnd, ref a, ref b, DownLimit, UpLimit);
		}

		protected abstract int ProcessOperation(int a, int b);

		protected virtual void RandomNumbers(Random rnd, ref int a, ref int b, int downLimit, int upLimit)
		{
			upLimit += 1 - downLimit;
			a = rnd.Next(upLimit) + downLimit;
			b = rnd.Next(upLimit) + downLimit;
		}

		public void GetOperands(Random rnd, ref int a, ref int b)
		{
			GenerateRandomNumbers(rnd, ref a, ref b);
		}
	}
}
