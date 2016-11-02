using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMath_v._1._0
{
	class Addition : Operation
	{
		public Addition()
		{
			Sign = '+';
		}

		protected override int ProcessOperation(int a, int b)
		{
			return a + b;
		}
	}
}
