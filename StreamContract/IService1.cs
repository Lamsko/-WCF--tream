using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StreamContract
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract]
	public interface IStrumien
	{
		[OperationContract]
		System.IO.Stream getStream(string nazwa);

		[OperationContract]
		ResponseFileMessage getMStream(RequestFileMessage request);
			  		
	}
	[MessageContract]
	public class RequestFileMessage
	{
		[MessageBodyMember]
		public string nazwa1;
	}

	[MessageContract]
	public class ResponseFileMessage
	{
		[MessageHeader]
		public string nazwa2;
		[MessageHeader]
		public long rozmiar;
		[MessageBodyMember]
		public Stream dane;
	}
}
