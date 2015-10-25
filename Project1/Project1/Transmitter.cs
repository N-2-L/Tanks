﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows;

namespace Tanks
{
    class Transmitter
    {

        private TcpClient client;

        private Thread thread;
        private TcpListener tcpListener;

        Int32 sendPort = 6000;
        Int32 receivePort = 7000;

        IPAddress localAddr = IPAddress.Parse("127.0.0.1");

        public Transmitter()
        {
            thread = new Thread(new ThreadStart(Receiver));
        }

        public void Sender(String msg)
        {
            client = new TcpClient();
            client.Connect(localAddr, sendPort);
            Stream stream = client.GetStream();

            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] temp = ascii.GetBytes(msg);

            stream.Write(temp, 0, temp.Length);
            stream.Close();
            client.Close();
            if (msg.Equals("JOIN#"))
            {
                thread.Start();
            }

        }

        public void Receiver() {
            this.tcpListener = new TcpListener(IPAddress.Any, receivePort);

            while (true){
                tcpListener.Start();
                TcpClient client = this.tcpListener.AcceptTcpClient();
                Stream streamReceiver = client.GetStream();
                Byte[] bytes = new Byte[256];

                int i;
                String data = null;

                while ((i = streamReceiver.Read(bytes, 0, bytes.Length)) != 0) { 

                    //gets the string
                    data = System.Text.Encoding.ASCII.GetString( bytes , 0 , i);
                }
                Console.WriteLine(data);

                streamReceiver.Close();
                tcpListener.Stop();
                client.Close();

            }



        }

    }

}

        /*
        public Boolean Transmit(String ip, String port, String data)
        {
            TcpClient client = new TcpClient();
            int _port = 0;
            int.TryParse(port, out _port);
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ip), _port);
            client.Connect(serverEndPoint);
            Console.WriteLine("Connected to Server");
            NetworkStream clientStream = client.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(data);
            Console.WriteLine(buffer);
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
            return true;
        }
    }

    class Listener
    {

        private TcpListener tcpListener;
        private Thread listenThread;
        // Set the TcpListener on port 13000.
        Int32 port = 7000;
        IPAddress localAddr = IPAddress.Parse("127.0.0.1");
        Byte[] bytes = new Byte[256];
        //MainWindow mainwind = null;
        public void Server()
        {
            //mainwind = wind;
            this.tcpListener = new TcpListener(IPAddress.Any, port);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();

        }
        private void ListenForClients()
        {

            this.tcpListener.Start();

            while (true)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();

                //create a thread to handle communication 
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }
        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    // System.Windows.MessageBox.Show("socket");
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    // System.Windows.MessageBox.Show("disc");
                    break;
                }

                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();
                //mainwind.setText(encoder.GetString(message, 0, bytesRead));
                //System.Windows.MessageBox.Show(encoder.GetString(message, 0, bytesRead));
                // System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));
            }

            tcpClient.Close();
        }
    }
}*/