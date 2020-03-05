using Snet.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class SNetClient : SNetCore
{
    public static object IsLock = new object();

    public static IPEndPoint ClientEndPoint = null;

    private static bool IsInit = false;

    public static bool Construct(string Ip, int Port)
    {
        if (!IsInit)
        {
            ClientEndPoint = new IPEndPoint(IPAddress.Parse(Ip), Port);

            UdpClientSocket = new UdpClient(ClientEndPoint);
            TcpClientSocket = new TcpClient(ClientEndPoint);
            TcpClientSocket.NoDelay = true;

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
