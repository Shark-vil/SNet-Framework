using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

namespace Snet.Templates
{
    [System.Serializable]
    public class TemplatePlayer
    {
        [SerializeField]
        public int Id;
        [SerializeField]
        public string Ip;
        [SerializeField]
        public int Port;
        [SerializeField]
        public IPEndPoint IpPoint;
    }
}