using Snet.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using Snet.Templates;

namespace Snet.Client
{
    public class SNetClientProcess : SNetCore
    {
        public static object IsLock = new object();

        public static bool IsEngine = false;

        public static IPEndPoint ServerEndPoint = null;
        public static List<TemplateReceiver> Receives = new List<TemplateReceiver>();

        public static Thread ServerThread;
        private static bool IsInit = false;

        public static void StartProcess()
        {
            if (!IsInit)
            {
                ServerThread = new Thread(new ThreadStart(SocketReceiver));
                ServerThread.IsBackground = true;
                ServerThread.Start();

                IsInit = true;
            }
        }

        public static void StopProcess()
        {
            if (IsInit)
            {
                ServerThread.Abort();
                ServerThread.Join();

                IsInit = false;
            }
        }

        private static async void SocketReceiver()
        {
            while (true)
            {
                UdpReceiveResult Result = await ClientSocket.ReceiveAsync();
                ServerEndPoint = Result.RemoteEndPoint;

                TemplateReceiver Receive = Framework.Utilities.SNetPackage.Unpacking<TemplateReceiver>(Result.Buffer);

                if (Receive.IsGaranted)
                    Receives.Add(Receive);
                else
                {
                    if (Receives.Count <= 50)
                        if (!Receives.Exists(x => x.NetworkKey == Receive.NetworkKey && x.DataBytes.Length == Receive.DataBytes.Length))
                            Receives.Add(Receive);
                }

                lock (IsLock)
                {
                    IsEngine = true;
                }
            }
        }
    }
}