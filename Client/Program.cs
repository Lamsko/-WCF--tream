using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Client.ServiceReference1;
using System.Threading;
using Client.ServiceReference2;

namespace Client
{
	class Program
	{
		static void Main(string[] args)
		{
			SerwisClient client1 = new SerwisClient("WSHttpBinding_ISerwis");
			Console.WriteLine("...wywoluje funkja1:");
			client1.Funkcja1("Klient1");
			Thread.Sleep(10);
			Console.WriteLine("...kontynuacja po funkcji1");
			Console.WriteLine("...wywoluje funkcja2:");
			client1.Funkcja2("Klient1");
			Thread.Sleep(10);
			Console.WriteLine("...kontynuacja po funkcji2");
			Console.WriteLine("...wywoluje funkcja1:");
			client1.Funkcja1("Klient1");
			Thread.Sleep(10);
			Console.WriteLine("...kontynuacja po funkcji1");
			client1.Close();
			Console.WriteLine("KONIEC KLIENT1");

			Console.WriteLine("\nKLIENT2:");

			CallbackHandler mojCallbackHandler = new CallbackHandler();
			InstanceContext instanceContext = new InstanceContext(mojCallbackHandler);
			CallbackKalkulatorClient client2 = new CallbackKalkulatorClient(instanceContext);
			double value1 = 10;
			Console.WriteLine("...wywoluje Silnia({0}...", value1);
			client2.Silnia(value1);
			int value2 = 2;
			Console.WriteLine("...wywoluje ObliczCos({0})...", value2);
			client2.ObliczCos(value2);
			Console.WriteLine("Czekam chwile na odbior wynikow...");
			Thread.Sleep(5000);
			client2.Close();
			Console.WriteLine("KONIEC KLIENT2");
		}
	}

}
