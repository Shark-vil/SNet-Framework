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
    public class SNetCore : SNetMonoBehaviour
    {
        public static bool IsClient = false;
        public static bool IsServer = false;
        public static bool IsHost = false;

        internal static UdpClient ClientSocket;
        internal static UdpClient ServerSocket;

        internal static TcpClient SecureClientSocket;
        internal static TcpClient SecureServerSocket;

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
            if (IsClient && IsServer)
                return true;
            return false;
        }

        public static bool IsUnityServer()
        {
#if UNITY_SERVER
            return true;
#else
            return false;
#endif
        }
    }
}