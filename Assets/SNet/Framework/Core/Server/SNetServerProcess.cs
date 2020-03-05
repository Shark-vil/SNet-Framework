using Snet.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class SNetServerProcess : SNetCore
{
    public static object IsLockUdp = new object();
    public static object IsLockTcp = new object();

    public static bool IsEngineUdp = false;

    public static IPEndPoint Receive_ClientEndPoint = null;
    public static byte[] Receive_UdpDataBytes = null;
    public static byte[] Receive_TcpDataBytes = null;

    public static UdpClient Receive_UdpServerSocket;
    public static Thread UdpServerThread;

    public static TcpClient Receive_TcpServerSocket;
    public static Thread TcpServerThread;

    public static void StartThread()
    {
        UdpServerThread = new Thread(new ThreadStart(UdpSocketReceiver));
        UdpServerThread.IsBackground = true;
        UdpServerThread.Start();

        TcpServerThread = new Thread(new ThreadStart(TcpSocketReceiver));
        TcpServerThread.IsBackground = true;
        TcpServerThread.Start();
    }

    public static void StopThread()
    {
        UdpServerThread.Abort();
        UdpServerThread.Join();

        TcpServerThread.Abort();
        TcpServerThread.Join();
    }

    private static async void UdpSocketReceiver()
    {
        while (true)
        {
            Receive_UdpDataBytes = null;

            UdpReceiveResult Result = await UdpServerSocket.ReceiveAsync();
            Receive_ClientEndPoint = Result.RemoteEndPoint;
            Receive_UdpDataBytes = Result.Buffer;

            lock (IsLockUdp)
            {
                IsEngine = true;
            }
        }
    }

    private static async void TcpSocketReceiver()
    {
        while (true)
        {
            Receive_TcpDataBytes = null;

            TcpListener Result = await UdpServerSocket.ReceiveAsync();
            Receive_ClientEndPoint = Result.RemoteEndPoint;
            Receive_DataBytes = Result.Buffer;

            lock (IsLockTcp)
            {
                IsEngine = true;
            }
        }
    }
}
