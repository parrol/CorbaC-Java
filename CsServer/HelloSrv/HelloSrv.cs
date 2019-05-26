/**
**
** MiddCor-C# -Demo
**			CORBA Solution for .Net with C# Language mapping							 
**			Version: 1.0 																 
**				
** Copyright:
**			MiddTec GmbH, Hamburg
**			Germany  2003
**			www.middtec.com
**			info@middtec.de	
**
*/



using System;
using MiddTec;


namespace HelloCorba
{
	// Implementation of Greetings
	public class GreetingsImpl: GreetingsPOA 
	{
		public override string hello(  string a_sendMsg ) 
		{
			System.Console.WriteLine("Client says: Hello {0}\n", a_sendMsg);
			return "Good Bye Winter";
		}
	
	}

	// This Class Implements the Server.
	class Server 
	{		
		static void Main(string[] args) 
		{
			MiddTec.CORBA.ORB oOrb = MiddTec.CORBA._ORB.init( args, null);
			
			// Get the ROOT-POA
			MiddTec.PortableServer.POA oRootPOA 
				= MiddTec.PortableServer.POAHelper.narrow( 
					oOrb.resolve_initial_references( "RootPOA" ));

			// Activate POA
			oRootPOA.the_POAManager.activate();

			// Our implementation of the Greetings Interface
			GreetingsImpl oGreetings = new GreetingsImpl();
		
			// Create CORBA object reference 
			MiddTec.CORBA.Object obj = oRootPOA.servant_to_reference( oGreetings);

			// Write IOR-File
			MiddTec.CORBA._ORB.wrIORtoFile( "c:\\hello.ior", obj );

			System.Console.WriteLine("Server is running ...\n" );

			try 
			{
				// Workup Requests				
				oOrb.run();
			}
			catch( System.Exception ) 
			{
				// Destroy the ORB Resources
				oOrb.destroy();
			}
		}
	}
}
