using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snet.Templates
{
    [System.Serializable]
    public class TemplateReceiver
    {
        [SerializeField]
        public string NetworkKey;
        [SerializeField]
        public byte[] DataBytes;
        [SerializeField]
        public bool IsSecure;
    }
}