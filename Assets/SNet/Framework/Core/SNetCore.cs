using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Snet.Framework.Procedures;

namespace Snet.Framework
{
    public class SNetCore : SNetCoreProcedures
    {
        public static bool IsClient = false;
        public static bool IsServer = false;
        public static bool IsHost = false;

        internal static UdpClient UdpClientSocket;
        internal static TcpClient TcpClientSocket;

        internal static UdpClient UdpServerSocket;
        internal static TcpClient TcpServerSocket;

        public static bool IsGameServer()
        {
            return IsServer;
        }

        public static bool IsGameClient()
        {
            return IsClient;
        }

        public static bool IsGameHost()
        {
            return IsHost;
        }
    }
}