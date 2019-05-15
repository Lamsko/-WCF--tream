using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WCF4
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
	[ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple)]
	public class MojSerwis : ISerwis
	{
		public void Funkcja1(String s1)
		{
			Console.WriteLine("...{0}: funkcja1 - start", s1);
			Thread.Sleep(3000);
			Console.WriteLine("...{0}: funkcja1 - stop", s1);
		}

		public void Funkcja2(string s2)
		{
			Console.WriteLine("...{0}: funkcja2 - start", s2);
			Thread.Sleep(3000);
			Console.WriteLine("...{0}: funkcja2 - stop", s2);
		}
	}
}
