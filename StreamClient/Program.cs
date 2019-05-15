using StreamClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamClient
{
	class Program
	{
		static void Main(string[] args)
		{
			StrumienClient client2 = new StrumienClient();
			string filePath = Path.Combine(System.Environment.CurrentDirectory, "klient.jpg");

			Console.WriteLine("Wywoluje getStream()");
			Stream stream2 = client2.getStream("image.jpg");
			ZapiszPlik(stream2, filePath);
			Console.WriteLine("Koniec getStream()");

			Console.WriteLine("Wywoluje getMStream()");
			Stream fs = null;
			long rozmiar;
			string nnn = "image.jpg";
			nnn = client2.getMStream(nnn, out rozmiar, out fs);
			filePath = Path.Combine(System.Environment.CurrentDirectory, nnn);
			ZapiszPlik(fs, filePath);
			Console.WriteLine("Koniec getMStream()");

			client2.Close();
			Console.WriteLine();
			Console.WriteLine("Nacisnij <ENTER> aby zakonczyc.");
			Console.ReadLine();
		}

		private static void ZapiszPlik(Stream instream, string filePath)
		{
			const int bufferLength = 8192;
			int byteCount = 0;
			int counter = 0;
			byte[] buffer = new byte[bufferLength];

			Console.WriteLine("---> Zapisuje plik {0}", filePath);
			FileStream outsream = File.Open(filePath, FileMode.Create, FileAccess.Write);

			while((counter = instream.Read(buffer, 0, bufferLength)) > 0)
			{
				outsream.Write(buffer, 0, counter);
				Console.Write(".{0}", counter);
				byteCount += counter;
			}
			Console.WriteLine();
			Console.WriteLine("Zapisano {0} bajtow,", byteCount);

			outsream.Close();
			instream.Close();
			Console.WriteLine();
			Console.WriteLine("--->Plik {0} zapisany", filePath);
		}
	}
}
