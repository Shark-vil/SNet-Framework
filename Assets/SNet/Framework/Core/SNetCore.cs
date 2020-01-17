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
        internal UdpClient UdpClientSocket;
        internal TcpClient TcpClientSocket;

        internal UdpClient UdpServerSocket;
        internal TcpClient TcpServerSocket;

        public static byte[] Packaging(object data)
        {
            try
            {
                BinaryFormatter Formatter = new BinaryFormatter();
                using (MemoryStream Stream = new MemoryStream())
                {
                    Formatter.Serialize(Stream, data);
                    return Stream.ToArray();
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"An exception while packing the object data.\nError code:\n" + ex);
                return null;
            }
        }

        public static T Unpacking<T>(byte[] Data)
        {
            try
            {
                BinaryFormatter Formatter = new BinaryFormatter();
                MemoryStream Stream = new MemoryStream(Data);

                Stream.Seek(0, SeekOrigin.Begin);
                object Component = Formatter.Deserialize(Stream);
                Stream.Position = 0;
                Stream.Close();

                return (T)Component;
            }
            catch (Exception ex)
            {
                Debug.LogError("An exception while trying to unpack the object data.\nError code:\n" + ex);
                return default;
            }
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