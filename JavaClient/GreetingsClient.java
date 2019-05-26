import HelloCorba.*;

import org.omg.CORBA.ORB;
import java.io.*;

public class GreetingsClient
{
   public static void main(String args[]) throws IOException
   {
		 	try
		 	{
				//initialize ORB and stringify object
				ORB orb = ORB.init(args, null);
				//read stringified object to file
				FileReader fr = new
				FileReader("c:\\hello.ior");
				BufferedReader br = new
				BufferedReader(fr);
				String ior = br.readLine();

				org.omg.CORBA.Object obj = orb.string_to_object(ior);

				Greetings proxy = GreetingsHelper.narrow(obj);

				//invoke method
				String msg = proxy.hello("Spring");
				System.out.println("Server says: " + msg);

			} catch (Exception e) {
        e.printStackTrace(System.err);
    }
   }
}