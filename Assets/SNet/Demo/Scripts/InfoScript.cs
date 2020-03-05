using Snet;
using Snet.Framework.Utilities;
using Snet.Templates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoScript : SNetMonoBehaviour
{
    public override void OnServerReceiver(TemplateReceiver Receiver, TemplatePlayer Player)
    {
        if (Receiver.NetworkKey != "Player.Print")
            return;

        Debug.Log("NetworkKey: " + Receiver.NetworkKey + " - " + SNetPackage.Unpacking<string>(Receiver.DataBytes));
    }
}
