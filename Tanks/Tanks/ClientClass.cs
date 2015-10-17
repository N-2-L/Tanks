using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Tanks
{
    class ClientClass
    {
        public static void Main(string[] args)
        {
            Transmitter temp = new Transmitter();
            temp.Transmit("127.0.0.1", "6000", "hello");
            temp.Transmit("127.0.0.1", "6000", "JOIN#");
            Listener temp2 = new Listener();
            temp2.Server();






            //    TcpClient client = new TcpClient("127.0.0.1", 6000);

            //    Console.WriteLine("Connected to the server");

            //    //TcpClient client2 = new TcpClient("127.0.0.1", 7000);
            //    //Console.WriteLine("Connected to the receiving port");
            //    try
            //    {
            //        Stream s = client.GetStream();
            //        StreamReader sr = new StreamReader(s);
            //        StreamWriter sw = new StreamWriter(s);
            //        sw.AutoFlush = true;
            //        Console.WriteLine(sr.ReadLine());
            //        while (true)
            //        {
            //            Console.Write("Name: ");
            //            string name = Console.ReadLine();
            //            sw.WriteLine(name);
            //            if (name == "") break;
            //            Console.WriteLine(sr.ReadLine());
            //        }
            //        s.Close();
            //    }
            //    finally
            //    {
            //        // code in finally block is guranteed 
            //        // to execute irrespective of 
            //        // whether any exception occurs or does 
            //        // not occur in the try block
            //        client.Close();
            //    }
            //}

        }


    }
}
