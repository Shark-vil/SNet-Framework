using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Snet.Framework;
using System.Net.Sockets;

namespace Snet.Client
{
    public class NetClient : SNetCore
    {
        private static bool IsInit = false;

        public static bool Construct()
        {
            if (!IsInit)
            {
                UdpClientSocket = new UdpClient();
                TcpClientSocket = new TcpClient();

                IsInit = true;

                return true;
            }
            return false;
        }

        public static bool Destruct()
        {
            if (IsInit)
            {
                UdpClientSocket = null;
                TcpClientSocket.Close();
                TcpClientSocket = null;

                IsInit = false;

                return true;
            }
            return false;
        }
    }
}