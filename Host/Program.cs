using Callback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCF4;

namespace Host
{
	class Program
	{
		static void Main(string[] args)
		{
			Uri baseAddress1 = new Uri("http://localhost:10216/serwis1");
			ServiceHost mojHost1 = new ServiceHost(typeof(MojSerwis), baseAddress1);
			WSHttpBinding binding1 = new WSHttpBinding();

			Uri baseAddress2 = new Uri("http://localhost:20216/serwis2");
			ServiceHost mojHost2 = new ServiceHost(typeof(mojCallbackKalkulator), baseAddress2);
			WSDualHttpBinding binding2 = new WSDualHttpBinding();
			try
			{
				ServiceEndpoint endpoint1 = mojHost1.AddServiceEndpoint(typeof(ISerwis), binding1, "endpoint1");
				ServiceEndpoint endpoint2 = mojHost2.AddServiceEndpoint(typeof(ICallbackKalkulator),
					binding2, "CallbackKalkulator");
				ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
				ServiceMetadataBehavior smb2 = new ServiceMetadataBehavior();

				smb.HttpGetEnabled = true;
				smb2.HttpGetEnabled = true;

				mojHost1.Description.Behaviors.Add(smb);
				mojHost2.Description.Behaviors.Add(smb2);

				mojHost1.Open();
				mojHost2.Open();

				Console.WriteLine("--->MojSerwis jest uruchomiony.");
				Console.WriteLine("--->CallbackKalkulator jest uruchomiony.");
				Console.WriteLine("--->Wcisnij ENTER aby zakonczyc.\n");
				Console.ReadLine();
				mojHost1.Close();
				mojHost2.Close();
			}
			catch (CommunicationException ce)
			{
				Console.WriteLine("Wystapil wyjatek {0}", ce);
				mojHost1.Abort();
				mojHost2.Abort();
			}

		}
	}
}
