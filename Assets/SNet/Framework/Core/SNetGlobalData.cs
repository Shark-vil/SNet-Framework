using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Snet.Templates;
using System.Net;

public class SNetGlobalData : MonoBehaviour
{
    public static List<TemplatePlayer> Players = new List<TemplatePlayer>();
    public static List<TemplateEntity> PlayerCharacters = new List<TemplateEntity>();
    public static List<GameObject> PlayerGameObjects = new List<GameObject>();

    public static List<TemplateEntity> Entities = new List<TemplateEntity>();
    public static List<TemplateEntity> EntitiesMap = new List<TemplateEntity>();
    public static List<TemplateEntity> EntitiesDynamic = new List<TemplateEntity>();

    public static void AddPlayer(TemplateReceiver Receiver, IPEndPoint IpPlayerPoint)
    {
        Players.Add(new TemplatePlayer
        {
            Id = Players.Count + 1,
            Ip = IpPlayerPoint.Address.ToString(),
            Port = IpPlayerPoint.Port,
            IpPoint = IpPlayerPoint
        });

        Debug.Log("Player is connected - " + IpPlayerPoint.Address.ToString() + ":" + IpPlayerPoint.Port);
    }
}
