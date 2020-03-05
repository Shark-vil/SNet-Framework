using Snet.Client;
using Snet.Framework;
using Snet.Server;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialGame : MonoBehaviour
{
    private void Start()
    {
        if (SNetCore.IsUnityServer())
        {
            SNetServer.Construct("127.0.0.1", 30150);
            SNetServer.StartUp();
        }
        else
        {
            SNetServer.Construct("127.0.0.1", 30150);
            SNetServer.StartUp();

            SNetClient.Construct(30050);
            SNetClient.StartUp("127.0.0.1", 30150);
        }
    }

    private void OnApplicationQuit()
    {
        SNetServer.Destruct();
        SNetClient.Destruct();
    }
}
