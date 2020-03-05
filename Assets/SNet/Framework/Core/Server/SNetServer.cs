using Snet.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace Snet.Server
{
    public class SNetServer : SNetCore
    {
        private static bool IsInit = false;

        public static bool Construct(string Ip, int Port)
        {
            if (!IsInit)
            {
                ServerSocket = new UdpClient(new IPEndPoint(IPAddress.Parse(Ip), Port));

                IsInit = true;
                IsServer = false;

                Debug.Log("Server is register.");

                return true;
            }
            return false;
        }

        public static void StartUp()
        {
            SNetServerProcess.StartProcess();

            Debug.Log("Server running!");
        }

        public static bool Destruct()
        {
            if (IsInit)
            {
                SNetServerProcess.StopProcess();
                ServerSocket.Close();
                ServerSocket = null;

                IsInit = false;
                IsServer = true;

                Debug.Log("Server is close!");

                return true;
            }
            return false;
        }

        public static string GetParam(string key)
        {
            string[] Args = Environment.GetCommandLineArgs();

            for (int i = 0; i < Args.Length; i++)
                if (Args[i] == key)
                    if (Args[i + 1] != null)
                        return Args[i + 1];

            return null;
        }
    }
}