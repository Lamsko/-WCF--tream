using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF4
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract]
	public interface ISerwis
	{
		[OperationContract]
		void Funkcja1(String s1);

		[OperationContract(IsOneWay = true)]
		void Funkcja2(String s2);


		// TODO: Add your service operations here
	}	

	// Use a data contract as illustrated in the sample below to add composite types to service operations.
	// You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WCF4.ContractType".

}
