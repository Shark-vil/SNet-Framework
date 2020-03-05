using Snet.Framework.Procedures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Snet.Game.MasterServer;
using System.Linq;

public class SNetMonoBehaviour : SNetCoreProcedures
{
    private void Start()
    {
        SNetMasterServerBase MasterServerBase = GameObject.FindObjectOfType<SNetMasterServerBase>();
        if (MasterServerBase != null && MasterServerBase.IsLoadLevel && !MasterServerBase.SNets.Exists(x => x == this))
        {
            MasterServerBase.SNets = MasterServerBase.SNets.Where(x => x != null).Distinct().ToList();
            MasterServerBase.SNets.Add(this);
        }
    }
}