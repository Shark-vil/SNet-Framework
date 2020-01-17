using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using Snet.Templates;

namespace Snet.Framework.Procedures
{
    public class SNetCoreProcedures : MonoBehaviour
    {
        /**
         * ONLY CLIENT
         */
        public virtual void OnUdpClientReceiver(TemplateReceiver receiver, IPEndPoint RemoteIp) { }
        public virtual void OnTcpClientReceiver(TemplateReceiver receiver, IPEndPoint RemoteIp) { }

        /**
         * ONLY SERVER
         */
        public virtual void OnUdpServerReceiver(TemplateReceiver receiver, IPEndPoint RemoteIp) { }
        public virtual void OnUdpPlayerReceiver(TemplateReceiver receiver, TemplatePlayer player) { }

        public virtual void OnTcpServerReceiver(TemplateReceiver receiver, IPEndPoint RemoteIp) { }
        public virtual void OnTcpPlayerReceiver(TemplateReceiver receiver, TemplatePlayer player) { }
    }
}