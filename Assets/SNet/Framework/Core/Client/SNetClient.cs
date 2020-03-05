using Snet.Framework;
using Snet.Server;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace Snet.Client
{
    public class SNetClient : SNetCore
    {
        private static bool IsInit = false;

        public static bool Construct(int Port)
        {
            if (!IsInit)
            {
                ClientSocket = new UdpClient(Port);
                SecureClientSocket = new TcpClient(new IPEndPoint(IPAddress.Loopback, Port));
                SecureClientSocket.NoDelay = true;;

                IsInit = true;
                IsClient = true;

                Debug.Log("Client is register.");

                return true;
            }
            return false;
        }

        public static void StartUp(string Ip, int Port)
        {
            ClientSocket.Connect(IPAddress.Parse(Ip), Port);
            SecureClientSocket.Connect(IPAddress.Parse(Ip), Port);

            SNetServerProcess.StartProcess();
            SNetPlayerConnector.Connect();

            Debug.Log("Client running!");
        }

        public static bool Destruct()
        {
            if (IsInit)
            {
                SNetClientProcess.StopProcess();
                ClientSocket.Close();
                ClientSocket = null;

                SecureClientSocket.Close();
                SecureClientSocket = null;

                IsInit = false;
                IsClient = false;

                Debug.Log("Client is close!");

                return true;
            }
            return false;
        }
    }
}