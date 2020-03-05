using Snet.Templates;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace Snet.Framework.Utilities
{
    public class SNetSender : SNetCore
    {
        public class Client
        {
            public static void SendToServer(string NetworkKey, object DataObject = null, bool IsSecure = false)
            {
                try
                {
                    byte[] DataBytes = default;

                    if (DataObject != null)
                    {
                        if (DataObject.GetType().Name == "Byte[]")
                            DataBytes = (byte[])DataObject;
                        else
                            DataBytes = SNetPackage.Packaging(DataObject);
                    }

                    TemplateReceiver receiver = new TemplateReceiver();
                    receiver.NetworkKey = NetworkKey;
                    receiver.DataBytes = DataBytes;
                    receiver.IsSecure = IsSecure;

                    byte[] WriteDataBytes = SNetPackage.Packaging(receiver);
                    ClientSocket.Send(WriteDataBytes, WriteDataBytes.Length);
                }
                catch (SocketException ex)
                {
                    Debug.LogError("Client socket exception:\n" + ex);
                }
            }
        }

        public class Server
        {
            public static void Send(string NetworkKey, object DataObject, TemplatePlayer Player, bool IsSecure = false)
            {
                try
                {
                    byte[] DataBytes;

                    if (DataObject.GetType().Name == "Byte[]")
                        DataBytes = (byte[])DataObject;
                    else
                        DataBytes = SNetPackage.Packaging(DataObject);

                    TemplateReceiver receiver = new TemplateReceiver();
                    receiver.NetworkKey = NetworkKey;
                    receiver.DataBytes = DataBytes;
                    receiver.IsSecure = IsSecure;

                    byte[] WriteDataBytes = SNetPackage.Packaging(receiver);
                    ServerSocket.Send(WriteDataBytes, WriteDataBytes.Length, Player.IpPoint);
                }
                catch (SocketException ex)
                {
                    Debug.LogError("Server socket exception:\n" + ex);
                }
            }

            public static void Send(string NetworkKey, object DataObject, TemplatePlayer[] Players, bool IsGaranted = false)
            {
                foreach (var Player in Players)
                    Send(NetworkKey, DataObject, Player);
            }

            public static void Send(string NetworkKey, object DataObject, List<TemplatePlayer> Players, bool IsGaranted = false)
            {
                foreach (var Player in Players)
                    Send(NetworkKey, DataObject, Player);
            }

            public static void SendOmit(string NetworkKey, object DataObject, TemplatePlayer[] Players, bool IsGaranted = false)
            {
                foreach (var Player in SNetGlobalData.Players)
                    if (!Array.Exists(Players, x => x.Id == Player.Id))
                        Send(NetworkKey, DataObject, Player);
            }

            public static void SendOmit(string NetworkKey, object DataObject, List<TemplatePlayer> Players, bool IsGaranted = false)
            {
                foreach (var Player in Players)
                    if (!Players.Exists(x => x.Id == Player.Id))
                        Send(NetworkKey, DataObject, Player);
            }
        }
    }
}