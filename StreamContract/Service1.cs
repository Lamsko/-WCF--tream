using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StreamContract
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
	public class MojStrumien : IStrumien
	{
		public ResponseFileMessage getMStream(RequestFileMessage request)
		{
			FileStream myFile;
			Console.WriteLine("--->Wywolano getMSream.");
			ResponseFileMessage wynik = new ResponseFileMessage();
			string nazwa = request.nazwa1;
			string filepath = Path.Combine(System.Environment.CurrentDirectory, ".\\image.jpg");
			try
			{
				myFile = File.OpenRead(filepath);
			}
			catch (IOException ex)
			{
				Console.WriteLine(String.Format("Wyjatek otwarcia pliku {0}", filepath));
				Console.WriteLine(ex.ToString());
				throw ex;
			}
			wynik.nazwa2 = "mklient.jpg";
			wynik.rozmiar = myFile.Length;
			wynik.dane = myFile;
			return wynik;
		}

		public Stream getStream(string nazwa)
		{
			FileStream myFile;
			Console.WriteLine("--->Wywolano getSream.");
			string filepath = Path.Combine(System.Environment.CurrentDirectory, ".\\image.jpg");
			try
			{
				myFile = File.OpenRead(filepath);
			}
			catch (IOException ex)
			{
				Console.WriteLine(String.Format("Wyjatek otwarcia pliku {0}", filepath));
				Console.WriteLine(ex.ToString());
				throw ex;
			}

			return myFile;
		}
	}
}
