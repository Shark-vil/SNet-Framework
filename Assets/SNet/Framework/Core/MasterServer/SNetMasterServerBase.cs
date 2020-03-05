using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Snet.Templates;
using System.Reflection;

namespace Snet.Game.MasterServer
{
    public abstract class SNetMasterServerBase : MonoBehaviour
    {
        public bool IsLoadLevel = false;
        public List<SNetMonoBehaviour> SNets = new List<SNetMonoBehaviour>();

        private void Start()
        {
            SNetMonoBehaviour[] SNetsArray = GameObject.FindObjectsOfType<SNetMonoBehaviour>();
            List<SNetMonoBehaviour> SNetsNew = new List<SNetMonoBehaviour>();

            foreach (var SNetComponent in SNetsArray)
            {
                SNetsNew.Add(SNetComponent);
            }

            SNets = SNetsNew;

            IsLoadLevel = true;
        }
    }
}