using Snet.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class SNetServer : SNetCore
{
    public static IPEndPoint ServerEndPoint = null;

    private static bool IsInit = false;

    public static bool Construct(string Ip, int Port)
    {
        if (!IsInit)
        {
            ServerEndPoint = new IPEndPoint(IPAddress.Parse(Ip), Port);

            UdpServerSocket = new UdpClient(ServerEndPoint);
            TcpServerSocket = new TcpClient(ServerEndPoint);
            TcpServerSocket.NoDelay = true;

            IsInit = true;

            return true;
        }
        return false;
    }

    public static bool Destruct()
    {
        if (IsInit)
        {
            UdpServerSocket = null;
            TcpServerSocket.Close();
            TcpServerSocket = null;

            IsInit = false;

            return true;
        }
        return false;
    }
}
