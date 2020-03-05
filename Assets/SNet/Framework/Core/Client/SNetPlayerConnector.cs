using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Snet.Framework.Utilities;

namespace Snet.Client
{
    public class SNetPlayerConnector : MonoBehaviour
    {
        public static void Connect()
        {
            SNetSender.Client.SendToServer("Player.Connect");
            SNetSender.Client.SendToServer("Player.Print", "Hello World!", true);

            for (int i = 0; i < 1000; i++)
                SNetSender.Client.SendToServer("Player.Print", "Hello World!");

            SNetSender.Client.SendToServer("Player.Print", "Hello World! G 1", true);
            SNetSender.Client.SendToServer("Player.Print", "Hello World! G 2", true);
            SNetSender.Client.SendToServer("Player.Print", "Hello World! G 3", true);
            SNetSender.Client.SendToServer("Player.Print", "Hello World! G 4", true);
            SNetSender.Client.SendToServer("Player.Print", "Hello World! G 5", true);
        }
    }
}