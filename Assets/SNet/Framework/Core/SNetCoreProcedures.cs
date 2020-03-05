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
        public virtual void OnClientReceiver(TemplateReceiver Receiver, IPEndPoint IpServerPoint) { }

        /**
         * ONLY SERVER
         */
        public virtual void OnServerReceiver(TemplateReceiver Receiver, TemplatePlayer Player) { }
    }
}