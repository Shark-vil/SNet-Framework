using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Snet.Client;
using Snet.Server;
using Snet.Templates;

namespace Snet.Game.MasterServer
{
    public class SNetMasterServerDefault : SNetMasterServerBase
    {
        private void Update()
        {
            lock (SNetServerProcess.IsLock)
            {
                if (SNetServerProcess.IsEngine)
                {
                    SNetServerProcess.IsEngine = false;
                    int Count = SNets.Count;
                    if (Count != 0 && SNetServerProcess.Receives.Count != 0)
                    {
                        TemplatePlayer player = SNetGlobalData.Players.Find(
                            x => x.Ip == SNetServerProcess.ClientEndPoint.Address.ToString());

                        if (player != null)
                            for (int i = 0; i < Count; i++)
                            {
                                try
                                {
                                    foreach(var Receive in SNetServerProcess.Receives)
                                        SNets[i].OnServerReceiver(Receive, player);
                                }
                                catch { }
                            }

                        SNetServerProcess.Receives.Clear();
                    }
                }
            }

            lock (SNetClientProcess.IsLock)
            {
                if (SNetClientProcess.IsEngine)
                {
                    SNetClientProcess.IsEngine = false;
                    int Count = SNets.Count;
                    if (Count != 0 && SNetClientProcess.Receives.Count != 0)
                    {
                        for (int i = 0; i < Count; i++)
                        {
                            try
                            {
                                foreach(var Receive in SNetClientProcess.Receives)
                                    SNets[i].OnClientReceiver(Receive, SNetClientProcess.ServerEndPoint);
                            }
                            catch { }
                        }

                        SNetClientProcess.Receives.Clear();
                    }
                }
            }

        }
    }
}